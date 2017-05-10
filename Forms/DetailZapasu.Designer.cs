namespace HokejovaLigaORM.Forms
{
    partial class DetailZapasu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetailZapasu));
            this.score = new System.Windows.Forms.Label();
            this.domaciL = new System.Windows.Forms.Label();
            this.hosteL = new System.Windows.Forms.Label();
            this.cas = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.strelciLB = new System.Windows.Forms.ListBox();
            this.asistenceLB = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // score
            // 
            this.score.AutoSize = true;
            this.score.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.score.Location = new System.Drawing.Point(219, 9);
            this.score.Name = "score";
            this.score.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.score.Size = new System.Drawing.Size(91, 55);
            this.score.TabIndex = 0;
            this.score.Text = "8:8";
            this.score.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.score.Click += new System.EventHandler(this.label1_Click);
            // 
            // domaciL
            // 
            this.domaciL.AutoSize = true;
            this.domaciL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.domaciL.Location = new System.Drawing.Point(16, 13);
            this.domaciL.Name = "domaciL";
            this.domaciL.Size = new System.Drawing.Size(150, 20);
            this.domaciL.TabIndex = 1;
            this.domaciL.Text = "HC Vitkovice Ridera";
            this.domaciL.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // hosteL
            // 
            this.hosteL.AutoSize = true;
            this.hosteL.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.hosteL.Location = new System.Drawing.Point(359, 13);
            this.hosteL.Name = "hosteL";
            this.hosteL.Size = new System.Drawing.Size(150, 20);
            this.hosteL.TabIndex = 2;
            this.hosteL.Text = "HC Vitkovice Ridera";
            this.hosteL.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.hosteL.Click += new System.EventHandler(this.label2_Click);
            // 
            // cas
            // 
            this.cas.AutoSize = true;
            this.cas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cas.Location = new System.Drawing.Point(226, 64);
            this.cas.Name = "cas";
            this.cas.Size = new System.Drawing.Size(73, 16);
            this.cas.TabIndex = 3;
            this.cas.Text = "1. září 2016";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Střelci";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(276, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Asistence";
            // 
            // strelciLB
            // 
            this.strelciLB.FormattingEnabled = true;
            this.strelciLB.Location = new System.Drawing.Point(12, 119);
            this.strelciLB.Name = "strelciLB";
            this.strelciLB.Size = new System.Drawing.Size(230, 199);
            this.strelciLB.TabIndex = 6;
            // 
            // asistenceLB
            // 
            this.asistenceLB.FormattingEnabled = true;
            this.asistenceLB.Location = new System.Drawing.Point(279, 119);
            this.asistenceLB.Name = "asistenceLB";
            this.asistenceLB.Size = new System.Drawing.Size(230, 199);
            this.asistenceLB.TabIndex = 7;
            // 
            // DetailZapasu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 330);
            this.Controls.Add(this.asistenceLB);
            this.Controls.Add(this.strelciLB);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cas);
            this.Controls.Add(this.hosteL);
            this.Controls.Add(this.domaciL);
            this.Controls.Add(this.score);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DetailZapasu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detail zápasu";
            this.Load += new System.EventHandler(this.DetailZapasu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label score;
        private System.Windows.Forms.Label domaciL;
        private System.Windows.Forms.Label hosteL;
        private System.Windows.Forms.Label cas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListBox strelciLB;
        private System.Windows.Forms.ListBox asistenceLB;
    }
}