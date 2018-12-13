﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CourseHelperBasicVersion.Models
{
    public enum SEASON
    {
        FALL,
        WINTER,
        SUMMER
    }

    public class Course
    {
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        public string Description { get; set; }
        [Required]
        public SEASON Season { get; set; }
        [Required]
        public string Faculty { get; set; }
        [Required]
        [Range(1, 36)]
        public int MaxSize { get; set; }
        public ICollection<CourseStudent> CourseStudents { get; set; } = new List<CourseStudent>();

        private IEnumerable<Student> GetStudents()
        {
            foreach (CourseStudent cs in CourseStudents)
            {
                yield return cs.Student;
            }
        }
        [NotMapped]
        public ICollection<Student> Students { get { return GetStudents().ToList<Student>(); } }

        public CourseStudent AddStudent(Student student)
        {
            if (student.Courses.Contains(this))
            {
                return null;
            }
            else
            {
                CourseStudent cs = new CourseStudent(this, student);
                CourseStudents.Add(cs);
                student.CourseStudents.Add(cs);
                return cs;
            }
        }
        public CourseStudent DeleteStudent(Student student)
        {
            if (!student.Courses.Contains(this))
            {
                return null;
            }
            else
            {
                CourseStudent cs = CourseStudents.FirstOrDefault(
                    cst => cst.CourseId == CourseId && cst.StudentId == student.StudentId);
                CourseStudents.Remove(cs);
                student.CourseStudents.Remove(cs);
                return cs;
            }
        }
    }
}
