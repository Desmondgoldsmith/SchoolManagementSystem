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

namespace DessySchoolComplesApp.cs
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        KingDessySchool.cs.omagaconnections des = new KingDessySchool.cs.omagaconnections();
        string role = "";
        string query = "";
        SqlDataReader dr;
        SqlCommand cmd;
        
       

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.BackColor = Color.FromArgb(120, Color.Black);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginx();
        }

        public void loginx()
        {
            if (String.IsNullOrWhiteSpace(textBox1.Text.Trim()))
            {
                MessageBox.Show("Specify Your Username To Login !", "Enter Your UserName", 0, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (String.IsNullOrWhiteSpace(textBox2.Text.Trim()))
            {
                MessageBox.Show("Specify Your Password To Login !", "Enter Your Password", 0, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(185, Color.Black);
        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(155, Color.Black);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are You Sure You Want To Exit This App ?", "Close Application", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Application.Exit();
            }
            else
            {
                this.Show();
            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            vallogin();

        }

        public void vallogin()
        {

            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {

                MessageBox.Show("Please Input Your UserName", "UserName Required", 0, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text.ToString()))
            {

                MessageBox.Show("Please Input Your Password", "Password Required", 0, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            else
            {
                //       
             //Class2 Teacher
             //Class3 Teacher
             //Class4 Teacher
             //Class5 Teacher
             //Class6 Teacher
             //Form1 Teacher
             //Form2 Teacher
             //Form3 Teacher
             //
                try
                {
                    des.opencon();
                    query = "SELECT * FROM RegUsers WHERE Username = '" + textBox1.Text + "'and  Passwordx ='" + textBox2.Text + "'";
                    cmd = new SqlCommand(query, des.returnCon());
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows == true)
                    {

                        while (dr.Read())
                        {
                            role = dr.GetValue(2).ToString();
                            string Date = dr.GetValue(4).ToString();                
                            if (role == "HeadMaster" && textBox1.Text == dr.GetValue(1).ToString() && textBox2.Text == dr.GetValue(3).ToString())
                            {
                                MessageBox.Show(" '" + textBox1.Text + "' Logged In Successfully As HeadMaster", "Login Successful", 0, MessageBoxIcon.Information);
                                var main = new DessySchoolComplesApp.cs.MainWindow();
                                main.Show();
                                main.label2.Text = textBox1.Text;
                                main.textBox1.Text = textBox1.Text;
                                main.textBox2.Text = textBox2.Text;
                                main.textBox3.Text = role;
                                main.textBox4.Text = Date;
                               // main.ShowInTaskbar = false;
                                main.FormBorderStyle = FormBorderStyle.FixedToolWindow;

                                // main.textBox4.Text = pasHint;
                                Byte[] data = new Byte[0];
                                data = (Byte[])dr.GetValue(7);
                                MemoryStream mem = new MemoryStream(data);
                                main.pictureBox13.Image = Image.FromStream(mem);

                                this.Hide();
                            }
                            else if (role == "Secretary" && textBox1.Text == dr.GetValue(1).ToString() && textBox2.Text == dr.GetValue(3).ToString())
                            {
                                MessageBox.Show(" '" + textBox1.Text + "' Logged In Successfully As Secretary", "Login Successful", 0, MessageBoxIcon.Information);
                                var main = new DessySchoolComplesApp.cs.MainWindow();
                                main.Show();
                                main.label2.Text = textBox1.Text;
                                main.textBox1.Text = textBox1.Text;
                                main.textBox2.Text = textBox2.Text;
                                main.textBox3.Text = role;
                                main.textBox4.Text = Date;
                                Byte[] data = new Byte[0];
                                data = (Byte[])dr.GetValue(7);
                                MemoryStream mem = new MemoryStream(data);
                                main.pictureBox13.Image = Image.FromStream(mem);
                                this.Hide();
                            }
                            else if (role == "Class1 Teacher" && textBox1.Text == dr.GetValue(1).ToString() && textBox2.Text == dr.GetValue(3).ToString())
                            {
                                MessageBox.Show(" '" + textBox1.Text + "' Logged In Successfully As Class1 Teacher", "Login Successful", 0, MessageBoxIcon.Information);
                                var main = new MainWindow();
                                main.button1.Enabled = false;
                                main.button3.Enabled = false;
                               // main.button4.Enabled = false;
                                main.button6.Enabled = false;
                                main.button9.Enabled = false;
                                Byte[] data = new Byte[0];
                                data = (Byte[])dr.GetValue(7);
                                MemoryStream mem = new MemoryStream(data);
                                main.pictureBox13.Image = Image.FromStream(mem);
                                main.Show();
                                main.label2.Text = textBox1.Text;
                                main.textBox1.Text = textBox1.Text;
                                main.textBox2.Text = textBox2.Text;
                                main.textBox3.Text = role;
                                main.textBox4.Text = Date;

                                this.Hide();
                            }
                            else if (role == "Class2 Teacher" && textBox1.Text == dr.GetValue(1).ToString() && textBox2.Text == dr.GetValue(3).ToString())
                            {
                                MessageBox.Show(" '" + textBox1.Text + "' Logged In Successfully As Class2 Teacher", "Login Successful", 0, MessageBoxIcon.Information);
                                var main = new DessySchoolComplesApp.cs.MainWindow();
                                main.button1.Enabled = false;
                                main.button3.Enabled = false;
                               // main.button4.Enabled = false;
                                main.button6.Enabled = false;
                                main.button9.Enabled = false;
                                main.Show();
                                main.label2.Text = textBox1.Text;
                                main.textBox1.Text = textBox1.Text;
                                main.textBox2.Text = textBox2.Text;
                                main.textBox3.Text = role;
                                main.textBox4.Text = Date;

                                Byte[] data = new Byte[0];
                                data = (Byte[])dr.GetValue(7);
                                MemoryStream mem = new MemoryStream(data);
                                main.pictureBox13.Image = Image.FromStream(mem);
                                this.Hide();
                            }
                            else if (role == "Class3 Teacher" && textBox1.Text == dr.GetValue(1).ToString() && textBox2.Text == dr.GetValue(3).ToString())
                            {
                                MessageBox.Show(" '" + textBox1.Text + "' Logged In Successfully As Class3 Teacher", "Login Successful", 0, MessageBoxIcon.Information);
                                var main = new DessySchoolComplesApp.cs.MainWindow();
                                main.button1.Enabled = false;
                                main.button3.Enabled = false;
                                main.button4.Enabled = false;
                                main.button6.Enabled = false;
                                main.button9.Enabled = false;
                                Byte[] data = new Byte[0];
                                data = (Byte[])dr.GetValue(7);
                                MemoryStream mem = new MemoryStream(data);
                                main.pictureBox13.Image = Image.FromStream(mem);
                                main.Show();
                                main.label2.Text = textBox1.Text;
                                main.textBox1.Text = textBox1.Text;
                                main.textBox2.Text = textBox2.Text;
                                main.textBox3.Text = role;
                                this.Hide();
                            }
                            else if (role == "Librarian" && textBox1.Text == dr.GetValue(1).ToString() && textBox2.Text == dr.GetValue(3).ToString())
                            {
                                MessageBox.Show(" '" + textBox1.Text + "' Logged In Successfully As The School Librarian", "Login Successful", 0, MessageBoxIcon.Information);
                                var main = new DessySchoolComplesApp.cs.MainWindow();
                                main.button1.Enabled = false;
                                main.button2.Enabled = false;
                                main.button3.Enabled = false;
                                main.button4.Enabled = false;
                                main.button5.Enabled = false;
                                main.button6.Enabled = false;
                                main.button7.Enabled = false;
                                main.button8.Enabled = false;
                                main.button9.Enabled = false;
                                main.Show();
                                 
                                main.label2.Text = textBox1.Text;
                                //+ "('" + role +"')";
                                main.textBox1.Text = textBox1.Text;
                                main.textBox2.Text = textBox2.Text;
                                main.textBox3.Text = role;
                                Byte[] data = new Byte[0];
                                data = (Byte[])dr.GetValue(7);
                                MemoryStream mem = new MemoryStream(data);
                                main.pictureBox13.Image = Image.FromStream(mem);
                                this.Hide();
                            }
                            
                        }
                    }
                    else
                    {

                        MessageBox.Show("Wrong Credentials ! Check Your UserName Or Password ..", "Error", 0, MessageBoxIcon.Error);
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
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            var opt = new KingDessySchool.cs.OptionWindow();
           opt.Show();
            opt.panel3.Visible = true;
            //opt.panel3.Width = opt.panel3.Width + 25;
            opt.button6.Visible = true;

        }
    }
}
