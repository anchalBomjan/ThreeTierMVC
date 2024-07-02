using Global.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentsAsync();
        Task<StudentViewModel> GetStudentByIdAsync(string id);
        Task AddStudentAsync(StudentViewModel viewModel);
        Task UpdateStudentAsync(string id, StudentViewModel viewModel);
        Task DeleteStudentAsync(string id);
       
    }
}
