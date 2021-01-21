using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Threading;
using excel = Microsoft.Office.Interop.Excel;
namespace KingDessySchool.cs
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }
        omagaconnections des = new omagaconnections();
        string imglocation = "";
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(185, Color.Black);
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            
            
            
            // TODO: This line of code loads data into the 'dessySoftDataSet79.employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.dessySoftDataSet79.employees);
             //fill combobox1 with dates
            des.opencon();
            SqlDataAdapter da = new SqlDataAdapter("SELECT Distinct subjectx FROM subjects ORDER BY subjectx desc", des.returnCon());

            DataTable dt = new DataTable();
            da.Fill(dt);
            comboBox3.DataSource = dt;
            comboBox3.DisplayMember = "subjectx";
            comboBox3.ValueMember = "subjectx"; 
            
        }

        private void label15_MouseClick(object sender, MouseEventArgs e)
        {
            this.Hide();
            var main = new DessySchoolComplesApp.cs.MainWindow();
            main.Show();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            
            var main = new DessySchoolComplesApp.cs.MainWindow();
            main.Hide();
            main.Hide();

            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Save_Employee();
        }
        public void Save_Employee()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                MessageBox.Show("Enter The Employee's UserName!", "UserName Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox1.Focus();
                textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
            {
                MessageBox.Show("Enter Employee Role", "Employee Role Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                comboBox1.Focus();
                comboBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox2.Text.ToString()))
            {
                MessageBox.Show("Select The Teacher's Class!", "Teacher Class !", 0, MessageBoxIcon.Exclamation);
                comboBox2.Focus();
                comboBox2.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox3.Text.ToString()))
            {
                MessageBox.Show("Enter The Subject Taught", "Subjects Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                comboBox3.Focus();
                comboBox3.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker2.Text.ToString()))
            {
                MessageBox.Show("Select The Date Of Birth!", "Date Of Birth Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                dateTimePicker2.Focus();
                dateTimePicker2.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text.ToString()))
            {
                MessageBox.Show("Enter The Employee's Age!", "Employee Age Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox3.Focus();
                textBox3.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text.ToString()))
            {
                MessageBox.Show("Enter The Employee's HomeTown!", "Employee Hometown Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox4.Focus();
                textBox4.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text.ToString()))
            {
                MessageBox.Show("Enter The Place Of Residence!", "Place Of Residence Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox5.Focus();
                textBox5.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text.ToString()))
            {
                MessageBox.Show("Input The Employee's Experience!", "Employee's Experience Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox6.Focus();
                textBox6.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text.ToString()))
            {
                MessageBox.Show("Select The Date Employed!", "Date Employed Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                dateTimePicker1.Focus();
                dateTimePicker1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox7.Text.ToString()))
            {
                MessageBox.Show("Input The Telephone Number!", "Employee's Telephone Number Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox7.Focus();
                textBox7.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox8.Text.ToString()))
            {
                MessageBox.Show("Input The Employee's Email!", "Employee's Email Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox8.Focus();
                textBox8.BackColor = Color.Pink;
                return;
            }
            //if (pictureBox1.Image = )
            //{
            //    MessageBox.Show("Upload THe Employees' Image!", "Employees' Image Cant Be Empty", 0, MessageBoxIcon.Exclamation);
            //    pictureBox1.Focus();
            //    //textBdesox6.BackColor = Color.Pink;
            //    return;
            //}

            try
            {
                byte[] images = null;
                FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                images = brs.ReadBytes((int)stream.Length);
                des.opencon();
                string sqlQuery = "INSERT INTO employees(name,EmpRole,TeacherClass,SubjectTaught,DOB,empAge,HomeTown,Residence,PastExp,DateEmployed,email,Num,Picture) Values(@txt1,@cbo1,@cbo2,@cbo3,@dtp2,@txt3,@txt4,@txt5,@txt6,@dtp1,@txt8,@txt7,@pic)";
                SqlCommand cmd = new SqlCommand(sqlQuery, des.returnCon());

                cmd.Parameters.Add(new SqlParameter("@pic", images));
                cmd.Parameters.AddWithValue("@txt1", textBox1.Text);
                cmd.Parameters.AddWithValue("@cbo1", comboBox1.Text);
                cmd.Parameters.AddWithValue("@cbo2", comboBox2.Text);
                cmd.Parameters.AddWithValue("@cbo3", comboBox3.Text);
                cmd.Parameters.AddWithValue("@dtp2", dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@txt3", textBox3.Text);
                cmd.Parameters.AddWithValue("@txt4", textBox4.Text);
                cmd.Parameters.AddWithValue("@txt5", textBox5.Text);
                cmd.Parameters.AddWithValue("@txt6", textBox6.Text);
                cmd.Parameters.AddWithValue("@dtp1", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@txt8", textBox8.Text);
                cmd.Parameters.AddWithValue("@txt7", textBox7.Text);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    // clear();
                    MessageBox.Show("Employee With Name '" + textBox1.Text + "' Saved Successfully.", "Saved", 0, MessageBoxIcon.Information);
                    this.employeesTableAdapter.Fill(this.dessySoftDataSet79.employees);
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
                des.closeCon();
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
            //bukgiuhn




        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            
            }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow click = dataGridView1.Rows[e.RowIndex];
                button5.Enabled = true;
                button4.Enabled = true;
                button3.Enabled = false;
                textBox2.Text = click.Cells[0].Value.ToString();
                textBox3.Text = click.Cells[6].Value.ToString();
                textBox1.Text = click.Cells[1].Value.ToString();
                comboBox1.Text = click.Cells[2].Value.ToString();
                comboBox2.Text = click.Cells[3].Value.ToString();
                comboBox3.Text = click.Cells[4].Value.ToString();

                dateTimePicker2.Text = click.Cells[5].Value.ToString();
                textBox4.Text = click.Cells[7].Value.ToString();
                textBox5.Text = click.Cells[8].Value.ToString();
                textBox6.Text = click.Cells[9].Value.ToString();
                dateTimePicker1.Text = click.Cells[10].Value.ToString();
                textBox8.Text = click.Cells[11].Value.ToString();
                textBox7.Text = click.Cells[12].Value.ToString();
                //textBox10.Text = click.Cells[11].Value.ToString();
                Byte[] data = new Byte[0];
                data = (Byte[])click.Cells[13].Value;
                MemoryStream mem = new MemoryStream(data);
                pictureBox1.Image = Image.FromStream(mem);
            }
    }
        public void clear()
        {
            button5.Enabled = false;
            button4.Enabled = false;
            button3.Enabled = true;
            textBox2.Clear();
            textBox1.Clear();
            comboBox1.Text = null;
            comboBox2.Text = null;
            comboBox3.Text = null;
            dateTimePicker2.Text = null;
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();
            textBox7.Clear();
            dateTimePicker1.Text = null;
            pictureBox1.Image = null;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            update();
        }
        public void update()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                MessageBox.Show("Enter The Employee's UserName!", "UserName Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox1.Focus();
                textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
            {
                MessageBox.Show("Enter Employee Role", "Employee Role Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                comboBox1.Focus();
                comboBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox2.Text.ToString()))
            {
                MessageBox.Show("Select The Teacher's Class!", "Teacher Class !", 0, MessageBoxIcon.Exclamation);
                comboBox2.Focus();
                comboBox2.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox3.Text.ToString()))
            {
                MessageBox.Show("Enter The Subject Taught", "Subjects Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                comboBox3.Focus();
                comboBox3.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker2.Text.ToString()))
            {
                MessageBox.Show("Select The Date Of Birth!", "Date Of Birth Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                dateTimePicker2.Focus();
                dateTimePicker2.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text.ToString()))
            {
                MessageBox.Show("Enter The Employee's Age!", "Employee Age Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox3.Focus();
                textBox3.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text.ToString()))
            {
                MessageBox.Show("Enter The Employee's HomeTown!", "Employee Hometown Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox4.Focus();
                textBox4.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text.ToString()))
            {
                MessageBox.Show("Enter The Place Of Residence!", "Place Of Residence Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox5.Focus();
                textBox5.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text.ToString()))
            {
                MessageBox.Show("Input The Employee's Experience!", "Employee's Experience Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox6.Focus();
                textBox6.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text.ToString()))
            {
                MessageBox.Show("Select The Date Employed!", "Date Employed Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                dateTimePicker1.Focus();
                dateTimePicker1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox7.Text.ToString()))
            {
                MessageBox.Show("Input The Telephone Number!", "Employee's Telephone Number Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox7.Focus();
                textBox7.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox8.Text.ToString()))
            {
                MessageBox.Show("Input The Employee's Email!", "Employee's Email Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox8.Focus();
                textBox8.BackColor = Color.Pink;
                return;
            }
            try
            {
                MemoryStream stream = new MemoryStream();
                pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] pic = stream.ToArray();
                des.opencon();
                string Query = "UPDATE employees SET name = @txt1 ,EmpRole = @cbo1,TeacherClass = @cbo2 ,SubjectTaught = @cbo3 ,DOB=@dtp2,empAge=@txt3,HomeTown= @txt4,Residence=@txt5,PastExp=@txt6,DateEmployed = @dtp1,email = @txt8,Num = @txt7,Picture =@pic  where id = @txt0";
                SqlCommand cmd = new SqlCommand(Query, des.returnCon());
                cmd.Parameters.AddWithValue("@txt1", textBox1.Text);
                cmd.Parameters.AddWithValue("@cbo1", comboBox1.Text);
                cmd.Parameters.AddWithValue("@cbo2", comboBox2.Text);
                cmd.Parameters.AddWithValue("@cbo3", comboBox3.Text);
                cmd.Parameters.AddWithValue("@dtp2", dateTimePicker2.Text);
                cmd.Parameters.AddWithValue("@txt3", textBox3.Text);
                cmd.Parameters.AddWithValue("@txt4", textBox4.Text);
                cmd.Parameters.AddWithValue("@txt5", textBox5.Text);
                cmd.Parameters.AddWithValue("@txt6", textBox6.Text);
                cmd.Parameters.AddWithValue("@dtp1", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@txt8", textBox8.Text);
                cmd.Parameters.AddWithValue("@txt7", textBox7.Text);
                cmd.Parameters.AddWithValue("@txt0", textBox2.Text);
                cmd.Parameters.AddWithValue("@pic",pic);
                if (cmd.ExecuteNonQuery() == 1)
                {
        
                     clear();
                    MessageBox.Show("Employee With Name '" + textBox1.Text + "' Is Updated Successfully.", "Updated", 0, MessageBoxIcon.Information);
                    this.employeesTableAdapter.Fill(this.dessySoftDataSet79.employees);
                }
                else
                {
                    MessageBox.Show("Error in Updating Data.", "Error", 0, MessageBoxIcon.Error);

                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                des.closeCon();
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            clear();
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
                dataGridView1.Visible = false;
                button7.Text = "VIEW";

            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text.ToString()))
            {
                MessageBox.Show("Enter The Employee's UserName!", "UserName Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox1.Focus();
                textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox1.Text.ToString()))
            {
                MessageBox.Show("Enter Employee Role", "Employee Role Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                comboBox1.Focus();
                comboBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox2.Text.ToString()))
            {
                MessageBox.Show("Select The Teacher's Class!", "Teacher Class !", 0, MessageBoxIcon.Exclamation);
                comboBox2.Focus();
                comboBox2.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox3.Text.ToString()))
            {
                MessageBox.Show("Enter The Subject Taught", "Subjects Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                comboBox3.Focus();
                comboBox3.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker2.Text.ToString()))
            {
                MessageBox.Show("Select The Date Of Birth!", "Date Of Birth Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                dateTimePicker2.Focus();
                dateTimePicker2.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text.ToString()))
            {
                MessageBox.Show("Enter The Employee's Age!", "Employee Age Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox3.Focus();
                textBox3.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text.ToString()))
            {
                MessageBox.Show("Enter The Employee's HomeTown!", "Employee Hometown Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox4.Focus();
                textBox4.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text.ToString()))
            {
                MessageBox.Show("Enter The Place Of Residence!", "Place Of Residence Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox5.Focus();
                textBox5.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text.ToString()))
            {
                MessageBox.Show("Input The Employee's Experience!", "Employee's Experience Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox6.Focus();
                textBox6.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text.ToString()))
            {
                MessageBox.Show("Select The Date Employed!", "Date Employed Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                dateTimePicker1.Focus();
                dateTimePicker1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox7.Text.ToString()))
            {
                MessageBox.Show("Input The Telephone Number!", "Employee's Telephone Number Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox7.Focus();
                textBox7.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox8.Text.ToString()))
            {
                MessageBox.Show("Input The Employee's Email!", "Employee's Email Cant Be Empty", 0, MessageBoxIcon.Exclamation);
                textBox8.Focus();
                textBox8.BackColor = Color.Pink;
                return;
            }
            try
            {
                des.opencon();
                SqlCommand cmd = new SqlCommand("Delete from employees where id = '" + textBox2.Text + "'",des.returnCon());
                if(cmd.ExecuteNonQuery() == 1)
                {
                    
                    MessageBox.Show("Employee With Name '" + textBox1.Text + "' Is Deleted Successfully.", "Updated", 0, MessageBoxIcon.Information);
                    this.employeesTableAdapter.Fill(this.dessySoftDataSet79.employees);
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
                des.closeCon();
            }

        }

        private void button8_Click(object sender, EventArgs e)
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
          
        }
    }
        }
    

