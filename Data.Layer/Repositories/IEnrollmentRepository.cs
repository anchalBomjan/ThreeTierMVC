using Global.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Repositories
{
    public interface IEnrollmentRepository
    {
        Task<List<Enrollment>> GetEnrollmentsAsync();
        Task<Enrollment> GetEnrollmentByIdAsync(int id);
        Task AddEnrollmentAsync(Enrollment enrollment);
        Task UpdateEnrollmentAsync(Enrollment enrollment);
        Task DeleteEnrollmentAsync(int id);

    }
}
