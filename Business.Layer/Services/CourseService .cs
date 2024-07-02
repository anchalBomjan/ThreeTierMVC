using Data.Layer.Repositories;
using Global.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services
{
    public class CourseService:ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _courseRepository.GetAllAsync();
        }

        public async Task<CourseViewModel> GetCourseByIdAsync(int id)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return null;

            return new CourseViewModel
            {
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription,
                Credits = course.Credits
            };
        }

        public async Task AddCourseAsync(CourseViewModel viewModel)
        {
            var course = new Course
            {
                CourseName = viewModel.CourseName,
                CourseDescription = viewModel.CourseDescription,
                Credits = viewModel.Credits
            };
            await _courseRepository.AddAsync(course);
        }

        public async Task UpdateCourseAsync(int id, CourseViewModel viewModel)
        {
            var course = await _courseRepository.GetByIdAsync(id);
            if (course == null) return;

            course.CourseName = viewModel.CourseName;
            course.CourseDescription = viewModel.CourseDescription;
            course.Credits = viewModel.Credits;

            await _courseRepository.UpdateAsync(course);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _courseRepository.DeleteAsync(id);
        }
    }
}
