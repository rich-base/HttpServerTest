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
    public partial class Form1 : Form
    {
        private Form2 serverForm;
        public Form1()
        {
            InitializeComponent();
        }
        
        private void startServerForm()
        {
            if (serverForm == null)
            {
                serverForm = new Form2();
            }
            serverForm.Show();
        }
        private void serverToolStripMenuItem_Click(object sender, EventArgs e)
        {
            startServerForm();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            startServerForm();
        }
    }
}
