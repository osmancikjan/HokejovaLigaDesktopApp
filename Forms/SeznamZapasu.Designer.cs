namespace HokejovaLigaORM.Forms
{
    partial class SeznamZapasu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeznamZapasu));
            this.zapasDTP = new System.Windows.Forms.DateTimePicker();
            this.detailZapasu = new System.Windows.Forms.Button();
            this.hledejZapas = new System.Windows.Forms.Button();
            this.zapasyListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // zapasDTP
            // 
            this.zapasDTP.Location = new System.Drawing.Point(13, 13);
            this.zapasDTP.Name = "zapasDTP";
            this.zapasDTP.Size = new System.Drawing.Size(137, 20);
            this.zapasDTP.TabIndex = 0;
            // 
            // detailZapasu
            // 
            this.detailZapasu.Location = new System.Drawing.Point(370, 10);
            this.detailZapasu.Name = "detailZapasu";
            this.detailZapasu.Size = new System.Drawing.Size(132, 23);
            this.detailZapasu.TabIndex = 1;
            this.detailZapasu.Text = "Detail zápasu";
            this.detailZapasu.UseVisualStyleBackColor = true;
            this.detailZapasu.Click += new System.EventHandler(this.detailZapasu_Click);
            // 
            // hledejZapas
            // 
            this.hledejZapas.Location = new System.Drawing.Point(508, 10);
            this.hledejZapas.Name = "hledejZapas";
            this.hledejZapas.Size = new System.Drawing.Size(75, 23);
            this.hledejZapas.TabIndex = 2;
            this.hledejZapas.Text = "Hledej";
            this.hledejZapas.UseVisualStyleBackColor = true;
            this.hledejZapas.Click += new System.EventHandler(this.hledejZapas_Click);
            // 
            // zapasyListBox
            // 
            this.zapasyListBox.FormattingEnabled = true;
            this.zapasyListBox.Location = new System.Drawing.Point(13, 40);
            this.zapasyListBox.Name = "zapasyListBox";
            this.zapasyListBox.Size = new System.Drawing.Size(570, 173);
            this.zapasyListBox.TabIndex = 3;
            this.zapasyListBox.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // SeznamZapasu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 228);
            this.Controls.Add(this.zapasyListBox);
            this.Controls.Add(this.hledejZapas);
            this.Controls.Add(this.detailZapasu);
            this.Controls.Add(this.zapasDTP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SeznamZapasu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seznam zápasů";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker zapasDTP;
        private System.Windows.Forms.Button detailZapasu;
        private System.Windows.Forms.Button hledejZapas;
        private System.Windows.Forms.ListBox zapasyListBox;
    }
}