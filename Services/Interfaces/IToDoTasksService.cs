using System.Collections.Generic;
using ToDoList.Models;

namespace ToDoList.Services.Interfaces
{
    public interface IToDoTasksService
    {
        ApplicationUser GetUserById(string userId);

        ToDoTask GetToDoTaskById(int toDoTaskId);

        IEnumerable<ToDoTask> GetUserToDoTasks(string userId);

        ToDoTask AddToDoTask(string userId, ToDoTask toDoTask);

        int UpdateToDoTask(ToDoTask toDoTask);

        int RemoveToDoTask(ToDoTask toDoTask);

        void Dispose();
    }
}