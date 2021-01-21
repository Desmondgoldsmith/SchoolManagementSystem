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
    public partial class Grade1PrintReport : Form
    {
        public Grade1PrintReport()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        ReportDocument rd = new ReportDocument();
        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void Grade1PrintReport_Load(object sender, EventArgs e)
        {
            //select from Grade2FeesRec1 and display in descending order
            dessy.opencon();
            string query = "SELECT * FROM C1Reports ORDER BY id DESC";
            SqlDataAdapter da = new SqlDataAdapter(query, dessy.returnCon());
            DataSet mydata = new DataSet();
            da.Fill(mydata, "C1Reports");
            Class1Grade datax = new Class1Grade();
            datax.SetDataSource(mydata);
            crystalReportViewer2.ReportSource = datax;
            dessy.closeCon();
        }

        private void crystalReportViewer2_Load(object sender, EventArgs e)
        {

        }
    }
}
