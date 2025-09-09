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
        IEnumerable <Course> GetAllCourses();
        
    }
}
