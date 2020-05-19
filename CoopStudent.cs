using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class CoopStudent:Student
    {
        //properties
        public static int MaxWeeklyHours{get;set;}
        public static int MaxNumOfCourses { get; set; }

        //constructor
        public CoopStudent(string name) :base(name)
        { }

        //method
        public override void RegisterCourses(List<Course> selectedCourses)
        {
            int hours = 0;
        foreach(Course course in selectedCourses)
            { hours += course.WeeklyHours; }
        if (hours > MaxWeeklyHours)
            { throw new Exception("Your selection exceeds the maximum weekly hours: " + MaxWeeklyHours); }
        if(selectedCourses.Count>MaxNumOfCourses)
            {
                throw new Exception("Your selection exceeds the maximum number of courses: " + MaxNumOfCourses);
            }
            base.RegisterCourses(selectedCourses);
        }
        //method2
        public override string ToString() 
        { return Id + " - " + Name + " (Coop)"; }
    }
}