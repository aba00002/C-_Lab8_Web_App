using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Lab8
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            Models.FulltimeStudent.MaxWeeklyHours = 16;
            Models.ParttimeStudent.MaxNumOfCourses = 3;
            Models.CoopStudent.MaxWeeklyHours = 4;
            Models.CoopStudent.MaxNumOfCourses = 2;
        }
    }
}