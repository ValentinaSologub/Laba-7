using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class FunctionCache<TKey, TResult>
{
    private Dictionary<TKey, CacheItem> cache = new Dictionary<TKey, CacheItem>();

    public delegate TResult Func(TKey key);

    public TResult GetOrAdd(TKey key, Func func, TimeSpan expirationTime)
    {
        if (cache.TryGetValue(key, out var cacheItem) && IsCacheItemValid(cacheItem, expirationTime))
        {
            return cacheItem.Result;
        }
        else
        {
            TResult result = func(key);
            cache[key] = new CacheItem(result, DateTime.Now.Add(expirationTime));
            return result;
        }
    }

    private bool IsCacheItemValid(CacheItem cacheItem, TimeSpan expirationTime)
    {
        return DateTime.Now < cacheItem.ExpirationTime;
    }

    private class CacheItem
    {
        public TResult Result { get; }
        public DateTime ExpirationTime { get; }

        public CacheItem(TResult result, DateTime expirationTime)
        {
            Result = result;
            ExpirationTime = expirationTime;
        }
    }
}
