using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            Parallel.ForEach(items, i =>
            {
                var r = Task.Run(() => i).Result; // Using Result to await the Task synchronously
                bag.Add(r);
            });
            var list = bag.ToList();
            return list;
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var itemsToInitialize = Enumerable.Range(0, 100).ToList();

            var concurrentDictionary = new ConcurrentDictionary<int, string>();

            Parallel.ForEach(itemsToInitialize, item =>
            {
                var newItem = getItem(item);
                concurrentDictionary.TryAdd(item, newItem);
            });

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}