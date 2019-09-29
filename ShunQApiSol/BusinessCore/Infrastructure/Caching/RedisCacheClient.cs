using System;
using System.Threading.Tasks;
using BusinessCore.Infrastructure.Caching;
using StackExchange.Redis;
using System.Linq;

public class RedisCacheClient : ICacheManager
{
    private static readonly Lazy<ConnectionMultiplexer> redis = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(RedisConStr));
    private static string RedisConStr;
    public bool IsCachingEnabled { get; set; }


    public RedisCacheClient(string redisConStr, bool isCachingEnabled)
    {
        RedisConStr = redisConStr;
        this.IsCachingEnabled = isCachingEnabled;
    }

    private IDatabase getContext()
    {
        if (!IsCachingEnabled)
            return null;

        var asyncState = new object();
        return redis.Value.GetDatabase(0, asyncState);
    }
    private IServer getServer()
    {
        if (!IsCachingEnabled)
            return null;

        var asyncState = new object();
        return redis.Value.GetServer(RedisConStr, asyncState);

    }

    public bool Exist(string cacheKey)
    {
        if (!IsCachingEnabled)
            return false;

        var db = getContext();
        return db.KeyExistsAsync(cacheKey).Result;
    }

    public void Set<T>(string cacheKey, T item)
    {
        if (!IsCachingEnabled)
            return;

        var db = getContext();

        if (item != null)
        {
            var jstring = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            db.StringSetAsync(cacheKey, jstring, flags: CommandFlags.FireAndForget);
        }
    }

    public async Task<T> Get<T>(string cacheKey) where T : class
    {
        T item = null;
        if (!IsCachingEnabled)
            return item;

        var db = getContext();
        var jstring = await db.StringGetAsync(cacheKey);
        if (!jstring.IsNullOrEmpty)
        {
            item = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jstring);
        }
        return item;
    }

    public async Task<T> Get<T>(string cacheKey, Func<T> getItemCallback) where T : class
    {
        if (!IsCachingEnabled)
            return getItemCallback();

        var db = getContext();

        var jstring = await db.StringGetAsync(cacheKey);
        T item = null;
        if (!jstring.IsNullOrEmpty)
        {
            item = Newtonsoft.Json.JsonConvert.DeserializeObject<T>(jstring);
        }
        if (item == null)
        {
            item = getItemCallback();
            jstring = Newtonsoft.Json.JsonConvert.SerializeObject(item);
            db.StringSetAsync(cacheKey, jstring, flags: CommandFlags.FireAndForget);
        }
        return item;
    }

    public void Remove(string cacheKey)
    {
        if (!IsCachingEnabled)
            return;

        var db = getContext();
        db.KeyDeleteAsync(cacheKey, flags: CommandFlags.FireAndForget);
    }

    public void Remove(string cacheKey, bool isPattern)
    {
        if (!IsCachingEnabled)
            return;

        if (!isPattern)
            Remove(cacheKey);
        else
        {

            var db = getContext();

            var server = getServer();
            var keys = server.Keys(0, cacheKey).ToArray();
            db.KeyDeleteAsync(keys, flags: CommandFlags.FireAndForget);
        }
    }

    public void Test()
    {
        getContext().Ping();
    }
}
