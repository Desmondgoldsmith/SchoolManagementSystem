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
    public partial class Grade2Fees : Form
    {
        public Grade2Fees()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        string imglocation;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(170, Color.Black);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //converting image to binay format
                byte[] image = null;
                FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                image = brs.ReadBytes((int)stream.Length);
                dessy.opencon();
                SqlCommand cmd = new SqlCommand("SaveG2Fees", dessy.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@sn", textBox1.Text);
                cmd.Parameters.AddWithValue("@sc", comboBox1.Text);
                cmd.Parameters.AddWithValue("@ap", textBox2.Text);
                cmd.Parameters.AddWithValue("@apw", textBox3.Text);
                cmd.Parameters.AddWithValue("@dp", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@b", textBox4.Text);
                cmd.Parameters.AddWithValue("@h", textBox5.Text);
                cmd.Parameters.AddWithValue("@s", comboBox2.Text);
                cmd.Parameters.AddWithValue("@bei", comboBox3.Text);
                cmd.Parameters.AddWithValue("@pm", comboBox4.Text);
                cmd.Parameters.Add(new SqlParameter("@i", image));
                if (cmd.ExecuteNonQuery() == 1)
                {

                    //Clear();
                    MessageBox.Show("Please Wait Patiently For The Receipts", "Saved", 0, MessageBoxIcon.Information);
                    //this.regUsersTableAdapter.Fill(this.dessySoftDataSet29.RegUsers);
                    var receipt = new Grade2Receipt();
                    receipt.Show();
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
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void Grade2Fees_Load(object sender, EventArgs e)
        {

        }
    }
}
