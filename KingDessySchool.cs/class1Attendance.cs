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
using excel = Microsoft.Office.Interop.Excel;
namespace KingDessySchool.cs
{
    public partial class class1Attendance : Form
    {
        public class1Attendance()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        private void class1Attendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet101.RealGrade1Attendance' table. You can move, or remove it, as needed.
            this.realGrade1AttendanceTableAdapter3.Fill(this.dessySoftDataSet101.RealGrade1Attendance);
            // TODO: This line of code loads data into the 'dessySoftDataSet100.RealGrade1Attendance' table. You can move, or remove it, as needed.
            this.realGrade1AttendanceTableAdapter2.Fill(this.dessySoftDataSet100.RealGrade1Attendance);
            // TODO: This line of code loads data into the 'dessySoftDataSet94.NewGrade1' table. You can move, or remove it, as needed.
            this.newGrade1TableAdapter.Fill(this.dessySoftDataSet94.NewGrade1);
            // this.newGrade1TableAdapter.Fill(this.dessySoftDataSet92.NewGrade1);
            panel3.Visible = false;
            panel4.Visible = false;
            progressBar1.Visible = false;
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "ATTENDANCE STATUS";
            combo.Name = "promote";
            combo.Width = 120;
            combo.DefaultCellStyle.BackColor = Color.Black;
            combo.DefaultCellStyle.ForeColor = Color.White;

            combo.Items.Add("Present");
            combo.Items.Add("Absent");
            dataGridView1.Columns.Insert(0, combo);

            //Reason
            DataGridViewTextBoxColumn txxt = new DataGridViewTextBoxColumn();
            txxt.HeaderText = "REASON";
            txxt.Name = "REASON";
            txxt.Width = 180;

            dataGridView1.Columns.Insert(5, txxt);
            //fill combobox1 with dates
            dessy.opencon();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Distinct Datex FROM RealGrade1Attendance ORDER BY Datex desc", dessy.returnCon());

            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Datex";
            comboBox1.ValueMember = "Datex";

