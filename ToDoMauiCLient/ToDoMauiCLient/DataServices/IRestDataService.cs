using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoMauiCLient.Models;

namespace ToDoMauiCLient.DataServices
{
    public interface IRestDataService
    {
        Task<List<Todo>> GetAllToDosAsync();
        Task AddToDoAsync(Todo todo);
        Task DeleteToDoAsync(int id);
        Task UpdateToDoAsync(Todo todo);

    }
}
