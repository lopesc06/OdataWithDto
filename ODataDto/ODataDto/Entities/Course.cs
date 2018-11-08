using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataDto.Entities
{
    public class Course
    {
        [Key]
        [MaxLength(30)]
        [Column("Name")]
        public string CourseName { get; set; }

        [Required]
        public int CourseLevel { get; set;  }

        [Required]
        public string Teacher { get; set;  }

    }
}
