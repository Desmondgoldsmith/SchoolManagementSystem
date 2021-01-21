using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DessySchoolComplexReal.cs
{
    public partial class classrooms : Form
    {
        public classrooms()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void classrooms_Load(object sender, EventArgs e)
        {

        }

        private void insertRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Form2 newMDIChild = new Form2();
            // Set the Parent Form of the Child window.
            // Display the new form.
            //newMDIChild.Show();
            var main = new DessySchoolComplexReal.cs.classrooms();
            var cls1 = new Grade1();
            cls1.BringToFront();
            
                 cls1.MdiParent = main;
                   cls1.Show();
            MessageBox.Show("GOOD");
            
           // cls1.Focus();
            cls1.button2.Enabled = false;
            cls1.button3.Enabled = false;

        }

        private void class2ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void studentAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var stdAttClass1 = new KingDessySchool.cs.attendnce();
            stdAttClass1.MdiParent = this;
            this.SendToBack();
            stdAttClass1.BringToFront();
            stdAttClass1.Show();
        }

        private void teacherAttendanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var TattClass1 = new KingDessySchool.cs.TAttendanceC1();
            TattClass1.Show();
        }

        private void updateRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cls1 = new Grade1();
            cls1.Show();
            cls1.button1.Enabled = false;
            cls1.button3.Enabled = false;
        }

        private void deleteRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cls1 = new Grade1();
            cls1.Show();
            cls1.button1.Enabled = false;
            cls1.button2.Enabled = false;
        }

        private void lockScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lockx = new DessySchoolComplesApp.cs.login();
            lockx.Show();
            var main = new DessySchoolComplesApp.cs.MainWindow();
            main.Close();
            this.Hide();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var lockx = new DessySchoolComplesApp.cs.login();
            lockx.Show();
            this.Hide();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("ARE YOU SURE YOU WANT TO EXIT ? SAVE ALL CHANGES BEFORE YOU EXIT!","EXIT?",MessageBoxButtons.YesNo,MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                
            }
        }

        private void studentFeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fees = new KingDessySchool.cs.ViewFeesC1();
            fees.Show();
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var all = new KingDessySchool.cs.ViewC1();
            all.Show();
        }
    }
}
