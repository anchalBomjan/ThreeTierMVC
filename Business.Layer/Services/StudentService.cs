using Data.Layer.Repositories;
using Global.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services
{
    public class StudentService:IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<IEnumerable<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<StudentViewModel> GetStudentByIdAsync(string id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return null;

            return new StudentViewModel
            {
                StudentID = student.StudentID,
                Name = student.Name,
                Email = student.Email
            };
        }

        public async Task AddStudentAsync(StudentViewModel viewModel)
        {
            var student = new Student
            {
                StudentID = viewModel.StudentID,
                Name = viewModel.Name,
                Email = viewModel.Email
            };
            await _studentRepository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(string id, StudentViewModel viewModel)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            if (student == null) return;

            student.StudentID = viewModel.StudentID;
            student.Name = viewModel.Name;
            student.Email = viewModel.Email;

            await _studentRepository.UpdateAsync(student);
        }

        public async Task DeleteStudentAsync(string id)
        {
            await _studentRepository.DeleteAsync(id);
        }
    }
}
