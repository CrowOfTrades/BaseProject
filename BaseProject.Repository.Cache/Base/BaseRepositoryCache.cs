using BaseProject.Model;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Linq;

namespace BaseProject.Repository.Cache
{
    public abstract class BaseRepositoryCache<T> where T : BaseEntity
    {
        internal readonly IMemoryCache _cache;
        internal string CACHE_KEY;

        public BaseRepositoryCache(IMemoryCache cache)
        {
            _cache = cache;
        }

        internal IList<T> Get()
        {
            var list = _cache.Get<IList<T>>(CACHE_KEY);
            return list ?? new List<T>();
        }

        internal void Save(T item)
        {
            var list = Get();
            Save(list, item);
        }

        internal void Save(IList<T> list, T item)
        {
            if (list.Any(a => a.Id == item.Id))
            {
                list = list.Where(w => w.Id != item.Id).ToList();
            }
            list.Add(item);
            Save(list);
        }

        internal void Save(IList<T> list)
        {
            _cache.Set(CACHE_KEY, list);
        }

    }
}
