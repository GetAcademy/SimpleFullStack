using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleFullStack.ViewModel
{
    public class TodoItem
    {
        public TodoItem()
        {
            OtherId = Guid.NewGuid();
        }

        public Guid OtherId { get; set; }
        public int Id { get; set; }
        public string Task { get; set; }
    }
}
