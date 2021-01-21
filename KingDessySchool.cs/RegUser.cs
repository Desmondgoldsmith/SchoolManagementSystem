using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using excel = Microsoft.Office.Interop.Excel;
namespace KingDessySchool.cs
{
    public partial class RegUser : Form
    {
        public RegUser()
        {
            InitializeComponent();
        }
        omagaconnections des = new omagaconnections();
        string imglocation;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(190, Color.Black);
        }

        private void RegUser_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet60.RegUsers' table. You can move, or remove it, as needed.
            this.regUsersTableAdapter.Fill(this.dessySoftDataSet60.RegUsers);
            textBox4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                MessageBox.Show("Input The User Name", "ERROR", 0, MessageBoxIcon.Asterisk);
                textBox1.Focus();
                return;

            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
            {
                MessageBox.Show("Select The User Role", "ERROR", 0, MessageBoxIcon.Asterisk);
                comboBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text.ToString()))
            {
                MessageBox.Show("Input The Password", "ERROR", 0, MessageBoxIcon.Asterisk);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text.ToString()))
            {
                MessageBox.Show("Input Your Password Hint", "ERROR", 0, MessageBoxIcon.Asterisk);
                textBox5.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text.ToString()))
            {
                MessageBox.Show("Re-Enter Password", "ERROR", 0, MessageBoxIcon.Asterisk);
                textBox2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text.ToString()))
            {
                MessageBox.Show("select the date", "ERROR", 0, MessageBoxIcon.Asterisk);
                dateTimePicker1.Focus();
                return;
            }
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Upload Your Picture", "ERROR", 0, MessageBoxIcon.Asterisk);
                pictureBox1.Focus();
                return;
            }
            if (textBox3.Text != textBox2.Text)
            {
                MessageBox.Show("Passwords Do Not Match", "ERROR", 0, MessageBoxIcon.Asterisk);
                textBox2.Focus();
                return;
            }
            try
            {
                //setting guarrantor to headnaster only
                des.opencon();
                string sql = "SELECT * FROM RegUsers WHERE GGuaPass = '" + textBox6.Text + "' and UserRole = 'HeadMaster' and Username = Username";
                SqlCommand scmd = new SqlCommand(sql, des.returnCon());
                SqlDataReader dr1 = scmd.ExecuteReader();
                if (dr1.HasRows == true)
                {

                    while (dr1.Read())
                    {
                        string role = dr1.GetValue(2).ToString();
                        if (role == "HeadMaster" && textBox5.Text == dr1.GetValue(1).ToString() && textBox2.Text == dr1.GetValue(3).ToString())
                        {
                            MessageBox.Show("Correct");
                        }
                    }
                }

                else
                {
                    MessageBox.Show("THE HEADMASTER IS THE ONLY GUARRANTOR!! CONTACT HIM TO INPUT HIS NAME AND PASSWORD FOR YOU TO BE ADDED TO THE SYSTEM", "FAILED TO ADD USER", 0, MessageBoxIcon.Information);
                    return;
                }
                des.closeCon();


                //converting image to binay format
                byte[] image = null;
                FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
                des.opencon();
                SqlCommand cmd = new SqlCommand("insertRegUsers1", des.returnCon()) { CommandType = CommandType.StoredProcedure};
                cmd.Parameters.AddWithValue("@u", textBox1.Text);
                cmd.Parameters.AddWithValue("@Ur", comboBox1.Text);
                cmd.Parameters.AddWithValue("@p", textBox3.Text);
                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@g", textBox5.Text);
                cmd.Parameters.AddWithValue("@gp", textBox6.Text);
                cmd.Parameters.Add(new SqlParameter("@pi", image));
               if (cmd.ExecuteNonQuery() == 1)
                {

                    Clear();
                    MessageBox.Show("User Saved Successfully.", "Saved", 0, MessageBoxIcon.Information);
                    this.regUsersTableAdapter.Fill(this.dessySoftDataSet60.RegUsers);

                }
                else
                {
                    MessageBox.Show("Error in Saving Data.", "Error", 0, MessageBoxIcon.Error);

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

        private void button1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void button4_Click(object sender, EventArgs e)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
                {
                    MessageBox.Show("Input The User Name", "ERROR", 0, MessageBoxIcon.Asterisk);
                    textBox1.Focus();
                    return;

                }
                if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
                {
                    MessageBox.Show("Select The User Role", "ERROR", 0, MessageBoxIcon.Asterisk);
                    comboBox1.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox3.Text.ToString()))
                {
                    MessageBox.Show("Input The Password", "ERROR", 0, MessageBoxIcon.Asterisk);
                    textBox3.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox5.Text.ToString()))
                {
                    MessageBox.Show("Input Your Password Hint", "ERROR", 0, MessageBoxIcon.Asterisk);
                    textBox5.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(textBox2.Text.ToString()))
                {
                    MessageBox.Show("Re-Enter Password", "ERROR", 0, MessageBoxIcon.Asterisk);
                    textBox2.Focus();
                    return;
                }
                if (string.IsNullOrWhiteSpace(dateTimePicker1.Text.ToString()))
                {
                    MessageBox.Show("select the date", "ERROR", 0, MessageBoxIcon.Asterisk);
                    dateTimePicker1.Focus();
                    return;
                }
                if (pictureBox1.Image == null)
                {
                    MessageBox.Show("Upload Your Pictuse", "ERROR", 0, MessageBoxIcon.Asterisk);
                    pictureBox1.Focus();
                    return;
                }
                if (textBox3.Text != textBox2.Text)
                {
                    MessageBox.Show("Passwords Do Not Match", "ERROR", 0, MessageBoxIcon.Asterisk);
                    textBox2.Focus();
                    return;
                }
                des.opencon();
                SqlCommand cmd = new SqlCommand("NewUpdateRegx", des.returnCon()) { CommandType = CommandType.StoredProcedure };
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] pic = stream.ToArray();
                cmd.Parameters.AddWithValue("@id", textBox4.Text);
                cmd.Parameters.AddWithValue("@uname", textBox1.Text);
                cmd.Parameters.AddWithValue("@R", comboBox1.Text);
                cmd.Parameters.AddWithValue("@p", textBox3.Text);
                cmd.Parameters.AddWithValue("@g", textBox5.Text);
                cmd.Parameters.AddWithValue("@gp", textBox6.Text);

                cmd.Parameters.AddWithValue("@d", dateTimePicker1.Text);
                cmd.Parameters.Add(new SqlParameter("@i", pic));
                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("User  Updated Successfully.", "Updated", 0, MessageBoxIcon.Information);
                    this.regUsersTableAdapter.Fill(this.dessySoftDataSet60.RegUsers);
                    Clear();
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=1)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox4.Text = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
                comboBox1.Text = row.Cells[2].Value.ToString();
                //                textBox3.Text = row.Cells[3].Value.ToString() ;
                dateTimePicker1.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                //textBox5.Text = row.Cells[5].Value.ToString();
                Byte[] image = new Byte[0];
                image = (Byte[])row.Cells[5].Value;
                MemoryStream mem = new MemoryStream(image);
                pictureBox1.Image = Image.FromStream(mem);


            }
        }

        public void Clear()
        {
            textBox1.Clear();
            comboBox1.Text = null;
            textBox3.Clear();
            textBox4.Clear();
            textBox2.Clear();
            dateTimePicker1.Text = null;
            pictureBox1.Image = null;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("THIS ACTION CAN NEVER BE REVERSED. ARE YOU SURE YOU WANT TO DELETE?", "DELETE RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    des.opencon();
                SqlCommand cmd = new SqlCommand("NewDeleteReg", des.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", textBox4.Text);
                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("User With Name '" + textBox1.Text + "' Is Deleted Successfully.", "Deleted", 0, MessageBoxIcon.Information);
                    this.regUsersTableAdapter.Fill(this.dessySoftDataSet60.RegUsers);
                    Clear();
                }
                else
                {
                    MessageBox.Show("Error in Deleting Data.", "Error", 0, MessageBoxIcon.Error);

                }
            }
            catch (Exception )
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                des.closeCon();
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox4.Text = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
                comboBox1.Text = row.Cells[2].Value.ToString();
                //                textBox3.Text = row.Cells[3].Value.ToString() ;
                dateTimePicker1.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                //textBox5.Text = row.Cells[5].Value.ToString();
                Byte[] image = new Byte[0];
                image = (Byte[])row.Cells[5].Value;
                MemoryStream mem = new MemoryStream(image);
                pictureBox1.Image = Image.FromStream(mem);


            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Excel();
        }
        public void Excel()
        {
            //loading datagrid contents to excel worksheets
            Thread.Sleep(3000);
            excel.Application app = new excel.Application();
            excel.Workbook workbook = app.Workbooks.Add();
            excel.Worksheet Worksheetx = new excel.Worksheet();
            Worksheetx = null;
            app.Visible = true;
            Worksheetx = workbook.Sheets["sheet1"];
            Worksheetx = workbook.ActiveSheet;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Worksheetx.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }

            for (int j = 0; j <= dataGridView1.Rows.Count - 1; j++)
            {

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {

                    //excel.Worksheet Worksheetx = new excel.Worksheet();
                    Worksheetx.Cells[j + 2, i + 1] = this.dataGridView1.Rows[j].Cells[i].Value.ToString();
                }
            }
            Worksheetx.Columns.AutoFit();
            //Worksheet.Columns.Text.Bold();

        }
    }
    }

    

