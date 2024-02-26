
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
            this.SuspendLayout();
            // 
            // LBfiscal
            // 
            this.LBfiscal.FormattingEnabled = true;
            this.LBfiscal.Location = new System.Drawing.Point(881, 96);
            this.LBfiscal.Name = "LBfiscal";
            this.LBfiscal.Size = new System.Drawing.Size(91, 199);
            this.LBfiscal.TabIndex = 0;
            this.LBfiscal.SelectedIndexChanged += new System.EventHandler(this.LBfiscal_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(880, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Räkenskapsår";
            // 
            // FormRR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 961);
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
    }
}