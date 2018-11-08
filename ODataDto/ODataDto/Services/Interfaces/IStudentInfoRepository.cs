using System;
using System.Collections.Generic;
using ODataDto.Entities;

namespace ODataDto.Services.Interfaces
{
    public interface IStudentInfoRepository
    {
        Student GetStudent(string id);
        IEnumerable<Student> GetStudents();
    }
}
