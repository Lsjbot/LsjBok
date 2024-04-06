
namespace LsjBok
{
    partial class FormRR
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
            this.LBfiscal = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBstart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBslut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LBfiscal
            // 
            this.LBfiscal.FormattingEnabled = true;
            this.LBfiscal.Location = new System.Drawing.Point(972, 94);
            this.LBfiscal.Name = "LBfiscal";
            this.LBfiscal.Size = new System.Drawing.Size(91, 199);
            this.LBfiscal.TabIndex = 0;
            this.LBfiscal.SelectedIndexChanged += new System.EventHandler(this.LBfiscal_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(971, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Räkenskapsår";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(971, 313);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Startdatum";
            // 
            // TBstart
            // 
            this.TBstart.Location = new System.Drawing.Point(972, 329);
            this.TBstart.Name = "TBstart";
            this.TBstart.Size = new System.Drawing.Size(100, 20);
            this.TBstart.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(971, 375);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Slutdatum";
            // 
            // TBslut
            // 
            this.TBslut.Location = new System.Drawing.Point(972, 391);
            this.TBslut.Name = "TBslut";
            this.TBslut.Size = new System.Drawing.Size(100, 20);
            this.TBslut.TabIndex = 5;
            // 
            // FormRR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 961);
            this.Controls.Add(this.TBslut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBstart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBfiscal);
            this.Name = "FormRR";
            this.Text = "FormRR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBfiscal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBstart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBslut;
    }
}