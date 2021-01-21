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
    public partial class Promote : Form
    {
        public Promote()
        {
            InitializeComponent();
        }

        omagaconnections dessy = new omagaconnections();

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(190, Color.Black);

        }

        private void Promote_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet41.NewGrade1' table. You can move, or remove it, as needed.
            this.newGrade1TableAdapter.Fill(this.dessySoftDataSet41.NewGrade1);
            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            chkbox.HeaderText = "SELECT STUDENT";
            chkbox.Name = "checkBox";
            chkbox.Width = 80;
            chkbox.DefaultCellStyle.BackColor = Color.Red;
            dataGridView1.Columns.Insert(0, chkbox);

            

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void dataGridView1_MouseClick_1(object sender, MouseEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("id");
            dt.Columns.Add("FirstName");
            dt.Columns.Add("LastName");
            dt.Columns.Add("Classx");
            dt.Columns.Add("Age");
            dt.Columns.Add("Teacher");
            dt.Columns.Add("Photo");

            foreach(DataGridViewRow drv in dataGridView1.Rows)
            {
                bool chkBox = Convert.ToBoolean(drv.Cells["checkBox"].Value);
                if (chkBox)
                {
                    dt.Rows.Add(drv.Cells[2].Value, drv.Cells[3].Value, drv.Cells[4].Value, drv.Cells[5].Value, drv.Cells[6].Value);
                   //dataGridView1.SelectedRows.Remove();
                    drv.DefaultCellStyle.BackColor = Color.Black;
                    drv.DefaultCellStyle.ForeColor = Color.Yellow;
                   // dataGridView1.Rows.RemoveAt(drv);
              }
                dataGridView2.DataSource = dt;
            }




           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dessy.opencon();
            for(int i = 0; i < dataGridView2.Rows.Count ; i++)
            {
                int count = dataGridView2.Rows.Count;
                SqlCommand cmd = new SqlCommand("INSERT INTO TRIAL(FirstName,LastName,Classx,Age,Teacher,Photo) values('" + dataGridView2.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView2.Rows[i].Cells["Photo"].Value.ToString() + "')", dessy.returnCon());

                dessy.opencon();
                label1.Text = count.ToString();
                if (cmd.ExecuteNonQuery() == Convert.ToInt32(label1.Text))
                {
                    MessageBox.Show("Saved Successfully", "saved", 0, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error", "Error", 0, MessageBoxIcon.Error);

                }
                dessy.closeCon();
            }
        }
    }
}
