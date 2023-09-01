using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Web.Mvc;
using ToDoList.Models;
using Unity;
using Unity.Mvc5;
using ToDoList.Controllers;
using Unity.Injection;
using ToDoList.Repositories.Interfaces;
using ToDoList.Repositories;
using ToDoList.Services;
using ToDoList.Services.Interfaces;
using Unity.Lifetime;

namespace ToDoList
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // Register DbContext within a scoped lifetime
            container.RegisterType<ApplicationDbContext>(new HierarchicalLifetimeManager());

            // Register UserStore with injected DbContext
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
                new InjectionConstructor(typeof(ApplicationDbContext)));

            // Registering Repositories with injected DbContext
            container.RegisterType<IUsersRepository, UsersRepository>(
                new InjectionConstructor(typeof(ApplicationDbContext)));
            container.RegisterType<IToDoTasksRepository, ToDoTasksRepository>(
                new InjectionConstructor(typeof(ApplicationDbContext)));

            //Resistering Services
            container.RegisterType<IUsersService, UsersService>();
            container.RegisterType<IToDoTasksService, ToDoTasksService>();

            //Registering Controllers
            container.RegisterType<AccountController>(new InjectionConstructor());
            container.RegisterType<ManageController>(new InjectionConstructor());

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}