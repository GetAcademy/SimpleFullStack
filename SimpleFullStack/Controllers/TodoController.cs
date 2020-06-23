using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleFullStack.ViewModel;

namespace SimpleFullStack.Controllers
{
    [Route("api/todo")]
    [ApiController]
    public class TodoController : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<TodoItem> GetData(int id)
        {
            var repo = new TodoItemRepository();
            return await repo.GetOne(id);
        }

        [HttpGet]
        public async Task<IEnumerable<TodoItem>> GetData()
        {
            var repo = new TodoItemRepository();
            return await repo.GetAll();
        }

        [HttpPost]
        public async Task<bool> Create(TodoItem todoItem)
        {
            var repo = new TodoItemRepository();
            var rows = await repo.Create(todoItem);
            return rows == 1;
        }
    }

    //public class TodoController : ControllerBase
    //{


    //    static List<TodoItem> _data = new List<TodoItem>()
    //    {
    //        new TodoItem {Task = "Re opp senga", Id = 1},
    //        new TodoItem {Task = "Handle til middag", Id=2},
    //    };

    //    [HttpGet("{id}")]
    //    public TodoItem GetData(int id)
    //    {
    //        return _data.SingleOrDefault(ti => ti.Id == id);
    //    }

    //    [HttpGet]
    //    public IEnumerable<TodoItem> GetData()
    //    {
    //        return _data;
    //    }

    //    [HttpPost]
    //    public void Create(TodoItem todoItem)
    //    {
    //        _data.Add(todoItem);
    //    }
    //}
}
