using ToDoList.Models;

namespace ToDoList.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        ApplicationUser GetUserById(string userId);
    }
}