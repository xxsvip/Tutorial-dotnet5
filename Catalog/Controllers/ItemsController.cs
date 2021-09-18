using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly IItemsRepository _repository;
        public ItemsController(IItemsRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            var items = _repository.GetItems().Select(item => item.AsDto());
            return items;
        }
        
        
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id)
        {
            var item =  await _repository.GetItemAsync(id);
            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }


        [HttpPost]
        public async  Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
        {
            Item item = new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.Now
            };
            _repository.CreateItem(item);
            return  CreatedAtAction(nameof(GetItemAsync).Replace("Async",""),new{id = item.Id}, item.AsDto()); //HTTP状态码返回201:表示已创建，并返回了新的资源。

        }

        [HttpPut("{id}")]
        public async  Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = await _repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with  //with表达式可以修改record类型的对象。
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };
            
            _repository.UpdateItem(updatedItem);
            return NoContent();                //HTTP状态码返回204：表示已经执行成功，但没有返回内容

        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = _repository.GetItemAsync(id);
            if (existingItem is null)
            {
                return NotFound();
            }
            _repository.DeleteItem(id);
            return NoContent();
        }


      
    }
}