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
    public partial class ReceiptFees : Form
    {
        public ReceiptFees()
        {
            InitializeComponent();
        }
        omagaconnections dessy = new omagaconnections();
        ReportDocument rd = new ReportDocument();
        private void ReceiptFees_Load(object sender, EventArgs e)
        {
            dessy.opencon();
            string query = "SELECT * FROM feesRec ORDER BY id DESC";
            SqlDataAdapter da = new SqlDataAdapter(query, dessy.returnCon());
            DataSet mydata = new DataSet();
            da.Fill(mydata, "feesRec");
            feesReceiptsx datax = new feesReceiptsx();
            datax.SetDataSource(mydata);
            crystalReportViewer1.ReportSource = datax;
            dessy.closeCon();
        }
    }
}
