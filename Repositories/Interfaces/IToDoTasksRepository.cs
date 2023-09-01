using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Repositories.Interfaces
{
    public interface IToDoTasksRepository
    {
        ApplicationUser GetUserById(string userId);

        ToDoTask GetToDoTaskById(int toDoTaskId);

        IEnumerable<ToDoTask> GetUserToDoTasks(string userId);

        ToDoTask AddToDoTask(ToDoTask toDoTask);

        int UpdateToDoTask(ToDoTask toDoTask);

        int RemoveToDoTask(ToDoTask toDoTask);

        void Dispose();
    }
}