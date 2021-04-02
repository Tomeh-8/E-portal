using student_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace student_management_system.data.Interface
{
    public interface IBioDataRepository
    {
        IEnumerable<Student> GetAllStudentsInfo();

        Student AddStudentInfo(Student student);

        Student EditStudentInfo(Student student);

        Student GetStudentInfo(string id);
    }
}
