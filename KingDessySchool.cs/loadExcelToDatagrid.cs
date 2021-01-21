using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace KingDessySchool.cs
{
    public partial class loadExcelToDatagrid : Form
    {
        public loadExcelToDatagrid()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "SELECT YOUR EXEL FILE";
            ofd.FileName = textBox1.Text;
            ofd.Filter = "Excel Sheets (*.xls)|*.xls|All Files(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofd.FileName;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //loading excel data into datagrid view
            OleDbConnection con = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = '"+textBox1.Text+"'; Extended Properties = \'Excel 12.0 Xml;HDR=YES\'");
            //provider=Microsoft.Jet.OLEDB.4.0;data source='"+textBox1.Text+"';Extended Properties=\'Excel 8.0;HDR=NO;IMEX=1\'
            // "";Provider = Microsoft.ACE.OLEDB.12.0;    Data Source = c:\myFolder\myExcel2007file.xlsx; Extended Properties = "Excel 12.0 Xml;HDR ="YES";
            con.Open();
            OleDbDataAdapter oad = new OleDbDataAdapter("select * from [sheet1$]",con);
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            oad.Fill(dt);
            this.dataGridView1.DataSource = dt.DefaultView;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    int count = dataGridView1.Rows.Count;
            //    SqlCommand cmd = new SqlCommand("INSERT INTO TRIAL(FirstName,LastName,Classx,Age,Teacher,Photo) values('" + dataGridView2.Rows[i].Cells[1].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[2].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[3].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[4].Value.ToString() + "','" + dataGridView2.Rows[i].Cells[5].Value.ToString() + "','" + dataGridView2.Rows[i].Cells["Photo"].Value.ToString() + "')", dessy.returnCon());

            //    dessy.opencon();
            //    label1.Text = count.ToString();
            //    if (cmd.ExecuteNonQuery() == Convert.ToInt32(label1.Text))
            //    {
            //        MessageBox.Show("Saved Successfully", "saved", 0, MessageBoxIcon.Information);

            //    }
            //    else
            //    {
            //        MessageBox.Show("Error", "Error", 0, MessageBoxIcon.Error);

            //    }
            //    dessy.closeCon();
            //}
        }
    }
}
