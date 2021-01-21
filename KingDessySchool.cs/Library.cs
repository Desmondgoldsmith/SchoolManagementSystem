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
using System.Globalization;
using excel = Microsoft.Office.Interop.Excel;
namespace KingDessySchool.cs
{
    public partial class Library : Form
    {
        public Library()
        {
            InitializeComponent();
        }

        omagaconnections dessy = new omagaconnections();
        String imglocation;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(170, Color.Black);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            panel2.BackColor = Color.FromArgb(190, Color.Black);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(190, Color.Black);

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            panel4.BackColor = Color.FromArgb(100, Color.Black);

        }

        private void panel23_Paint(object sender, PaintEventArgs e)
        {
            panel23.BackColor = Color.FromArgb(30, Color.Black);
            //button21.Enabled = false;
            //button22.Enabled = false;

        }

        private void Library_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet86.issueBook' table. You can move, or remove it, as needed.
            this.issueBookTableAdapter1.Fill(this.dessySoftDataSet86.issueBook);
            // TODO: This line of code loads data into the 'dessySoftDataSet85.issueBook' table. You can move, or remove it, as needed.
            this.issueBookTableAdapter.Fill(this.dessySoftDataSet85.issueBook);
            // TODO: This line of code loads data into the 'dessySoftDataSet82.LiReg' table. You can move, or remove it, as needed.
            this.liRegTableAdapter.Fill(this.dessySoftDataSet82.LiReg);
            //round picturebox
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, pictureBox1.Width - 3, pictureBox1.Height - 3);
            Region rg = new Region(gp);
            pictureBox1.Region = rg;

            button21.Visible = false;
            button22.Visible = false;
            

            // TODO: This line of code loads data into the 'dessySoftDataSet45.issueBook' table. You can move, or remove it, as needed.
         //   this.issueBookTableAdapter.Fill(this.dessySoftDataSet45.issueBook);
            //panel29 = return book
            //panel23 = register student
            //panel26 - add book
            //panel27-issue book
            panel23.Hide();
            panel26.Hide();
            panel27.Hide();
            textBox9.Visible = false;
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            dataGridView3.Visible = false;
            dataGridView4.Visible = false;
            textBox13.Visible = false;
            textBox14.Visible = false;
            textBox18.Visible = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel25.Visible = true;
            button21.Enabled = false;
            button22.Enabled = false;
            panel23.Show();
            panel23.BringToFront();
            // panel26.SendToBack();
            panel26.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            panel23.Hide();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        { //panel23.BringToFront();
          //    panel26.SendToBack();
            panel25.Visible = false;
            panel27.Hide();
            panel26.Show();
            panel23.Show();
            //panel23.Hide();


        }

        private void panel26_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel25.Visible = false;
            panel29.Hide();
            panel27.Show();
            panel26.Show();
            panel23.Show();

        }

        private void label25_Click(object sender, EventArgs e)
        {


        }

        private void button6_Click(object sender, EventArgs e)
        {


            if (string.IsNullOrWhiteSpace(textBox10.Text.ToString()))
            {
                MessageBox.Show("Enter The Student's Name!", "Error", 0, MessageBoxIcon.Exclamation);
                textBox10.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox4.Text.ToString()))
            {
                MessageBox.Show("Select The Student's Class!", "Error", 0, MessageBoxIcon.Exclamation);
                comboBox4.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker4.Text.ToString()))
            {
                MessageBox.Show("Select Today's Date!", "Error", 0, MessageBoxIcon.Exclamation);
                dateTimePicker4.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox5.Text.ToString()))
            {
                MessageBox.Show("Select The Gender!", "Error", 0, MessageBoxIcon.Exclamation);
                comboBox5.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox11.Text.ToString()))
            {
                MessageBox.Show("Input The Class Teacher's Name !", "Error", 0, MessageBoxIcon.Exclamation);
                textBox11.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }

            try
            {

                //byte[] images = null;
                //FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                //BinaryReader brs = new BinaryReader(stream);
                //images = brs.ReadBytes((int)stream.Length);
                dessy.opencon();
                SqlCommand cmd = new SqlCommand("stSaveLi", dessy.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@sn", textBox10.Text);
                cmd.Parameters.AddWithValue("@c", comboBox4.Text);
                cmd.Parameters.AddWithValue("@d", dateTimePicker4.Text);
                cmd.Parameters.AddWithValue("@g", comboBox5.Text);
                cmd.Parameters.AddWithValue("@t", textBox11.Text);
                //cmd.Parameters.Add(new SqlParameter("@i", images));

                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Data Saved Successfully", "Saved", 0, MessageBoxIcon.Information);
                     clear();
                }
                else
                {
                    MessageBox.Show("Error", "Error!!!", 0, MessageBoxIcon.Error);

                }
                dessy.opencon();
                string query = "SELECT COUNT(*) FROM LiReg ";
                SqlCommand cmdx = new SqlCommand(query, dessy.returnCon());
                Int32 count = Convert.ToInt32(cmdx.ExecuteScalar());
                this.label2.Text = count.ToString();

                dessy.closeCon();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                dessy.closeCon();
            }

        }

        private void button7_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox10.Text.ToString()))
            {
                MessageBox.Show("Enter The Student's Name!", "Error", 0, MessageBoxIcon.Exclamation);
                textBox10.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox4.Text.ToString()))
            {
                MessageBox.Show("Select The Student's Class!", "Error", 0, MessageBoxIcon.Exclamation);
                comboBox4.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker4.Text.ToString()))
            {
                MessageBox.Show("Select Today's Date!", "Error", 0, MessageBoxIcon.Exclamation);
                dateTimePicker4.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox5.Text.ToString()))
            {
                MessageBox.Show("Select The Gender!", "Error", 0, MessageBoxIcon.Exclamation);
                comboBox5.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox11.Text.ToString()))
            {
                MessageBox.Show("Input The Class Teacher's Name !", "Error", 0, MessageBoxIcon.Exclamation);
                textBox11.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }

            try
            {
                //MemoryStream stream = new MemoryStream();
                //pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //Byte[] pic = stream.ToArray();
                dessy.opencon();
                SqlCommand cmd = new SqlCommand("stUpdateLi", dessy.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", textBox9.Text);
                cmd.Parameters.AddWithValue("@sn", textBox10.Text);
                cmd.Parameters.AddWithValue("@c", comboBox4.Text);
                cmd.Parameters.AddWithValue("@d", dateTimePicker4.Text);
                cmd.Parameters.AddWithValue("@g", comboBox5.Text);
                cmd.Parameters.AddWithValue("@t", textBox11.Text);
                //cmd.Parameters.AddWithValue("@i", pic);

                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Student With Firstname '" + textBox10.Text + "' Is Updated Successfully", "Updated Successfully", 0, MessageBoxIcon.Information);
                    //                    clear();
                }
                else
                {
                    MessageBox.Show("Error Updating Record With Firstname '" + textBox10.Text + "'", "Error!!!", 0, MessageBoxIcon.Error);

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                dessy.closeCon();
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(textBox10.Text.ToString()))
            {
                MessageBox.Show("Enter The Student's Name!", "Error", 0, MessageBoxIcon.Exclamation);
                textBox10.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox4.Text.ToString()))
            {
                MessageBox.Show("Select The Student's Class!", "Error", 0, MessageBoxIcon.Exclamation);
                comboBox4.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker4.Text.ToString()))
            {
                MessageBox.Show("Select Today's Date!", "Error", 0, MessageBoxIcon.Exclamation);
                dateTimePicker4.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox5.Text.ToString()))
            {
                MessageBox.Show("Select The Gender!", "Error", 0, MessageBoxIcon.Exclamation);
                comboBox5.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox11.Text.ToString()))
            {
                MessageBox.Show("Input The Class Teacher's Name !", "Error", 0, MessageBoxIcon.Exclamation);
                textBox11.Focus();
                //textBox1.BackColor = Color.Pink;
                return;
            }
            try
            {
                if (MessageBox.Show("THIS ACTION CAN NEVER BE REVERSED. ARE YOU SURE YOU WANT TO DELETE?", "DELETE RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)

                    dessy.opencon();
                SqlCommand cmd = new SqlCommand("DELETE from LiReg where id = '" + textBox9.Text + "'", dessy.returnCon());
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Student With Firstname '" + textBox10.Text + "' Is Deleted Successfully", "Deleted Successfully", 0, MessageBoxIcon.Information);
                    //                    clear();
                }
                else
                {
                    MessageBox.Show("Error Deleting Record With Name'" + textBox10.Text + "'", "Error!!!", 0, MessageBoxIcon.Error);

                }
                //count rows in the database
                dessy.opencon();
                string query = "SELECT COUNT(*) FROM LiReg ";
                SqlCommand cmdx = new SqlCommand(query, dessy.returnCon());
                Int32 count = Convert.ToInt32(cmdx.ExecuteScalar());
                this.label2.Text = count.ToString();

                dessy.closeCon();

            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);

            }
            finally
            {
                dessy.closeCon();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible != true)
            {
                //LOADS DATA TO DATA GRID
                dataGridView1.Visible = true;
                button9.Text = "HIDE";
                dessy.opencon();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LiReg", dessy.returnCon());
                DataTable dt = new DataTable();
                da.Fill(dt);
                //byte[] data = (byte[])dt.Rows[0]["pic"];
                //MemoryStream ms = new MemoryStream(data);
                ////pictureBox2.Image = Image.FromStream(ms);
                dataGridView1.DataSource = dt;
            }
            else
            {
                dataGridView1.Visible = false;
                button9.Text = "VIEW";
            }
        }





        private void panel24_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            clear();
            //pictureBox2.Image = null;
        }
        public void clear()
        {
            button22.Enabled = false;
            button21.Enabled = false;
            button20.Enabled = true;
            textBox10.Clear();
            comboBox4.Text = null;
            dateTimePicker4.Text = null;
            comboBox5.Text = null;
            textBox11.Clear();
            textBox9.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow click = dataGridView1.Rows[e.RowIndex];
                textBox9.Text = click.Cells[0].Value.ToString();
                textBox10.Text = click.Cells[1].Value.ToString();
                comboBox4.Text = click.Cells[2].Value.ToString();
                dateTimePicker4.Text = click.Cells[3].Value.ToString();
                comboBox5.Text = click.Cells[4].Value.ToString();
                textBox11.Text = click.Cells[5].Value.ToString();
                // pictureBox2.Image = click.GetValue(6);
                //Byte[] data = new Byte[0];
                //data = (Byte[])click.Cells[6].Value;
                //MemoryStream mem = new MemoryStream(data);
                //pictureBox2.Image = Image.FromStream(mem);
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox25_TextChanged(object sender, EventArgs e)
        {
            //search
            try
            {

                string search = textBox12.Text;
                SqlCommand cmd = new SqlCommand("select * from LiReg where CONCAT(id,name) like '%" + textBox12.Text + "%'", dessy.returnCon());
                SqlDataAdapter sda = new SqlDataAdapter("select * from LiReg  where CONCAT(id,name) like '%" + textBox12.Text + "%'", dessy.returnCon());
                button21.Enabled = true;
                button22.Enabled = true;
                button20.Enabled = false;
                //cmd.Parameters.AddWithValue("@fname", search);
                //cmd.Parameters.AddWithValue("@lname", search);
                dessy.opencon();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView1.DataSource = dt;
                //end
                dessy.opencon();
                SqlDataReader rd;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    textBox9.Text = rd.GetValue(0).ToString();
                    textBox10.Text = rd.GetValue(1).ToString();
                    comboBox4.Text = rd.GetValue(2).ToString();
                    dateTimePicker4.Text = rd.GetValue(3).ToString();
                    comboBox5.Text = rd.GetValue(4).ToString();
                    textBox11.Text = rd.GetValue(5).ToString();

                    if (string.IsNullOrEmpty(textBox12.Text.ToString()))
                    {
                        clear();
                    }
                    rd.Close();
                }
                else
                {
                    rd.Close();
                    MessageBox.Show("NO RECORD AVAILABLE WITH NAME '" + textBox12.Text + "'", " RECORD DOES NOT EXIST", 0, MessageBoxIcon.Error);
                    textBox12.Clear();

                    clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dessy.closeCon();

            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label34_Click(object sender, EventArgs e)
        {
            panel23.Hide();
        }

        private void label39_Click(object sender, EventArgs e)
        {
            panel23.Hide();
            panel26.Hide();
        }

        private void label38_Click(object sender, EventArgs e)
        {
            panel23.Hide();
            panel26.Hide();
            panel27.Hide();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text.ToString()))
            {
                MessageBox.Show("Enter Book Name", "Error", 0, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text.ToString()))
            {
                MessageBox.Show("Enter Author Name", "Error", 0, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text.ToString()))
            {
                MessageBox.Show("Enter Book Type", "Error", 0, MessageBoxIcon.Information);
                textBox5.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text.ToString()))
            {
                MessageBox.Show("Enter The Book's Number Of Pages", "Error", 0, MessageBoxIcon.Information);
                textBox6.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker2.Text.ToString()))
            {
                MessageBox.Show("Enter Date Registered", "Error", 0, MessageBoxIcon.Information);
                dateTimePicker2.Focus();
                return;
            }
            try
            {

                //byte[] images = null;
                //FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                //BinaryReader brs = new BinaryReader(stream);
                //images = brs.ReadBytes((int)stream.Length);
                dessy.opencon();
                SqlCommand cmd = new SqlCommand("RegBook", dessy.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@bn", textBox3.Text);
                cmd.Parameters.AddWithValue("@a", textBox4.Text);
                cmd.Parameters.AddWithValue("@bt", textBox5.Text);
                cmd.Parameters.AddWithValue("@np", textBox6.Text);
                cmd.Parameters.AddWithValue("@da", dateTimePicker2.Text);
                //cmd.Parameters.Add(new SqlParameter("@i", images));

                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Book With Title '" + textBox3.Text + "' Saved Successfully", "Saved", 0, MessageBoxIcon.Information);
                     Clear();
                    button14.Text = "REFRESH";
                    button14.ForeColor = Color.Red;
                }
                else
                {
                    MessageBox.Show("Error", "Error!!!", 0, MessageBoxIcon.Error);

                }
                dessy.opencon();
                string query = "SELECT COUNT(*) FROM LiRegBook ";
                SqlCommand cmdx = new SqlCommand(query, dessy.returnCon());
                Int32 count = Convert.ToInt32(cmdx.ExecuteScalar());
                this.label5.Text = count.ToString();

                dessy.closeCon();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                dessy.closeCon();
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text.ToString()))
            {
                MessageBox.Show("Enter Book Name", "Error", 0, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text.ToString()))
            {
                MessageBox.Show("Enter Author Name", "Error", 0, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text.ToString()))
            {
                MessageBox.Show("Enter Book Type", "Error", 0, MessageBoxIcon.Information);
                textBox5.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text.ToString()))
            {
                MessageBox.Show("Enter The Book's Number Of Pages", "Error", 0, MessageBoxIcon.Information);
                textBox6.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker2.Text.ToString()))
            {
                MessageBox.Show("Enter Date Registered", "Error", 0, MessageBoxIcon.Information);
                dateTimePicker2.Focus();
                return;
            }
            try
            {
                //MemoryStream stream = new MemoryStream();
                //pictureBox1.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                //Byte[] pic = stream.ToArray();
                dessy.opencon();
                SqlCommand cmd = new SqlCommand("UpdateRegBook", dessy.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", textBox13.Text);
                cmd.Parameters.AddWithValue("@bn", textBox3.Text);
                cmd.Parameters.AddWithValue("@a", textBox4.Text);
                cmd.Parameters.AddWithValue("@bt", textBox5.Text);
                cmd.Parameters.AddWithValue("@np", textBox6.Text);
                cmd.Parameters.AddWithValue("@da", dateTimePicker2.Text);
                //cmd.Parameters.AddWithValue("@i", pic);

                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Book With Name '" + textBox3.Text + "' Is Updated Successfully", "Updated Successfully", 0, MessageBoxIcon.Information);
                    //                    clear();
                }
                else
                {
                    MessageBox.Show("Error Updating Book With Name '" + textBox3.Text + "'", "Error!!!", 0, MessageBoxIcon.Error);

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                dessy.closeCon();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox3.Text.ToString()))
            {
                MessageBox.Show("Enter Book Name", "Error", 0, MessageBoxIcon.Information);
                textBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text.ToString()))
            {
                MessageBox.Show("Enter Author Name", "Error", 0, MessageBoxIcon.Information);
                textBox4.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text.ToString()))
            {
                MessageBox.Show("Enter Book Type", "Error", 0, MessageBoxIcon.Information);
                textBox5.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text.ToString()))
            {
                MessageBox.Show("Enter The Book's Number Of Pages", "Error", 0, MessageBoxIcon.Information);
                textBox6.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker2.Text.ToString()))
            {
                MessageBox.Show("Enter Date Registered", "Error", 0, MessageBoxIcon.Information);
                dateTimePicker2.Focus();
                return;
            }
            try
            {
                if (MessageBox.Show("THIS ACTION CAN NEVER BE REVERSED. ARE YOU SURE YOU WANT TO DELETE?", "DELETE RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)

                    dessy.opencon();
                SqlCommand cmd = new SqlCommand("DELETE from LiRegBook where id = '" + textBox13.Text + "'", dessy.returnCon());
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Book With Name '" + textBox3.Text + "' Is Deleted Successfully", "Deleted Successfully", 0, MessageBoxIcon.Information);
                    //                    clear();
                }
                else
                {
                    MessageBox.Show("Error Deleting Record With Name'" + textBox10.Text + "'", "Error!!!", 0, MessageBoxIcon.Error);

                }
                //count rows in the database
                dessy.opencon();
                string query = "SELECT COUNT(*) FROM LiRegBook ";
                SqlCommand cmdx = new SqlCommand(query, dessy.returnCon());
                Int32 count = Convert.ToInt32(cmdx.ExecuteScalar());
                this.label5.Text = count.ToString();

                dessy.closeCon();

            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);

            }
            finally
            {
                dessy.closeCon();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Visible != true)
            {
                dataGridView2.Visible = true;
                button14.Text = "HIDE";
                button14.ForeColor = Color.White;
                dessy.opencon();
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LiRegBook", dessy.returnCon());
                DataTable dt = new DataTable();
                da.Fill(dt);
                //byte[] data = (byte[])dt.Rows[0]["pic"];
                //MemoryStream ms = new MemoryStream(data);
                ////pictureBox2.Image = Image.FromStream(ms);
                dataGridView2.DataSource = dt;
            }
            else
            {
                dataGridView2.Visible = false;
                button14.Text = "VIEW";
                button14.ForeColor = Color.Yellow;

            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Clear();

        }
        public void Clear()
        {
            textBox18.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            dateTimePicker2.Text = null;

        }

        private void button15_Click(object sender, EventArgs e)
        {
            excel.Application app = new excel.Application();
            excel.Workbook workbook = app.Workbooks.Add();
            excel.Worksheet Worksheet = null;
            app.Visible = true;
            Worksheet = workbook.Sheets["sheet1"];
            Worksheet = workbook.ActiveSheet;
            for (int i = 0; i < dataGridView2.Columns.Count; i++)
            {
                Worksheet.Cells[1, i + 1] = dataGridView2.Columns[i].HeaderText;
            }

            for (int j = 0; j <= dataGridView2.Rows.Count - 1; j++)
            {

                for (int i = 0; i < dataGridView2.Columns.Count; i++)
                {

                    Worksheet.Cells[j + 2, i + 1] = dataGridView2.Rows[j].Cells[i].Value.ToString();
                }
            }
            Worksheet.Columns.AutoFit();
            //Worksheet.Columns.Text.Bold();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow click = dataGridView2.Rows[e.RowIndex];
                textBox13.Text = click.Cells[0].Value.ToString();
                textBox3.Text = click.Cells[1].Value.ToString();
                textBox4.Text = click.Cells[2].Value.ToString();
                textBox5.Text = click.Cells[3].Value.ToString();
                textBox6.Text = click.Cells[4].Value.ToString();
                dateTimePicker2.Text = click.Cells[5].Value.ToString();
                // pictureBox2.Image = click.GetValue(6);
                //Byte[] data = new Byte[0];
                //data = (Byte[])click.Cells[6].Value;
                //MemoryStream mem = new MemoryStream(data);
                //pictureBox2.Image = Image.FromStream(mem);
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox7.Text.ToString()))
            {
                MessageBox.Show("Input Student's Name", "ERROR", 0, MessageBoxIcon.Information);
                textBox7.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox3.Text.ToString()))
            {
                MessageBox.Show("Input Student's Class", "ERROR", 0, MessageBoxIcon.Information);
                comboBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox8.Text.ToString()))
            {
                MessageBox.Show("Input Book Name", "ERROR", 0, MessageBoxIcon.Information);
                textBox8.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker3.Text.ToString()))
            {
                MessageBox.Show("SELECT DATE ISSUED", "ERROR", 0, MessageBoxIcon.Information);
                dateTimePicker3.Focus();
                return;
            }
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Upload Student's Image", "ERROR", 0, MessageBoxIcon.Information);
                pictureBox2.Focus();
                return;
            }
            try
            {
                byte[] images = null;
                FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                BinaryReader brs = new BinaryReader(stream);
                images = brs.ReadBytes((int)stream.Length);
                dessy.opencon();
                SqlCommand cmd = new SqlCommand("PRissueBook", dessy.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@sn", textBox7.Text);
                cmd.Parameters.AddWithValue("@sc", comboBox3.Text);
                cmd.Parameters.AddWithValue("@bn", textBox8.Text);
                cmd.Parameters.AddWithValue("@di", dateTimePicker3.Text);
                cmd.Parameters.AddWithValue("@ti", dateTimePicker7.Text);
                cmd.Parameters.Add(new SqlParameter("@i", images));

                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("BOOK WITH NAME '" + textBox8.Text + "' ISSUED TO '" + textBox7.Text + "' SUCCESSFULLY", "ISSUED!", 0, MessageBoxIcon.Information);
                    this.issueBookTableAdapter.Fill(this.dessySoftDataSet85.issueBook);


                    //count the issue book table to find number of books issued 
                    string query2 = "SELECT COUNT(*) FROM issueBook ";
                    SqlCommand cmdx2 = new SqlCommand(query2, dessy.returnCon());
                    Int32 count2 = Convert.ToInt32(cmdx2.ExecuteScalar());
                    this.label7.Text = count2.ToString();

                    ClearIssueBook();
                }
                else
                {
                    MessageBox.Show("CANNOT ISSUE THIS BOOK WITH NAME '" + textBox8.Text + "'", "Error!!!", 0, MessageBoxIcon.Error);

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                dessy.closeCon();
            }
        }

        private void panel24_Click(object sender, EventArgs e)
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
            //bukgiuhn
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //update for issue book
            if (string.IsNullOrWhiteSpace(textBox7.Text.ToString()))
            {
                MessageBox.Show("Input Student's Name", "ERROR", 0, MessageBoxIcon.Information);
                textBox7.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox3.Text.ToString()))
            {
                MessageBox.Show("Input Student's Class", "ERROR", 0, MessageBoxIcon.Information);
                comboBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox8.Text.ToString()))
            {
                MessageBox.Show("Input Book Name", "ERROR", 0, MessageBoxIcon.Information);
                textBox8.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker3.Text.ToString()))
            {
                MessageBox.Show("SELECT DATE ISSUED", "ERROR", 0, MessageBoxIcon.Information);
                dateTimePicker3.Focus();
                return;
            }
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Upload Student's Image", "ERROR", 0, MessageBoxIcon.Information);
                pictureBox2.Focus();
                return;
            }
            try
            {
                MemoryStream stream = new MemoryStream();
                pictureBox2.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] pic = stream.ToArray();
                dessy.opencon();
                SqlCommand cmd = new SqlCommand("PRissueBookUpdate", dessy.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", textBox14.Text);
                cmd.Parameters.AddWithValue("@sn", textBox7.Text);
                cmd.Parameters.AddWithValue("@sc", comboBox3.Text);
                cmd.Parameters.AddWithValue("@bn", textBox8.Text);
                cmd.Parameters.AddWithValue("@di", dateTimePicker3.Text);
                cmd.Parameters.AddWithValue("@ti", dateTimePicker7.Text);
                cmd.Parameters.AddWithValue("@i", pic);

                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Book With Name '" + textBox8.Text + "' Is Updated Successfully", "Updated Successfully", 0, MessageBoxIcon.Information);
                    this.issueBookTableAdapter.Fill(this.dessySoftDataSet85.issueBook);

                    ClearIssueBook();
                }
                else
                {
                    MessageBox.Show("Error Updating Book Record With Name '" + textBox8.Text + "'", "Error!!!", 0, MessageBoxIcon.Error);

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                dessy.closeCon();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {
            //deleting book from issueBook Table
            if (string.IsNullOrWhiteSpace(textBox7.Text.ToString()))
            {
                MessageBox.Show("Input Student's Name", "ERROR", 0, MessageBoxIcon.Information);
                textBox7.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox3.Text.ToString()))
            {
                MessageBox.Show("Input Student's Class", "ERROR", 0, MessageBoxIcon.Information);
                comboBox3.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox8.Text.ToString()))
            {
                MessageBox.Show("Input Book Name", "ERROR", 0, MessageBoxIcon.Information);
                textBox8.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker3.Text.ToString()))
            {
                MessageBox.Show("SELECT DATE ISSUED", "ERROR", 0, MessageBoxIcon.Information);
                dateTimePicker3.Focus();
                return;
            }
            if (pictureBox2.Image == null)
            {
                MessageBox.Show("Upload Student's Image", "ERROR", 0, MessageBoxIcon.Information);
                pictureBox2.Focus();
                return;
            }
            try
            {
                if (MessageBox.Show("THIS ACTION CAN NEVER BE REVERSED. ARE YOU SURE YOU WANT TO DELETE?", "DELETE RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    dessy.opencon();
                SqlCommand cmd = new SqlCommand("DELETE from issueBook where id = '" + textBox14.Text + "'", dessy.returnCon());
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Book With Name '" + textBox8.Text + "' Is Removed Successfully", "Deleted Successfully", 0, MessageBoxIcon.Information);
                    this.issueBookTableAdapter.Fill(this.dessySoftDataSet85.issueBook);

                    //count the issue book table to find number of books issued 
                    string query2 = "SELECT COUNT(*) FROM issueBook ";
                    SqlCommand cmdx2 = new SqlCommand(query2, dessy.returnCon());
                    Int32 count2 = Convert.ToInt32(cmdx2.ExecuteScalar());
                    this.label7.Text = count2.ToString();

                    ClearIssueBook();
                }
                else
                {
                    MessageBox.Show("Error Deleting Record With Firstname '" + textBox1.Text + "'", "Error!!!", 0, MessageBoxIcon.Error);

                }




            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);

            }
            finally
            {
                dessy.closeCon();
            }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            ClearIssueBook();
        }
        public void ClearIssueBook()
        {
            textBox7.Clear();
            comboBox3.Text = null;
            textBox8.Clear();
            dateTimePicker3.Text = null;
            pictureBox2.Image = null;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (dataGridView3.Visible == false)
            {
                dataGridView3.Visible = true;
                button26.Text = "HIDE";
            }
            else if (dataGridView3.Visible == true)
            {
                dataGridView3.Visible = false;
                button26.Text = "VIEW";

            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow click1 = dataGridView3.Rows[e.RowIndex];
                textBox14.Text = click1.Cells[0].Value.ToString();
                textBox7.Text = click1.Cells[1].Value.ToString();
                comboBox3.Text = click1.Cells[2].Value.ToString();
                textBox8.Text = click1.Cells[3].Value.ToString();
                dateTimePicker3.Text = click1.Cells[4].Value.ToString();
                dateTimePicker7.Text = click1.Cells[5].Value.ToString();

                //textBox15.Text = click1.Cells[5].Value.ToString();
                Byte[] data1 = new Byte[0];
                data1 = (Byte[])click1.Cells[6].Value;
                MemoryStream mem1 = new MemoryStream(data1);
                pictureBox2.Image = Image.FromStream(mem1);
            }
        }

        private void button31_Click(object sender, EventArgs e)
        {

        }

        private void label40_Click(object sender, EventArgs e)
        {
            panel23.Hide();
            panel26.Hide();
            panel27.Hide();
            panel29.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel25.Visible = false;
            panel27.Show();
            panel26.Show();
            panel23.Show();
            panel29.Show();
            dataGridView4.Refresh();

        }

        private void button30_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox19.Text.ToString()))
            {
                MessageBox.Show("Input Student's Name", "ERROR", 0, MessageBoxIcon.Information);
                textBox19.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox6.Text.ToString()))
            {
                MessageBox.Show("Input Student's Class", "ERROR", 0, MessageBoxIcon.Information);
                comboBox6.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox17.Text.ToString()))
            {
                MessageBox.Show("Input Book Name", "ERROR", 0, MessageBoxIcon.Information);
                textBox17.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker5.Text.ToString()))
            {
                MessageBox.Show("SELECT DATE ISSUED", "ERROR", 0, MessageBoxIcon.Information);
                dateTimePicker5.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker6.Text.ToString()))
            {
                MessageBox.Show("INPUT DATE RETURNED", "ERROR", 0, MessageBoxIcon.Information);
                dateTimePicker6.Focus();
                return;
            }
            if (pictureBox3.Image == null)
            {
                MessageBox.Show("Upload Student's Image", "ERROR", 0, MessageBoxIcon.Information);
                pictureBox3.Focus();
                return;
            }
            try
            {
                MemoryStream stream = new MemoryStream();
                pictureBox3.Image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] pic = stream.ToArray();
                dessy.opencon();
                SqlCommand cmd = new SqlCommand("PRreturnBookUpdate", dessy.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@id", textBox18.Text);
                cmd.Parameters.AddWithValue("@sn", textBox19.Text);
                cmd.Parameters.AddWithValue("@sc", comboBox6.Text);
                cmd.Parameters.AddWithValue("@bn", textBox17.Text);
                cmd.Parameters.AddWithValue("@di", dateTimePicker5.Text);
                cmd.Parameters.AddWithValue("@ti", dateTimePicker8.Text);

                cmd.Parameters.AddWithValue("@dr", dateTimePicker6.Text);
                cmd.Parameters.AddWithValue("@i", pic);

                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Book With Name '" + textBox17.Text + "' HAS BEEN RETURNEB BY '" + textBox19.Text + "'  Successfully", "Updated Successfully", 0, MessageBoxIcon.Information);
                    this.issueBookTableAdapter1.Fill(this.dessySoftDataSet86.issueBook);

                    //count the returned date column to find the number of books returned (num of columns which are not null)
                    string query3 = "SELECT  COUNT(DateReturned)  FROM issueBook ";
                    SqlCommand cmdx3 = new SqlCommand(query3, dessy.returnCon());
                    Int32 count3 = Convert.ToInt32(cmdx3.ExecuteScalar());
                    this.label9.Text = count3.ToString();

                    clearReturnBook(); //clear controls


                }
                else
                {
                    MessageBox.Show("Error Updating Book Record With Name '" + textBox17.Text + "'", "Error!!!", 0, MessageBoxIcon.Error);

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                dessy.closeCon();
            }
        }

        private void panel29_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button27_Click(object sender, EventArgs e)
        {
            if (dataGridView4.Visible == false)
            {
                dataGridView4.Visible = true;
                button27.Text = "HIDE";
            }
            else if (dataGridView4.Visible == true)
            {
                dataGridView4.Visible = false;
                button27.Text = "VIEW";

            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            //deleting book from issueBook Table
            if (string.IsNullOrWhiteSpace(textBox19.Text.ToString()))
            {
                MessageBox.Show("Input Student's Name", "ERROR", 0, MessageBoxIcon.Information);
                textBox19.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(comboBox6.Text.ToString()))
            {
                MessageBox.Show("Input Student's Class", "ERROR", 0, MessageBoxIcon.Information);
                comboBox6.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBox17.Text.ToString()))
            {
                MessageBox.Show("Input Book Name", "ERROR", 0, MessageBoxIcon.Information);
                textBox17.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker5.Text.ToString()))
            {
                MessageBox.Show("SELECT DATE ISSUED", "ERROR", 0, MessageBoxIcon.Information);
                dateTimePicker5.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker6.Text.ToString()))
            {
                MessageBox.Show("SELECT DATE ISSUED", "ERROR", 0, MessageBoxIcon.Information);
                dateTimePicker6.Focus();
                return;
            }
            if (pictureBox3.Image == null)
            {
                MessageBox.Show("Upload Student's Image", "ERROR", 0, MessageBoxIcon.Information);
                pictureBox3.Focus();
                return;
            }
            try
            {
                if (MessageBox.Show("THIS ACTION CAN NEVER BE REVERSED. ARE YOU SURE YOU WANT TO DELETE?", "DELETE RECORD", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    dessy.opencon();
                SqlCommand cmd = new SqlCommand("DELETE from issueBook where id = '" + textBox17.Text + "'", dessy.returnCon());
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Book With Name '" + textBox17.Text + "' Is Removed Successfully", "Deleted Successfully", 0, MessageBoxIcon.Information);
                    this.issueBookTableAdapter1.Fill(this.dessySoftDataSet86.issueBook);

                    //count the issue book table to find number of books issued 
                    string query2 = "SELECT COUNT(*) FROM issueBook ";
                    SqlCommand cmdx2 = new SqlCommand(query2, dessy.returnCon());
                    Int32 count2 = Convert.ToInt32(cmdx2.ExecuteScalar());
                    this.label7.Text = count2.ToString();
                    ClearIssueBook(); //clear controls
                }
                else
                {
                    MessageBox.Show("Error Deleting Book Record With Name '" + textBox17.Text + "'", "Error!!!", 0, MessageBoxIcon.Error);

                }




            }
            catch (Exception)
            {
                // MessageBox.Show(ex.Message);

            }
            finally
            {
                dessy.closeCon();
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //loading data frm the cells of datagrid to controls under cell click event

            if (e.RowIndex >= 0)
            {
                DataGridViewRow click1 = dataGridView3.Rows[e.RowIndex];
                textBox18.Text = click1.Cells[0].Value.ToString();
                textBox19.Text = click1.Cells[1].Value.ToString();
                comboBox6.Text = click1.Cells[2].Value.ToString();
                textBox17.Text = click1.Cells[3].Value.ToString();
                dateTimePicker5.Text = click1.Cells[4].Value.ToString();
                dateTimePicker8.Text = click1.Cells[5].Value.ToString();

                //dateTimePicker6.Value = DateTime.ParseExact(
                //    click1.Cells[5].Value.ToString(),
                //    "dd-MMM-yy",
                //    CultureInfo.InvariantCulture);
                //dateTimePicker6.Text = click1.Cells[5].Value.ToString();
                Byte[] data1 = new Byte[0];
                data1 = (Byte[])click1.Cells[6].Value;
                MemoryStream mem1 = new MemoryStream(data1);
                pictureBox3.Image = Image.FromStream(mem1);
            }
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker6.CustomFormat = "dd/mm/yyy hh:mm:ss";
            dateTimePicker6.Format = DateTimePickerFormat.Long;
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox15_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string search = textBox15.Text;
                //view record in controls
                SqlCommand cmd = new SqlCommand("select * from issueBook  where CONCAT(StudName,BookName) like '%" + textBox15.Text + "%' ", dessy.returnCon());
                //view records in datagrid
                SqlDataAdapter sda = new SqlDataAdapter("select * from issueBook  where CONCAT(StudName,BookName) like '%" + textBox15.Text + "%'", dessy.returnCon());

                //cmd.Parameters.AddWithValue("@fname", search);
                //cmd.Parameters.AddWithValue("@lname", search);
                dessy.opencon();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView3.DataSource = dt;
                //end of view record in data grid
                SqlDataReader rd;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    textBox14.Text = rd.GetValue(0).ToString();
                    textBox7.Text = rd.GetValue(1).ToString();
                    comboBox3.Text = rd.GetValue(2).ToString();
                    textBox8.Text = rd.GetValue(3).ToString();
                    dateTimePicker3.Text = rd.GetValue(4).ToString();
                    dateTimePicker7.Text = rd.GetValue(5).ToString();
                    Byte[] data = new Byte[0];
                    data = (Byte[])rd.GetValue(6);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox2.Image = Image.FromStream(mem);
                    if (string.IsNullOrWhiteSpace(textBox15.Text.ToString()))
                    {
                        ClearIssueBook();
                    }
                }
                else
                {
                    rd.Close();
                    MessageBox.Show("NO RECORD AVAILABLE WITH STUDENT NAME '" + textBox7.Text + "' Or BOOK NAME  '" + textBox8.Text + "'", " RECORD DOES NOT EXIST", 0, MessageBoxIcon.Error);
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

            }
        }

        private void button28_Click(object sender, EventArgs e)
        {

            clearReturnBook();
        }
        public void clearReturnBook()
        {
            textBox18.Clear();
            textBox19.Clear();
            comboBox6.Text = null;
            textBox17.Clear();
            dateTimePicker5.Text = null;
            dateTimePicker6.Text = null;
            dateTimePicker8.Text = null;
            pictureBox3.Image = null;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel30_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string search = textBox16.Text;
                //view record in controls
                SqlCommand cmd = new SqlCommand("select * from issueBook  where CONCAT(StudName,BookName) like '%" + textBox16.Text + "%' ", dessy.returnCon());
                //view records in datagrid
                SqlDataAdapter sda = new SqlDataAdapter("select * from issueBook  where CONCAT(StudName,BookName) like '%" + textBox16.Text + "%'", dessy.returnCon());

                //cmd.Parameters.AddWithValue("@fname", search);
                //cmd.Parameters.AddWithValue("@lname", search);
                dessy.opencon();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView4.DataSource = dt;
                //end of view record in data grid
                SqlDataReader rd;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    textBox18.Text = rd.GetValue(0).ToString();
                    textBox19.Text = rd.GetValue(1).ToString();
                    comboBox6.Text = rd.GetValue(2).ToString();
                    textBox17.Text = rd.GetValue(3).ToString();
                    dateTimePicker5.Text = rd.GetValue(4).ToString();
                    dateTimePicker8.Text = rd.GetValue(5).ToString();
                    //        dateTimePicker6.Text = rd.GetValue(6).ToString();
                    Byte[] data = new Byte[0];
                    data = (Byte[])rd.GetValue(6);
                    MemoryStream mem = new MemoryStream(data);
                    pictureBox3.Image = Image.FromStream(mem);
                    if (string.IsNullOrWhiteSpace(textBox16.Text.ToString()))
                    {
                        clearReturnBook();

                    }
                }
                else
                {
                    rd.Close();
                    MessageBox.Show("NO RECORD AVAILABLE WITH  NAME '" + textBox19.Text + "' Or BOOK NAME  '" + textBox17.Text + "'", " RECORD DOES NOT EXIST", 0, MessageBoxIcon.Error);
                    textBox16.Clear();
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

            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var loginxx = new DessySchoolComplesApp.cs.login();

            if (MessageBox.Show("ARE YOU SURE YOU WANT TO EXIT THIS APP ??", "EXIT?", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                this.Dispose();
                loginxx.Show();
            }
            else
            {
                this.Show();
                loginxx.Hide();
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            //search
            try
            {

                string search = textBox20.Text;
                SqlCommand cmd = new SqlCommand("select * from LiRegBook where CONCAT(BookName,Author) like '%" + textBox20.Text + "%'", dessy.returnCon());
                SqlDataAdapter sda = new SqlDataAdapter("select * from LiRegBook  where CONCAT(BookName,Author) like '%" + textBox20.Text + "%'", dessy.returnCon());
                //button21.Enabled = true;
                //button22.Enabled = true;
                //button20.Enabled = false;
                //cmd.Parameters.AddWithValue("@fname", search);
                //cmd.Parameters.AddWithValue("@lname", search);
                dessy.opencon();
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dataGridView2.DataSource = dt;
                //end
                dessy.opencon();
                SqlDataReader rd;
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    textBox13.Text = rd.GetValue(0).ToString();
                    textBox3.Text = rd.GetValue(1).ToString();
                    textBox4.Text = rd.GetValue(2).ToString();
                    textBox5.Text = rd.GetValue(3).ToString();
                    textBox6.Text = rd.GetValue(4).ToString();

                    dateTimePicker2.Text = rd.GetValue(5).ToString();
                    
                    if (string.IsNullOrEmpty(textBox20.Text.ToString()))
                    {
                        Clear();
                    }
                    rd.Close();
                }
                else
                {
                    rd.Close();
                    MessageBox.Show("NO RECORD AVAILABLE WITH NAME '" + textBox20.Text + "'", " RECORD DOES NOT EXIST", 0, MessageBoxIcon.Error);
                    textBox20.Clear();

                    clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                dessy.closeCon();

            }
        }
    }
}
    
    