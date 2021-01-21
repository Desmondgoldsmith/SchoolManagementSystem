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
using CrystalDecisions.CrystalReports.Engine;

namespace KingDessySchool.cs
{
    public partial class Grade2Receipt : Form
    {
        public Grade2Receipt()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        ReportDocument rd = new ReportDocument();
        private void Grade2Receipt_Load(object sender, EventArgs e)
        {
            //select from Grade2FeesRec1 and display in descending order
            dessy.opencon();
            string query = "SELECT * FROM Grade2FeesRec1 ORDER BY id DESC";
            SqlDataAdapter da = new SqlDataAdapter(query, dessy.returnCon());
            DataSet mydata = new DataSet();
            da.Fill(mydata, "Grade2FeesRec1");
            Grade2Report datax = new Grade2Report();
            datax.SetDataSource(mydata);
            crystalReportViewer1.ReportSource = datax;
            dessy.closeCon();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
