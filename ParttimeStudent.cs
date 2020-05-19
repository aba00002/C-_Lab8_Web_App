using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class ParttimeStudent : Student
    {
        //property
        public static int MaxNumOfCourses { get; set; }

        //constuctor
        public ParttimeStudent(string name) :base(name)
        { }

        //method
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            if (selectedCourses.Count > MaxNumOfCourses)
            { throw new Exception("Your selection exceeds the maximum number of courses: " + MaxNumOfCourses); }
            base.RegisterCourses(selectedCourses);
        }
        //method2
        public override string ToString()
        { return Id + " - " + Name + " (Part time)"; }
    }
}