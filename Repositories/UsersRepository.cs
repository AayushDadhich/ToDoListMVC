using System.Linq;
using ToDoList.Models;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UsersRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ApplicationUser GetUserById(string userId)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Id.Equals(userId));
        }
    }
}