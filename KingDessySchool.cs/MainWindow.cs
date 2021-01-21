using System;  
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DessySchoolComplesApp.cs
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        KingDessySchool.cs.omagaconnections des = new KingDessySchool.cs.omagaconnections();

        private void button1_Click_1(object sender, EventArgs e)
        {
            var adm = new KingDessySchool.cs.RegisterStudentX();
           // adm.MdiParent = this;
            adm.Show();
            //this.Hide();
        }

        private void panel13_Paint_1(object sender, PaintEventArgs e)
        {
            panel13.BackColor = Color.FromArgb(165, Color.Black);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (this.textBox3.Text == "Class1 Teacher")
            {
                var classr = new KingDessySchool.cs.ResalClassroom();
                classr.class2ToolStripMenuItem.Enabled = false;
                classr.Show();

            }else if(this.textBox3.Text == "Class2 Teacher")
            {
                var classr = new KingDessySchool.cs.ResalClassroom();             
                classr.cToolStripMenuItem.Enabled = false;
                
            }
            //else if(this.textBox3.Text == "Class3 Teacher")
            //{
            //    var classr = new DessySchoolComplexReal.cs.classrooms();
            //    classr.class1ToolStripMenuItem.Enabled = false;
            //    classr.class2ToolStripMenuItem.Enabled = false;
            //}

            else
            {
                var classx = new KingDessySchool.cs.ResalClassroom(); ;
                classx.Show();

            }
            // this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var employees = new KingDessySchool.cs.Employees();
            employees.Show();
            //this.Hide();
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //var attendance = new KingDessySchool.cs.ResalClassroom(); 
            //attendance.Show();

            //if user == headmaster panel4 should display
            if (this.textBox3.Text == "HeadMaster")
            {
                if (panel14.Visible == true)
                {
                    panel14.Visible = false;
                    button5.Text = "ATTENDANCE";

                }
                else if(panel14.Visible == false)
                {
                    panel14.Visible = true;
                    button5.Text = "ATTENDANCE >>";
                    panel15.Visible = false;
                    button4.Text = "FEES";
                }
            }
            else if (this.textBox3.Text == "Class1 Teacher")
            {
                var attendance = new KingDessySchool.cs.ResalClassroom();
                attendance.class2ToolStripMenuItem.Enabled = false;
                attendance.Show();

            }
            else if (this.textBox3.Text == "Class2 Teacher")
            {
                var attendance = new KingDessySchool.cs.ResalClassroom();
                attendance.cToolStripMenuItem.Enabled = false;
                attendance.Show();
            }
            }

        private void button6_Click_1(object sender, EventArgs e)
        {
            var sub = new KingDessySchool.cs.subjects();
            sub.Show();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            var Reg = new KingDessySchool.cs.RegUser();
            Reg.Show();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            var details = new KingDessySchool.cs.profile();
            details.textBox1.Text = this.textBox1.Text;
            details.textBox3.Text = this.textBox2.Text;
            details.textBox2.Text = this.textBox3.Text;
            details.pictureBox1.Image = this.pictureBox13.Image;
            details.textBox4.Text = this.textBox4.Text;
            details.Show();
        } 

        private void MainWindow_Load(object sender, EventArgs e)
        {
            //makes picturebox13 round
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox13.Width - 3, pictureBox13.Height - 3);
            Region rg = new Region(gp);
            pictureBox13.Region = rg;

            textBox4.Visible = false;  
            this.textBox1.Visible = false;
            this.textBox2.Visible = false;
            this.textBox3.Visible = false;
            if(this.textBox3.Text == "Class1 Teacher") { 
                   var classr = new DessySchoolComplexReal.cs.classrooms();
                     classr.class2ToolStripMenuItem.Enabled = false;
                     classr.class3ToolStripMenuItem.Enabled = false;
              }

            //hide panel14
            panel14.Visible = false;
            panel15.Visible = false;


        }

        private void button10_Click(object sender, EventArgs e)
        {
            var loginxx = new DessySchoolComplesApp.cs.login();

            if (MessageBox.Show("ARE YOU SURE YOU WANT TO EXIT THIS APP ??", "EXIT?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            { 
            this.Dispose();
            loginxx.Show();
            }
            else
            {
                this.Show();
            loginxx.Hide();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            if (this.textBox3.Text == "HeadMaster")
            {
                if (panel15.Visible == true)
                {
                    panel15.Visible = false;
                    button4.Text = "FEES";

                }
                else if (panel15.Visible == false)
                {
                    panel15.Visible = true;
                    button4.Text = "FEES >>";
                    panel14.Visible = false;
                    button5.Text = "ATTENDANCE";
                }
            }
            if (this.textBox3.Text == "Class1 Teacher")
            {
                var feess = new KingDessySchool.cs.fees();
                feess.Show();
            }
            else if (this.textBox3.Text == "Class2 Teacher")
            {
                var g2 = new KingDessySchool.cs.Grade2Fees();
                g2.Show();
            }
           // else
            //{
               // var g2 = new KingDessySchool.cs.Grade2Fees();
               // g2.Show();
                // MessageBox.Show("ONLY CLASS 1 & CLASS 2 FEES PAGE ARE READY! THE OTHER PAGES ARE UNDER CONSTRACTION");
            //}
            }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            // counting the number of rows in the LiReg table and displaying in a label on the library page
            var lib = new KingDessySchool.cs.Library();
            lib.pictureBox1.Image = this.pictureBox13.Image;
            lib.label10.Text = this.label2.Text;  
            lib.Show();
            this.Hide();
   
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;
            des.opencon();
            string query = "SELECT COUNT(*) FROM LiReg ";
            SqlCommand cmd = new SqlCommand(query, des.returnCon());
            Int32 count = Convert.ToInt32(cmd.ExecuteScalar()); 
                lib.label2.Text = count.ToString();

            //count the LiRegBook table and display the num of rows in the label
            string query1 = "SELECT COUNT(*) FROM LiRegBook ";
            SqlCommand cmdx = new SqlCommand(query1, des.returnCon());
            Int32 count1 = Convert.ToInt32(cmdx.ExecuteScalar());
            lib.label5.Text = count1.ToString();

         
            //count the issue book table to find number of books issued 
            string query2 = "SELECT COUNT(*) FROM issueBook ";
            SqlCommand cmdx2 = new SqlCommand(query2, des.returnCon());
            Int32 count2 = Convert.ToInt32(cmdx2.ExecuteScalar());
            lib.label7.Text = count2.ToString();
            
            //count the returned date column to find the number of books returned (num of columns which are not null)
            string query3 = "SELECT  COUNT(DateReturned)  FROM issueBook ";
            SqlCommand cmdx3 = new SqlCommand(query3, des.returnCon());
            Int32 count3 = Convert.ToInt32(cmdx3.ExecuteScalar());
            lib.label9.Text = count3.ToString();

            des.closeCon();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(85, Color.Black);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (this.textBox3.Text == "Class1 Teacher")
            {
                var c1 = new KingDessySchool.cs.Grade1ReportCards();
                c1.Show();
                return;
            }else if (this.textBox3.Text == "Class2 Teacher")
            {
                MessageBox.Show("CLASS 2 REPORT PAGE IS STILL UNDER CONSTRUCTION");
                return;
            } else if (this.textBox3.Text == "HeadMaster")
            {
                var c1 = new KingDessySchool.cs.Grade1ReportCards();
                c1.Show();
                return;
            }
            }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://mail.google.com");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }
            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://calendar.google.com/calendar/");
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message);
            }

            // var gmail = new KingDessySchool.cs.GmailMain();
            //gmail.Show();
        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {
            panel14.BackColor = Color.FromArgb(80, Color.Black);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            var attendance = new KingDessySchool.cs.ResalClassroom();
            attendance.Show();
            attendance.cToolStripMenuItem.ShowDropDown();
            attendance.studentAttendanceToolStripMenuItem.BackColor = Color.Red;
            attendance.teacherAttendanceToolStripMenuItem.BackColor = Color.Yellow;
            attendance.teacherAttendanceToolStripMenuItem.ForeColor = Color.Black;

        }

        private void button16_Click(object sender, EventArgs e)
        {
            var attendance = new KingDessySchool.cs.ResalClassroom();
            attendance.Show();
            attendance.class2ToolStripMenuItem.ShowDropDown();
            attendance.studentAttendanceToolStripMenuItem1.BackColor = Color.Red;
            attendance.teacherAttendanceToolStripMenuItem1.BackColor = Color.Yellow;
            attendance.teacherAttendanceToolStripMenuItem1.ForeColor = Color.Black;

        }

        private void button19_Click(object sender, EventArgs e)
        {
            panel14.Hide();
            button5.Text = "ATTENDANCE";

        }

        private void button23_Click(object sender, EventArgs e)
        {
            var g2 = new KingDessySchool.cs.Grade2Fees();
            g2.Show();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            var feess = new KingDessySchool.cs.fees();
            feess.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            panel15.Hide();
            button4.Text = "FEES";

        }
    }
}
