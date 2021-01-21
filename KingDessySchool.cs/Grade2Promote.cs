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
using System.Data.OleDb;
using System.IO;
using excel = Microsoft.Office.Interop.Excel;
namespace KingDessySchool.cs
{
    public partial class Grade2Promote : Form
    {
        public Grade2Promote()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(180, Color.Black);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "SELECT YOUR EXEL FILE";
            ofd.FileName = textBox1.Text;
            ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //loading excel data into datagrid view
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = '" + textBox1.Text + "'; Extended Properties = \'Excel 12.0 Xml;HDR=YES\'");
            //provider=Microsoft.Jet.OLEDB.4.0;data source='"+textBox1.Text+"';Extended Properties=\'Excel 8.0;HDR=NO;IMEX=1\'
            // "";Provider = Microsoft.ACE.OLEDB.12.0;    Data Source = c:\myFolder\myExcel2007file.xlsx; Extended Properties = "Excel 12.0 Xml;HDR ="YES";
            con.Open();
            OleDbDataAdapter oad = new OleDbDataAdapter("select * from [sheet1$]", con);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            oad.Fill(dt);
            this.dataGridView1.DataSource = dt.DefaultView;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Excel();
            //setting the timer
            this.timer1.Start();
            progressBar1.Visible = true;
            // Excel();
        }
        public void Excel()
        {
            //loading datagrid contents to excel worksheets
            //   Thread.Sleep(3000);
            excel.Application app = new excel.Application();
            excel.Workbook workbook = app.Workbooks.Add();
            excel.Worksheet Worksheet = null;
            app.Visible = true;
            Worksheet = workbook.Sheets["sheet1"];
            Worksheet = workbook.ActiveSheet;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }

            for (int j = 0; j <= dataGridView1.Rows.Count - 1; j++)
            {

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {

                    Worksheet.Cells[j + 2, i + 1] = dataGridView1.Rows[j].Cells[i].Value.ToString();
                }
            }
            Worksheet.Columns.AutoFit();
            //Worksheet.Columns.Text.Bold();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("id");
            dt.Columns.Add("id");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Classx");
            dt.Columns.Add("Age");
            dt.Columns.Add("Teacher");
            dt.Columns.Add("Photo");

            foreach (DataGridViewRow drv in dataGridView1.Rows)
            {
                bool chkBox = Convert.ToBoolean(drv.Cells["checkBox"].Value);
                //if (!chkBox)
                //{
                //    MessageBox.Show("SELECT STUDENTS TO BE PROMOTED");
                //    return;
                //}
                if (chkBox)
                {
                    dt.Rows.Add(drv.Cells[1].Value, drv.Cells[2].Value, drv.Cells[3].Value, drv.Cells[4].Value, drv.Cells[5].Value, drv.Cells[6].Value,drv.Cells[7].Value);
                    //dataGridView1.SelectedRows.Remove();
                    drv.DefaultCellStyle.BackColor = Color.Black;
                    drv.DefaultCellStyle.ForeColor = Color.Yellow;
                    // dataGridView1.Rows.RemoveAt(drv);
                }
                dataGridView2.DataSource = dt;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            button1.Text = progressBar1.Value.ToString() + "%";
            button1.ForeColor = Color.Red;
            dataGridView1.Visible = true;
            this.progressBar1.Increment(10);
            if (progressBar1.Value == 100)
            {
                //timer1.Tick.Tostring() = label7.Text;
                Excel();
                progressBar1.Visible = false;
                button1.Text = "EXPORT";
                button1.ForeColor = Color.White;
                timer1.Enabled = false;

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //cleaar data table
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO EMPTY THE CLASS 1 DATA TABLE ?? THIS ACTION CANNOT BE REVERSED", "EMPTY CLASS 1 DATA TABLE", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                dessy.opencon();
                SqlCommand cmd = new SqlCommand("truncate table NewGrade1", dessy.returnCon());
                dessy.opencon();

                cmd.ExecuteNonQuery();
                MessageBox.Show("DATA TABLE EMPTIED SUCCESSFULLY", "DATA TABLE EMPTIED", 0, MessageBoxIcon.Information);
                dessy.closeCon();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "SELECT YOUR EXEL FILE";
            ofd.FileName = textBox2.Text;
            ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = ofd.FileName;

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //loading excel data into datagrid view
            OleDbConnection con1 = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = '" + textBox2.Text + "'; Extended Properties = \'Excel 12.0 Xml;HDR=YES\'");
            //provider=Microsoft.Jet.OLEDB.4.0;data source='"+textBox1.Text+"';Extended Properties=\'Excel 8.0;HDR=NO;IMEX=1\'
            // "";Provider = Microsoft.ACE.OLEDB.12.0;    Data Source = c:\myFolder\myExcel2007file.xlsx; Extended Properties = "Excel 12.0 Xml;HDR ="YES";
            con1.Open();
            OleDbDataAdapter oad = new OleDbDataAdapter("select * from [sheet1$]", con1);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            oad.Fill(dt);
            this.dataGridView2.DataSource = dt.DefaultView;

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        

        public void Excel2()
        {
            //loading datagrid contents to excel worksheets
            //   Thread.Sleep(3000);
            excel.Application app = new excel.Application();
            excel.Workbook workbook = app.Workbooks.Add();
            excel.Worksheet Worksheet = null;
            app.Visible = true;
            Worksheet = workbook.Sheets["sheet1"];
            Worksheet = workbook.ActiveSheet;
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                Worksheet.Cells[1, i + 1] = dataGridView2.Columns[i].HeaderText;
            }

            for (int j = 0; j <= dataGridView2.Rows.Count - 1; j++)
            {

                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {

                    Worksheet.Cells[j + 2, i + 1] = dataGridView2.Rows[j].Cells[i].Value.ToString();
                }
            }
            Worksheet.Columns.AutoFit();
            //Worksheet.Columns.Text.Bold();

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            button3.Text = progressBar1.Value.ToString() + "%";
            button3.ForeColor = Color.Red;
            dataGridView2.Visible = true;
            this.progressBar2.Increment(10);
            if (progressBar2.Value == 100)
            {
                //timer1.Tick.Tostring() = label7.Text;
                Excel2();
                progressBar2.Visible = false;
                button3.Text = "EXPORT";
                button3.ForeColor = Color.White;
                timer2.Enabled = false;

            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            // Excel();
            //setting the timer
            this.timer2.Start();
            progressBar2.Visible = true;
            // Excel();
        }

        private void Grade2Promote_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet57.Grade2' table. You can move, or remove it, as needed.
           // this.grade2TableAdapter.Fill(this.dessySoftDataSet57.Grade2);
            //checkbox in datagrid
            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            chkbox.HeaderText = "SELECT STUDENT";
            chkbox.Name = "checkBox";
            chkbox.Width = 80;
            chkbox.DefaultCellStyle.BackColor = Color.Red;
            dataGridView1.Columns.Insert(0, chkbox);
            progressBar1.Visible = false;
        }
    }
}
