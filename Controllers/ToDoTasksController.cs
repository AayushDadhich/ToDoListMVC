using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;
using ToDoList.Models;
using ToDoList.Services.Interfaces;

namespace ToDoList.Controllers
{
    [JwtAuthorize]
    public class ToDoTasksController : Controller
    {
        private readonly IToDoTasksService _toDoTasksService;

        public ToDoTasksController() { }

        public ToDoTasksController(IToDoTasksService toDoTasksService)
        {
            _toDoTasksService = toDoTasksService;
        }

        public ActionResult Index()
        {
            try
            {
                string userId = User.Identity.GetUserId();
                IEnumerable<ToDoTask> toDoTasks = _toDoTasksService.GetUserToDoTasks(userId);
                return View(toDoTasks);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Details(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ToDoTask toDoTask = _toDoTasksService.GetToDoTaskById(id.Value);

                if (toDoTask == null)
                {
                    return HttpNotFound();
                }

                return View(toDoTask);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description,IsCompleted,DueDate")] ToDoTask toDoTask)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    string userId = User.Identity.GetUserId();
                    _toDoTasksService.AddToDoTask(userId, toDoTask);
                    return RedirectToAction("Index");
                }

                return View(toDoTask);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ToDoTask toDoTask = _toDoTasksService.GetToDoTaskById(id.Value);

                if (toDoTask == null)
                {
                    return HttpNotFound();
                }

                string userId = User.Identity.GetUserId();
                ApplicationUser currentUser = _toDoTasksService.GetUserById(userId);

                if (currentUser != toDoTask.User)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                return View(toDoTask);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,IsCompleted,DueDate")] ToDoTask toDoTask)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _toDoTasksService.UpdateToDoTask(toDoTask);
                    return RedirectToAction("Index");
                }

                return View(toDoTask);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                ToDoTask toDoTask = _toDoTasksService.GetToDoTaskById(id.Value);

                if (toDoTask == null)
                {
                    return HttpNotFound();
                }

                return View(toDoTask);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                ToDoTask toDoTask = _toDoTasksService.GetToDoTaskById(id);

                if (toDoTask == null)
                {
                    return HttpNotFound();
                }

                _toDoTasksService.RemoveToDoTask(toDoTask);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _toDoTasksService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
