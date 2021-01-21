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
    public partial class GmailMain : Form
    {
        public GmailMain()
        {
            InitializeComponent();
        }

        private void GmailMain_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.google.com/calendar/");
        }

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.Text = e.Url.ToString() + "Loading ....";
        }

        private void webBrowser2_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
