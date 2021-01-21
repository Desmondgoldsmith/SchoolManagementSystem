using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Threading;
using excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace KingDessySchool.cs
{
    public partial class TAttendanceC1 : Form
    {
        public TAttendanceC1()
        {
            InitializeComponent();
        }
        omagaconnections des = new omagaconnections();
        string imgLocation;
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
                FileStream stream = new FileStream(imgLocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
                des.opencon();
                string Query = "INSERT INTO Teacher_Attendance (stdClass,FName,Datex,attendanceStatus,Reason,Signaturex)  Values(@cbo1,@cbo2,@dtp1,@cbo3,@txt1,@pic)";
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
                    MessageBox.Show("Record Taken For Teacher With Name '" + comboBox1.Text + "' And  Attendance Status = '" + comboBox3.Text + "' ", "Saved!", 0, MessageBoxIcon.Information);
                    this.teacher_AttendanceTableAdapter.Fill(this.dessySoftDataSet70.Teacher_Attendance);
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
                string Query = "UPDATE Teacher_Attendance SET stdClass = @cbo4 ,FName = @cbo1,Datex = @dtp1 ,attendanceStatus=@cbo3,Reason=@txt1,Signaturex= @pic  where id = @txt0";
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

                    clear();
                    MessageBox.Show("Teacher With Name '" + comboBox1.Text + "' Is Updated Successfully.", "Updated", 0, MessageBoxIcon.Information);
                    this.teacher_AttendanceTableAdapter.Fill(this.dessySoftDataSet70.Teacher_Attendance);

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

        private void button11_Click(object sender, EventArgs e)
        {
            //open dialog
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "ImageFiles(*.jpg; *.jpeg ; *.png ; *.gif *.bmp)|*.jpg; *.jpeg ; *.png ; *.gif *.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imgLocation = dialog.FileName.ToString();
                pictureBox1.ImageLocation = imgLocation;
            }

        }

        private void button12_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void TAttendanceC1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet70.Teacher_Attendance' table. You can move, or remove it, as needed.
            this.teacher_AttendanceTableAdapter.Fill(this.dessySoftDataSet70.Teacher_Attendance);
            dataGridView1.Visible = false;
            progressBar1.Visible = false;
            textBox4.Visible = false;
            label3.Visible = false;
            button2.Enabled = false;
            button3.Enabled = false;


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
                comboBox1.Text = row.Cells[2].Value.ToString();
                dateTimePicker1.Text = row.Cells[3].Value.ToString();
                comboBox3.Text = row.Cells[4].Value.ToString();
                textBox1.Text = row.Cells[5].Value.ToString();
                Byte[] data = new Byte[0];
                data = (Byte[])row.Cells[6].Value;
                MemoryStream ms = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(ms);
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
                SqlCommand cmd = new SqlCommand("DELETE FROM Teacher_Attendance WHERE id = '" + textBox4.Text + "'", des.returnCon());
                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Teacher With Name '" + comboBox1.Text + "' Is Deleted Successfully.", "Deleted", 0, MessageBoxIcon.Information);
                    this.teacher_AttendanceTableAdapter.Fill(this.dessySoftDataSet70.Teacher_Attendance);

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
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
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

        private void button6_Click(object sender, EventArgs e)
        {
            //setting the timer
            this.timer1.Start();
            progressBar1.Visible = true;
            label3.Visible = true;
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

