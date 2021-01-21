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
namespace KingDessySchool.cs
{
    public partial class FindPassword : Form
    {
        public FindPassword()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //FOR BLURRED PANELS
            panel1.BackColor = Color.FromArgb(170, Color.Black);
        }

        private void FindPassword_Load(object sender, EventArgs e)
        {
               dataGridView1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //SELECTING VALUS FROM THE DATABASE WHICH MATCHES THE VALUES IN THE TEXTBOXES
            dataGridView1.Visible = true;
            dessy.opencon();
            string Query = " SELECT * FROM RegUsers WHERE Username = '" + textBox1.Text + "' and Gua = '" + textBox2.Text + "' and GGuaPass = '" + textBox3.Text + "'";
            SqlCommand cmd = new SqlCommand(Query,dessy.returnCon());
            SqlDataReader dr = cmd.ExecuteReader();
            //IF THE VALUES IN THE TEXTBOX ARE ASLO  IN THE DATABASE THEN
            if(dr.HasRows == true)
            {
                while (dr.Read())
                {
                    //THEN I CREATE VARIABLES TO HOLD THEM AND EQUATE THEM TO THE CELLS IN THE DATAGRID VIEW
                    string id = dr.GetValue(0).ToString();
                    string uname = dr.GetValue(1).ToString();
                    string gua = dr.GetValue(5).ToString();
                    string role = dr.GetValue(2).ToString();
                    string guapass = dr.GetValue(3).ToString();
                    int index = dataGridView1.Rows.Add();
                    dataGridView1.Rows[index].Cells[0].Value = id;
                    dataGridView1.Rows[index].Cells[1].Value = uname;
                    dataGridView1.Rows[index].Cells[2].Value = role;
                    dataGridView1.Rows[index].Cells[3].Value = guapass;
                    //dr.Close();
                   // dataGridView1.ClearSelection();
                }
                //CLOSE DATAREADER
                dr.Close();

            }
            else
            {
                dr.Close();
                MessageBox.Show("WRONG CREDENTIALS! CHECK YOUR INPUTS", "ERROR", 0, MessageBoxIcon.Error);
                dataGridView1.Visible = false;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            //DISMISSING THIS FORM AND OPENING THE OPTION FORM
            var opt = new OptionWindow();
            this.Hide();
            opt.Show();

        }
    }
}
