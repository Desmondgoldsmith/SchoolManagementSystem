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
using System.Threading;
using excel = Microsoft.Office.Interop.Excel;
namespace KingDessySchool.cs
{
    public partial class RegisterStudentX : Form
    {
        public RegisterStudentX()
        {
            InitializeComponent();
        }

        omagaconnections great = new omagaconnections();
        string imglocation;
        private void button3_Click(object sender, EventArgs e)
        {

        }

      

        

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(140, Color.Black);

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(60, Color.Black);

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox20.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S FIRST NAME", "ERROR", 0, MessageBoxIcon.Information);
                textBox20.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox19.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S LAST NAME", "ERROR", 0, MessageBoxIcon.Information);
                textBox19.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox2.Text.ToString()))
            {
                MessageBox.Show("SELECT STUDENT CLASS", "ERROR", 0, MessageBoxIcon.Information);
                comboBox2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox3.Text.ToString()))
            {
                MessageBox.Show("SELECT STUDENT'S GENDER", "ERROR", 0, MessageBoxIcon.Information);
                comboBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox21.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S AGE", "ERROR", 0, MessageBoxIcon.Information);
                textBox21.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker2.Text.ToString()))
            {
                MessageBox.Show("SELECT TODAY'S DATE", "ERROR", 0, MessageBoxIcon.Information);
                dateTimePicker2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox17.Text.ToString()))
            {
                MessageBox.Show("INPUT PARENT NAME", "ERROR", 0, MessageBoxIcon.Information);
                textBox17.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox16.Text.ToString()))
            {
                MessageBox.Show("INPUT PARENT PHONE NUMBER", "ERROR", 0, MessageBoxIcon.Information);
                textBox16.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox15.Text.ToString()))
            {
                MessageBox.Show("INPUT PARENT'S EMAIL", "ERROR", 0, MessageBoxIcon.Information);
                textBox15.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox14.Text.ToString()))
            {
                MessageBox.Show("INPUT NATIONALITY", "ERROR", 0, MessageBoxIcon.Information);
                textBox14.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox13.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S HOMETOWN", "ERROR", 0, MessageBoxIcon.Information);
                textBox13.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox12.Text.ToString()))
            {
                MessageBox.Show("INPUT  PLACE OF RESIDENCE", "ERROR", 0, MessageBoxIcon.Information);
                textBox12.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox22.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S UNDERLAYING CONDITIONS OR SICKNESS", "ERROR", 0, MessageBoxIcon.Information);
                textBox22.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox23.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S EMERGENCY CONTACT NAME", "ERROR", 0, MessageBoxIcon.Information);
                textBox23.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox24.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S EMERGENCY CONTACT PHONE NUMBER", "ERROR", 0, MessageBoxIcon.Information);
                textBox24.Focus();
                return;
            }
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("UPLOAD STUDENT PHOTOGRAPH", "ERROR", 0, MessageBoxIcon.Information);
                pictureBox2.Focus();
                return;
            }
            try
            {
                //picking id from the database 
                try
                {
                    int idNum = 0;


                    great.opencon();
                    SqlCommand SqlCmd = new SqlCommand(" SELECT MAX(id) FROM NewStudentRegX", great.returnCon());
                    SqlDataAdapter da = new SqlDataAdapter(SqlCmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds.Tables[0].Rows[0][0] != DBNull.Value)
                    {
                        idNum = Convert.ToInt32(ds.Tables[0].Rows[0][0]);
                        idNum = idNum + 1;
                        textBox18.Text = idNum.ToString();
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
                string sqlQuery = "insert into NewStudentRegX (firstname,lastname,StdClass,gender,DoB,age,RegisterDate,Parent,ParentNum,ParentEmail,Nationality,HomeTown,Residence,sickness,emergencyName,emergencyPhone,Std_Photograph) values('" + textBox20.Text + "', '" + textBox19.Text + "','" + comboBox2.Text + "','"+ comboBox3.Text +"','"+ textBox21.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + textBox17.Text + "','" + textBox16.Text + "','" + textBox15.Text + "','" + textBox14.Text + "','" + textBox13.Text + "','" + textBox12.Text + "','" + textBox22.Text + "','" + textBox23.Text + "','" + textBox24.Text + "',@img)";
                SqlCommand cmd = new SqlCommand(sqlQuery, great.returnCon());

                cmd.Parameters.Add(new SqlParameter("@img", images));
                //int n = cmd.ExecuteNonQuery();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    clear();
                    MessageBox.Show("Data Saved Successfully.", "Saved", 0, MessageBoxIcon.Information);
                    this.newStudentRegXTableAdapter.Fill(this.dessySoftDataSet61.NewStudentRegX);

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

        private void button13_Click(object sender, EventArgs e)
        {
            // open file dialog   
            OpenFileDialog dialog = new OpenFileDialog();
            // image filters  
            dialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = dialog.FileName.ToString();
                // display image in picture box  
                pictureBox2.ImageLocation = imglocation;
                // image file path  
                // textBox1.Text = open.FileName;
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {

        }

        private void RegisterStudentX_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet61.NewStudentRegX' table. You can move, or remove it, as needed.
            this.newStudentRegXTableAdapter.Fill(this.dessySoftDataSet61.NewStudentRegX);
            progressBar1.Visible = false;
            dataGridView1.Visible = false;
            button10.Enabled = false;
            button11.Enabled = false;

          //  great.opencon();
            //string query = "COUNT  FROM NewStudentRegX WHERE gender = "Male""
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox20.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S FIRST NAME", "ERROR", 0, MessageBoxIcon.Information);
                textBox20.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox19.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S LAST NAME", "ERROR", 0, MessageBoxIcon.Information);
                textBox19.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox2.Text.ToString()))
            {
                MessageBox.Show("SELECT STUDENT CLASS", "ERROR", 0, MessageBoxIcon.Information);
                comboBox2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox3.Text.ToString()))
            {
                MessageBox.Show("SELECT STUDENT'S GENDER", "ERROR", 0, MessageBoxIcon.Information);
                comboBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox21.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S AGE", "ERROR", 0, MessageBoxIcon.Information);
                textBox21.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker2.Text.ToString()))
            {
                MessageBox.Show("SELECT TODAY'S DATE", "ERROR", 0, MessageBoxIcon.Information);
                dateTimePicker2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox17.Text.ToString()))
            {
                MessageBox.Show("INPUT PARENT NAME", "ERROR", 0, MessageBoxIcon.Information);
                textBox17.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox16.Text.ToString()))
            {
                MessageBox.Show("INPUT PARENT PHONE NUMBER", "ERROR", 0, MessageBoxIcon.Information);
                textBox16.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox15.Text.ToString()))
            {
                MessageBox.Show("INPUT PARENT'S EMAIL", "ERROR", 0, MessageBoxIcon.Information);
                textBox15.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox14.Text.ToString()))
            {
                MessageBox.Show("INPUT NATIONALITY", "ERROR", 0, MessageBoxIcon.Information);
                textBox14.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox13.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S HOMETOWN", "ERROR", 0, MessageBoxIcon.Information);
                textBox13.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox12.Text.ToString()))
            {
                MessageBox.Show("INPUT  PLACE OF RESIDENCE", "ERROR", 0, MessageBoxIcon.Information);
                textBox12.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox22.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S UNDERLAYING CONDITIONS OR SICKNESS", "ERROR", 0, MessageBoxIcon.Information);
                textBox22.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox23.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S EMERGENCY CONTACT NAME", "ERROR", 0, MessageBoxIcon.Information);
                textBox23.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox24.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S EMERGENCY CONTACT PHONE NUMBER", "ERROR", 0, MessageBoxIcon.Information);
                textBox24.Focus();
                return;
            }
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("UPLOAD STUDENT PHOTOGRAPH", "ERROR", 0, MessageBoxIcon.Information);
                pictureBox2.Focus();
                return;
            }
            try
            {

                                                                                              
                SqlCommand cmd = new SqlCommand("update NewStudentRegX set firstname = @txt1,lastname=@txt2,StdClass=@cbo1,gender=@gen,age=@age,RegisterDate=@dtp1,Parent=@txt4,ParentNum=@txt5,ParentEmail=@txt6,Nationality=@txt7,HomeTown=@txt8,Residence=@txt9,sickness=@txt10,emergencyName=@txt11,emergencyPhone=@txt12,Std_Photograph=@pic where id='" + textBox18.Text + "' ", great.returnCon());
                MemoryStream stream = new MemoryStream();
                pictureBox2.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] pic = stream.ToArray();
                cmd.Parameters.AddWithValue("@pic", pic);
                cmd.Parameters.AddWithValue("@txt1", textBox20.Text);
                cmd.Parameters.AddWithValue("@txt2", textBox19.Text);
                cmd.Parameters.AddWithValue("@cbo1", comboBox2.Text);
                cmd.Parameters.AddWithValue("@gen", comboBox3.Text);
                cmd.Parameters.AddWithValue("@age", textBox21.Text);
                cmd.Parameters.AddWithValue("@dtp1", dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@txt4", textBox17.Text);
                cmd.Parameters.AddWithValue("@txt5", textBox16.Text);
                cmd.Parameters.AddWithValue("@txt6", textBox15.Text);
                cmd.Parameters.AddWithValue("@txt7", textBox14.Text);
                cmd.Parameters.AddWithValue("@txt8", textBox13.Text);
                cmd.Parameters.AddWithValue("@txt9", textBox12.Text);
                cmd.Parameters.AddWithValue("@txt10", textBox22.Text);
                cmd.Parameters.AddWithValue("@txt11", textBox23.Text);
                cmd.Parameters.AddWithValue("@txt12", textBox24.Text);
                
                // cmd.Parameters.Add(new SqlParameter("@txt3", textBox3.Text));
                great.opencon();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    //int RowsEffected = da.UpdateCommand.ExecuteNonQuery();
                    MessageBox.Show("Student With Name '" + textBox20.Text + " " + textBox19.Text + "' And ID of '" + textBox18.Text + "' Is  Updated Successfully.", "Saved", 0, MessageBoxIcon.Information);
                    this.newStudentRegXTableAdapter.Fill(this.dessySoftDataSet61.NewStudentRegX);
                    clear();
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

       

        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow click = dataGridView1.Rows[e.RowIndex];
                button10.Enabled = true;
                button11.Enabled = true;
                button12.Enabled = false;
                textBox18.Text = click.Cells[0].Value.ToString();
                textBox20.Text = click.Cells[1].Value.ToString();
                textBox19.Text = click.Cells[2].Value.ToString();
                comboBox2.Text = click.Cells[3].Value.ToString();
                comboBox3.Text = click.Cells[4].Value.ToString();
                textBox21.Text = click.Cells[5].Value.ToString();
                dateTimePicker2.Text = click.Cells[6].Value.ToString();
                textBox17.Text = click.Cells[7].Value.ToString();
                textBox16.Text = click.Cells[8].Value.ToString();
                textBox15.Text = click.Cells[9].Value.ToString();
                textBox14.Text = click.Cells[10].Value.ToString();
                textBox13.Text = click.Cells[11].Value.ToString();
                textBox12.Text = click.Cells[12].Value.ToString();
                textBox22.Text = click.Cells[13].Value.ToString();
                textBox23.Text = click.Cells[14].Value.ToString();
                textBox24.Text = click.Cells[15].Value.ToString();
                Byte[] data = new Byte[0];
                data = (Byte[])click.Cells[16].Value;
                MemoryStream mem = new MemoryStream(data);
                pictureBox2.Image = Image.FromStream(mem);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox20.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S FIRST NAME", "ERROR", 0, MessageBoxIcon.Information);
                textBox20.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox19.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S LAST NAME", "ERROR", 0, MessageBoxIcon.Information);
                textBox19.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox2.Text.ToString()))
            {
                MessageBox.Show("SELECT STUDENT CLASS", "ERROR", 0, MessageBoxIcon.Information);
                comboBox2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox3.Text.ToString()))
            {
                MessageBox.Show("SELECT STUDENT'S GENDER", "ERROR", 0, MessageBoxIcon.Information);
                comboBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox21.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S AGE", "ERROR", 0, MessageBoxIcon.Information);
                textBox21.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker2.Text.ToString()))
            {
                MessageBox.Show("SELECT TODAY'S DATE", "ERROR", 0, MessageBoxIcon.Information);
                dateTimePicker2.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox17.Text.ToString()))
            {
                MessageBox.Show("INPUT PARENT NAME", "ERROR", 0, MessageBoxIcon.Information);
                textBox17.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox16.Text.ToString()))
            {
                MessageBox.Show("INPUT PARENT PHONE NUMBER", "ERROR", 0, MessageBoxIcon.Information);
                textBox16.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox15.Text.ToString()))
            {
                MessageBox.Show("INPUT PARENT'S EMAIL", "ERROR", 0, MessageBoxIcon.Information);
                textBox15.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox14.Text.ToString()))
            {
                MessageBox.Show("INPUT NATIONALITY", "ERROR", 0, MessageBoxIcon.Information);
                textBox14.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox13.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S HOMETOWN", "ERROR", 0, MessageBoxIcon.Information);
                textBox13.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox12.Text.ToString()))
            {
                MessageBox.Show("INPUT  PLACE OF RESIDENCE", "ERROR", 0, MessageBoxIcon.Information);
                textBox12.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox22.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S UNDERLAYING CONDITIONS OR SICKNESS", "ERROR", 0, MessageBoxIcon.Information);
                textBox22.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox23.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S EMERGENCY CONTACT NAME", "ERROR", 0, MessageBoxIcon.Information);
                textBox23.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox24.Text.ToString()))
            {
                MessageBox.Show("INPUT STUDENT'S EMERGENCY CONTACT PHONE NUMBER", "ERROR", 0, MessageBoxIcon.Information);
                textBox24.Focus();
                return;
            }
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("UPLOAD STUDENT PHOTOGRAPH", "ERROR", 0, MessageBoxIcon.Information);
                pictureBox2.Focus();
                return;
            }
            try
            {

                if (MessageBox.Show("THIS ACTION CAN NEVER BE REVERSED. ARE YOU SURE YOU WANT TO DELETE?", "DELETE RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    great.opencon();
                SqlCommand cmd = new SqlCommand("DELETE FROM NewStudentRegX WHERE id = '" + textBox18.Text + "'", great.returnCon());
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Student With Name '" + textBox20.Text + " " + textBox19.Text + "' and ID '" + textBox18.Text + "'  Is Deleted Successfully.", "Deleted", 0, MessageBoxIcon.Information);
                    this.newStudentRegXTableAdapter.Fill(this.dessySoftDataSet61.NewStudentRegX);
                    clear();
                }
                else
                {
                    MessageBox.Show("Error in Deleting Data.", "Error", 0, MessageBoxIcon.Error);

                }
            }
            catch (Exception )
            {
               // MessageBox.Show(ex.Message);
            }
            finally
            {
                great.closeCon();
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            clear();
        }
        public void clear()
        {
            button12.Enabled = true;
            textBox20.Clear();
            textBox18.Clear();
            textBox19.Clear();
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker2.Text = null;
            textBox17.Clear();
            textBox16.Clear();
            textBox15.Clear();
            textBox14.Clear();
            textBox21.Clear();
            textBox13.Clear();
            textBox12.Clear();
            textBox22.Clear();
            textBox23.Clear();
            textBox24.Clear();
            pictureBox2.Image = null;
            button10.Enabled = false;
            button11.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Visible != true)
            {
                dataGridView1.Visible = true;
                button6.Text = "HIDE";

            }
            else if (dataGridView1.Visible == true)
            {
                button6.Text = "VIEW";

                dataGridView1.Visible = false;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Excel();
            //setting the timer
            this.timer1.Start();
            progressBar1.Visible = true;
            //label7.Visible = true;

        }

        public void Excel()
        {
            //loading datagrid contents to excel worksheets
             Thread.Sleep(3000);
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
            progressBar1.Increment(1);
            button2.Text = progressBar1.Value.ToString() + "%";
            button2.ForeColor = Color.Red;
            dataGridView1.Visible = true;
            this.progressBar1.Increment(10);
            if (progressBar1.Value == 100)
            {
                //timer1.Tick.Tostring() = label7.Text;
                Excel();
                progressBar1.Visible = false;
                button2.Text = "EXPORT";
                button2.ForeColor = Color.White;
                timer1.Enabled = false;

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(50, Color.White);
        }
         
        private void textBox25_TextChanged(object sender, EventArgs e)
        {

            try
            {
                
                string search = textBox25.Text;
                SqlCommand cmd = new SqlCommand("select * from NewStudentRegX  where CONCAT(firstname,lastname) like '%" + textBox25.Text + "%' ", great.returnCon());
             
                great.opencon();
                SqlDataReader rd;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    button10.Enabled = true;
                    button11.Enabled = true;
                    button12.Enabled = false;

                    textBox18.Text = rd.GetValue(0).ToString();
                    textBox20.Text = rd.GetValue(1).ToString();
                    textBox19.Text = rd.GetValue(2).ToString();
                    comboBox2.Text = rd.GetValue(3).ToString();
                    comboBox3.Text = rd.GetValue(4).ToString();
                    textBox21.Text = rd.GetValue(5).ToString();
                    dateTimePicker2.Text = rd.GetValue(6).ToString();
                    textBox17.Text = rd.GetValue(7).ToString();
                    textBox16.Text = rd.GetValue(8).ToString();
                    textBox15.Text = rd.GetValue(9).ToString();
                    textBox14.Text = rd.GetValue(10).ToString();
                    textBox13.Text = rd.GetValue(11).ToString();
                    textBox12.Text = rd.GetValue(12).ToString();
                    textBox22.Text = rd.GetValue(13).ToString();
                    textBox23.Text = rd.GetValue(14).ToString();
                    textBox24.Text = rd.GetValue(15).ToString();
                    Byte[] data = new Byte[0];
                    data = (Byte[])rd.GetValue(16);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox2.Image = Image.FromStream(mem);
                    
                    if (string.IsNullOrEmpty(textBox25.Text.ToString()))
                    {
                        clear();
                    }
                    rd.Close();
                }
                else
                {
                    rd.Close();
                    MessageBox.Show("NO RECORD AVAILABLE WITH NAME '"+textBox25.Text+"'", " RECORD DOES NOT EXIST", 0, MessageBoxIcon.Error);
                    textBox25.Clear();
                    
                    clear();
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

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = null;
        }

        private void newStudentRegXBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