            //assigning an empty combobox on formload
            comboBox1.SelectedIndex = -1;
            //empty textBox an formload
            textBox1.Clear();
            //textbox1 hidden
            textBox1.Visible = false;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(160, Color.Black);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panel3.Visible == true)
            {
                panel3.Visible = false;
                dataGridView2.Refresh();
            }
            else
            {
                //hide panel4
                panel4.Hide();
                //fill combobox1 with dates
                dessy.opencon();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Distinct Datex FROM RealGrade1Attendance ORDER BY Datex desc", dessy.returnCon());

                DataTable dt = new DataTable();

                da.Fill(dt);
                comboBox1.DataSource = dt;
                comboBox1.DisplayMember = "Datex";
                comboBox1.ValueMember = "Datex";
                panel3.Visible = true;
                dataGridView2.Refresh();

                //assigning an empty combobox on formload
                comboBox1.SelectedIndex = -1;
                //empty textBox an formload
                textBox1.Clear();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(190, Color.Black);

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //validate empty cells
            foreach (DataGridViewRow rw in this.dataGridView1.Rows)
            {
                for (int i = 0; i < rw.Cells.Count; i++)
                {
                    if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                    {
                        MessageBox.Show("Can't Save Records With Empty Cells", "Complete The Attendance!", 0, MessageBoxIcon.Error);
                        return;
                    }
                }
            }



            //insert
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dessy.opencon();
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO RealGrade1Attendance VALUES(@promote, @FirstName, @LastName,@Classx,@Teacher,@Reason,@Datex)", dessy.returnCon());
                    {
                        cmd.Parameters.AddWithValue("@promote", row.Cells["promote"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@FirstName", row.Cells["firstNameDataGridViewTextBoxColumn"].Value);
                        cmd.Parameters.AddWithValue("@LastName", row.Cells["lastNameDataGridViewTextBoxColumn"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Classx", row.Cells["classxDataGridViewTextBoxColumn"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Teacher", row.Cells["teacherDataGridViewTextBoxColumn"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Reason", row.Cells["REASON"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Datex", dateTimePicker1.Text);

                        dessy.opencon();
                        cmd.ExecuteNonQuery();
                        dessy.closeCon();
                    }
                }
            }
            MessageBox.Show("ATTENDANCE TAKEN FOR '" + dateTimePicker1.Text + "'.", "ATTENDANCE TAKEN", 0, MessageBoxIcon.Information);
            //clear first n last column
            foreach (DataGridViewRow des in dataGridView1.Rows)
            {
                des.Cells[0].Value = null;
                des.Cells[5].Value = null;
            }



        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(100, Color.Black);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load combobox date into textbox
            textBox1.Text = comboBox1.Text;


        }


        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //view records in datagrid
            SqlDataAdapter sda = new SqlDataAdapter("select * from RealGrade1Attendance  where CONCAT(Datex,id) like '%" + textBox1.Text + "%'", dessy.returnCon());
            dessy.opencon();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView2.DataSource = dt;
            //end
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            textBox1.Clear();
        }

        private void label40_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel4.Visible == true)
            {
                panel4.Visible = false;
                dataGridView3.Refresh();
                button7.Enabled = false;

            }
            else
            {
                //hide panel3
                panel3.Hide();
                //disable the delete button
                button7.Enabled = false;

                //fill combobox1 with dates
                dessy.opencon();
                SqlDataAdapter da = new SqlDataAdapter("SELECT Distinct Datex FROM RealGrade1Attendance ORDER BY Datex desc", dessy.returnCon());

                DataTable dt = new DataTable();

                da.Fill(dt);
                comboBox2.DataSource = dt;
                comboBox2.DisplayMember = "Datex";
                comboBox2.ValueMember = "Datex";
                panel4.Visible = true;
                dataGridView3.Refresh();

                //assigning an empty combobox on formload
                comboBox2.SelectedIndex = -1;
                //empty textBox an formload
                textBox2.Clear();
                button7.Enabled = false;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //update gatagrid once
            dessy.opencon();
            SqlCommand cmd = new SqlCommand(@"UPDATE RealGrade1Attendance
                                     SET promote = @p,FirstName = @fn,LastName = @ln,Classx = @c,Teacher = @t,Reason = @r, Datex = @d   
                                     WHERE id= @id", dessy.returnCon());

            cmd.Parameters.Add("@p", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@c", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@t", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@r", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@d", SqlDbType.VarChar).Value = "";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = 0;

            foreach (DataGridViewRow row in dataGridView3.Rows)
            {
                // matching parameters with row names
                cmd.Parameters["@p"].Value = row.Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                cmd.Parameters["@fn"].Value = row.Cells["dataGridViewTextBoxColumn3"].Value.ToString();
                cmd.Parameters["@ln"].Value = row.Cells["dataGridViewTextBoxColumn4"].Value.ToString();
                cmd.Parameters["@c"].Value = row.Cells["dataGridViewTextBoxColumn5"].Value.ToString();
                cmd.Parameters["@t"].Value = row.Cells["dataGridViewTextBoxColumn6"].Value.ToString();
                cmd.Parameters["@r"].Value = row.Cells["dataGridViewTextBoxColumn7"].Value.ToString();
                cmd.Parameters["@d"].Value = row.Cells["dataGridViewTextBoxColumn8"].Value.ToString();
                cmd.Parameters["@id"].Value = Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn1"].Value);
                cmd.ExecuteNonQuery();
                dataGridView3.Refresh();
            }
            MessageBox.Show("ATTENDANCE RECORD UPDATED SUCCESSFULLY", "UPDATED!!", 0, MessageBoxIcon.Information);
            dessy.closeCon();
        }


        private void button7_Click(object sender, EventArgs e)
        {
            //validate Delete
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE ATTENDANCE TAKEN ON DATE: '" + comboBox2.Text + "'??", "DELETE RECORDS?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (MessageBox.Show("DELETED RECORDS CAN NEVER BE RECOVERD! ARE YOU STILL SURE YOU WANT TO DELETE?", "DELETE RECORDS?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //detete datagrid once
                    dessy.opencon();
                    SqlCommand cmd = new SqlCommand(@"Delete RealGrade1Attendance   
                                     WHERE id= @id", dessy.returnCon());

                    cmd.Parameters.Add("@id", SqlDbType.Int).Value = 0;

                    foreach (DataGridViewRow row in dataGridView3.Rows)
                    {
                        // matching parameters with row names
                        cmd.Parameters["@id"].Value = Convert.ToInt32(row.Cells["dataGridViewTextBoxColumn1"].Value);
                        cmd.ExecuteNonQuery();
                    }
                    MessageBox.Show("ATTENDANCE RECORD OF DATE: '" + comboBox2.Text + "'  DELETED SUCCESSFULLY ", "ATTENDACE DELETED!!", 0, MessageBoxIcon.Information);
                    dataGridView3.Refresh();
                    dessy.closeCon();
                }
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox2.Text = null;
            textBox2.Clear();
            dataGridView3.Refresh();
            button7.Enabled = false;
            comboBox2.Refresh();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            panel4.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //view records in datagrid
            SqlDataAdapter sda = new SqlDataAdapter("select * from RealGrade1Attendance  where CONCAT(Datex,id) like '%" + textBox2.Text + "%'", dessy.returnCon());
            dessy.opencon();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView3.DataSource = dt;
            button7.Enabled = true;

            //end
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load combobox date into textbox
            textBox2.Text = comboBox2.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.timer1.Start();
            progressBar1.Visible = true;

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
            for (int i = 0; i < dataGridView3.Columns.Count; i++)
            {
                Worksheet.Cells[1, i + 1] = dataGridView3.Columns[i].HeaderText;
            }

            for (int j = 0; j <= dataGridView3.Rows.Count - 1; j++)
            {

                for (int i = 0; i < dataGridView3.Columns.Count; i++)
                {

                    Worksheet.Cells[j + 2, i + 1] = dataGridView3.Rows[j].Cells[i].Value.ToString();
                }
            }
            Worksheet.Columns.AutoFit();
            //Worksheet.Columns.Text.Bold();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //indicating loading of data to excel when the export btn is triggerd
            progressBar1.Increment(1);
            button8.Text = progressBar1.Value.ToString() + "%";
            button8.ForeColor = Color.Red;
            this.progressBar1.Increment(10);
            if (progressBar1.Value == 100)
            {
                //timer1.Tick.Tostring() = label7.Text;
                Excel();
                progressBar1.Visible = false;
                button8.Text = "EXPORT";
                button8.ForeColor = Color.White;
                timer1.Enabled = false;
            }
        }
    }
}
