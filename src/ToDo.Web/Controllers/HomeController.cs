using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ToDo.Web.Data;
using ToDo.Web.Models;
using ToDo.Web.ViewModels;

namespace ToDo.Web.Controllers
{
    public class HomeController : Controller
    {
        private ITasksRepository _repo;

        public HomeController(ITasksRepository repository) {
            _repo = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allTasks = await _repo.ListAsync();

            var model = new IndexViewModel()
            {
                AllTasks = allTasks,
                NewTask = new NewTaskViewModel()
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(IndexViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _repo.AddAsync(new TaskItem()
            {
                Description = model.NewTask.Description,
                DateCreated = DateTime.Now,
                IsCompleted = false
            });

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkCompleted(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var task = await _repo.FindByIdAsync(id.Value);
            task.IsCompleted = true;
            await _repo.UpdateAsync(task);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Error");
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            var task = await _repo.FindByIdAsync(id.Value);
            await _repo.DeleteAsync(task);

            return RedirectToAction("Index");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
