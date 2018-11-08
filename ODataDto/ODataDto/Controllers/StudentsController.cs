using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ODataDto.Models;
using ODataDto.Services.Interfaces;

namespace ODataDto.Controllers
{
    [Route("api/students")]
    public class StudentsController : Controller
    {
        private IStudentInfoRepository _studentInfoRepository;

        public StudentsController(IStudentInfoRepository studentInfoRepository)
        {
            _studentInfoRepository = studentInfoRepository;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var resultEntity = _studentInfoRepository.GetStudents();
            var studentDto = Mapper.Map<IEnumerable<StudentDto>>(resultEntity);
            return Ok(studentDto);
        }

        [HttpGet("{studentId}")]
        public IActionResult GetStudents(string studentId){
            var resultEntity = _studentInfoRepository.GetStudent(studentId);
            var studentDto = Mapper.Map<StudentDto>(resultEntity);
            return Ok(studentDto);
        }
        
    }
}
