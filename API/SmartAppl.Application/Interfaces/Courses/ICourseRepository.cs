using SmartAppl.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAppl.Application.Interfaces.Courses
{
    public interface ICourseRepository
    {
//        IEnumerable <Course> GetAllCourses();
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course?> GetCourseByID(int id);
//        Task<IEnumerable<Course>> GetCoursesByIDAsync(IEnumerable<int> ids);
        Task<Course> AddCourseAsync(Course course);
        Task<bool> DeleteCourseAsync(int id);
        Task<bool> IsTitleDuplicatedAsync(string title);
        Task<Course?> UpdateCourseAsync(Course course);
        Task<Course?> UpdateDescriptionAsync(Course course, string description);
    }
}
