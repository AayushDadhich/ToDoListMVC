using ToDoList.Models;

namespace ToDoList.Services.Interfaces
{
    public interface IUsersService
    {
        ApplicationUser GetUserById(string userId);
    }
}