using System;

namespace Catalog.Entities
{
    public record Item
    {
        /** init 初始化赋值后就不再允许改变 
          Item item = new(){
               Id = Guid.NewGuid()
          };
         不可以 item.Id = Guid.NewGuid();

        C# 9 通过新的init-only属性和record类型引入了对不可变性的支持。
        仅init-only属性可以用于使得对象的各个属性不可变，而record可用于整个对象不可变。
        不可变性使你的对象线程安全并有助于改进内存管理。
         
         
         */
        public Guid Id { get; init; }

        public string Name { get; init; }

        public decimal Price { get; init; }

        public DateTimeOffset CreatedDate { get; init; }
        
        
        
        
    }
}