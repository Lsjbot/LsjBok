
namespace LsjBok
{
    partial class FormHuvudbok
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
            this.closebutton = new System.Windows.Forms.Button();
            this.TBslut = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBstart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LBfiscal = new System.Windows.Forms.ListBox();
            this.IBbutton = new System.Windows.Forms.Button();
            this.updatebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // closebutton
            // 
            this.closebutton.Location = new System.Drawing.Point(693, 927);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(75, 23);
            this.closebutton.TabIndex = 0;
            this.closebutton.Text = "Stäng";
            this.closebutton.UseVisualStyleBackColor = true;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // TBslut
            // 
            this.TBslut.Location = new System.Drawing.Point(803, 382);
            this.TBslut.Name = "TBslut";
            this.TBslut.Size = new System.Drawing.Size(100, 20);
            this.TBslut.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(802, 366);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Slutdatum";
            // 
            // TBstart
            // 
            this.TBstart.Location = new System.Drawing.Point(803, 320);
            this.TBstart.Name = "TBstart";
            this.TBstart.Size = new System.Drawing.Size(100, 20);
            this.TBstart.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(802, 304);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Startdatum";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(802, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Räkenskapsår";
            // 
            // LBfiscal
            // 
            this.LBfiscal.FormattingEnabled = true;
            this.LBfiscal.Location = new System.Drawing.Point(803, 85);
            this.LBfiscal.Name = "LBfiscal";
            this.LBfiscal.Size = new System.Drawing.Size(91, 199);
            this.LBfiscal.TabIndex = 6;
            this.LBfiscal.SelectedIndexChanged += new System.EventHandler(this.LBfiscal_SelectedIndexChanged);
            // 
            // IBbutton
            // 
            this.IBbutton.Location = new System.Drawing.Point(530, 927);
            this.IBbutton.Name = "IBbutton";
            this.IBbutton.Size = new System.Drawing.Size(141, 23);
            this.IBbutton.TabIndex = 12;
            this.IBbutton.Text = "Fixa IB-bugg";
            this.IBbutton.UseVisualStyleBackColor = true;
            this.IBbutton.Visible = false;
            this.IBbutton.Click += new System.EventHandler(this.IBbutton_Click);
            // 
            // updatebutton
            // 
            this.updatebutton.Location = new System.Drawing.Point(803, 419);
            this.updatebutton.Name = "updatebutton";
            this.updatebutton.Size = new System.Drawing.Size(100, 23);
            this.updatebutton.TabIndex = 13;
            this.updatebutton.Text = "Uppdatera";
            this.updatebutton.UseVisualStyleBackColor = true;
            this.updatebutton.Click += new System.EventHandler(this.updatebutton_Click);
            // 
            // FormHuvudbok
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(906, 965);
            this.Controls.Add(this.updatebutton);
            this.Controls.Add(this.IBbutton);
            this.Controls.Add(this.TBslut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBstart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBfiscal);
            this.Controls.Add(this.closebutton);
            this.Name = "FormHuvudbok";
            this.Text = "FormHuvudbok";
            this.ResizeEnd += new System.EventHandler(this.FormHuvudbok_ResizeEnd);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closebutton;
        private System.Windows.Forms.TextBox TBslut;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBstart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox LBfiscal;
        private System.Windows.Forms.Button IBbutton;
        private System.Windows.Forms.Button updatebutton;
    }
}