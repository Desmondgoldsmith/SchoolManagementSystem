using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Microsoft.VisualBasic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using excel = Microsoft.Office.Interop.Excel;
namespace DessySchoolComplexReal.cs
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        KingDessySchool.cs.omagaconnections great = new KingDessySchool.cs.omagaconnections();
        string imglocation = "";
        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet27.StdRegister' table. You can move, or remove it, as needed.
            this.stdRegisterTableAdapter.Fill(this.dessySoftDataSet27.StdRegister);
            dataGridView1.Visible = false;
            progressBar1.Visible = false;
            //using(StdRegModel db = new StdRegModel )
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(185, Color.Black);
        }

       
        public void clear() {

            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = "";
            dateTimePicker1.Text =null;
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
             pictureBox1.Image = null ;

        }



        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //picking id from the database 
                try
                {
                    int idNum = 0;


                    great.opencon();
                    SqlCommand SqlCmd = new SqlCommand(" SELECT MAX(StudentId) FROM StdRegister", great.returnCon());
                    SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows[0][0] != DBNull.Value)
                    {  
                        idNum = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        idNum = idNum + 1;
                        textBox3.Text = idNum.ToString();
                    }
                    else
                    {
                        idNum = 1;
                    }

                    // return TranNo.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    great.closeCon();
                }
                byte[] images = null;
                FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                images = brs.ReadBytes((int)stream.Length);
                great.opencon();
                string sqlQuery = "insert into StdRegister (firstname,lastname,StdClass,RegisterDate,Parent,ParentNum,ParentEmail,Nationality,HomeTown,Residence,Fees,Std_Photograph) values('" + textBox1.Text + "', '" + textBox2.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "',@img)";
                SqlCommand cmd = new SqlCommand(sqlQuery, great.returnCon());

                cmd.Parameters.Add(new SqlParameter("@img", images));
                //int n = cmd.ExecuteNonQuery();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    clear();
                    MessageBox.Show("Data Saved Successfully.", "Saved", 0, MessageBoxIcon.Information);
                    this.stdRegisterTableAdapter.Fill(this.dessySoftDataSet27.StdRegister);




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
                great.closeCon();
            }


        }



        private void button1_Click(object sender, EventArgs e)
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

       

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
              
             
                SqlCommand cmd = new SqlCommand("update StdRegister set firstname = @txt1,lastname=@txt2,StdClass=@cbo1,RegisterDate=@dtp1,Parent=@txt4,ParentNum=@txt5,ParentEmail=@txt6,Nationality=@txt7,HomeTown=@txt8,Residence=@txt9,Fees=@txt10,Std_Photograph=@pic where StudentId='" + textBox3.Text +"' ",great.returnCon());
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream,System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] pic = stream.ToArray();
                cmd.Parameters.AddWithValue("@pic", pic);
                cmd.Parameters.AddWithValue("@txt1", textBox1.Text);
                cmd.Parameters.AddWithValue("@txt2", textBox2.Text);
                cmd.Parameters.AddWithValue("@cbo1", comboBox1.Text);
                cmd.Parameters.AddWithValue("@dtp1", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@txt4", textBox4.Text);
                cmd.Parameters.AddWithValue("@txt5", textBox5.Text);
                cmd.Parameters.AddWithValue("@txt6", textBox6.Text);
                cmd.Parameters.AddWithValue("@txt7", textBox7.Text);
                cmd.Parameters.AddWithValue("@txt8", textBox8.Text);
                cmd.Parameters.AddWithValue("@txt9", textBox9.Text);
                cmd.Parameters.AddWithValue("@txt10", textBox10.Text);
               // cmd.Parameters.Add(new SqlParameter("@txt3", textBox3.Text));
                great.opencon();
                
                if (cmd.ExecuteNonQuery() == 1) {
                    //int RowsEffected = da.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Student With Name '"+textBox1.Text+ " " + textBox2.Text + "' And ID of '"+textBox3.Text+"' Is  Updated Successfully.", "Saved", 0, MessageBoxIcon.Information);
                    this.stdRegisterTableAdapter.Fill(this.dessySoftDataSet27.StdRegister);

                }
                else
                {
                    MessageBox.Show("Error in Updating Record.", "Error", 0, MessageBoxIcon.Error);
                }
                
            }
            
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                great.closeCon();
            }
        }

      

        private void button7_Click(object sender, EventArgs e)
        {
               if (dataGridView1.Visible != true)
            {
                dataGridView1.Visible = true;
                button7.Text = "HIDE";

            }
            else if (dataGridView1.Visible == true)
            {
                button7.Text = "VIEW";

                dataGridView1.Visible = false;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try {

                if (MessageBox.Show("THIS ACTION CAN NEVER BE REVERSED. ARE YOU SURE YOU WANT TO DELETE?", "DELETE RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    great.opencon();
                    SqlCommand cmd = new SqlCommand("DELETE FROM StdRegister WHERE StudentId = '" + textBox3.Text + "'", great.returnCon());
            if(cmd.ExecuteNonQuery() == 1)
            {
               
                MessageBox.Show("Student With Name '" + textBox1.Text + " " + textBox2.Text + "' and ID '"+textBox3.Text+"'  Is Deleted Successfully.", "Deleted", 0, MessageBoxIcon.Information);
                    this.stdRegisterTableAdapter.Fill(this.dessySoftDataSet27.StdRegister);
                    clear();
            }
            else
            {
                MessageBox.Show("Error in Deleting Data.", "Error", 0, MessageBoxIcon.Error);

            }
        }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                great.closeCon();
            }
            
        }

       

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
           // Excel();
            //setting the timer
            this.timer1.Start();
            progressBar1.Visible = true;
            //label7.Visible = true;
        }
        public void Excel()
        {
            dataGridView1.Visible = true;
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

            for (int j = 0; j <= dataGridView1.Rows.Count-1 ; j++)
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
            if (progressBar1.Value > 99)
            {
                //timer1.Tick.Tostring() = label7.Text;
                Excel();
                progressBar1.Visible = false;
                //  label7.Visible = false;
                timer1.Enabled = false;

            }
        }

      

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == 1)
            {
                DataGridViewRow click = dataGridView1.Rows[e.RowIndex];

                textBox3.Text = click.Cells[0].Value.ToString();
                textBox1.Text = click.Cells[1].Value.ToString();
                textBox2.Text = click.Cells[2].Value.ToString();
                comboBox1.Text = click.Cells[3].Value.ToString();
                dateTimePicker1.Text = click.Cells[4].Value.ToString();
                textBox4.Text = click.Cells[5].Value.ToString();
                textBox5.Text = click.Cells[6].Value.ToString();
                textBox6.Text = click.Cells[7].Value.ToString();
                textBox7.Text = click.Cells[8].Value.ToString();
                textBox8.Text = click.Cells[9].Value.ToString();
                textBox9.Text = click.Cells[10].Value.ToString();
                textBox10.Text = click.Cells[11].Value.ToString();
                Byte[] data = new Byte[0];
                data = (Byte[])click.Cells[12].Value;
                MemoryStream mem = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(mem);
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
    
        }
   






