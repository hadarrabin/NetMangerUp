namespace WindowsFormsApplication3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComputersList = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.UUIDbox = new System.Windows.Forms.TextBox();
            this.UserNameBox = new System.Windows.Forms.TextBox();
            this.OsBox = new System.Windows.Forms.TextBox();
            this.CPUBox = new System.Windows.Forms.TextBox();
            this.CpuNumBox = new System.Windows.Forms.TextBox();
            this.RAMBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComputersList
            // 
            this.ComputersList.DropDownHeight = 115;
            this.ComputersList.FormattingEnabled = true;
            this.ComputersList.IntegralHeight = false;
            this.ComputersList.Location = new System.Drawing.Point(256, 22);
            this.ComputersList.Name = "ComputersList";
            this.ComputersList.Size = new System.Drawing.Size(134, 21);
            this.ComputersList.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(1, 342);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(425, 46);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(1, 266);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(425, 53);
            this.textBox2.TabIndex = 2;
            // 
            // UUIDbox
            // 
            this.UUIDbox.Location = new System.Drawing.Point(3, 3);
            this.UUIDbox.Name = "UUIDbox";
            this.UUIDbox.Size = new System.Drawing.Size(186, 20);
            this.UUIDbox.TabIndex = 3;
            this.UUIDbox.Text = "UUID: ";
            this.UUIDbox.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // UserNameBox
            // 
            this.UserNameBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.UserNameBox.Location = new System.Drawing.Point(3, 29);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(186, 23);
            this.UserNameBox.TabIndex = 4;
            this.UserNameBox.Text = "user name: ";
            // 
            // OsBox
            // 
            this.OsBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.OsBox.Location = new System.Drawing.Point(3, 140);
            this.OsBox.Name = "OsBox";
            this.OsBox.Size = new System.Drawing.Size(186, 22);
            this.OsBox.TabIndex = 5;
            this.OsBox.Text = "OS version: ";
            // 
            // CPUBox
            // 
            this.CPUBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CPUBox.Location = new System.Drawing.Point(3, 112);
            this.CPUBox.Name = "CPUBox";
            this.CPUBox.Size = new System.Drawing.Size(186, 22);
            this.CPUBox.TabIndex = 6;
            this.CPUBox.Text = "processor: ";
            // 
            // CpuNumBox
            // 
            this.CpuNumBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CpuNumBox.Location = new System.Drawing.Point(3, 85);
            this.CpuNumBox.Name = "CpuNumBox";
            this.CpuNumBox.Size = new System.Drawing.Size(186, 21);
            this.CpuNumBox.TabIndex = 7;
            this.CpuNumBox.Text = "CPU\'s: ";
            // 
            // RAMBox
            // 
            this.RAMBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.RAMBox.Location = new System.Drawing.Point(3, 58);
            this.RAMBox.Name = "RAMBox";
            this.RAMBox.Size = new System.Drawing.Size(186, 21);
            this.RAMBox.TabIndex = 8;
            this.RAMBox.Text = "RAM size: ";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.UUIDbox);
            this.flowLayoutPanel1.Controls.Add(this.UserNameBox);
            this.flowLayoutPanel1.Controls.Add(this.RAMBox);
            this.flowLayoutPanel1.Controls.Add(this.CpuNumBox);
            this.flowLayoutPanel1.Controls.Add(this.CPUBox);
            this.flowLayoutPanel1.Controls.Add(this.OsBox);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 22);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(219, 207);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(423, 389);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ComputersList);
            this.Name = "Form1";
            this.Text = "Form1";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.ComboBox ComputersList;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.TextBox UUIDbox;
        public System.Windows.Forms.TextBox UserNameBox;
        public System.Windows.Forms.TextBox OsBox;
        public System.Windows.Forms.TextBox CPUBox;
        public System.Windows.Forms.TextBox CpuNumBox;
        public System.Windows.Forms.TextBox RAMBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}

