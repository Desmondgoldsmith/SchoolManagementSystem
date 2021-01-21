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
    public partial class Grade1ReportCards : Form
    {
        public Grade1ReportCards()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        int score;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(160, Color.Black);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel39_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //byte[] images = null;
                //FileStream stream = new FileStream(imglocation, FileMode.Open, FileAccess.Read);
                //BinaryReader brs = new BinaryReader(stream);
                //images = brs.ReadBytes((int)stream.Length);
                dessy.opencon();
                SqlCommand cmd = new SqlCommand("SaveC1Reports", dessy.returnCon()) { CommandType = CommandType.StoredProcedure };
                cmd.Parameters.AddWithValue("@sn", textBox1.Text);
                cmd.Parameters.AddWithValue("@sc", comboBox1.Text);
                cmd.Parameters.AddWithValue("@T", comboBox2.Text);
                cmd.Parameters.AddWithValue("@P", comboBox3.Text);
                cmd.Parameters.AddWithValue("@od", dateTimePicker1.Text);
                cmd.Parameters.AddWithValue("@Y", textBox3.Text);
                cmd.Parameters.AddWithValue("@Att", textBox4.Text);
                cmd.Parameters.AddWithValue("@NOR", textBox5.Text);
                cmd.Parameters.AddWithValue("@FD", textBox43.Text);
                cmd.Parameters.AddWithValue("@TC", textBox45.Text);
                cmd.Parameters.AddWithValue("@Cs", textBox2.Text);
                cmd.Parameters.AddWithValue("@ES", textBox6.Text);
                cmd.Parameters.AddWithValue("@TS", textBox7.Text);
                cmd.Parameters.AddWithValue("@G", textBox18.Text);
                cmd.Parameters.AddWithValue("@Po", textBox24.Text);
                cmd.Parameters.AddWithValue("@rm", textBox30.Text);
                cmd.Parameters.AddWithValue("@Mcs", textBox8.Text);
                cmd.Parameters.AddWithValue("@Mes", textBox17.Text);
                cmd.Parameters.AddWithValue("@Mt", textBox23.Text);
                cmd.Parameters.AddWithValue("@MG", textBox29.Text);
                cmd.Parameters.AddWithValue("@Mp", textBox35.Text);
                cmd.Parameters.AddWithValue("@Mrm", textBox36.Text);
                cmd.Parameters.AddWithValue("@Scs", textBox9.Text);
                cmd.Parameters.AddWithValue("@Ses", textBox16.Text);


                cmd.Parameters.AddWithValue("@St", textBox22.Text);
                cmd.Parameters.AddWithValue("@SG", textBox28.Text);
                cmd.Parameters.AddWithValue("@Sp", textBox34.Text);
                cmd.Parameters.AddWithValue("@srm", textBox40.Text);
                cmd.Parameters.AddWithValue("@sscs", textBox10.Text);
                cmd.Parameters.AddWithValue("@sses", textBox15.Text);
                cmd.Parameters.AddWithValue("@sst", textBox21.Text);
                cmd.Parameters.AddWithValue("@ssG", textBox27.Text);
                cmd.Parameters.AddWithValue("@sSp", textBox33.Text);
                cmd.Parameters.AddWithValue("@Ssrm", textBox31.Text);
                cmd.Parameters.AddWithValue("@Fcs", textBox11.Text);
                cmd.Parameters.AddWithValue("@Fes", textBox14.Text);
                cmd.Parameters.AddWithValue("@Ft", textBox20.Text);
                cmd.Parameters.AddWithValue("@FG", textBox26.Text);
                cmd.Parameters.AddWithValue("@Fp", textBox32.Text);
                cmd.Parameters.AddWithValue("@Frm", textBox38.Text);
                cmd.Parameters.AddWithValue("@Tcs", textBox12.Text);
                cmd.Parameters.AddWithValue("@Tes", textBox13.Text);
                cmd.Parameters.AddWithValue("@Tt", textBox19.Text);
                cmd.Parameters.AddWithValue("@TG", textBox25.Text);
                cmd.Parameters.AddWithValue("@Tp", textBox31.Text);
                cmd.Parameters.AddWithValue("@Trm", textBox37.Text);
                // cmd.Parameters.Add(new SqlParameter("@i", images));

                if (cmd.ExecuteNonQuery() == 1)
                {

                    MessageBox.Show("Data Saved Successfully For Student With Name '" + textBox1.Text + "'", "Saved", 0, MessageBoxIcon.Information);
                    MessageBox.Show("Please Wait Patiently For The Reports", "Saved", 0, MessageBoxIcon.Information);
                    var reports = new Grade1PrintReport();
                    reports.Show();
                    //clear();

                }
                else
                {
                    MessageBox.Show("Error", "Error!!!", 0, MessageBoxIcon.Error);

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

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Grade1ReportCards_Load(object sender, EventArgs e)
        {
        }

        protected void textBox2_TextChanged_1(object sender, EventArgs e)
        {
            //summing values in textboxes
            if ((!string.IsNullOrWhiteSpace(textBox2.Text)) && (!string.IsNullOrEmpty(textBox6.Text)))
            {
                textBox7.Text = (Convert.ToInt32(textBox2.Text) + Convert.ToInt32(textBox6.Text)).ToString();
            }
            else
            {
                textBox7.Text = "";
            }
            //if (string.IsNullOrWhiteSpace(textBox2.Text.ToString()))
            //{
            //    textBox7.Clear();
            //    textBox6.Clear();
            //    textBox2.Clear();
            //}
            //else
            //{
            //    textBox7.Text = (Convert.ToInt32(textBox2.Text) + Convert.ToInt32(textBox6.Text)).ToString();
            //}

            // int num1 = Convert.ToInt32(textBox2.Text);
        }

        private void textBox30_TextChanged(object sender, EventArgs e)
        {

        }

        protected void textBox7_TextChanged(object sender, EventArgs e)
        {
            //No letters or decimal numbers allowed
            //e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            if((!string.IsNullOrWhiteSpace(textBox7.Text)))
            {
                score = Convert.ToInt32(textBox7.Text);

                if (score >= 80 && score <= 100)
                {
                    this.textBox18.Text = "A";
                    this.textBox30.Text = "EXCELLENT";
                }
                else if (score >= 75 && score <= 80)
                {
                    this.textBox18.Text = "B+";
                    this.textBox30.Text = "VERY GOOD";

                }
                else if (score >= 70 && score <= 75)
                {
                    this.textBox18.Text = "B";
                    this.textBox30.Text = "GOOD";

                }
                else if (score >= 65 && score <= 70)
                {
                    this.textBox18.Text = "C+";
                    this.textBox30.Text = "NICE";

                }
                else if (score >= 60 && score <= 65)
                {
                    this.textBox18.Text = "C";
                    this.textBox30.Text = "EGO BEE";

                }
                else if (score >= 55 && score <= 60)
                {
                    this.textBox18.Text = "D+";
                    this.textBox30.Text = "Eii Koo";

                }
                else if (score >= 50 && score <= 55)
                {
                    this.textBox18.Text = "D";
                    this.textBox30.Text = "POOR";

                }
                else if (score >= 45 && score <= 50)
                {
                    this.textBox18.Text = "E";
                    this.textBox30.Text = "BAD";

                }
                else if (score >= 0 && score <= 45)
                {
                    this.textBox18.Text = "F";
                    this.textBox30.Text = "FAIL";

                }
            }
            else
            {
                this.textBox18.Clear();
                this.textBox30.Clear();
            }
           
        }

        protected void textBox6_TextChanged(object sender, EventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(textBox6.Text.ToString()))
            //{
            //   // textBox7.Clear();
            //    textBox6.Clear();
            //}
            //else { 
            //textBox7.Text = (Convert.ToInt32(textBox2.Text) + Convert.ToInt32(textBox6.Text)).ToString();
            //}

            if ((!string.IsNullOrWhiteSpace(textBox2.Text)) && (!string.IsNullOrEmpty(textBox6.Text)))
            {
                textBox7.Text = (Convert.ToInt32(textBox2.Text) + Convert.ToInt32(textBox6.Text)).ToString();
            }
        }

        private void textBox6_TextChanged_1(object sender, EventArgs e)
        {
           //sum textbox2 and 6 to display ans in textbox 7
            if ((!string.IsNullOrWhiteSpace(textBox2.Text)) && (!string.IsNullOrEmpty(textBox6.Text)))
            {
                textBox7.Text = (Convert.ToInt32(textBox2.Text) + Convert.ToInt32(textBox6.Text)).ToString();
            }
            else
            {
                textBox7.Text = "";
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
           // MessageBox.Show("INPUT ONLY INTEGER NUMBERS [NO LETTERS OR DECIMAL NUMBERS]","", 0, MessageBoxIcon.Error);
            return;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            //No letters or decimal numbers allowed
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //summing values in textboxes
            if ((!string.IsNullOrWhiteSpace(textBox8.Text)) && (!string.IsNullOrEmpty(textBox17.Text)))
            {
                textBox23.Text = (Convert.ToInt32(textBox8.Text) + Convert.ToInt32(textBox17.Text)).ToString();
            }
            else
            {
                textBox23.Text = "";
            }
        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            //summing values in textboxes
            if ((!string.IsNullOrWhiteSpace(textBox8.Text)) && (!string.IsNullOrEmpty(textBox17.Text)))
            {
                textBox23.Text = (Convert.ToInt32(textBox8.Text) + Convert.ToInt32(textBox17.Text)).ToString();
            }
            else
            {
                textBox23.Text = "";
            }
        }

        private void textBox23_TextChanged(object sender, EventArgs e)
        {
            //grades
            if ((!string.IsNullOrWhiteSpace(textBox23.Text)))
            {
                score = Convert.ToInt32(textBox23.Text);

                if (score >= 80 && score <= 100)
                {
                    this.textBox29.Text = "A";
                    this.textBox36.Text = "EXCELLENT";
                }
                else if (score >= 75 && score <= 80)
                {
                    this.textBox29.Text = "B+";
                    this.textBox36.Text = "VERY GOOD";

                }
                else if (score >= 70 && score <= 75)
                {
                    this.textBox29.Text = "B";
                    this.textBox36.Text = "GOOD";

                }
                else if (score >= 65 && score <= 70)
                {
                    this.textBox29.Text = "C+";
                    this.textBox36.Text = "NICE";

                }
                else if (score >= 60 && score <= 65)
                {
                    this.textBox29.Text = "C";
                    this.textBox36.Text = "EGO BEE";

                }
                else if (score >= 55 && score <= 60)
                {
                    this.textBox29.Text = "D+";
                    this.textBox36.Text = "Eii Koo";

                }
                else if (score >= 50 && score <= 55)
                {
                    this.textBox29.Text = "D";
                    this.textBox36.Text = "POOR";

                }
                else if (score >= 45 && score <= 50)
                {
                    this.textBox29.Text = "E";
                    this.textBox36.Text = "BAD";

                }
                else if (score >= 0 && score <= 45)
                {
                    this.textBox29.Text = "F";
                    this.textBox36.Text = "FAIL";

                }
            }
            else
            {
                this.textBox29.Clear();
                this.textBox36.Clear();
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox17_KeyPress(object sender, KeyPressEventArgs e)
        {
           //no letters or decimal
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox23_KeyPress(object sender, KeyPressEventArgs e)
        {
            //no letters or decimal
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //summing values in textboxes
            if ((!string.IsNullOrWhiteSpace(textBox9.Text)) && (!string.IsNullOrEmpty(textBox16.Text)))
            {
                textBox22.Text = (Convert.ToInt32(textBox9.Text) + Convert.ToInt32(textBox16.Text)).ToString();
            }
            else
            {
                textBox22.Text = "";
            }
        }

        private void textBox16_TextChanged(object sender, EventArgs e)
        {
            //summing values in textboxes
            if ((!string.IsNullOrWhiteSpace(textBox9.Text)) && (!string.IsNullOrEmpty(textBox16.Text)))
            {
                textBox22.Text = (Convert.ToInt32(textBox9.Text) + Convert.ToInt32(textBox16.Text)).ToString();
            }
            else
            {
                textBox22.Text = "";
            }
        }

        private void textBox22_TextChanged(object sender, EventArgs e)
        {
            //grades
            if ((!string.IsNullOrWhiteSpace(textBox22.Text)))
            {
                score = Convert.ToInt32(textBox22.Text);

                if (score >= 80 && score <= 100)
                {
                    this.textBox28.Text = "A";
                    this.textBox40.Text = "EXCELLENT";
                }
                else if (score >= 75 && score <= 80)
                {
                    this.textBox28.Text = "B+";
                    this.textBox40.Text = "VERY GOOD";

                }
                else if (score >= 70 && score <= 75)
                {
                    this.textBox28.Text = "B";
                    this.textBox40.Text = "GOOD";

                }
                else if (score >= 65 && score <= 70)
                {
                    this.textBox28.Text = "C+";
                    this.textBox40.Text = "NICE";

                }
                else if (score >= 60 && score <= 65)
                {
                    this.textBox28.Text = "C";
                    this.textBox40.Text = "EGO BEE";

                }
                else if (score >= 55 && score <= 60)
                {
                    this.textBox28.Text = "D+";
                    this.textBox40.Text = "Eii Koo";

                }
                else if (score >= 50 && score <= 55)
                {
                    this.textBox28.Text = "D";
                    this.textBox40.Text = "POOR";

                }
                else if (score >= 45 && score <= 50)
                {
                    this.textBox28.Text = "E";
                    this.textBox40.Text = "BAD";

                }
                else if (score >= 0 && score <= 45)
                {
                    this.textBox28.Text = "F";
                    this.textBox40.Text = "FAIL";

                }
            }
            else
            {
                this.textBox28.Clear();
                this.textBox40.Clear();

            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox22_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            //summing values in textboxes
            if ((!string.IsNullOrWhiteSpace(textBox10.Text)) && (!string.IsNullOrEmpty(textBox15.Text)))
            {
                textBox21.Text = (Convert.ToInt32(textBox10.Text) + Convert.ToInt32(textBox15.Text)).ToString();
            }
            else
            {
                textBox21.Text = "";
            }
        }

        private void textBox15_TextChanged(object sender, EventArgs e)
        {
            //summing values in textboxes
            if ((!string.IsNullOrWhiteSpace(textBox10.Text)) && (!string.IsNullOrEmpty(textBox15.Text)))
            {
                textBox21.Text = (Convert.ToInt32(textBox10.Text) + Convert.ToInt32(textBox15.Text)).ToString();
            }
            else
            {
                textBox21.Text = "";
            }
        }

        private void textBox21_TextChanged(object sender, EventArgs e)
        {
            //grades
            if ((!string.IsNullOrWhiteSpace(textBox21.Text)))
            {
                score = Convert.ToInt32(textBox21.Text);

                if (score >= 80 && score <= 100)
                {
                    this.textBox27.Text = "A";
                    this.textBox39.Text = "EXCELLENT";
                }
                else if (score >= 75 && score <= 80)
                {
                    this.textBox27.Text = "B+";
                    this.textBox39.Text = "VERY GOOD";

                }
                else if (score >= 70 && score <= 75)
                {
                    this.textBox27.Text = "B";
                    this.textBox39.Text = "GOOD";

                }
                else if (score >= 65 && score <= 70)
                {
                    this.textBox27.Text = "C+";
                    this.textBox39.Text = "NICE";

                }
                else if (score >= 60 && score <= 65)
                {
                    this.textBox27.Text = "C";
                    this.textBox39.Text = "EGO BEE";

                }
                else if (score >= 55 && score <= 60)
                {
                    this.textBox27.Text = "D+";
                    this.textBox39.Text = "Eii Koo";

                }
                else if (score >= 50 && score <= 55)
                {
                    this.textBox27.Text = "D";
                    this.textBox39.Text = "POOR";

                }
                else if (score >= 45 && score <= 50)
                {
                    this.textBox27.Text = "E";
                    this.textBox39.Text = "BAD";

                }
                else if (score >= 0 && score <= 45)
                {
                    this.textBox27.Text = "F";
                    this.textBox39.Text = "FAIL";

                }
            }
            else
            {
                this.textBox27.Clear();
                this.textBox40.Clear();

            }
        }

        private void textBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox15_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox21_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            //summing values in textboxes
            if ((!string.IsNullOrWhiteSpace(textBox11.Text)) && (!string.IsNullOrEmpty(textBox14.Text)))
            {
                textBox20.Text = (Convert.ToInt32(textBox11.Text) + Convert.ToInt32(textBox14.Text)).ToString();
            }
            else
            {
                textBox20.Text = "";
                textBox32.Text = "";
            }
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            //summing values in textboxes
            if ((!string.IsNullOrWhiteSpace(textBox11.Text)) && (!string.IsNullOrEmpty(textBox14.Text)))
            {
                textBox20.Text = (Convert.ToInt32(textBox11.Text) + Convert.ToInt32(textBox14.Text)).ToString();
            }
            else
            {
                textBox20.Text = "";
                textBox32.Text = "";
            }
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            //grades
            if ((!string.IsNullOrWhiteSpace(textBox20.Text)))
            {
                score = Convert.ToInt32(textBox20.Text);

                if (score >= 80 && score <= 100)
                {
                    this.textBox26.Text = "A";
                    this.textBox38.Text = "EXCELLENT";
                }
                else if (score >= 75 && score <= 80)
                {
                    this.textBox26.Text = "B+";
                    this.textBox38.Text = "VERY GOOD";

                }
                else if (score >= 70 && score <= 75)
                {
                    this.textBox26.Text = "B";
                    this.textBox38.Text = "GOOD";

                }
                else if (score >= 65 && score <= 70)
                {
                    this.textBox26.Text = "C+";
                    this.textBox38.Text = "NICE";

                }
                else if (score >= 60 && score <= 65)
                {
                    this.textBox26.Text = "C";
                    this.textBox38.Text = "EGO BEE";

                }
                else if (score >= 55 && score <= 60)
                {
                    this.textBox26.Text = "D+";
                    this.textBox38.Text = "Eii Koo";

                }
                else if (score >= 50 && score <= 55)
                {
                    this.textBox26.Text = "D";
                    this.textBox38.Text = "POOR";

                }
                else if (score >= 45 && score <= 50)
                {
                    this.textBox26.Text = "E";
                    this.textBox38.Text = "BAD";

                }
                else if (score >= 0 && score <= 45)
                {
                    this.textBox26.Text = "F";
                    this.textBox38.Text = "FAIL";

                }
            }
            else
            {
                this.textBox26.Clear();
                this.textBox38.Clear();

            }
        }

        private void textBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox14_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox20_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            //summing values in textboxes
            if ((!string.IsNullOrWhiteSpace(textBox12.Text)) && (!string.IsNullOrEmpty(textBox13.Text)))
            {
                textBox19.Text = (Convert.ToInt32(textBox12.Text) + Convert.ToInt32(textBox13.Text)).ToString();
            }
            else
            {
                textBox19.Text = "";
                textBox37.Text = "";
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            //summing values in textboxes
            if ((!string.IsNullOrWhiteSpace(textBox12.Text)) && (!string.IsNullOrEmpty(textBox13.Text)))
            {
                textBox19.Text = (Convert.ToInt32(textBox12.Text) + Convert.ToInt32(textBox13.Text)).ToString();
            }
            else
            {
                textBox19.Text = "";
                textBox37.Text = "";
            }
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            //grades
            if ((!string.IsNullOrWhiteSpace(textBox19.Text)))
            {
                score = Convert.ToInt32(textBox19.Text);

                if (score >= 80 && score <= 100)
                {
                    this.textBox25.Text = "A";
                    this.textBox37.Text = "EXCELLENT";
                }
                else if (score >= 75 && score <= 80)
                {
                    this.textBox25.Text = "B+";
                    this.textBox37.Text = "VERY GOOD";

                }
                else if (score >= 70 && score <= 75)
                {
                    this.textBox25.Text = "B";
                    this.textBox37.Text = "GOOD";

                }
                else if (score >= 65 && score <= 70)
                {
                    this.textBox25.Text = "C+";
                    this.textBox37.Text = "NICE";

                }
                else if (score >= 60 && score <= 65)
                {
                    this.textBox25.Text = "C";
                    this.textBox37.Text = "EGO BEE";

                }
                else if (score >= 55 && score <= 60)
                {
                    this.textBox25.Text = "D+";
                    this.textBox37.Text = "Eii Koo";

                }
                else if (score >= 50 && score <= 55)
                {
                    this.textBox25.Text = "D";
                    this.textBox37.Text = "POOR";

                }
                else if (score >= 45 && score <= 50)
                {
                    this.textBox25.Text = "E";
                    this.textBox37.Text = "BAD";

                }
                else if (score >= 0 && score <= 45)
                {
                    this.textBox25.Text = "F";
                    this.textBox37.Text = "FAIL";

                }
            }
            else
            {
                this.textBox25.Clear();
                this.textBox37.Clear();

            }
        }
    }
}
