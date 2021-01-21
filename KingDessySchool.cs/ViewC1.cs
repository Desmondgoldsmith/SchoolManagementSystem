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
    public partial class ViewC1 : Form
    {
        public ViewC1()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        DataTable dt;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(180, Color.Black);
        }

        private void ViewC1_Load(object sender, EventArgs e)
        {
            SqlDataAdapter sda = new SqlDataAdapter("select firstname,lastname, StdClass,gender,age,RegisterDate,Parent,ParentNum,ParentEmail,sickness,emergencyName, emergencyPhone, AmtPaid, Balance, Std_Photograph from NewStudentRegX, Grade1Fees where NewStudentRegX.StdClass = 'CLASS 1' and Grade1Fees.StudentClass = 'CLASS 1' and  NewStudentRegX.id = Grade1Fees.id", dessy.returnCon());
             dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dessy.opencon();
                string search = textBox15.Text;
                SqlCommand cmd = new SqlCommand("select firstname,lastname, StdClass,gender,age,RegisterDate,Parent,ParentNum,ParentEmail,sickness,emergencyName, emergencyPhone, AmtPaid, Balance, Std_Photograph from NewStudentRegX, Grade1Fees  where CONCAT(firstname,lastname) like '%" + textBox15.Text + "%' ", dessy.returnCon());
                SqlDataReader rd;
                dessy.opencon(); 
                rd = cmd.ExecuteReader();
                DataView Dv = new DataView(dt);
                Dv.RowFilter = String.Format("firstname  like '%{0}%'", textBox15.Text);
                // DataGridViewRow row = dataGridView1.Rows[0];
                // dataGridView1.CurrentRow = row;
                dataGridView1.DataSource = Dv;

                //DataGridViewRow row = this.dataGridView1.SelectedRows[1];
                // textBox1.Text = row.Cells[1].Value.ToString();
                dessy.opencon();
                rd.Read();
                if (rd.Read())
                {

                    textBox1.Text = rd.GetValue(0).ToString();
                    textBox2.Text = rd.GetValue(1).ToString();
                    textBox3.Text = rd.GetValue(2).ToString();
                    textBox4.Text = rd.GetValue(3).ToString();
                    textBox5.Text = rd.GetValue(4).ToString();
                    textBox6.Text = rd.GetValue(5).ToString();
                    textBox12.Text = rd.GetValue(6).ToString();
                    textBox11.Text = rd.GetValue(7).ToString();
                    textBox10.Text = rd.GetValue(8).ToString();
                    textBox9.Text = rd.GetValue(9).ToString();
                    textBox8.Text = rd.GetValue(10).ToString();
                    textBox7.Text = rd.GetValue(11).ToString();
                    textBox13.Text = rd.GetValue(12).ToString();
                    textBox14.Text = rd.GetValue(13).ToString();
                    Byte[] data = new Byte[0];
                    data = (Byte[])rd.GetValue(14);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox1.Image = Image.FromStream(mem);
                    if (string.IsNullOrWhiteSpace(textBox15.Text.ToString()))
                    {
         //               clear();
                    }
                }

                else
                {
                    rd.Close();
                    MessageBox.Show("NO RECORD AVAILABLE ", " RECORD DOES NOT EXIST", 0, MessageBoxIcon.Error);
                    textBox15.Clear();
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
              //  rd.Close();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow click = dataGridView1.Rows[e.RowIndex];
                //textBox16.Text = click.Cells[0].Value.ToString();
                textBox1.Text = click.Cells[1].Value.ToString();
                textBox2.Text = click.Cells[2].Value.ToString();
                textBox3.Text = click.Cells[3].Value.ToString();
                textBox4.Text = click.Cells[4].Value.ToString();
                textBox5.Text = click.Cells[5].Value.ToString();
                textBox6.Text = click.Cells[6].Value.ToString();
                textBox12.Text = click.Cells[7].Value.ToString();
                textBox11.Text = click.Cells[8].Value.ToString();
                textBox10.Text = click.Cells[9].Value.ToString();
                textBox9.Text = click.Cells[10].Value.ToString();
                textBox8.Text = click.Cells[11].Value.ToString();
                textBox7.Text = click.Cells[12].Value.ToString();
                textBox13.Text = click.Cells[13].Value.ToString();
                textBox14.Text = click.Cells[14].Value.ToString();
                Byte[] data = new Byte[0];
                data = (Byte[])click.Cells[15].Value;
                MemoryStream mem = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(mem);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
