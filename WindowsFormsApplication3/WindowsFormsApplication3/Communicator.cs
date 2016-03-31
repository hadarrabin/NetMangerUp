using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Pipes;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    class Communicator
    {
        //handles rhe communication between the Form and the python programm
        NamedPipeServerStream server;
        Form1 Form_1;
        BinaryReader br;
        BinaryWriter bw;
        public Communicator(Form1 Form)
        {
            this.Form_1 = Form;
            try
            {
                server = new NamedPipeServerStream("myPipee");
                server.WaitForConnection();
                this.Form_1.textBox1.AppendText("Waiting for Connection");
                var bro = new BinaryReader(server);
                this.br = bro;
                var bwo = new BinaryWriter(server);
                this.bw = bwo;
            }
            catch (Exception e)
            {
                this.Form_1.textBox1.Text = e.ToString();
            }
        }
        public string Reead()
        {
            var lenn = (int)this.br.ReadUInt32();            // Read string length
            var str = new string(this.br.ReadChars(lenn));
            return str;
        }
        public void Wriite( string str)
        {
            this.bw.Write((uint)str.Length);
            this.bw.Write(str);
        }
        public void continues()
        {
            this.Form_1.Invoke(new MethodInvoker(delegate()
            {
                this.Form_1.UUIDbox.AppendText(Reead());
                this.Form_1.UUIDbox.ReadOnly = true;
                this.Form_1.UserNameBox.AppendText(Reead());
                this.Form_1.UserNameBox.ReadOnly = true;
                this.Form_1.OsBox.AppendText(Reead());
                this.Form_1.OsBox.ReadOnly = true;
                this.Form_1.CPUBox.AppendText(Reead());
                this.Form_1.CPUBox.ReadOnly = true;
                this.Form_1.CpuNumBox.AppendText(Reead());
                this.Form_1.CpuNumBox.ReadOnly = true;
                this.Form_1.RAMBox.AppendText(Reead());
                this.Form_1.RAMBox.ReadOnly = true;
                this.Form_1.textBox1.AppendText(Reead());
            }));
            while (true)
            {
                var st = this.Form_1.textBox2.Text;
                Wriite(st);
                this.Form_1.Invoke(new MethodInvoker(delegate()
                {
                    this.Form_1.textBox1.AppendText(Reead());
                }));
            }
        }
    }
}
