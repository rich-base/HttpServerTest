using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HttpServerTest
{
    public partial class Form2 : Form
    {
        private System.Net.HttpListener httpListener;
        private int counter1;
        private int counter2;
        public Form2()
        {
            InitializeComponent();
            counter1 = 0;
            counter2 = 0;
            httpListener = new System.Net.HttpListener();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void start_Click(object sender, EventArgs e)
        {
            logTextBox.Text = "START Pushed. " + counter1 + "\r\n" + logTextBox.Text;
            counter1++;
        }

        private void stop_Click(object sender, EventArgs e)
        {
            logTextBox.Text = "STOP Pushed. " + counter2 + "\r\n" + logTextBox.Text;
            counter2++;
        }

        private void clear_Click(object sender, EventArgs e)
        {
            logTextBox.Clear();
            counter1 = 0;
            counter2 = 0;
        }
    }
}
