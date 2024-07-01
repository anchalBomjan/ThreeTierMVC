using Data.Layer.Repositories;
using Global.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services
{
    internal class StudentService : IStudentService
    {
        private readonly IStudentRepository _repository;

        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Student> GetStudentByIdAsync(string id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task AddStudentAsync(Student viewModel)
        {
            var student = new Student
            {
                StudentID = viewModel.StudentID,
                Name = viewModel.Name,
                Email = viewModel.Email
            };
            await _repository.AddAsync(student);
        }

        public async Task UpdateStudentAsync(string id, Student viewModel)
        {
            var student = await _repository.GetByIdAsync(id);
            if (student != null)
            {
                student.StudentID = viewModel.StudentID;
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                await _repository.UpdateAsync(student);
            }
        }

        public async Task DeleteStudentAsync(string id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
