
using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using ODataDto.Entities;
using ODataDto.Models;
using ODataDto.Services.Interfaces;

namespace ODataDto.Controllers
{
    [ODataRoutePrefix("Stuudeent")]
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
        [ODataRoute("({key})")]
        public IActionResult absa([FromODataUri]string key)
        {
            var resultEntity = _studentInfoRepository.GetStudent(key);
            var studentDto = Mapper.Map<StudentDto>(resultEntity);
            return Ok(studentDto);
        }

       public IActionResult Post([FromBody] StudentForCreationDto studentDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var studentEntity = Mapper.Map<Student>(studentDto);
            studentEntity.Alias = "@" + studentEntity.Lastname + " " + studentEntity.Name;
            _studentInfoRepository.AddStudent(studentEntity);
            if (!_studentInfoRepository.Save())
            {
                return StatusCode(500, "Could not save in DB");
            }
            var CreatedUser = Mapper.Map<StudentDto>(studentEntity);
            return Ok();//CreatedAtRoute("OdataGetStudent", new {key = studentEntity.Alias}, CreatedUser);
        }
    }
}
