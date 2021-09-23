using student_management_system.data.Interface;
using student_management_system.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace student_management_system.data.Repositories
{
    public class BioDataRepository : IBioDataRepository
    {
        private readonly StudentDbcontext _db;
       

        public BioDataRepository(StudentDbcontext db)
        {
            _db = db;
        }


        public IEnumerable<Student> GetAllStudentsInfo()
        {
            return _db.studentInfo;
        }

        public Student AddStudentInfo(Student student)
        {
            _db.studentInfo.Add(student);
            _db.SaveChanges();
             return student;
        }

        public void EditStudentInfo(Student studentChanges)
        {
            _db.Update(studentChanges);
            _db.SaveChanges();
        }
        public Student GetStudentInfo(string id)
        {
           return  _db.studentInfo.Find(id);
        }

    }
}
