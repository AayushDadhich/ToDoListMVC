using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToDoList.Models;
using ToDoList.Repositories.Interfaces;

namespace ToDoList.Repositories
{
    public class ToDoTasksRepository : IToDoTasksRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ToDoTasksRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ApplicationUser GetUserById(string userId)
        {
            return _dbContext.Users.FirstOrDefault(user => user.Id.Equals(userId));
        }

        public ToDoTask GetToDoTaskById(int toDoTaskId)
        {
            return _dbContext.ToDoTasks.FirstOrDefault(task => task.Id == toDoTaskId);
        }

        public IEnumerable<ToDoTask> GetUserToDoTasks(string userId)
        {
            ApplicationUser currentUser = _dbContext.Users.FirstOrDefault(user => user.Id.Equals(userId));
            IEnumerable<ToDoTask> toDoTasks = _dbContext.ToDoTasks.ToList().Where(task => task.User == currentUser);
            return toDoTasks;
        }

        public ToDoTask AddToDoTask(ToDoTask toDoTask)
        {
            ToDoTask toDoTaskAdded = _dbContext.ToDoTasks.Add(toDoTask);
            _dbContext.SaveChanges();
            return toDoTaskAdded;
        }

        public int UpdateToDoTask(ToDoTask toDoTask)
        {
            _dbContext.Entry(toDoTask).State = EntityState.Modified;
            return _dbContext.SaveChanges();
        }

        public int RemoveToDoTask(ToDoTask toDoTask)
        {
            _dbContext.ToDoTasks.Remove(toDoTask);
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}