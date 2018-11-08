using System;
using Microsoft.EntityFrameworkCore;

namespace ODataDto.Entities
{
    public class MyDbcontext : DbContext
    {
        public MyDbcontext(DbContextOptions<MyDbcontext> options): base(options)
        {
        }



        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }

    }
}
