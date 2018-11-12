using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataDto.Entities
{
    public class Student
    {
        [Key]
        [MaxLength(70)]
        public string Alias { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set;  }

        [Required]
        [MaxLength(35)]
        public string Lastname { get; set; }

        public int Age { get; set; }

        [ForeignKey("Name")]
        [Column("Class")]
        public string Course { get; set; }
        public Course Mycourse { get; set; }
    }
}
