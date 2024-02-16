
namespace LsjBok
{
    partial class FormAddcompany
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
            this.label1 = new System.Windows.Forms.Label();
            this.TBnamn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TBorgnr = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LBcompanytype = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.TBaddress = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TBphone = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TBemail = new System.Windows.Forms.TextBox();
            this.createbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RBkontant = new System.Windows.Forms.RadioButton();
            this.RBfaktura = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.RB1month = new System.Windows.Forms.RadioButton();
            this.RB3months = new System.Windows.Forms.RadioButton();
            this.RB12months = new System.Windows.Forms.RadioButton();
            this.RBnomoms = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Namn:";
            // 
            // TBnamn
            // 
            this.TBnamn.Location = new System.Drawing.Point(85, 28);
            this.TBnamn.Name = "TBnamn";
            this.TBnamn.Size = new System.Drawing.Size(377, 20);
            this.TBnamn.TabIndex = 1;
            this.TBnamn.TextChanged += new System.EventHandler(this.TBnamn_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Organisationsnummer";
            // 
            // TBorgnr
            // 
            this.TBorgnr.Location = new System.Drawing.Point(151, 54);
            this.TBorgnr.Name = "TBorgnr";
            this.TBorgnr.Size = new System.Drawing.Size(118, 20);
            this.TBorgnr.TabIndex = 3;
            this.TBorgnr.TextChanged += new System.EventHandler(this.TBorgnr_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "XXYYZZ-AAAA";
            // 
            // LBcompanytype
            // 
            this.LBcompanytype.FormattingEnabled = true;
            this.LBcompanytype.Location = new System.Drawing.Point(430, 57);
            this.LBcompanytype.Name = "LBcompanytype";
            this.LBcompanytype.Size = new System.Drawing.Size(167, 290);
            this.LBcompanytype.TabIndex = 5;
            this.LBcompanytype.SelectedIndexChanged += new System.EventHandler(this.LBcompanytype_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Adress:";
            // 
            // TBaddress
            // 
            this.TBaddress.Location = new System.Drawing.Point(85, 86);
            this.TBaddress.Name = "TBaddress";
            this.TBaddress.Size = new System.Drawing.Size(311, 96);
            this.TBaddress.TabIndex = 7;
            this.TBaddress.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Telefon:";
            // 
            // TBphone
            // 
            this.TBphone.Location = new System.Drawing.Point(85, 202);
            this.TBphone.Name = "TBphone";
            this.TBphone.Size = new System.Drawing.Size(136, 20);
            this.TBphone.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "E-post";
            // 
            // TBemail
            // 
            this.TBemail.Location = new System.Drawing.Point(85, 244);
            this.TBemail.Name = "TBemail";
            this.TBemail.Size = new System.Drawing.Size(229, 20);
            this.TBemail.TabIndex = 11;
            // 
            // createbutton
            // 
            this.createbutton.Location = new System.Drawing.Point(107, 407);
            this.createbutton.Name = "createbutton";
            this.createbutton.Size = new System.Drawing.Size(147, 52);
            this.createbutton.TabIndex = 12;
            this.createbutton.Text = "Skapa";
            this.createbutton.UseVisualStyleBackColor = true;
            this.createbutton.Click += new System.EventHandler(this.createbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(419, 409);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(120, 50);
            this.cancelbutton.TabIndex = 13;
            this.cancelbutton.Text = "Avbryt";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RBfaktura);
            this.groupBox1.Controls.Add(this.RBkontant);
            this.groupBox1.Location = new System.Drawing.Point(33, 277);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(150, 70);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bokföringsmetod";
            // 
            // RBkontant
            // 
            this.RBkontant.AutoSize = true;
            this.RBkontant.Checked = true;
            this.RBkontant.Location = new System.Drawing.Point(7, 20);
            this.RBkontant.Name = "RBkontant";
            this.RBkontant.Size = new System.Drawing.Size(103, 17);
            this.RBkontant.TabIndex = 0;
            this.RBkontant.TabStop = true;
            this.RBkontant.Text = "Kontantmetoden";
            this.RBkontant.UseVisualStyleBackColor = true;
            // 
            // RBfaktura
            // 
            this.RBfaktura.AutoSize = true;
            this.RBfaktura.Location = new System.Drawing.Point(7, 44);
            this.RBfaktura.Name = "RBfaktura";
            this.RBfaktura.Size = new System.Drawing.Size(124, 17);
            this.RBfaktura.TabIndex = 1;
            this.RBfaktura.Text = "Faktureringsmetoden";
            this.RBfaktura.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.RBnomoms);
            this.groupBox2.Controls.Add(this.RB12months);
            this.groupBox2.Controls.Add(this.RB3months);
            this.groupBox2.Controls.Add(this.RB1month);
            this.groupBox2.Location = new System.Drawing.Point(196, 277);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 116);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Momsperiod";
            // 
            // RB1month
            // 
            this.RB1month.AutoSize = true;
            this.RB1month.Location = new System.Drawing.Point(7, 20);
            this.RB1month.Name = "RB1month";
            this.RB1month.Size = new System.Drawing.Size(66, 17);
            this.RB1month.TabIndex = 0;
            this.RB1month.Text = "1 månad";
            this.RB1month.UseVisualStyleBackColor = true;
            // 
            // RB3months
            // 
            this.RB3months.AutoSize = true;
            this.RB3months.Location = new System.Drawing.Point(7, 43);
            this.RB3months.Name = "RB3months";
            this.RB3months.Size = new System.Drawing.Size(75, 17);
            this.RB3months.TabIndex = 1;
            this.RB3months.Text = "3 månader";
            this.RB3months.UseVisualStyleBackColor = true;
            // 
            // RB12months
            // 
            this.RB12months.AutoSize = true;
            this.RB12months.Checked = true;
            this.RB12months.Location = new System.Drawing.Point(7, 66);
            this.RB12months.Name = "RB12months";
            this.RB12months.Size = new System.Drawing.Size(81, 17);
            this.RB12months.TabIndex = 2;
            this.RB12months.TabStop = true;
            this.RB12months.Text = "12 månader";
            this.RB12months.UseVisualStyleBackColor = true;
            // 
            // RBnomoms
            // 
            this.RBnomoms.AutoSize = true;
            this.RBnomoms.Location = new System.Drawing.Point(7, 89);
            this.RBnomoms.Name = "RBnomoms";
            this.RBnomoms.Size = new System.Drawing.Size(94, 17);
            this.RBnomoms.TabIndex = 3;
            this.RBnomoms.TabStop = true;
            this.RBnomoms.Text = "Ej momspliktigt";
            this.RBnomoms.UseVisualStyleBackColor = true;
            // 
            // FormAddcompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 471);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.createbutton);
            this.Controls.Add(this.TBemail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TBphone);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TBaddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LBcompanytype);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBorgnr);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBnamn);
            this.Controls.Add(this.label1);
            this.Name = "FormAddcompany";
            this.Text = "FormAddcompany";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBnamn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBorgnr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox LBcompanytype;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox TBaddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TBphone;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TBemail;
        private System.Windows.Forms.Button createbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RBfaktura;
        private System.Windows.Forms.RadioButton RBkontant;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton RB12months;
        private System.Windows.Forms.RadioButton RB3months;
        private System.Windows.Forms.RadioButton RB1month;
        private System.Windows.Forms.RadioButton RBnomoms;
    }
}