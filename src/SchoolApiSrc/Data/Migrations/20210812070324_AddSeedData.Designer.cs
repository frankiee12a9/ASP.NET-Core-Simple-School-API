﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolApiSrc.Data;

namespace SchoolApiSrc.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20210812070324_AddSeedData")]
    partial class AddSeedData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SchoolApiSrc.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("DepartmentId1")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DepartmentId1");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 3000,
                            CourseName = "Data Structure",
                            DepartmentId = 4000
                        },
                        new
                        {
                            CourseId = 3001,
                            CourseName = "Calculus",
                            DepartmentId = 4001
                        },
                        new
                        {
                            CourseId = 3002,
                            CourseName = "English Conversation",
                            DepartmentId = 4002
                        });
                });

            modelBuilder.Entity("SchoolApiSrc.Models.CourseAssignment", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("LecturerId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "LecturerId");

                    b.HasIndex("LecturerId");

                    b.ToTable("CourseAssignments");

                    b.HasData(
                        new
                        {
                            CourseId = 3000,
                            LecturerId = 2000,
                            Id = 0
                        },
                        new
                        {
                            CourseId = 3001,
                            LecturerId = 2001,
                            Id = 0
                        },
                        new
                        {
                            CourseId = 3002,
                            LecturerId = 2002,
                            Id = 0
                        });
                });

            modelBuilder.Entity("SchoolApiSrc.Models.CourseEnrollment", b =>
                {
                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("courseEnrollments");

                    b.HasData(
                        new
                        {
                            CourseId = 3000,
                            StudentId = 1000,
                            Id = 0
                        },
                        new
                        {
                            CourseId = 3001,
                            StudentId = 1001,
                            Id = 0
                        },
                        new
                        {
                            CourseId = 3002,
                            StudentId = 1002,
                            Id = 0
                        });
                });

            modelBuilder.Entity("SchoolApiSrc.Models.Department", b =>
                {
                    b.Property<int>("DepartmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentId");

                    b.ToTable("Departments");

                    b.HasData(
                        new
                        {
                            DepartmentId = 4000,
                            DepartmentName = "Computer Science Dept"
                        },
                        new
                        {
                            DepartmentId = 4001,
                            DepartmentName = "Mathematics Dept"
                        },
                        new
                        {
                            DepartmentId = 4002,
                            DepartmentName = "Business and Language Dept"
                        });
                });

            modelBuilder.Entity("SchoolApiSrc.Models.Lecturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LecturerType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Lecturers");

                    b.HasData(
                        new
                        {
                            Id = 2000,
                            DepartmentId = 4000,
                            Email = "kim@kkk.com",
                            LecturerType = "Professor",
                            Name = "Kim"
                        },
                        new
                        {
                            Id = 2001,
                            DepartmentId = 4001,
                            Email = "lee@kkk.com",
                            LecturerType = "Professor",
                            Name = "Lee"
                        },
                        new
                        {
                            Id = 2002,
                            DepartmentId = 4002,
                            Email = "park@kkk.com",
                            LecturerType = "Professor",
                            Name = "Park"
                        });
                });

            modelBuilder.Entity("SchoolApiSrc.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1000,
                            DepartmentId = 4000,
                            Email = "st1@abc.com",
                            Name = "Student1",
                            StudentType = "Freshman"
                        },
                        new
                        {
                            Id = 1001,
                            DepartmentId = 4001,
                            Email = "st2@abc.com",
                            Name = "Student2",
                            StudentType = "Junior"
                        },
                        new
                        {
                            Id = 1002,
                            DepartmentId = 4002,
                            Email = "st3@abc.com",
                            Name = "Student3",
                            StudentType = "Senior"
                        });
                });

            modelBuilder.Entity("SchoolApiSrc.Models.Course", b =>
                {
                    b.HasOne("SchoolApiSrc.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SchoolApiSrc.Models.Department", null)
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentId1");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SchoolApiSrc.Models.CourseAssignment", b =>
                {
                    b.HasOne("SchoolApiSrc.Models.Course", "Course")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolApiSrc.Models.Lecturer", "Lecturer")
                        .WithMany("CourseAssignments")
                        .HasForeignKey("LecturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Lecturer");
                });

            modelBuilder.Entity("SchoolApiSrc.Models.CourseEnrollment", b =>
                {
                    b.HasOne("SchoolApiSrc.Models.Course", "Course")
                        .WithMany("CourseEnrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolApiSrc.Models.Student", "Student")
                        .WithMany("CourseEnrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("SchoolApiSrc.Models.Lecturer", b =>
                {
                    b.HasOne("SchoolApiSrc.Models.Department", "Department")
                        .WithMany("Lecturers")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SchoolApiSrc.Models.Student", b =>
                {
                    b.HasOne("SchoolApiSrc.Models.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SchoolApiSrc.Models.Course", b =>
                {
                    b.Navigation("CourseAssignments");

                    b.Navigation("CourseEnrollments");
                });

            modelBuilder.Entity("SchoolApiSrc.Models.Department", b =>
                {
                    b.Navigation("Courses");

                    b.Navigation("Lecturers");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolApiSrc.Models.Lecturer", b =>
                {
                    b.Navigation("CourseAssignments");
                });

            modelBuilder.Entity("SchoolApiSrc.Models.Student", b =>
                {
                    b.Navigation("CourseEnrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
