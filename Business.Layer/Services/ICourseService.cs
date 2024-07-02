using Global.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<CourseViewModel> GetCourseByIdAsync(int id);
        Task AddCourseAsync(CourseViewModel viewModel);
        Task UpdateCourseAsync(int id, CourseViewModel viewModel);
        Task DeleteCourseAsync(int id);

    }
}
