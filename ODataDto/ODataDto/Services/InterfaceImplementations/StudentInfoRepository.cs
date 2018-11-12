using System;
using System.Collections.Generic;
using System.Linq;
using ODataDto.Entities;
using ODataDto.Services.Interfaces;

namespace ODataDto.Services.InterfaceImplementations
{
    public class StudentInfoRepository : IStudentInfoRepository
    {
        private MyDbcontext _infocontext;

        public StudentInfoRepository(MyDbcontext infocontext)
        {
            _infocontext = infocontext;
        }

        public void AddStudent(Student student)
        {
            _infocontext.Students.Add(student);
        }

        public Student GetStudent(string id)
        {
            return _infocontext.Students.Where(s => s.Alias == id).FirstOrDefault();
        }

        public IEnumerable<Student> GetStudents()
        {
            return _infocontext.Students;
        }

        public bool Save()
        {
            return (_infocontext.SaveChanges() >= 0);
        }
    }
}
