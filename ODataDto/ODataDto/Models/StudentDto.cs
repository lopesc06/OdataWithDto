using System;
using System.ComponentModel.DataAnnotations;

namespace ODataDto.Models
{
    public class StudentDto
    {
        [Required]
        [MaxLength(30)]
        public string Username { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(25)]
        public string Apellidos { get; set; }

        public int Age { get; set; }


        public CourseDto Mycourse { get; set; }
    }
}
