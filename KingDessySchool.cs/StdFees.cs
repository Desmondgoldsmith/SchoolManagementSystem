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
namespace KingDessySchool.cs
{
    public partial class StdFees : Form
    {
        public StdFees()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        string imglocation;

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(150, Color.Black);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                MessageBox.Show("Input Student First Name", "Error!", 0, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text.ToString()))
            {
                MessageBox.Show("Input Student First Last", "Error!", 0, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text.ToString()))
            {
                MessageBox.Show("Input Student Total Fees", "Error!", 0, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text.ToString()))
            {
                MessageBox.Show("Input The Amount Paid", "Error!", 0, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text.ToString()))
            {
                MessageBox.Show("Input Today's Date ", "Error!", 0, MessageBoxIcon.Information);
                dateTimePicker1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
            {
                MessageBox.Show("Select Student Class", "Error!", 0, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text.ToString()))
            {
                MessageBox.Show("Input Student Debt", "Error!", 0, MessageBoxIcon.Information);
                textBox5.Focus();
                return;
            }
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Upload Student Photograph", "Error!", 0, MessageBoxIcon.Information);
                pictureBox1.Focus();
                return;
            }
           
            //    dessy.opencon();
            //    string count = "select * from SG1Fees where Firstname = '" + textBox1 + "' and Lastname ='" + textBox2.Text + "'";
            //    SqlCommand command = new SqlCommand(count, dessy.returnCon());
            //    SqlDataReader dr = command.ExecuteReader();
            //    //if (dr.HasRows == true)
            //    //{
            //    while (dr.Read()) { 
            //       string fname = dr.GetValue(1).ToString();
            //       string lname = dr.GetValue(2).ToString();
            //        if(textBox1.Text == fname && textBox2.Text == lname) { 
            //        MessageBox.Show("Student With Name '" + textBox1.Text + "' '" + textBox2.Text + "' Already Exist", "STUDENT EXIST", 0, MessageBoxIcon.Information);
            //        return;
            //        }

            //    //}
            //}

