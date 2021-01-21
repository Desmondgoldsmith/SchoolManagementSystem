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
using System.IO;
using excel = Microsoft.Office.Interop.Excel;
using System.Threading;
namespace KingDessySchool.cs
{
    public partial class Grade2TAttendance : Form
    {
        public Grade2TAttendance()
        {
            InitializeComponent();
        }
        omagaconnections des = new omagaconnections();
        string imglocation;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(180, Color.Black);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save_Teacher();
        }
        public void Save_Teacher()
        {
            if (string.IsNullOrWhiteSpace(comboBox4.Text.ToString()))
            {
                MessageBox.Show("Select The Teacher's Class.This Feild Cannot Be Empty  ", "Select Teacher Class", 0, MessageBoxIcon.Information);
                comboBox4.Focus();
                comboBox4.BackColor = Color.Red;
                comboBox4.ForeColor = Color.Yellow;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
            {
                MessageBox.Show("Select The Teacher  Name.This Feild Cannot Be Empty  ", "Select Teacher's  Name!", 0, MessageBoxIcon.Information);
                comboBox1.Focus();
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
                des.opencon();
                string Query = "INSERT INTO Grade2Teacher_Attendance (TClass,Tname,TDate,AttStat,AbsentR,Sig)  Values(@cbo1,@cbo2,@dtp1,@cbo3,@txt1,@pic)";
                SqlCommand cmd = new SqlCommand(Query, des.returnCon());
                cmd.Parameters.AddWithValue("@cbo1", comboBox4.Text);
                cmd.Parameters.AddWithValue("@cbo2", comboBox1.Text);
                // cmd.Parameters.AddWithValue("@cbo3", comboBox2.Text);
                cmd.Parameters.AddWithValue("@dtp1", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@cbo3", comboBox3.Text);
                cmd.Parameters.AddWithValue("@txt1", textBox1.Text);
                cmd.Parameters.Add(new SqlParameter("@pic", image));
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Record Taken For Teacher With Name '" + comboBox1.Text + "' And  Attendance Status = '" + comboBox3.Text + "' ", "Saved!", 0, MessageBoxIcon.Information); this.grade2Teacher_AttendanceTableAdapter.Fill(this.dessySoftDataSet78.Grade2Teacher_Attendance);
                    this.grade2Teacher_AttendanceTableAdapter.Fill(this.dessySoftDataSet78.Grade2Teacher_Attendance);

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
                des.closeCon();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update_R();
        }
        public void update_R()
        {

            if (string.IsNullOrWhiteSpace(comboBox4.Text.ToString()))
            {
                MessageBox.Show("Select The Teacher Class.This Feild Cannot Be Empty  ", "Select Teacher Class", 0, MessageBoxIcon.Information);
                comboBox4.Focus();
                comboBox4.BackColor = Color.Red;
                comboBox4.ForeColor = Color.Yellow;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
            {
                MessageBox.Show("Select The Teacher First Name.This Feild Cannot Be Empty  ", "Select Teacher Name!", 0, MessageBoxIcon.Information);
                comboBox1.Focus();
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
            try
            {
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] pic = stream.ToArray();
                des.opencon();
                string Query = "UPDATE Grade2TAttendance SET TClass = @cbo4 ,Tname = @cbo1,TDate = @dtp1 ,AttStat=@cbo3,AbsentR=@txt1,Sig= @pic  where id = @txt0";
                SqlCommand cmd = new SqlCommand(Query, des.returnCon());
                cmd.Parameters.AddWithValue("@cbo4", comboBox4.Text);
                cmd.Parameters.AddWithValue("@cbo1", comboBox1.Text);
                // cmd.Parameters.AddWithValue("@cbo2", comboBox2.Text);
                cmd.Parameters.AddWithValue("@dtp1", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@cbo3", comboBox3.Text);
                cmd.Parameters.AddWithValue("@txt1", textBox1.Text);
                cmd.Parameters.AddWithValue("@txt0", textBox4.Text);

                cmd.Parameters.AddWithValue("@pic", pic);
                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Teacher With Name '" + comboBox1.Text + "' Is Updated Successfully.", "Updated", 0, MessageBoxIcon.Information);
                    this.grade2Teacher_AttendanceTableAdapter.Fill(this.dessySoftDataSet78.Grade2Teacher_Attendance);

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
                des.closeCon();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(comboBox4.Text.ToString()))
            {
                MessageBox.Show("Select The Teacher Class.This Feild Cannot Be Empty  ", "Select Teacher Class", 0, MessageBoxIcon.Information);
                comboBox4.Focus();
                comboBox4.BackColor = Color.Red;
                comboBox4.ForeColor = Color.Yellow;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
            {
                MessageBox.Show("Select The Teacher First Name.This Feild Cannot Be Empty  ", "Select Teacher Name!", 0, MessageBoxIcon.Information);
                comboBox1.Focus();
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

            try
            {
                if (MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS RECORD ?? THIS OPERATION IS IRREVERSIBLE.", "DELETE RECORD ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    des.opencon();
                SqlCommand cmd = new SqlCommand("DELETE FROM Grade2TAttendance WHERE id = '" + textBox4.Text + "'", des.returnCon());
                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Teacher With Name '" + comboBox1.Text + "' Is Deleted Successfully.", "Deleted", 0, MessageBoxIcon.Information);
                    this.grade2Teacher_AttendanceTableAdapter.Fill(this.dessySoftDataSet78.Grade2Teacher_Attendance);

                    clear();
                }
                else
                {
                    MessageBox.Show("Error in Deleting Data.", "Error", 0, MessageBoxIcon.Error);

                }
            }
            catch (Exception )
            {
                //   MessageBox.Show(ex.Message);
            }
            finally
            {
                des.closeCon();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            comboBox4.Text = "";
            comboBox1.Text = "";
            comboBox3.Text = "";
            //comboBox3.Text = "";
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

        private void Grade2TAttendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet78.Grade2Teacher_Attendance' table. You can move, or remove it, as needed.
            this.grade2Teacher_AttendanceTableAdapter.Fill(this.dessySoftDataSet78.Grade2Teacher_Attendance);
                    dataGridView1.Visible = false;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            //open dialog
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "ImageFiles(*.jpg; *.jpeg ; *.png ; *.gif *.bmp)|*.jpg; *.jpeg ; *.png ; *.gif *.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imglocation;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
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
            // Thread.Sleep(3000);
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
            progressBar1.Increment(1);
            button6.Text = progressBar1.Value.ToString() + "%";
            button6.ForeColor = Color.Red;
            dataGridView1.Visible = true;
            this.progressBar1.Increment(10);
            if (progressBar1.Value == 200)
            {
                //timer1.Tick.Tostring() = label7.Text;
              
                Excel();
                progressBar1.Visible = false;
                button6.Text = "EXPORT";
                button6.ForeColor = Color.White;
                timer1.Enabled = false;

            }
        }
    }
}