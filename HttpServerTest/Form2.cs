using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace HttpServerTest
{
    public partial class Form2 : Form
    {
        private HttpListener httpListener;
        delegate void AppendTextDelegate(string text);
        public Form2()
        {
            InitializeComponent();
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }

        private void start_Click(object sender, EventArgs e)
        {
            logTextBox.AppendText("START.\r\n");
            try
            {
                logTextBox.AppendText("http://localhost:8080/\r\n");
                Thread t = new Thread(new ThreadStart(threadServer));
                t.Start();
            }
            catch (Exception except)
            {
                logTextBox.AppendText(except.Message);
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            logTextBox.AppendText("STOP.\r\n");
            if(httpListener != null)
            {
                httpListener.Stop();
            }
        }

        private void clear_Click(object sender, EventArgs e)
        {
            logTextBox.Clear();
        }

        public void threadServer()
        {
            try
            {
                if (httpListener == null)
                {
                    httpListener = new System.Net.HttpListener();
                    httpListener.Prefixes.Clear();
                    httpListener.Prefixes.Add(@"http://+:8080/");
                    //この設定でサーバ起動するためには管理者権限で以下のコマンドを実行しておく必要がある
                    //netsh http add urlacl url=http://+:8080/ user=Everyone
                }
                httpListener.Start();
                while (true)
                {
                    HttpListenerContext context = httpListener.GetContext();
                    HttpListenerRequest request = context.Request;
                    HttpListenerResponse response = context.Response;
                    if (request != null)
                    {
                        string query = request.Url.Query;
                        Invoke(new AppendTextDelegate(logTextBox.AppendText), query + "\r\n");
                        byte[] text = Encoding.UTF8.GetBytes(query);
                        response.OutputStream.Write(text, 0, text.Length);
                    }
                    else
                    {
                        response.StatusCode = 404;
                    }
                    response.Close();

                }
            }
            catch(Exception except)
            {
                Invoke(new AppendTextDelegate(logTextBox.AppendText), except.Message);
            }
        }
    }
}
