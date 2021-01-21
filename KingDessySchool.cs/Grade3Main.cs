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
namespace KingDessySchool.cs
{
    public partial class Grade3Main : Form
    {
        public Grade3Main()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(170, Color.Black);
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //validate before deleting and delete record if all controls are !empty
            if (String.IsNullOrWhiteSpace(textBox1.Text.Trim()))
            {
                MessageBox.Show("Enter Student FirstName", "Enter Name", 0, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox2.Text.Trim()))
            {
                MessageBox.Show("Enter Student LastName", "Enter Name", 0, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select The Student Class", "Select Class", 0, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox3.Text.Trim()))
            {
                MessageBox.Show("Enter Student Age", "Enter age", 0, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox4.Text.Trim()))
            {

                MessageBox.Show("Enter Teacher's Name", "Teacher's Name", 0, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            //if(pictureBox1.Image == null)
            //{
            //    MessageBox.Show("UPLOAD STUDENT IMAGE", "**STUDENT IMAGE", 0, MessageBoxIcon.Information);
            //    pictureBox1.Focus();
            //    return;
            //}
            try
            {
                if (MessageBox.Show("THIS ACTION CAN NEVER BE REVERSED. ARE YOU SURE YOU WANT TO DELETE?", "DELETE RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    dessy.opencon();
                SqlCommand cmd = new SqlCommand("DELETE from Gade3 where id = '" + textBox6.Text + "'", dessy.returnCon());
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Student With Firstname '" + textBox1.Text + "' Is Deleted Successfully", "Deleted Successfully", 0, MessageBoxIcon.Information);
                    this.grade3TableAdapter.Fill(this.dessySoftDataSet89.Grade3);

                    //                    clear();
                }
                else
                {
                    MessageBox.Show("Error Deleting Record With Firstname '" + textBox1.Text + "'", "Error!!!", 0, MessageBoxIcon.Error);

                }




            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);

            }
            finally
            {
                dessy.closeCon();
            }

        }
    
        

        private void Grade3Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet89.Grade3' table. You can move, or remove it, as needed.
            this.grade3TableAdapter.Fill(this.dessySoftDataSet89.Grade3);
            textBox6.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            validate();
        }
        //insert
        public void validate()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text.Trim()))
            {
                MessageBox.Show("Enter Student FirstName", "Enter Name", 0, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox2.Text.Trim()))
            {
                MessageBox.Show("Enter Student LastName", "Enter Name", 0, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select The Student Class", "Select Class", 0, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox3.Text.Trim()))
            {
                MessageBox.Show("Enter Student Age", "Enter age", 0, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox4.Text.Trim()))
            {

                MessageBox.Show("Enter Teacher's Name", "Teacher's Name", 0, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            //if (pictureBox1.Image == null)
            //{
            //    MessageBox.Show("UPLOAD STUDENT IMAGE", "**STUDENT IMAGE", 0, MessageBoxIcon.Information);
            //    pictureBox1.Focus();
            //    return;
            // }
            else
            {
                try
                {
                    //byte[] images = null;
                    //FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                    //BinaryReader brs = new BinaryReader(stream);
                    //images = brs.ReadBytes((int)stream.Length);
                    dessy.opencon();
                    SqlCommand cmd = new SqlCommand("InsertGrade3", dessy.returnCon()) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@fn", textBox1.Text);
                    cmd.Parameters.AddWithValue("@ln", textBox2.Text);
                    cmd.Parameters.AddWithValue("@c", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@a", textBox3.Text);
                    cmd.Parameters.AddWithValue("@t", textBox4.Text);
                    //cmd.Parameters.Add(new SqlParameter("@i", images));

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Data Saved Successfully", "Saved", 0, MessageBoxIcon.Information);
                        this.grade3TableAdapter.Fill(this.dessySoftDataSet89.Grade3);

                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Error", "Error!!!", 0, MessageBoxIcon.Error);

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Updatevalidate();
        }

        public void Updatevalidate()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text.Trim()))
            {
                MessageBox.Show("Enter Student FirstName", "Enter Name", 0, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox2.Text.Trim()))
            {
                MessageBox.Show("Enter Student LastName", "Enter Name", 0, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Select The Student Class", "Select Class", 0, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox3.Text.Trim()))
            {
                MessageBox.Show("Enter Student Age", "Enter age", 0, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox4.Text.Trim()))
            {

                MessageBox.Show("Enter Teacher's Name", "Teacher's Name", 0, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            //if (pictureBox1.Image == null)
            //{
            //    MessageBox.Show("UPLOAD STUDENT IMAGE", "**STUDENT IMAGE", 0, MessageBoxIcon.Information);
            //    pictureBox1.Focus();
            //    return;
            //}
            else
            {
                try
                {
                    //MemoryStream stream = new MemoryStream();
                    //pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //Byte[] pic = stream.ToArray();
                    dessy.opencon();
                    SqlCommand cmd = new SqlCommand("UpdateGrade3", dessy.returnCon()) { CommandType = CommandType.StoredProcedure };
                    cmd.Parameters.AddWithValue("@id", textBox6.Text);
                    cmd.Parameters.AddWithValue("@fn", textBox1.Text);
                    cmd.Parameters.AddWithValue("@ln", textBox2.Text);
                    cmd.Parameters.AddWithValue("@c", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@a", textBox3.Text);
                    cmd.Parameters.AddWithValue("@t", textBox4.Text);
                    // cmd.Parameters.AddWithValue("@i", pic);

                    if (cmd.ExecuteNonQuery() == 1)
                    {

                        MessageBox.Show("Student With Firstname '" + textBox1.Text + "' Is Updated Successfully", "Updated Successfully", 0, MessageBoxIcon.Information);
                        this.grade3TableAdapter.Fill(this.dessySoftDataSet89.Grade3);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Error Updating Record With Firstname '" + textBox1.Text + "'", "Error!!!", 0, MessageBoxIcon.Error);

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
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            button1.Enabled = true;
            button2.Enabled = false;
            button3.Enabled = false;
            textBox1.Clear();
            textBox3.Clear();
            textBox2.Clear();
            textBox4.Clear();
            comboBox1.Text = null;
            //pictureBox1.Image = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow click = dataGridView1.Rows[e.RowIndex];
                button2.Enabled = true;
                button3.Enabled = true;
                button1.Enabled = false;
                textBox6.Text = click.Cells[0].Value.ToString();
                textBox1.Text = click.Cells[1].Value.ToString();
                textBox2.Text = click.Cells[2].Value.ToString();
                comboBox1.Text = click.Cells[3].Value.ToString();
                textBox3.Text = click.Cells[4].Value.ToString();
                textBox4.Text = click.Cells[5].Value.ToString();
                //    Byte[] data = new Byte[0];
                //    data = (Byte[])click.Cells[6].Value;
                //    MemoryStream mem = new MemoryStream(data);
                //    pictureBox1.Image = Image.FromStream(mem);
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = textBox5.Text;
                SqlCommand cmd = new SqlCommand("select * from Grade3  where CONCAT(FirstName,LastName) like '%" + textBox5.Text + "%' ", dessy.returnCon());
                //view records in datagrid
                SqlDataAdapter sda = new SqlDataAdapter("select * from Grade3  where CONCAT(FirstName,LastName) like '%" + textBox5.Text + "%'", dessy.returnCon());
                button2.Enabled = true;
                button3.Enabled = true;
                button1.Enabled = false;
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
                    textBox6.Text = rd.GetValue(0).ToString();
                    textBox1.Text = rd.GetValue(1).ToString();
                    textBox2.Text = rd.GetValue(2).ToString();
                    comboBox1.Text = rd.GetValue(3).ToString();
                    textBox3.Text = rd.GetValue(4).ToString();
                    textBox4.Text = rd.GetValue(5).ToString();
                    //Byte[] data = new Byte[0];
                    //data = (Byte[])rd.GetValue(6);
                    //MemoryStream mem = new MemoryStream(data);
                    //pictureBox1.Image = Image.FromStream(mem);
                    if (string.IsNullOrWhiteSpace(textBox5.Text.ToString()))
                    {
                        clear();
                    }
                }
                else
                {
                    rd.Close();
                    MessageBox.Show("NO RECORD AVAILABLE ", " RECORD DOES NOT EXIST", 0, MessageBoxIcon.Error);
                    textBox5.Clear();
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
    }
}
