using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Lab8
{
    public partial class AddStudent : System.Web.UI.Page
    {
        //student list
        
        protected void page_Load(object sender, EventArgs e)
        {
            List<Models.Student> students = null;
            if (Session["students"] == null) 
            { 
                students = new List<Models.Student>();
                Session["students"] = students;
            }
            else
            { students = (List<Models.Student>)Session["students"]; }

            displayStudents(students);

            if (!IsPostBack)
            {
                DrpStudentType.Items.Add(new ListItem("Select ...", ""));
                DrpStudentType.Items.Add(new ListItem("Full Time", "fulltime"));
                DrpStudentType.Items.Add(new ListItem("Part Time", "parttime"));
                DrpStudentType.Items.Add(new ListItem("Coop", "coop"));
            }
        }

      
        protected void Button1_Click(object sender, EventArgs e)
        {
            //If the user clicks the Add button without entering Student Name or select a Student Type, the web application will do nothing
            if (TextBox1.Text == "") return;
            List<Models.Student> students = (List<Models.Student>)Session["students"];
            if (DrpStudentType.SelectedValue == "fulltime")
            { students.Add(new Models.FulltimeStudent(TextBox1.Text)); }
            else if (DrpStudentType.SelectedValue == "parttime")
            { students.Add(new Lab8.Models.ParttimeStudent(TextBox1.Text)); }
            else if (DrpStudentType.SelectedValue == "coop")
            { students.Add(new Lab8.Models.CoopStudent(TextBox1.Text)); }
            else { return; }

            TextBox1.Text = "";
            DrpStudentType.SelectedValue = "";

            displayStudents(students);

        }

        private void displayStudents(List<Models.Student> students) 
        { 
            if(students.Count == 0) 
            {   
                TableRow newRow = new TableRow();
                Table1.Rows.Add(newRow);
                TableCell newCell = new TableCell();
                newRow.Cells.Add(newCell);
                newCell.Text = "No Student Yet!";
                newCell.ForeColor = System.Drawing.Color.Red;
                newCell.ColumnSpan = 2;
                newCell.HorizontalAlign = HorizontalAlign.Center;
            }
            else 
            { 
                if(Table1.Rows.Count > 1)
                {
                    for(int i = Table1.Rows.Count - 1; i > 0; i--) 
                    { Table1.Rows.RemoveAt(i); }
                }

            foreach(Models.Student student in students) 
                {
                    TableRow nextRows = new TableRow();
                    TableCell nextCells = new TableCell();
                    nextCells.Text = student.Id.ToString();
                    nextRows.Cells.Add(nextCells);
                    

                    nextCells = new TableCell();
                    nextCells.Text = student.Name;
                    nextRows.Cells.Add(nextCells);
                    Table1.Rows.Add(nextRows);

                }
            }
        }
        }

    }
