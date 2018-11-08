using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ODataDto.Entities
{
    public class Student
    {
        [Key]
        [MaxLength(30)]
        public string Alias { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set;  }

        [Required]
        [MaxLength(25)]
        public string Lastname { get; set; }

        public int Age { get; set; }

        [ForeignKey("Name")]
        [Column("Class")]
        public string Course { get; set; }
        public Course Mycourse { get; set; }
    }
}
