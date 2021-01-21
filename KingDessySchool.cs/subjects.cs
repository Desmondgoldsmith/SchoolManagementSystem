using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using excel = Microsoft.Office.Interop.Excel;
namespace KingDessySchool.cs
{
    public partial class subjects : Form
    {
        public subjects()
        {
            InitializeComponent();
        }
        omagaconnections des = new omagaconnections();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(180, Color.Black);
        }

        private void subjects_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet80.subjects' table. You can move, or remove it, as needed.
            this.subjectsTableAdapter.Fill(this.dessySoftDataSet80.subjects);
            dataGridView1.Visible = false;
            textBox3.Visible = false;
            progressBar1.Visible = false;
            label7.Visible = false;
            button2.Enabled = false;
            button3.Enabled = false;
           // button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            insert();
        }
        public void insert()
        {
            //validating controls to see if its empty or contains whitespace
            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                MessageBox.Show("COURSE NAME CANNOT BE EMPTY ", "INPUT THE COURSE NAME", 0, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
            {
                MessageBox.Show("SELECT THE CLASSES THAT APPLIES ", "SELECT THE CLASS", 0, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text.ToString()))
            {
                MessageBox.Show("SELECT THE DATE SUBJECT WAS ADDED ", "SELECT THE DATE", 0, MessageBoxIcon.Information);
                dateTimePicker1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox2.Text.ToString()))
            {
                MessageBox.Show("SELECT THE USER WHO ADDED COURSE ", "SELECT THE USER", 0, MessageBoxIcon.Information);
                comboBox2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text.ToString()))
            {
                MessageBox.Show("INPUT COURSE DESCRIPTION ", "COURSE DISCRIPTION", 0, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            //using try catch
            try
            {
                //open connection by calling the instance of the connection class 'des'
                des.opencon();
                SqlCommand cmd = new SqlCommand("SubjectsProc", des.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@class", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Add", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Desc", textBox2.Text);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    //message
                    
                    MessageBox.Show("A New Subject Added Successfully By '" + comboBox2.Text + "'", "Subject '" + textBox1.Text + "' Added", 0, MessageBoxIcon.Information);
                    this.subjectsTableAdapter.Fill(this.dessySoftDataSet80.subjects);

                    clear();
                }
                else
                {
                    MessageBox.Show("Error In Adding Subjects. ", "Error", 0, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                //throw an exception if theres any error
                MessageBox.Show("THE FOLLOWING ERROR OCCURED " + ex.Message);
            }
            finally
            {
                //close connection
                des.closeCon();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
        }
        public void update()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                MessageBox.Show("COURSE NAME CANNOT BE EMPTY ", "INPUT THE COURSE NAME", 0, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
            {
                MessageBox.Show("SELECT THE CLASSES THAT APPLIES ", "SELECT THE CLASS", 0, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text.ToString()))
            {
                MessageBox.Show("SELECT THE DATE SUBJECT WAS ADDED ", "SELECT THE DATE", 0, MessageBoxIcon.Information);
                dateTimePicker1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox2.Text.ToString()))
            {
                MessageBox.Show("SELECT THE USER WHO ADDED COURSE ", "SELECT THE USER", 0, MessageBoxIcon.Information);
                comboBox2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text.ToString()))
            {
                MessageBox.Show("INPUT COURSE DESCRIPTION ", "COURSE DISCRIPTION", 0, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            try
            {
                des.opencon();
                SqlCommand cmd = new SqlCommand("SubjectsProcUpdate", des.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@name", textBox1.Text);
                cmd.Parameters.AddWithValue("@class", comboBox1.Text);
                cmd.Parameters.AddWithValue("@Date", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Add", comboBox2.Text);
                cmd.Parameters.AddWithValue("@Desc", textBox2.Text);
                cmd.Parameters.AddWithValue("@id", textBox3.Text);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(" Subject Updated Successfully By '" + comboBox2.Text + "'", "Subject '" + textBox1.Text + "' Added", 0, MessageBoxIcon.Information);
                    this.subjectsTableAdapter.Fill(this.dessySoftDataSet80.subjects);

                    clear();
                }
                else
                {
                    MessageBox.Show("Error In Updating Subjects. ", "Error", 0, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("THE FOLLOWING ERROR OCCURED " + ex.Message);
            }
            finally
            {
                des.closeCon();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                button2.Enabled = true;
                button3.Enabled = true;
                button1.Enabled = false;
                textBox3.Text = row.Cells[0].Value.ToString();
                textBox1.Text = row.Cells[1].Value.ToString();
                comboBox1.Text = row.Cells[2].Value.ToString();
                dateTimePicker1.Text = row.Cells[3].Value.ToString();
                comboBox2.Text = row.Cells[4].Value.ToString();
                textBox2.Text = row.Cells[5].Value.ToString();
            }
        }
        public void Loader()
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Delete();
        }
        //delete record
        public void Delete()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                MessageBox.Show("COURSE NAME CANNOT BE EMPTY ", "INPUT THE COURSE NAME", 0, MessageBoxIcon.Information);
                textBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
            {
                MessageBox.Show("SELECT THE CLASSES THAT APPLIES ", "SELECT THE CLASS", 0, MessageBoxIcon.Information);
                comboBox1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text.ToString()))
            {
                MessageBox.Show("SELECT THE DATE SUBJECT WAS ADDED ", "SELECT THE DATE", 0, MessageBoxIcon.Information);
                dateTimePicker1.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox2.Text.ToString()))
            {
                MessageBox.Show("SELECT THE USER WHO ADDED COURSE ", "SELECT THE USER", 0, MessageBoxIcon.Information);
                comboBox2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text.ToString()))
            {
                MessageBox.Show("INPUT COURSE DESCRIPTION ", "COURSE DISCRIPTION", 0, MessageBoxIcon.Information);
                textBox2.Focus();
                return;
            }
            try
            {
                //des.opencon();

                if (MessageBox.Show("ARE YOU SURE YOU WANT TO DELETE THIS RECORD ?? THIS OPERATION IS IRREVERSIBLE.", "DELETE RECORD ?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    des.opencon();
                SqlCommand cmd = new SqlCommand("DeleteProc", des.returnCon()) { CommandType = CommandType.StoredProcedure };

                cmd.Parameters.AddWithValue("@id", textBox3.Text);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show(" Subject Deleted Successfully By '" + comboBox2.Text + "'", "Subject '" + textBox1.Text + "' Added", 0, MessageBoxIcon.Information);
                    this.subjectsTableAdapter.Fill(this.dessySoftDataSet80.subjects);

                    clear();
                }
                else
                {
                    MessageBox.Show("Error In Deleting Subjects. ", "Error", 0, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show( ex.Message);
            }
            finally
            {
                des.closeCon();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
            textBox1.Clear();
            comboBox1.Text = null;
            dateTimePicker1.Text = null;
            comboBox2.Text = null;
            textBox2.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible != true)
            {
                dataGridView1.Visible = true;
                button5.Text = "HIDE";

            }
            else if (dataGridView1.Visible == true)
            {
                dataGridView1.Visible = false;
                button5.Text = "VIEW";

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //setting the timer
            this.timer1.Start();
            progressBar1.Visible = true;


            label7.Visible = true;
        }
        public void Excel()
        {
            //loading datagrid contents to excel worksheets
            Thread.Sleep(1000);
            excel.Application app = new excel.Application();
            excel.Workbook workbook = app.Workbooks.Add();
            excel.Worksheet Worksheet = null;
            app.Visible = true;
            Worksheet = workbook.Sheets["sheet1"];
            Worksheet = workbook.ActiveSheet;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Worksheet.Cells[1, i + 1] = dataGridView1.Columns[i].HeaderText;
            }

            for (int j = 0; j <= dataGridView1.Rows.Count - 1; j++)
            {

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {

                    Worksheet.Cells[j + 2, i + 1] = dataGridView1.Rows[j].Cells[i].Value.ToString();
                }
            }
            Worksheet.Columns.AutoFit();
            //Worksheet.Columns.Text.Bold();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           
                
            dataGridView1.Visible = true;
            this.progressBar1.Increment(10);
            if(progressBar1.Value > 99)
            {
                 //timer1.Tick.Tostring() = label7.Text;
                Excel();
                progressBar1.Visible = false;
                label7.Visible = false;
                timer1.Enabled=false;

            }
            
            
        }
    }
}