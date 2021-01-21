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
    public partial class RealClass1TeacherAttendance : Form
    {
        public RealClass1TeacherAttendance()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(160, Color.Black);
        }

        private void RealClass1TeacherAttendance_Load(object sender, EventArgs e)
        {
            
            //first column
            DataGridViewComboBoxColumn combo = new DataGridViewComboBoxColumn();
            combo.HeaderText = "ATTENDANCE STATUS";
            combo.Name = "promote";
            combo.Width = 120;
            combo.DefaultCellStyle.BackColor = Color.Black;
            combo.DefaultCellStyle.ForeColor = Color.White;

            combo.Items.Add("Present");
            combo.Items.Add("Absent");
            dataGridView1.Columns.Insert(0, combo);

            //Reason
            DataGridViewTextBoxColumn txxt = new DataGridViewTextBoxColumn();
            txxt.HeaderText = "REASON";
            txxt.Name = "REASON";
            txxt.Width = 180;

            dataGridView1.Columns.Insert(6, txxt);


            dessy.opencon();
            SqlDataAdapter da = new SqlDataAdapter("SELECT name,TeacherClass,SubjectTaught,Num FROM employees where TeacherClass='Class 1' ", dessy.returnCon());
            DataTable dt = new DataTable();
            da.Fill(dt);
            //byte[] data = (byte[])dt.Rows[0]["pic"];
            //MemoryStream ms = new MemoryStream(data);
            ////pictureBox2.Image = Image.FromStream(ms);
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //update DataGrid

        //    cn.Open();
        //    SqlCommand cmd = new SqlCommand(@"UPDATE MEDICINE_REGISTRATION 
        //                             SET stock = @RStock 
        //                             WHERE id= @id", cn);

        //    cmd.Parameters.Add("@RStock", SqlDbType.VarChar).Value = "";
        //    cmd.Parameters.Add("@id", SqlDbType.Integer).Value = 0;

        //    foreach (DataGridViewRow row in Order_Datagridview.Rows)
        //    {
        //        // Use the row indexer here, not the fixed row at index zero
        //        cmd.Parameters["@RStock"].Value = row.Cells["RStock"].Value.ToString();
        //        cmd.Parameters["@id"].Value = Convert.ToInt32(row.Cells["id"].Value);
        //        cmd.ExecuteNonQuery();
        //    }
        //    cn.Close();
        //}
    }
    }
}
