//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace BusinessCore.Infrastructure.Caching
//{
//    public class InMemoryCache : ICacheManager
//    {
//        public bool IsCachingEnabled { get; set; }

//        public T Get<T>(string cacheKey) where T : class
//        {
//            T item = MemoryCache.Default.Get(cacheKey.ToString()) as T;
//            return item;
//        }

//        public T Get<T>(string cacheKey, Func<T> getItemCallback) where T : class
//        {
//            T item = MemoryCache.Default.Get(cacheKey.ToString()) as T;
//            if (item == null)
//            {
//                item = getItemCallback();
//                if (item != null)
//                    MemoryCache.Default.Add(cacheKey.ToString(), item, DateTime.Now.AddDays(30));
//            }
//            return item;
//        }

//        public void Set(string cacheKey, object item)
//        {
//            this.Remove(cacheKey);
//            MemoryCache.Default.Add(cacheKey.ToString(), item, DateTime.Now.AddDays(30));
//        }

//        public bool Exist(string cacheKey)
//        {
//            return MemoryCache.Default.Contains(cacheKey);
//        }

//        public void Remove(string cacheKey)
//        {
//            MemoryCache.Default.Remove(cacheKey);
//        }
//        public void Remove(string cacheKey, bool isPattern)
//        {
//            MemoryCache.Default.Remove(cacheKey);
//        }
//    }
//}
