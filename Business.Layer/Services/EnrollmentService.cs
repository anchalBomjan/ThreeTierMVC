using Data.Layer.Repositories;
using Global.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Layer.Services
{
    public class EnrollmentService:IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository)
        {
            _enrollmentRepository = enrollmentRepository;
        }

        public async Task<List<Enrollment>> GetEnrollmentsAsync()
        {
            return await _enrollmentRepository.GetEnrollmentsAsync();
        }

        public async Task<Enrollment> GetEnrollmentByIdAsync(int id)
        {
            return await _enrollmentRepository.GetEnrollmentByIdAsync(id);
        }

        public async Task AddEnrollmentAsync(Enrollment enrollment)
        {
            await _enrollmentRepository.AddEnrollmentAsync(enrollment);
        }

        public async Task UpdateEnrollmentAsync(Enrollment enrollment)
        {
            await _enrollmentRepository.UpdateEnrollmentAsync(enrollment);
        }

        public async Task DeleteEnrollmentAsync(int id)
        {
            await _enrollmentRepository.DeleteEnrollmentAsync(id);
        }

    }
}
