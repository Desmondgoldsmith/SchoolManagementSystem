using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using excel = Microsoft.Office.Interop.Excel;
namespace KingDessySchool.cs
{
    public partial class Grade2Attendance : Form
    {
        public Grade2Attendance()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        string imglocation;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(180, Color.Black);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save_Stud();
        }
        //save record
        public void Save_Stud()
        {
            if (string.IsNullOrWhiteSpace(comboBox4.Text.ToString()))
            {
                MessageBox.Show("Select The Student Class.This Feild Cannot Be Empty  ", "Select Student Class", 0, MessageBoxIcon.Information);
                comboBox4.Focus();
                comboBox4.BackColor = Color.Red;
                comboBox4.ForeColor = Color.Yellow;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text.ToString()))
            {
                MessageBox.Show("Input The Student  Name.This Feild Cannot Be Empty  ", "Input The Student's  Name!", 0, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text.ToString()))
            {
                MessageBox.Show("Input The Student LastName.This Feild Cannot Be Empty  ", "Select Student LastName", 0, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text.ToString()))
            {
                MessageBox.Show("Input Todays Date.This Feild Cannot Be Empty  ", "Select Today's Date", 0, MessageBoxIcon.Information);
                dateTimePicker1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox3.Text.ToString()))
            {
                MessageBox.Show("Select Attendance Status.This Feild Cannot Be Empty  ", "Select Attendance Status", 0, MessageBoxIcon.Information);
                comboBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                MessageBox.Show("Input The Reason For Absence.This Feild Cannot Be Empty  ", "Input Reasons For Absence", 0, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            //if (pictureBox1.Image = null)
            //{
            //    MessageBox.Show("Upload Your Signature.This Feild Cannot Be Empty  ", "Upload Your Signature", 0, MessageBoxIcon.Information);
            //    pictureBox1.Focus();
            //    return;
            //            }


            try
            {
                byte[] image = null;
                FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
                dessy.opencon();
                string Query = "INSERT INTO Grade2StudentAttendance (stdClass,FName,Lname,Datex,attendanceStatus,Reason,Signaturex)  Values(@cbo1,@cbo2,@cbo3,@dtp1,@cbo4,@txt1,@pic)";
                SqlCommand cmd = new SqlCommand(Query, dessy.returnCon());
                cmd.Parameters.AddWithValue("@cbo1", comboBox4.Text);
                cmd.Parameters.AddWithValue("@cbo2", textBox2.Text);
                cmd.Parameters.AddWithValue("@cbo3", textBox3.Text);
                cmd.Parameters.AddWithValue("@dtp1", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@cbo4", comboBox3.Text);
                cmd.Parameters.AddWithValue("@txt1", textBox1.Text);
                cmd.Parameters.Add(new SqlParameter("@pic", image));
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Record Taken For Student With Name '" + textBox2.Text + " " + textBox3.Text + "' Attendance Status = '" + comboBox3.Text + "' ", "Saved!", 0, MessageBoxIcon.Information);
                    this.grade2StudentAttendanceTableAdapter.Fill(this.dessySoftDataSet76.Grade2StudentAttendance);

                    clear();
                }
                else
                {
                    MessageBox.Show("Error Saving Record", "Error", 0, MessageBoxIcon.Error);

                }
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            update_R();
        }
        //update record
        public void update_R()
        {

            if (string.IsNullOrWhiteSpace(comboBox4.Text.ToString()))
            {
                MessageBox.Show("Select The Student Class.This Feild Cannot Be Empty  ", "Select Student Class", 0, MessageBoxIcon.Information);
                comboBox4.Focus();
                comboBox4.BackColor = Color.Red;
                comboBox4.ForeColor = Color.Yellow;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text.ToString()))
            {
                MessageBox.Show("Select The Student First Name.This Feild Cannot Be Empty  ", "Select Student Name!", 0, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text.ToString()))
            {
                MessageBox.Show("Input The Student LastName.This Feild Cannot Be Empty  ", "Select Student LastName", 0, MessageBoxIcon.Information);
              textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text.ToString()))
            {
                MessageBox.Show("Input Todays Date.This Feild Cannot Be Empty  ", "Select Today's Date", 0, MessageBoxIcon.Information);
                dateTimePicker1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox3.Text.ToString()))
            {
                MessageBox.Show("Select Attendance Status.This Feild Cannot Be Empty  ", "Select Attendance Status", 0, MessageBoxIcon.Information);
                comboBox4.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                MessageBox.Show("Input The Reason For Absence.This Feild Cannot Be Empty  ", "Input Reasons For Absence", 0, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            try
            {
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] pic = stream.ToArray();
                dessy.opencon();
                string Query = "UPDATE Grade2StudentAttendance SET stdClass = @cbo4 ,FName = @cbo1,Lname = @cbo2 ,Datex = @dtp1 ,attendanceStatus=@cbo3,Reason=@txt1,Signaturex= @pic  where id = @txt0";
                SqlCommand cmd = new SqlCommand(Query, dessy.returnCon());
                cmd.Parameters.AddWithValue("@cbo4", comboBox4.Text);
                cmd.Parameters.AddWithValue("@cbo1", textBox2.Text);
                cmd.Parameters.AddWithValue("@cbo2", textBox3.Text);
                cmd.Parameters.AddWithValue("@dtp1", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@cbo3", comboBox3.Text);
                cmd.Parameters.AddWithValue("@txt1", textBox1.Text);
                cmd.Parameters.AddWithValue("@txt0", textBox4.Text);

                cmd.Parameters.AddWithValue("@pic", pic);
                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Student With Name '" + textBox2.Text + "" + textBox3.Text + "' Is Updated Successfully.", "Updated", 0, MessageBoxIcon.Information);
                    this.grade2StudentAttendanceTableAdapter.Fill(this.dessySoftDataSet76.Grade2StudentAttendance);

                    clear();
                }
                else
                {
                    MessageBox.Show("Error in Updating Data.", "Error", 0, MessageBoxIcon.Error);

                }
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

        private void button3_Click(object sender, EventArgs e)
        {
            delete();
        }
        //delete record
        public void delete()
        {
            try
            {
                if (MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS RECORD ?? THIS OPERATION IS IRREVERSIBLE.", "DELETE RECORD ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    dessy.opencon();

                String Query = ("delete from Grade2SAttendance where id = '" + textBox4.Text + "'");
                SqlCommand cmd = new SqlCommand(Query, dessy.returnCon());
                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Student With Name '" + textBox2.Text + "' Is Deleted Successfully.", "Deleted", 0, MessageBoxIcon.Information);
                    this.grade2StudentAttendanceTableAdapter.Fill(this.dessySoftDataSet76.Grade2StudentAttendance);

                    clear();
                }
                else
                {
                    MessageBox.Show("Error in Deleting Data.", "Error", 0, MessageBoxIcon.Error);

                }
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

        private void button11_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog dialog = new OpenFileDialog();
            // image filters  
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                // display image in picture box  
                pictureBox1.ImageLocation = imglocation;
                // image file path  
                // textBox1.Text = open.FileName;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
            comboBox4.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = null;
            textBox1.Clear();
            pictureBox1.Image = null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible != true)
            {
                dataGridView1.Visible = true;
                button5.Text = "HIDE";
            }
            else if (dataGridView1.Visible == true)
            {
                dataGridView1.Visible = false;
                button5.Text = "VIEW";
            }
        }

        private void Grade2Attendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet76.Grade2StudentAttendance' table. You can move, or remove it, as needed.
            this.grade2StudentAttendanceTableAdapter.Fill(this.dessySoftDataSet76.Grade2StudentAttendance);
            dataGridView1.Visible = false;
            progressBar1.Visible = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //setting the timer
            this.timer1.Start();
            progressBar1.Visible = true;
            //label7.Visible = true;
        }
        public void Excel()
        {
            //loading datagrid contents to excel worksheets
            Thread.Sleep(1000);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            this.progressBar1.Increment(10);
            button6.Text = progressBar1.Value.ToString() + "%";
            button6.ForeColor = Color.Red;
            if (progressBar1.Value > 99)
            {
                //timer1.Tick.Tostring() = label7.Text;
                Excel();
                progressBar1.Visible = false;
                //  label7.Visible = false;
                button6.Text = "EXPORT";
                button6.ForeColor = Color.White;
                timer1.Enabled = false;

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                button2.Enabled = true;
                button3.Enabled = true;
                button1.Enabled = false;
                textBox4.Text = row.Cells[0].Value.ToString();
                comboBox4.Text = row.Cells[1].Value.ToString();
                textBox2.Text = row.Cells[2].Value.ToString();
                textBox3.Text = row.Cells[3].Value.ToString();
                dateTimePicker1.Text = row.Cells[4].Value.ToString();
                comboBox3.Text = row.Cells[5].Value.ToString();
                textBox1.Text = row.Cells[6].Value.ToString();
                Byte[] data = new Byte[0];
                data = (Byte[])row.Cells[7].Value;
                MemoryStream mem = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(mem);
            }
        }
    }
}