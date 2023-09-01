using System;
using System.Collections.Generic;
using ToDoList.Models;
using ToDoList.Repositories.Interfaces;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services
{
    public class ToDoTasksService : IToDoTasksService
    {
        private readonly IUsersService _usersService;
        private readonly IToDoTasksRepository _toDoTasksRepository;

        public ToDoTasksService(IUsersService usersService, IToDoTasksRepository toDoTasksRepository)
        {
            _usersService = usersService;
            _toDoTasksRepository = toDoTasksRepository;
        }

        public ApplicationUser GetUserById(string userId)
        {
            return _usersService.GetUserById(userId);
        }

        public ToDoTask GetToDoTaskById(int toDoTaskId)
        {
            return _toDoTasksRepository.GetToDoTaskById(toDoTaskId);
        }

        public IEnumerable<ToDoTask> GetUserToDoTasks(string userId)
        {
            IEnumerable<ToDoTask> toDoTasks = _toDoTasksRepository.GetUserToDoTasks(userId);
            return UpdateTaskListStatus(toDoTasks);
        }

        public ToDoTask AddToDoTask(string userId, ToDoTask toDoTask)
        {
            ApplicationUser currentUser = _usersService.GetUserById(userId);
            toDoTask.Status = GetTaskStatus(toDoTask);
            toDoTask.User = currentUser;
            return _toDoTasksRepository.AddToDoTask(toDoTask);
        }

        public int UpdateToDoTask(ToDoTask toDoTask)
        {
            toDoTask.Status = GetTaskStatus(toDoTask);
            return _toDoTasksRepository.UpdateToDoTask(toDoTask);
        }

        public int RemoveToDoTask(ToDoTask toDoTask)
        {
            return _toDoTasksRepository.RemoveToDoTask(toDoTask);
        }

        public void Dispose()
        {
            _toDoTasksRepository.Dispose();
        }

        #region private functions

        private IEnumerable<ToDoTask> UpdateTaskListStatus(IEnumerable<ToDoTask> toDoTasks)
        {
            foreach (var toDoTask in toDoTasks)
            {
                UpdateTaskStatus(toDoTask);
            }
            return toDoTasks;
        }

        private Enums.TaskStatus GetTaskStatus(ToDoTask task)
        {
            if (task.IsCompleted)
            {
                return Enums.TaskStatus.Completed;
            }
            else if (task.DueDate < DateTime.Now)
            {
                return Enums.TaskStatus.Delayed;
            }
            else
            {
                return Enums.TaskStatus.InProgress;
            }
        }

        private void UpdateTaskStatus(ToDoTask toDoTask)
        {
            toDoTask.Status = GetTaskStatus(toDoTask);
            _toDoTasksRepository.UpdateToDoTask(toDoTask);
        }

        #endregion private functions
    }
}