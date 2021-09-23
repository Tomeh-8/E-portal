using student_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_system.data.Interface
{
    public interface ICourseRepository
    {
        IEnumerable<StudentCourse> ShowCourses();

        StudentCourse AddCourse(StudentCourse course);

        StudentCourse GetCourse(int id);

        void DeleteCourse(StudentCourse course);

        void EditCourse(StudentCourse course);
    } 
}
