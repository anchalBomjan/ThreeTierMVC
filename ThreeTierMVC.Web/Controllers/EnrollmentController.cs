using Business.Layer.Services;
using Global.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThreeTierMVC.Web.Models;

namespace ThreeTierMVC.Web.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly IStudentService _studentService;
        private readonly ICourseService _courseService;

        public EnrollmentController(IEnrollmentService enrollmentService, IStudentService studentService, ICourseService courseService)
        {
            _enrollmentService = enrollmentService;
            _studentService = studentService;
            _courseService = courseService;
        }

        // GET: /Enrollment/Create
        public async Task<IActionResult> Create()
        {
            ViewData["Students"] = new SelectList(await _studentService.GetAllStudentsAsync(), "StudentID", "Name");
            ViewData["Courses"] = new SelectList(await _courseService.GetAllCoursesAsync(), "CourseID", "CourseName");
            return View();
        }

        // POST: /Enrollment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EnrollmentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Students"] = new SelectList(await _studentService.GetAllStudentsAsync(), "StudentID", "Name", viewModel.StudentID);
                ViewData["Courses"] = new SelectList(await _courseService.GetAllCoursesAsync(), "CourseID", "CourseName", viewModel.CourseID);
                return View(viewModel);
            }

            var enrollment = new Enrollment
            {
                StudentID = viewModel.StudentID,
                CourseID = viewModel.CourseID,
                EnrollmentDate = viewModel.EnrollmentDate
            };
            await _enrollmentService.AddEnrollmentAsync(enrollment);
            return RedirectToAction(nameof(Index));
        }

        // GET: /Enrollment/Index
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var enrollments = await _enrollmentService.GetEnrollmentsAsync();
            return View(enrollments);
        }

        // GET: /Enrollment/Edit/{id}
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id <= 0)
            {
                return View("Error", new ErrorViewModel { RequestId = "Invalid Enrollment ID" });
            }

            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return View("Error", new ErrorViewModel { RequestId = $"No enrollment found with ID {id}" });
            }

            ViewData["Students"] = new SelectList(await _studentService.GetAllStudentsAsync(), "StudentID", "Name", enrollment.StudentID);
            ViewData["Courses"] = new SelectList(await _courseService.GetAllCoursesAsync(), "CourseID", "CourseName", enrollment.CourseID);

            var viewModel = new  EnrollmentViewModel
            {
                EnrollmentID = enrollment.EnrollmentID,
                StudentID = enrollment.StudentID,
                CourseID = enrollment.CourseID,
                EnrollmentDate = enrollment.EnrollmentDate
            };

            return View(viewModel);
        }

        // POST: /Enrollment/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, EnrollmentViewModel viewModel)
        {
            if (id <= 0 || !ModelState.IsValid)
            {
                ViewData["Students"] = new SelectList(await _studentService.GetAllStudentsAsync(), "StudentID", "Name", viewModel.StudentID);
                ViewData["Courses"] = new SelectList(await _courseService.GetAllCoursesAsync(), "CourseID", "CourseName", viewModel.CourseID);
                return View(viewModel);
            }

            var enrollment = await _enrollmentService.GetEnrollmentByIdAsync(id);
            if (enrollment == null)
            {
                return View("Error", new ErrorViewModel { RequestId = $"No enrollment found with ID {id}" });
            }

            enrollment.StudentID = viewModel.StudentID;
            enrollment.CourseID = viewModel.CourseID;
            enrollment.EnrollmentDate = viewModel.EnrollmentDate;

            await _enrollmentService.UpdateEnrollmentAsync(enrollment);
            return RedirectToAction(nameof(Index));
        }

        // POST: /Enrollment/Delete
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            await _enrollmentService.DeleteEnrollmentAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
