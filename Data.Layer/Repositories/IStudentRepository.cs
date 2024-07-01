﻿using Global.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Layer.Repositories
{
    public interface IStudentRepository
    {

        Task<List<Student>> GetAllAsync();
        Task<Student> GetByIdAsync(string id);
        Task AddAsync(Student student);
        Task UpdateAsync(Student student);
        Task DeleteAsync(string id);
    }
}
