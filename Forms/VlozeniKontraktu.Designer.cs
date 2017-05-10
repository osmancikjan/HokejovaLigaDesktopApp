namespace HokejovaLigaORM.Forms
{
    partial class VlozeniKontraktu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VlozeniKontraktu));
            this.label5 = new System.Windows.Forms.Label();
            this.hracTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.hracListBox = new System.Windows.Forms.ListBox();
            this.tymyCombobox = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.odDTPicker = new System.Windows.Forms.DateTimePicker();
            this.doDTPicker = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Hráč";
            // 
            // hracTextBox
            // 
            this.hracTextBox.Location = new System.Drawing.Point(13, 30);
            this.hracTextBox.Name = "hracTextBox";
            this.hracTextBox.Size = new System.Drawing.Size(100, 20);
            this.hracTextBox.TabIndex = 1;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(119, 30);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 21);
            this.button3.TabIndex = 2;
            this.button3.Text = "Hledat";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(190, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Tým";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // hracListBox
            // 
            this.hracListBox.FormattingEnabled = true;
            this.hracListBox.Location = new System.Drawing.Point(13, 57);
            this.hracListBox.Name = "hracListBox";
            this.hracListBox.Size = new System.Drawing.Size(158, 134);
            this.hracListBox.TabIndex = 4;
            this.hracListBox.SelectedIndexChanged += new System.EventHandler(this.hracListBox_SelectedIndexChanged);
            // 
            // tymyCombobox
            // 
            this.tymyCombobox.FormattingEnabled = true;
            this.tymyCombobox.Location = new System.Drawing.Point(193, 30);
            this.tymyCombobox.Name = "tymyCombobox";
            this.tymyCombobox.Size = new System.Drawing.Size(121, 21);
            this.tymyCombobox.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(335, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Od:";
            // 
            // odDTPicker
            // 
            this.odDTPicker.Location = new System.Drawing.Point(338, 30);
            this.odDTPicker.Name = "odDTPicker";
            this.odDTPicker.Size = new System.Drawing.Size(131, 20);
            this.odDTPicker.TabIndex = 7;
            // 
            // doDTPicker
            // 
            this.doDTPicker.Location = new System.Drawing.Point(338, 76);
            this.doDTPicker.Name = "doDTPicker";
            this.doDTPicker.Size = new System.Drawing.Size(131, 20);
            this.doDTPicker.TabIndex = 9;
            this.doDTPicker.ValueChanged += new System.EventHandler(this.dateTimePicker4_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(335, 59);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(24, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Do:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(394, 175);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 10;
            this.button4.Text = "Proveď";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // VlozeniKontraktu
            // 
            this.ClientSize = new System.Drawing.Size(481, 210);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.doDTPicker);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.odDTPicker);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tymyCombobox);
            this.Controls.Add(this.hracListBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.hracTextBox);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VlozeniKontraktu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.VlozeniKontraktu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox hracTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox hracListBox;
        private System.Windows.Forms.ComboBox tymyCombobox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker odDTPicker;
        private System.Windows.Forms.DateTimePicker doDTPicker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
    }
}