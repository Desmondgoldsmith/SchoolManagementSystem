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
    public partial class TrialAttendance : Form
    {
        public TrialAttendance()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        private void TrialAttendance_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet92.NewGrade1' table. You can move, or remove it, as needed.
          //  this.newGrade1TableAdapter.Fill(this.dessySoftDataSet92.NewGrade1);
            //DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            //chkbox.HeaderText = "SELECT STUDENT";
            //chkbox.Name = "checkBox";
            //chkbox.Width = 80;
            //chkbox.DefaultCellStyle.BackColor = Color.Red;
            //dataGridView1.Columns.Insert(0, chkbox);

            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "promote";
            combo.Name = "promote";
            // combo.Width = 80;
            combo.DefaultCellStyle.BackColor = Color.Black;
            combo.DefaultCellStyle.ForeColor = Color.White;

            combo.Items.Add("Present");
            combo.Items.Add("Absent");
            dataGridView1.Columns.Insert(3, combo);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string StrQuery;
            //try
            //{


            //            dessy.opencon();
            //            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //            {
            //                SqlCommand comm = new SqlCommand();
            //                StrQuery = @"INSERT INTO Xtrial VALUES ("
            //                    + dataGridView1.Rows[i].Cells["promote"].Value + ", "
            //                    + dataGridView1.Rows[i].Cells["FirstName"].Value + " ,"
            //                     +dataGridView1.Rows[i].Cells["LastName"].Value + ", "
            //                    + dataGridView1.Rows[i].Cells["Classx"].Value +", "
            //                    +dataGridView1.Rows[i].Cells["Age"].Value + ", "
            //                    + dataGridView1.Rows[i].Cells["Teacher"].Value +

            //                    "); ";
            //                comm.CommandText = StrQuery;
            //                comm.ExecuteNonQuery();
            //                MessageBox.Show("good");
            //            }


            //}catch (Exception)
            //{

            //}
            //finally
            //{

            //}nn
            MessageBox.Show(dataGridView1.Columns[0].Name);
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                dessy.opencon();
                {
                    SqlCommand cmd = new SqlCommand("INSERT INTO Xtrial VALUES(@promote, @fn, @LastName,@LastName,@Age,@Teacher,@Datex)", dessy.returnCon());
                    {
                        cmd.Parameters.AddWithValue("@promote", row.Cells["promote"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@fn", row.Cells["firstNameDataGridViewTextBoxColumn"].Value);
                        cmd.Parameters.AddWithValue("@LastName", row.Cells["lastNameDataGridViewTextBoxColumn"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Age", row.Cells["ageDataGridViewTextBoxColumn"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Teacher", row.Cells["teacherDataGridViewTextBoxColumn"].Value ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Datex",dateTimePicker1.Text);

                        dessy.opencon();
                        cmd.ExecuteNonQuery();
                        dessy.closeCon();
                    }
                }
            }
            MessageBox.Show("Records inserted.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    }
