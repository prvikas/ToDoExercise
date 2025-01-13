using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using ToDoApp.Core;

namespace ToDoApp.Infrastructure
{
    internal class MockToDoItemsData
    {
        private static MockToDoItemsData _instance = null;
        private static readonly object _lock = new object();
        private static List<ToDoItem> _toDos;

        private MockToDoItemsData()
        {
            if (_toDos != null) return;

            _toDos = new List<ToDoItem>() {
                new() { Id = Guid.Parse("A5A227D5-64E9-4ED9-958C-FB14B3CC17F1"), Title = "Create React page", Description = string.Empty},
                new() { Id = Guid.Parse("B5A227D5-64E9-4ED9-958C-FB14B3CC17F2"), Title = "Create CSS file", Description = string.Empty},
                new() { Id = Guid.Parse("C5A227D5-64E9-4ED9-958C-FB14B3CC17F3"), Title = "Create Test page", Description = string.Empty, IsCompleted=true}
            };
        }

        internal static MockToDoItemsData Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new MockToDoItemsData();
                        }
                    }
                }
                return _instance;
            }
        }

        internal List<ToDoItem> GetToDoItems
        {
            get { return _toDos; }
        }

        internal void AddToDoItem(ToDoItem toDoItem)
        {
            _toDos.Add(toDoItem);
        }
    }

}
