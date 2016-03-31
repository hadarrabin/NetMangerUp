using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        Communicator com;
        public Form1()
        {
            InitializeComponent();
            this.HandleCreated += Form_HandleCreated;
        }
        private void Form_HandleCreated(object sender, EventArgs e)
        {
            this.com = new Communicator(this);
            // Handle enter keypress to send the command to the python client.
            Run();
        }
        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !this.textBox2.ReadOnly)
                Run();
        }
        private void Run()
        {
            Thread th = new Thread(new ThreadStart(this.com.continues));
            // Close the thread on application exit.
            th.IsBackground = true;
            th.Start();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
