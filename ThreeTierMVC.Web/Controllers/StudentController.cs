using Global.Entities;
using Microsoft.AspNetCore.Mvc;
using ThreeTierMVC.Web.Models;
using ThreeTierMVC.Web.Business.Layer.Services;

namespace ThreeTierMVC.Web.Controllers
{
    public class StudentController : ControllerBase
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
        public async Task<IActionResult> Create(Student viewModel)
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

            var student = await _studentService.GetStudentByIdAsync(id);
            if (student == null)
            {
                return View("Error", new ErrorViewModel { RequestId = $"No student found with ID {id}" });
            }

            var viewModel = new Student
            {
                StudentID = student.StudentID,
                Name = student.Name,
                Email = student.Email
            };

            return View(viewModel);
        }

        // POST: /Student/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, Student viewModel)
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
