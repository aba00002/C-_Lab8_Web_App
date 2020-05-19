using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class Student
    {
        //properties
        public int Id { get; }
        public string Name { get; }

        public List<Course> RegisteredCourses { get; }

        //constructor
        public Student(string name)
        {
            Name = name;
            Random number = new Random();
            Id= number.Next(900000, 999999);
            RegisteredCourses = new List<Course>();
        }

        //method
        public virtual void RegisterCourses(List<Course> selectedCourses) 
        { 
            RegisteredCourses.Clear();
            RegisteredCourses.AddRange(selectedCourses);
        }
        
        public int TotalWeeklyHours() 
        {
            int totalHours = 0;
            foreach(Course c in RegisteredCourses)
            { totalHours += c.WeeklyHours; }
            return totalHours;
        }
    }
}