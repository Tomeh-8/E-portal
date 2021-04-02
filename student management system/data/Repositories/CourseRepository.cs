using student_management_system.data.Interface;
using student_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_system.data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly StudentDbcontext _db;

        public CourseRepository(StudentDbcontext db)
        {
            _db = db;
        }
        public IEnumerable<StudentCourse> ShowCourses()
        {
            return _db.studentCourse;
        }


        public StudentCourse AddCourse(StudentCourse course)
        {
            _db.studentCourse.Add(course);
            _db.SaveChanges();
            return course;
        }

        public StudentCourse DeleteCourse(StudentCourse course)
        {
            _db.studentCourse.Remove(course);
            _db.SaveChanges();
            return course;
        }

        public StudentCourse GetCourse(int id)
        {
            return _db.studentCourse.Find(id);
        }

        public StudentCourse EditCourse(StudentCourse courseChanges)
        {
            _db.Update(courseChanges);
            _db.SaveChanges();
            return courseChanges;
        }
    }
}
