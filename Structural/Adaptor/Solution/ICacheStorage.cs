using System.Web;

namespace Adaptor.Solution
{
    public interface ICacheStorage
    {
        void Store(string key, object value);
        T Get<T>(string key);
    }

    class CacheStorage : ICacheStorage
    {
        public void Store(string key, object value)
        {
            HttpContext.Current.Cache.Insert(key, value);
        }

        public T Get<T>(string key)
        {
            return (T) HttpContext.Current.Cache.Get(key);
        }
    }
}