            try
            {
                //  dessy.closeCon();
            //    dr.Close();
                dessy.opencon();
                byte[] images = null;
                FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                images = brs.ReadBytes((int)stream.Length);

                SqlCommand cmd = new SqlCommand("g1Fees", dessy.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@fn", textBox1.Text);
                cmd.Parameters.AddWithValue("@ln", textBox2.Text);
                cmd.Parameters.AddWithValue("@tf", textBox3.Text);
                cmd.Parameters.AddWithValue("@ap", textBox4.Text);
                cmd.Parameters.AddWithValue("@dp", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@c", comboBox1.Text);
                cmd.Parameters.AddWithValue("@d", textBox5.Text);
                cmd.Parameters.Add(new SqlParameter("@p", images));

               
                if (cmd.ExecuteNonQuery() == 1)
                    {
                    //dr.Close();
                    MessageBox.Show("Student Fees Data Saved For '" + textBox1.Text + "'", " Saved Successfully", 0, MessageBoxIcon.Information);
                        this.sG1FeesTableAdapter.Fill(this.dessySoftDataSet39.SG1Fees);

                        //clear();
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                MessageBox.Show("Input Student First Name", "Error!", 0, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text.ToString()))
            {
                MessageBox.Show("Input Student First Last", "Error!", 0, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text.ToString()))
            {
                MessageBox.Show("Input Student Total Fees", "Error!", 0, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text.ToString()))
            {
                MessageBox.Show("Input The Amount Paid", "Error!", 0, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text.ToString()))
            {
                MessageBox.Show("Input Today's Date ", "Error!", 0, MessageBoxIcon.Information);
                dateTimePicker1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
            {
                MessageBox.Show("Select Student Class", "Error!", 0, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text.ToString()))
            {
                MessageBox.Show("Input Student Debt", "Error!", 0, MessageBoxIcon.Information);
                textBox5.Focus();
                return;
            }
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Upload Student Photograph", "Error!", 0, MessageBoxIcon.Information);
                pictureBox1.Focus();
                return;
            }



            try
            {
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] pic = stream.ToArray();
                dessy.opencon();
                SqlCommand cmd = new SqlCommand("Updateg1Fees", dessy.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", textBox6.Text);
                cmd.Parameters.AddWithValue("@fn", textBox1.Text);
                cmd.Parameters.AddWithValue("@ln", textBox2.Text);
                cmd.Parameters.AddWithValue("@tf", textBox3.Text);
                cmd.Parameters.AddWithValue("@ap", textBox4.Text);
                cmd.Parameters.AddWithValue("@dp", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@c", comboBox1.Text);
                cmd.Parameters.AddWithValue("@d", textBox5.Text);
                cmd.Parameters.AddWithValue("@p", pic);

                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Student Fees Record For '" + textBox1.Text + "' ", "Updated Successfully ", 0, MessageBoxIcon.Information);

                    this.sG1FeesTableAdapter.Fill(this.dessySoftDataSet39.SG1Fees);

                    // clear();
                }
                else
                {
                    MessageBox.Show("Error Updating Student Fees Record For  '" + textBox1.Text + "'", "Error!!!", 0, MessageBoxIcon.Error);

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

        private void panel4_Click(object sender, EventArgs e)
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
            //bukgiuhn
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                MessageBox.Show("Input Student First Name", "Error!", 0, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text.ToString()))
            {
                MessageBox.Show("Input Student First Last", "Error!", 0, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text.ToString()))
            {
                MessageBox.Show("Input Student Total Fees", "Error!", 0, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text.ToString()))
            {
                MessageBox.Show("Input The Amount Paid", "Error!", 0, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text.ToString()))
            {
                MessageBox.Show("Input Today's Date ", "Error!", 0, MessageBoxIcon.Information);
                dateTimePicker1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
            {
                MessageBox.Show("Select Student Class", "Error!", 0, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text.ToString()))
            {
                MessageBox.Show("Input Student Debt", "Error!", 0, MessageBoxIcon.Information);
                textBox5.Focus();
                return;
            }
            if (pictureBox1.Image == null)
            {
                MessageBox.Show("Upload Student Photograph", "Error!", 0, MessageBoxIcon.Information);
                pictureBox1.Focus();
                return;
            }


            try
            {
                if (MessageBox.Show("THIS ACTION CAN NEVER BE REVERSED. ARE YOU SURE YOU WANT TO DELETE?", "DELETE RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    dessy.opencon();
                SqlCommand cmd = new SqlCommand("DELETE from SG1Fees where id = '" + textBox6.Text + "'", dessy.returnCon());
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Student Fees Data For  '" + textBox1.Text + "'  Deleted Successfully", "Deleted Successfully", 0, MessageBoxIcon.Information);
                    this.sG1FeesTableAdapter.Fill(this.dessySoftDataSet39.SG1Fees);

                    //clear();
                }
                else
                {
                    MessageBox.Show("Error Deleting Fees Record With Firstname '" + textBox1.Text + "'", "Error!!!", 0, MessageBoxIcon.Error);

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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(40, Color.White);

        }

        private void StdFees_Load(object sender, EventArgs e)
        {// TODO: This line of code loads data into the 'dessySoftDataSet38.NewGrade1' table. You can move, or remove it, as needed.
            this.newGrade1TableAdapter.Fill(this.dessySoftDataSet38.NewGrade1);

            // TODO: This line of code loads data into the 'dessySoftDataSet39.SG1Fees' table. You can move, or remove it, as needed.
            this.sG1FeesTableAdapter.Fill(this.dessySoftDataSet39.SG1Fees);

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.RowIndex <= 1)
            //{
            //    DataGridViewRow click = dataGridView1.Rows[e.RowIndex];
            //    textBox6.Text = click.Cells[0].Value.ToString();
            //    textBox1.Text = click.Cells[1].Value.ToString();
            //    textBox2.Text = click.Cells[2].Value.ToString();
            //    textBox3.Text = click.Cells[3].Value.ToString();
            //    textBox4.Text = click.Cells[4].Value.ToString();
            //   //dateTimePicker1.Text = click.Cells[5].Value.ToString();
            //    comboBox1.Text = click.Cells[6].Value.ToString();
            //    //textBox5.Text = click.Cells[7].Value.ToString();
            //       Byte[] data = new Byte[0];
            //        data = (Byte[])click.Cells[6].Value;
            //        MemoryStream mem = new MemoryStream(data);
            //        pictureBox1.Image = Image.FromStream(mem);

            //}
        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            try
            {

                string search = textBox7.Text;
                SqlCommand cmd = new SqlCommand("select * from SG1Fees  where CONCAT(id,Firstname,Lastname) like '%" + textBox7.Text + "%' ", dessy.returnCon());

                dessy.opencon();
                SqlDataReader rd;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    textBox6.Text = rd.GetValue(0).ToString();
                    textBox1.Text = rd.GetValue(1).ToString();
                    textBox2.Text = rd.GetValue(2).ToString();
                    textBox3.Text = rd.GetValue(3).ToString();
                    textBox4.Text = rd.GetValue(4).ToString();
                    dateTimePicker1.Text = rd.GetValue(5).ToString();
                    comboBox1.Text = rd.GetValue(6).ToString();
                    textBox5.Text = rd.GetValue(7).ToString();


                    Byte[] data = new Byte[0];
                    data = (Byte[])rd.GetValue(8);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(mem);

                    if (string.IsNullOrWhiteSpace(textBox7.Text.ToString()))
                    {
                        clear();
                    }
                    rd.Close();
                }
                else
                {
                    rd.Close();
                    MessageBox.Show("NO RECORD AVAILABLE WITH NAME '" + textBox7.Text + "'", " RECORD DOES NOT EXIST", 0, MessageBoxIcon.Error);
                    textBox7.Clear();

                    clear();
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

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.Text = null;
            comboBox1.Text = "";
            textBox5.Clear();
            textBox6.Clear();
            pictureBox1.Image = null;
        }
    }
}
