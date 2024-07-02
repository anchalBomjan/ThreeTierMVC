using Business.Layer.Services;
using Global.Entities;
using Microsoft.AspNetCore.Mvc;
using ThreeTierMVC.Web.Models;

namespace ThreeTierMVC.Web.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: /Course/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            await _courseService.AddCourseAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Course/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return View(courses);
        }

        // GET: /Course/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return View("Error", new ErrorViewModel { RequestId = "Invalid Course ID" });
            }

            var viewModel = await _courseService.GetCourseByIdAsync(id);
            if (viewModel == null)
            {
                return View("Error", new ErrorViewModel { RequestId = $"No course found with ID {id}" });
            }

            return View(viewModel);
        }

        // POST: /Course/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CourseViewModel viewModel)
        {
            if (id <= 0 || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            await _courseService.UpdateCourseAsync(id, viewModel);
            return RedirectToAction(nameof(Index));
        }

        // POST: /Course/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _courseService.DeleteCourseAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
