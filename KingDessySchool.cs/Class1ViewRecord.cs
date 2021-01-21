using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KingDessySchool.cs
{
    public partial class Class1ViewRecord : Form
    {
        public Class1ViewRecord()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(180, Color.Black);
        }

        private void Class1ViewRecord_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dessySoftDataSet58.C1Reports' table. You can move, or remove it, as needed.
            this.c1ReportsTableAdapter.Fill(this.dessySoftDataSet58.C1Reports);

        }
    }
}
