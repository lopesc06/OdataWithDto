using System;
using System.ComponentModel.DataAnnotations;

namespace ODataDto.Models
{
    public class StudentForCreationDto
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(25)]
        public string Apellidos { get; set; }


        public int Age { get; set; }
    }
}
