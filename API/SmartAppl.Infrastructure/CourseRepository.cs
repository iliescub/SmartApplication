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

        public async Task<Course?> GetCourseByID(int id)
        {
            return await _dbContext.Courses.FindAsync(id);
        }

//        public async Task<IEnumerable<Course>> GetCoursesByIDAsync(IEnumerable<int> ids)
//       {
//            return await _dbContext.Courses
//                .Where(c => ids.Contains(c.CourseId))
 //               .ToListAsync();
 //       }
        public async Task<Course> AddCourseAsync(Course course)
        {
            _dbContext.Courses.Add(course);
            await _dbContext.SaveChangesAsync();
            return course;
        }
        public async Task<bool> DeleteCourseAsync(int id)
        {
            var course = await _dbContext.Courses.FindAsync(id);
            if (course == null)
                return false;

            _dbContext.Courses.Remove(course);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsTitleDuplicatedAsync(string title)
        {
            return await _dbContext.Courses.AnyAsync(c => c.Title == title);
        }

        public async Task<Course?> UpdateCourseAsync(Course course)
        {
            var existingCourse = await _dbContext.Courses.FindAsync(course.CourseId);
            if (existingCourse == null)
                return null;

            existingCourse.Title = course.Title;
            existingCourse.Description = course.Description;
            existingCourse.CreatedBy = course.CreatedBy;
            existingCourse.CreatedOn = course.CreatedOn;
            // Add other properties as needed

            await _dbContext.SaveChangesAsync();
            return existingCourse;
        }

        public async Task<Course?> UpdateDescriptionAsync(Course course, string description)
        {
            var _course = await _dbContext.Courses.FindAsync(course.CourseId);
            if (_course == null)
                return null;

            _course.Description = description;
            await _dbContext.SaveChangesAsync();
            return _course;
        }
    }
}
