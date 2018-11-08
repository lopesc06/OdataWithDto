using System;
using System.ComponentModel.DataAnnotations;

namespace ODataDto.Models
{
    public class CourseDto
    {

        [Required]
        [MaxLength(30)]
        public string CourseName { get; set; }

        [Required]
        public int CourseLevel { get; set; }

        [Required]
        public string Teacher { get; set; }
    }
}
