using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace task_management_system.Controllers
{
    public class MemberTasksController : Controller
    {
        // GET: MemberTasksController
        public ActionResult Index()
        {
            return View();
        }

        // GET: MemberTasksController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: MemberTasksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MemberTasksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberTasksController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MemberTasksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MemberTasksController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: MemberTasksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
