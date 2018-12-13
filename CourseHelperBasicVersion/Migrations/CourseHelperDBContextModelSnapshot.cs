﻿// <auto-generated />
using CourseHelperBasicVersion.Models.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace CourseHelperBasicVersion.Migrations
{
    [DbContext(typeof(CourseHelperDBContext))]
    partial class CourseHelperDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CourseHelperBasicVersion.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("Faculty")
                        .IsRequired();

                    b.Property<int>("MaxSize");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Season");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("CourseHelperBasicVersion.Models.CourseStudent", b =>
                {
                    b.Property<int>("CourseId");

                    b.Property<int>("StudentId");

                    b.HasKey("CourseId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("CourseStudent");
                });

            modelBuilder.Entity("CourseHelperBasicVersion.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment")
                        .IsRequired();

                    b.Property<string>("CourseCode")
                        .IsRequired();

                    b.Property<string>("CourseName");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("CreatorName");

                    b.Property<string>("Semester")
                        .IsRequired();

                    b.HasKey("ReviewId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("CourseHelperBasicVersion.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsRegistered");

                    b.Property<string>("LastName");

                    b.Property<string>("MiddleName");

                    b.Property<int>("Semester");

                    b.Property<int>("Status");

                    b.Property<long>("StudentNumber");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("CourseHelperBasicVersion.Models.CourseStudent", b =>
                {
                    b.HasOne("CourseHelperBasicVersion.Models.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CourseHelperBasicVersion.Models.Student", "Student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
