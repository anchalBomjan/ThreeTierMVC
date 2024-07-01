using Global.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services
{
    internal interface IStudentService
    {
        Task<List<Student>> GetAllStudentsAsync();
        Task<Student> GetStudentByIdAsync(string id);
        Task AddStudentAsync(Student viewModel);
        Task UpdateStudentAsync(string id, Student viewModel);
        Task DeleteStudentAsync(string id);
    }
}
