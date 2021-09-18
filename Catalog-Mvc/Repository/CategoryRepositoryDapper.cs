using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using Catalog_Mvc.Data;
using Catalog_Mvc.Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace Catalog_Mvc.Repository
{
    public class CategoryRepositoryDapper : ICategoryRepository
    {

        private readonly IDbConnection _db;


        public CategoryRepositoryDapper(IConfiguration configuration)
        {
            _db = new MySqlConnection(configuration.GetConnectionString("Mysql"));
        }

        public Category Find(int id)
        {
            var sql = "select * from Category where id = @id";
            return _db.Query<Category>(sql, new {@id = id}).Single();
        }

        public List<Category> GetAll()
        {
            var sql = "select * from Category";
            return _db.Query<Category>(sql).ToList();
        }

        public Category Add(Category category)
        {
            var sql = "insert into Category(name,display_order) values(@name,@display_order);"+
                            "select LAST_INSERT_ID()";
            var id = _db.Query<int>(sql,category).Single();
            category.id = id;
            return category;
        }

        public Category Update(Category category)
        {
            var sql = "update Category set name = @name,display_order = @display_order where id = @id";
            _db.Execute(sql, category); 
            return category;
        }

        public void Remove(int id)
        {
            var sql = "delete from Category where id = @id";
            _db.Execute(sql, new {@id = id});
           return;

        }
    }
}