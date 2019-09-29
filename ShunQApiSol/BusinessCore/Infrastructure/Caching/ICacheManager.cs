using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessCore.Infrastructure.Caching
{
    public interface ICacheManager
    {
        bool IsCachingEnabled { get; set; }

        bool Exist(string cacheKey);
        Task<T> Get<T>(string cacheKey) where T : class;
        void Remove(string cacheKey);
        void Remove(string cacheKey, bool isPattern);
        void Set<T>(string cacheKey, T item);

        /// <summary>
        /// GET or SET
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cacheKey"></param>
        /// <param name="getItemCallback"></param>
        /// <returns></returns>
       Task<T> Get<T>(string cacheKey, Func<T> getItemCallback) where T : class;
        void Test();
    }
}
