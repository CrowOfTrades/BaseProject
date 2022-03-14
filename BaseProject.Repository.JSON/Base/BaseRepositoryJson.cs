using BaseProject.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Repository.JSON
{
    public abstract class BaseRepositoryJson<T> where T : BaseEntity
    {
        internal string CACHE_KEY;
        internal string BASE_PATH = Environment.CurrentDirectory;

        internal IList<T> Get()
        {
            var path = $"{BASE_PATH}/{CACHE_KEY}.json";

            try
            {
                using StreamReader r = new(path);
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch (Exception ex)
            {
                return new List<T>();
            }
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
            var path = $"{BASE_PATH}/{CACHE_KEY}.json";

            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(path, json);
        }
    }
}
