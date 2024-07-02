using Business.Layer.Services;
using Global.Entities;
using Microsoft.AspNetCore.Mvc;
using ThreeTierMVC.Web.Models;

namespace ThreeTierMVC.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: /Student/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(StudentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            await _studentService.AddStudentAsync(viewModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Student/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudentsAsync();
            return View(students);
        }

        // GET: /Student/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("Error", new ErrorViewModel { RequestId = "Invalid Student ID" });
            }

            var viewModel = await _studentService.GetStudentByIdAsync(id);
            if (viewModel == null)
            {
                return View("Error", new ErrorViewModel { RequestId = $"No student found with ID {id}" });
            }

            var student = new Global.Entities.Student
            {
                StudentID = viewModel.StudentID,
                Name = viewModel.Name,
                Email = viewModel.Email
            };

            return View(student);
        }

        // POST: /Student/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, StudentViewModel viewModel)
        {
            if (string.IsNullOrEmpty(id) || !ModelState.IsValid)
            {
                return View(viewModel);
            }

            await _studentService.UpdateStudentAsync(id, viewModel);
            return RedirectToAction(nameof(Index));
        }

        // POST: /Student/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
            await _studentService.DeleteStudentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
