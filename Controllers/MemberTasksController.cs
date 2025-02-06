﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;
using task_management_system.Data;
using task_management_system.Models.DBModels;

namespace task_management_system.Controllers
{
    public class MemberTasksController : Controller
    {
        private MemberTaskRepository _repository;
        private ApplicationDbContext _context;

        public MemberTasksController(ApplicationDbContext dbContext)
        {
            _repository = new MemberTaskRepository(dbContext);
            _context = dbContext;
        }

        // GET: MemberTasksController
        public ActionResult Index()
        {
            var tasks = _repository.GetAllMemberTasks();
            return View("Index", tasks);
        }

        // GET: MemberTasksController/Details/5
        public ActionResult Details(int id)
        {
            return View("Details");
        }

        // GET: MemberTasksController/Create
        public ActionResult Create()
        {
            ViewData["AssignedUserId"] = new SelectList(_context.Users, "Id", "UserName");
            return View("Create");
        }

        // POST: MemberTasksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MemberTaskModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["AssignedUserId"] = new SelectList(_context.Users, "Id", "UserName", model.AssignedUserId);
                return View(model);
            }

            // Fetch AssignedUser from DB and attach it
            model.AssignedUser = _context.Users.FirstOrDefault(u => u.Id == model.AssignedUserId);

            _repository.InsertMemberTask(model);

            return RedirectToAction("Index");
        }


        // GET: MemberTasksController/Edit/5
        public ActionResult Edit(int id)
        {
            var task = _repository.GetMemberTaskById(id);
            return View("Edit", task);
        }

        // POST: MemberTasksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            MemberTaskModel model = new MemberTaskModel();
            var task = TryUpdateModelAsync(model);

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            _repository.UpdateMemberTask(model);

            var tasks = _repository.GetAllMemberTasks();
            return View("Index", tasks);
        }

        // GET: MemberTasksController/Delete/5
        public ActionResult Delete(int id)
        {
            var task = _repository.GetMemberTaskById(id);
            return View("Delete", task);
        }

        // POST: MemberTasksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _repository.DeleteMemberTask(_repository.GetMemberTaskById(id));

            var tasks = _repository.GetAllMemberTasks();
            return View("Index", tasks);
        }
    }
}
