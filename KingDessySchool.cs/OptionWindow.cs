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
    public partial class OptionWindow : Form
    {

        int pw;
        bool hide;
        public OptionWindow()
        {
            InitializeComponent();
            pw = panel3.Width;
            hide = false;
        }

        omagaconnections des = new omagaconnections();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(160,Color.Black);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            panel3.BackColor = Color.FromArgb(100, Color.White);
        }

        private void OptionWindow_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            panel3.Visible = false;
            button6.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //IF THE PANEL WIDTH IS LESS THAN ITS CURRENT + 25 , THEN IT SHOULD INCREASE ITS NORMAL WIDTH BY 25
            
            if (hide)
            {
                panel3.Width = panel3.Width + 25;
                if (panel3.Width >= pw)
                {
                    hide = false;
                   // this.Refresh();
                    panel3.Visible = true;
                    timer1.Stop();

                }
            }
            else
            {
                panel3.Width = panel3.Width - 25;
                if (panel3.Width <= 0)
                {
                    timer1.Stop();
                    hide = true;
                    //this.Refresh();
                }
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //CHECKING IF CONNECTION IS OPEN
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-5GO68TK\DESSY;Initial Catalog=DessySoft;Integrated Security=True");
            try {
                des.opencon();
                MessageBox.Show("CONNECTION IS OPEN AND ACTIVE", "CONNECTED", 0, MessageBoxIcon.Information);
                button2.Enabled = true;
                
                //button2.Cursor = Hand;
            }
            catch(Exception ex)
            {
                MessageBox.Show("THE FOLLOWING ERROR OCCURED." + ex.Message + "CONNECTION CLOSED");
            }
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var reg = new RegUser();
            reg.Show();
            //this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var log = new DessySchoolComplesApp.cs.login();
            log.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //EXIT APP ?? YES OR NO
            if (MessageBox.Show("ARE YOU SURE YOU WANT TO EXIT THIS APP ?", "EXIT??", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                MessageBox.Show("THANKS FOR USING THIS APP", "THANKS", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            }

        private void button6_Click(object sender, EventArgs e)
        {
            //SHOW THE FINDPASSWORD PAGE AND DISMISS THIS PAGE
            var pass = new FindPassword();
            pass.Show();
            this.Hide();
        }
    }
    }
