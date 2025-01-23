
namespace LsjBok
{
    partial class FormDeklaration
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RByesaccountant = new System.Windows.Forms.RadioButton();
            this.RBnoaccountant = new System.Windows.Forms.RadioButton();
            this.RByesrevision = new System.Windows.Forms.RadioButton();
            this.RBnorevision = new System.Windows.Forms.RadioButton();
            this.srubutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBaddress = new System.Windows.Forms.TextBox();
            this.TBzip = new System.Windows.Forms.TextBox();
            this.TBcity = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBnorevision);
            this.groupBox1.Controls.Add(this.RByesrevision);
            this.groupBox1.Location = new System.Drawing.Point(27, 773);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 76);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Årsredovisningen har varit föremål för revision";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RBnoaccountant);
            this.groupBox2.Controls.Add(this.RByesaccountant);
            this.groupBox2.Location = new System.Drawing.Point(27, 678);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(264, 89);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Uppdragstagare (t.ex. redovisningskonsult) har biträtt vid upprättandet av årsred" +
    "ovisningen";
            // 
            // RByesaccountant
            // 
            this.RByesaccountant.AutoSize = true;
            this.RByesaccountant.Location = new System.Drawing.Point(19, 35);
            this.RByesaccountant.Name = "RByesaccountant";
            this.RByesaccountant.Size = new System.Drawing.Size(36, 17);
            this.RByesaccountant.TabIndex = 0;
            this.RByesaccountant.Text = "Ja";
            this.RByesaccountant.UseVisualStyleBackColor = true;
            // 
            // RBnoaccountant
            // 
            this.RBnoaccountant.AutoSize = true;
            this.RBnoaccountant.Checked = true;
            this.RBnoaccountant.Location = new System.Drawing.Point(19, 59);
            this.RBnoaccountant.Name = "RBnoaccountant";
            this.RBnoaccountant.Size = new System.Drawing.Size(41, 17);
            this.RBnoaccountant.TabIndex = 1;
            this.RBnoaccountant.TabStop = true;
            this.RBnoaccountant.Text = "Nej";
            this.RBnoaccountant.UseVisualStyleBackColor = true;
            // 
            // RByesrevision
            // 
            this.RByesrevision.AutoSize = true;
            this.RByesrevision.Location = new System.Drawing.Point(19, 19);
            this.RByesrevision.Name = "RByesrevision";
            this.RByesrevision.Size = new System.Drawing.Size(36, 17);
            this.RByesrevision.TabIndex = 0;
            this.RByesrevision.Text = "Ja";
            this.RByesrevision.UseVisualStyleBackColor = true;
            // 
            // RBnorevision
            // 
            this.RBnorevision.AutoSize = true;
            this.RBnorevision.Checked = true;
            this.RBnorevision.Location = new System.Drawing.Point(19, 42);
            this.RBnorevision.Name = "RBnorevision";
            this.RBnorevision.Size = new System.Drawing.Size(41, 17);
            this.RBnorevision.TabIndex = 1;
            this.RBnorevision.TabStop = true;
            this.RBnorevision.Text = "Nej";
            this.RBnorevision.UseVisualStyleBackColor = true;
            // 
            // srubutton
            // 
            this.srubutton.Location = new System.Drawing.Point(336, 773);
            this.srubutton.Name = "srubutton";
            this.srubutton.Size = new System.Drawing.Size(172, 76);
            this.srubutton.TabIndex = 2;
            this.srubutton.Text = "Skapa SRU-filer";
            this.srubutton.UseVisualStyleBackColor = true;
            this.srubutton.Click += new System.EventHandler(this.srubutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(336, 690);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Adress";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(336, 717);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Postnr";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 743);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Postort";
            // 
            // TBaddress
            // 
            this.TBaddress.Location = new System.Drawing.Point(398, 687);
            this.TBaddress.Name = "TBaddress";
            this.TBaddress.Size = new System.Drawing.Size(100, 20);
            this.TBaddress.TabIndex = 6;
            // 
            // TBzip
            // 
            this.TBzip.Location = new System.Drawing.Point(398, 714);
            this.TBzip.Name = "TBzip";
            this.TBzip.Size = new System.Drawing.Size(100, 20);
            this.TBzip.TabIndex = 7;
            // 
            // TBcity
            // 
            this.TBcity.Location = new System.Drawing.Point(398, 740);
            this.TBcity.Name = "TBcity";
            this.TBcity.Size = new System.Drawing.Size(100, 20);
            this.TBcity.TabIndex = 8;
            // 
            // FormDeklaration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1484, 861);
            this.Controls.Add(this.TBcity);
            this.Controls.Add(this.TBzip);
            this.Controls.Add(this.TBaddress);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.srubutton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormDeklaration";
            this.Text = "FormDeklaration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBnorevision;
        private System.Windows.Forms.RadioButton RByesrevision;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RBnoaccountant;
        private System.Windows.Forms.RadioButton RByesaccountant;
        private System.Windows.Forms.Button srubutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBaddress;
        private System.Windows.Forms.TextBox TBzip;
        private System.Windows.Forms.TextBox TBcity;
    }
}