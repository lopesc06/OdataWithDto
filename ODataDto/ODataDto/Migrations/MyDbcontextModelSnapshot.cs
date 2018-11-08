﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ODataDto.Entities;

namespace ODataDto.Migrations
{
    [DbContext(typeof(MyDbcontext))]
    partial class MyDbcontextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ODataDto.Entities.Course", b =>
                {
                    b.Property<string>("CourseName")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Name")
                        .HasMaxLength(30);

                    b.Property<int>("CourseLevel");

                    b.Property<string>("Teacher")
                        .IsRequired();

                    b.HasKey("CourseName");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("ODataDto.Entities.Student", b =>
                {
                    b.Property<string>("Alias")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(30);

                    b.Property<int>("Age");

                    b.Property<string>("Course")
                        .HasColumnName("Class");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasMaxLength(25);

                    b.Property<string>("MycourseCourseName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.HasKey("Alias");

                    b.HasIndex("MycourseCourseName");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ODataDto.Entities.Student", b =>
                {
                    b.HasOne("ODataDto.Entities.Course", "Mycourse")
                        .WithMany()
                        .HasForeignKey("MycourseCourseName");
                });
#pragma warning restore 612, 618
        }
    }
}