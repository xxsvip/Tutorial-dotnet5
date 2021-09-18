using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Catalog.Entities;

namespace Catalog.Repositories
{
    public interface IItemsRepository
    {
        IEnumerable<Item> GetItems();
        Task<Item> GetItemAsync(Guid id);

        void CreateItem(Item item);

        void UpdateItem(Item item);
        void DeleteItem(Guid id);
    }
}