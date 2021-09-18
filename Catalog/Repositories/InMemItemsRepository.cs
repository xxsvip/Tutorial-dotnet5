using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        
        private readonly List<Item> _items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTimeOffset.Now},
            new Item {Id = Guid.NewGuid(), Name = "Sword", Price = 20, CreatedDate = DateTimeOffset.Now},
            new Item {Id = Guid.NewGuid(), Name = "Bronze", Price = 18, CreatedDate = DateTimeOffset.Now}
        };


        public IEnumerable<Item> GetItems()
        {
            return _items;
        }   


        public async Task<Item> GetItemAsync(Guid id)
        {
            var result = _items.SingleOrDefault(item => item.Id == id);
            return await Task.FromResult(result);
        }

        public void CreateItem(Item item)
        {
            _items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == item.Id);
            _items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == id);
            _items.RemoveAt(index);
        }
    }
}