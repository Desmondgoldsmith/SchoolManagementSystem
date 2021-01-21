using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KingDessySchool.cs
{
    public partial class ResalClassroom : Form
    {
        public ResalClassroom()
        {
            InitializeComponent();
        }

      
        private void insertRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var g1 = new DessySchoolComplexReal.cs.Grade1();
             //g1.BringToFront();

            g1.MdiParent = this;
            g1.Show();

            // cls1.Focus();
            g1.button2.Enabled = false;
            g1.button3.Enabled = false;
        }

        private void studentAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var stdAttClass1 = new KingDessySchool.cs.attendnce();
            //stdAttClass1.MdiParent = this;
            ////this.SendToBack();
            ////stdAttClass1.BringToFront();
            //stdAttClass1.Show();

            var Attendance = new class1Attendance();
            Attendance.MdiParent = this;
            Attendance.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void updateRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cls1 = new DessySchoolComplexReal.cs.Grade1();
            cls1.MdiParent = this;
            cls1.Show();
            cls1.button1.Enabled = false;
            cls1.button3.Enabled = false;
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cls1 = new DessySchoolComplexReal.cs.Grade1();
            cls1.MdiParent = this;
            cls1.Show();
            cls1.button1.Enabled = false;
            cls1.button2.Enabled = false;
        }

        private void viewStudentDataToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var all = new KingDessySchool.cs.ViewC1();
            all.MdiParent = this;
            all.Show();
        }

        private void studentFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fees = new KingDessySchool.cs.ViewFeesC1();
            fees.MdiParent = this;
            fees.Show();
        }

        private void teacherAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TattClass1 = new KingDessySchool.cs.TAttendanceC1();
            TattClass1.MdiParent = this;
            TattClass1.Show();
        }

        private void ResalClassroom_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.DarkGray;
        }

        private void addStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var class2 = new Grade2();
            class2.MdiParent = this;
            class2.Show();

        }

        private void promoteRepeatStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var pro = new C1Promote();
            pro.MdiParent = this;
            pro.Show();
        }

        private void studentFeesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //grade 2 view fees

            var Grade2 = new ViewGrade2Fees();
            Grade2.MdiParent = this;
            Grade2.Show();
        }

        private void studentAttendanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //grade 2 Student attendance

            var g2 = new Grade2Attendance();
            g2.MdiParent = this;
            g2.Show();
        }

        private void teacherAttendanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //grade 2 Teacher attendance
            var g2T = new Grade2TAttendance();
            g2T.MdiParent = this;
            g2T.Show();
        }

        private void promoteStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //grade 2 Promote student page
            var g2pro = new Grade2Promote();
            g2pro.MdiParent = this;
            g2pro.Show();
        }

        private void viewStudentDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //view all g2 student data
            var vg2 = new ViewGrade2();
            vg2.MdiParent = this;
            vg2.Show();
        }

        private void class3ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addStudentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var grade3 = new Grade3Main();
            grade3.MdiParent = this;
            grade3.Show();
        }

        private void class2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.studentAttendanceToolStripMenuItem1.BackColor = Color.Red;
            this.teacherAttendanceToolStripMenuItem1.BackColor = Color.Yellow;

        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.studentAttendanceToolStripMenuItem.BackColor = Color.Black; 
            this.teacherAttendanceToolStripMenuItem.BackColor = Color.Black;
            this.teacherAttendanceToolStripMenuItem.ForeColor = Color.White;

        }
    }
}
