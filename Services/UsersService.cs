using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ToDoList.Models;
using ToDoList.Repositories.Interfaces;
using ToDoList.Services.Interfaces;

namespace ToDoList.Services
{
    public class UsersService: IUsersService
    {
        private readonly IUsersRepository _usersRepository;

        public UsersService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public ApplicationUser GetUserById(string userId)
        {
            return _usersRepository.GetUserById(userId);
        }
    }
}