
using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using ODataDto.Models;
using ODataDto.Services.Interfaces;

namespace ODataDto.Controllers
{
    public class StuudeentController : ODataController
    {
        private readonly IStudentInfoRepository _studentInfoRepository;

        public StuudeentController(IStudentInfoRepository studentInfoRepository)
        {
            _studentInfoRepository = studentInfoRepository;
        }

        [EnableQuery]
        public IActionResult Get()
        {
            var resultEntity = _studentInfoRepository.GetStudents();
            var studentDto = Mapper.Map<IEnumerable<StudentDto>>(resultEntity);
            return Ok(studentDto);
        }

        [EnableQuery]
        public IActionResult Get(string key)
        {
            var resultEntity = _studentInfoRepository.GetStudent(key);
            var studentDto = Mapper.Map<StudentDto>(resultEntity);
            return Ok(studentDto);
        }
    }
}
