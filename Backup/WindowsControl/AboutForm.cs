using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WindowsControl
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }
        private void linkEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:cqitc@126.com");
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            for (Double x = 0.0; x <= 1.0; x += 0.01)
                for (int y = 0; y < 50;y++ )
                {
                    this.Opacity = x;
                    this.Refresh();
                }
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
    }
}
