
namespace LsjBok
{
    partial class FormFiscalyear
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
            this.createbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TBstart = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBslut = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // createbutton
            // 
            this.createbutton.Location = new System.Drawing.Point(77, 393);
            this.createbutton.Name = "createbutton";
            this.createbutton.Size = new System.Drawing.Size(108, 45);
            this.createbutton.TabIndex = 0;
            this.createbutton.Text = "Skapa";
            this.createbutton.UseVisualStyleBackColor = true;
            this.createbutton.Click += new System.EventHandler(this.createbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(348, 393);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(101, 45);
            this.cancelbutton.TabIndex = 1;
            this.cancelbutton.Text = "Avbryt";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Startdatum";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Slutdatum";
            // 
            // TBstart
            // 
            this.TBstart.Location = new System.Drawing.Point(107, 22);
            this.TBstart.Name = "TBstart";
            this.TBstart.Size = new System.Drawing.Size(100, 20);
            this.TBstart.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(213, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "ÅÅMMDD";
            // 
            // TBslut
            // 
            this.TBslut.Location = new System.Drawing.Point(107, 47);
            this.TBslut.Name = "TBslut";
            this.TBslut.Size = new System.Drawing.Size(100, 20);
            this.TBslut.TabIndex = 6;
            // 
            // FormFiscalyear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 450);
            this.Controls.Add(this.TBslut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBstart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.createbutton);
            this.Name = "FormFiscalyear";
            this.Text = "FormFiscalyear";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBstart;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBslut;
    }
}