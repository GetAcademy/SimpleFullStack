using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using SimpleFullStack.ViewModel;

namespace SimpleFullStack
{
    public class TodoItemRepository
    {
        private const string connectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Todo;Integrated Security=True";

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            var connection = new SqlConnection(connectionString);
            return await connection.QueryAsync<TodoItem>("select id, task from todoitem");
        }

        public async Task<TodoItem> GetOne(int id)
        {
            var connection = new SqlConnection(connectionString);
            var sql = "select id, task from todoitem where id = @id";
            var items = await connection.QueryAsync<TodoItem>(sql, new { Id = id });
            return items.SingleOrDefault();
        }

        public async Task<int> Create(TodoItem todoItem)
        {
            var connection = new SqlConnection(connectionString);
            var sql = "insert into todoitem (task) values (@task)";
            return await connection.ExecuteAsync(sql, todoItem);
        }
    }
}
