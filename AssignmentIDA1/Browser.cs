using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FancyInternetDataAcquisition
{
    public partial class Browser : Form
    {
        public Browser()
        {
            InitializeComponent();
        }

        public void load(string url)
        {
            webBrowser.Navigate(url);
            webBrowser.Show();
            Visible = true;
        }
    }
}
