
namespace LsjBok
{
    partial class FormBook
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
            this.bookbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.TBdecription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBdate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bookbutton
            // 
            this.bookbutton.Location = new System.Drawing.Point(241, 707);
            this.bookbutton.Name = "bookbutton";
            this.bookbutton.Size = new System.Drawing.Size(169, 62);
            this.bookbutton.TabIndex = 0;
            this.bookbutton.Text = "Bokför";
            this.bookbutton.UseVisualStyleBackColor = true;
            this.bookbutton.Click += new System.EventHandler(this.bookbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(517, 705);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(142, 64);
            this.cancelbutton.TabIndex = 1;
            this.cancelbutton.Text = "Avbryt";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // TBdecription
            // 
            this.TBdecription.Location = new System.Drawing.Point(80, 13);
            this.TBdecription.Name = "TBdecription";
            this.TBdecription.Size = new System.Drawing.Size(688, 20);
            this.TBdecription.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Beskrivning";
            // 
            // TBdate
            // 
            this.TBdate.Location = new System.Drawing.Point(80, 48);
            this.TBdate.Name = "TBdate";
            this.TBdate.Size = new System.Drawing.Size(128, 20);
            this.TBdate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Datum:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ÅÅMMDD";
            // 
            // FormBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 781);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBdecription);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.bookbutton);
            this.Name = "FormBook";
            this.Text = "FormBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bookbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.TextBox TBdecription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}