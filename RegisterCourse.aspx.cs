using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Lab8.Models;

namespace Lab8
{
    public partial class RegisterCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["students"] == null)
            { Response.Redirect(" AddStudent.aspx"); }

            List<Models.Course> courseList = Models.Helper.GetAvailableCourses();
            if (!IsPostBack)
            {
                DrpDownRegistered.Items.Add(new ListItem("Select ...", ""));
                List<Models.Student> students = (List<Models.Student>)Session["students"];
                foreach (Student student in students)
                {
                    ListItem item = new ListItem(student.ToString(), student.Id.ToString());
                    DrpDownRegistered.Items.Add(item);
                }
                for (int i = 0; i < courseList.Count; i++)
                {
                    CheckBoxList1.Items.Add(new ListItem(courseList[i].Code + " " + courseList[i].Title + " - " + courseList[i].WeeklyHours + " hours per week", courseList[i].Code));
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DrpDownRegistered.SelectedIndex == 0) return;
            List<Models.Student> students = (List<Models.Student>)Session["students"];
            Models.Student selectedStudent = students[DrpDownRegistered.SelectedIndex - 1];

            try
            {
                List<Models.Course> courseList = Models.Helper.GetAvailableCourses();
                List<Models.Course> selectedCourses = new List<Models.Course>();
                foreach (ListItem s in CheckBoxList1.Items)
                {
                    if (s.Selected == true)
                    {
                        Models.Course course = Models.Helper.GetCourseByCode(s.Value);
                        selectedCourses.Add(course);
                    }
                }
                if (selectedCourses.Count == 0)
                { throw new Exception("You need select atleast one course"); }

                selectedStudent.RegisterCourses(selectedCourses);
                Output.Text = "Selected student has registered "+ selectedStudent.RegisteredCourses.Count.ToString() + " course(s), "+ selectedStudent.TotalWeeklyHours().ToString()+ " hours weekly";
                Error.Text = "";
            }
            catch (Exception ex)
            {
                Error.Text = ex.Message;
                Output.Text = "";
            }
            
        }

        protected void drpDownReg(object sender, EventArgs e)
        {
            foreach (ListItem s in CheckBoxList1.Items)
            {
                s.Selected = false;
            }
                if (DrpDownRegistered.SelectedIndex != 0)
            {
                List<Models.Student> students = (List<Models.Student>)Session["students"];
                Models.Student selectedStudent = students[DrpDownRegistered.SelectedIndex - 1];
                Output.Text = "Selected student has registered " + selectedStudent.RegisteredCourses.Count.ToString() + " course(s), " + selectedStudent.TotalWeeklyHours().ToString() + " hours weekly";
                Error.Text = "";

                foreach(ListItem s in CheckBoxList1.Items)
                {
                    foreach(Models.Course c in selectedStudent.RegisteredCourses)
                    {
                        if(s.Value ==  c.Code)
                        { s.Selected = true; }
                    }
                }
            }
            
        }
    }
}