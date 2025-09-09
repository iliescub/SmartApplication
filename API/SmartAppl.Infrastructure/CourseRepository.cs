using Microsoft.EntityFrameworkCore;
using SmartAppl.Application.Interfaces.Courses;
using SmartAppl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAppl.Infrastructure
{
    public class CourseRepository : ICourseRepository
    {
        private readonly SmartApplContext _dbContext;

        public CourseRepository(SmartApplContext dbContext)
        {
            this._dbContext = dbContext;
        }
 //       public IEnumerable<Course> GetAllCourses()
 //       {
 //           var data = _dbContext.Courses.ToList();
 //           return data;
 //       }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _dbContext.Courses.ToListAsync();
        }
    }
}
