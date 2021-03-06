﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using excel = Microsoft.Office.Interop.Excel;
namespace KingDessySchool.cs
{
    public partial class ViewFeesC1 : Form
    {
        public ViewFeesC1()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(180, Color.Black);
        }

        private void ViewFeesC1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet64.Grade1Fees' table. You can move, or remove it, as needed.
            this.grade1FeesTableAdapter.Fill(this.dessySoftDataSet64.Grade1Fees);
            // TODO: This line of code loads data into the 'dessySoftDataSet63.Grade1Fees' table. You can move, or remove it, as needed.
            // TODO: This line of code loads data into the 'dessySoftDataSet48.feesRec' table. You can move, or remove it, as needed.
            pictureBox1.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //search datagrid
                string search = textBox1.Text;
                SqlCommand cmd = new SqlCommand("select * from Grade1Fees  where CONCAT(StudName,StudentClass) like '%" + textBox1.Text + "%' ", dessy.returnCon());
                //view records in datagrid
                SqlDataAdapter sda = new SqlDataAdapter("select * from Grade1Fees  where CONCAT(StudName,StudentClass) like '%" + textBox1.Text + "%'", dessy.returnCon());

                //cmd.Parameters.AddWithValue("@fname", search);
                //cmd.Parameters.AddWithValue("@lname", search);
                dessy.opencon();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                //end
                SqlDataReader rd;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    pictureBox1.Visible = true;

                    Byte[] data = new Byte[0];
                    data = (Byte[])rd.GetValue(8);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(mem);
                    if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
                    {
                        pictureBox1.Visible = false;

                        pictureBox1.Image = null;
                    }
                }
                else
                {
                    rd.Close();
                    MessageBox.Show("NO RECORD AVAILABLE ", " RECORD DOES NOT EXIST", 0, MessageBoxIcon.Error);
                    textBox1.Clear();
                }
                rd.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dessy.closeCon();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Excel();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
