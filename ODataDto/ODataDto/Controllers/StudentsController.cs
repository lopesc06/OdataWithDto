using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ODataDto.Entities;
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

        [HttpGet("{studentId}", Name = "GetStudent")]
        public IActionResult GetStudents(string studentId){
            var resultEntity = _studentInfoRepository.GetStudent(studentId);
            var studentDto = Mapper.Map<StudentDto>(resultEntity);
            return Ok(studentDto);
        }

        [HttpPost]
        public IActionResult AddUsers([FromBody]StudentForCreationDto studentDto){
            if(studentDto== null || !ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var studentEntity = Mapper.Map<Student>(studentDto);
            studentEntity.Alias = "@" + studentEntity.Lastname + " " + studentEntity.Name;
            _studentInfoRepository.AddStudent(studentEntity);
            if(!_studentInfoRepository.Save()){
                return StatusCode(500, "Could not save in DB");
            }
            var CreatedUser = Mapper.Map<StudentDto>(studentEntity);
            return CreatedAtRoute("GetStudent", new { studentId = studentEntity.Alias },CreatedUser);
        }

    }
}
