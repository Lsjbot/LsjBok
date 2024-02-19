
namespace LsjBok
{
    partial class Form1
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
            this.quitbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.folderlabel = new System.Windows.Forms.Label();
            this.folderchangebutton = new System.Windows.Forms.Button();
            this.adminbutton = new System.Windows.Forms.Button();
            this.bookbutton = new System.Windows.Forms.Button();
            this.LBuser = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LBcompany = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.LBfiscal = new System.Windows.Forms.ListBox();
            this.huvudbokbutton = new System.Windows.Forms.Button();
            this.importexportbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // quitbutton
            // 
            this.quitbutton.Location = new System.Drawing.Point(608, 367);
            this.quitbutton.Name = "quitbutton";
            this.quitbutton.Size = new System.Drawing.Size(103, 71);
            this.quitbutton.TabIndex = 0;
            this.quitbutton.Text = "Avsluta";
            this.quitbutton.UseVisualStyleBackColor = true;
            this.quitbutton.Click += new System.EventHandler(this.quitbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Bokföringsmapp:";
            // 
            // folderlabel
            // 
            this.folderlabel.AutoSize = true;
            this.folderlabel.Location = new System.Drawing.Point(145, 384);
            this.folderlabel.Name = "folderlabel";
            this.folderlabel.Size = new System.Drawing.Size(35, 13);
            this.folderlabel.TabIndex = 2;
            this.folderlabel.Text = "label2";
            // 
            // folderchangebutton
            // 
            this.folderchangebutton.Location = new System.Drawing.Point(41, 401);
            this.folderchangebutton.Name = "folderchangebutton";
            this.folderchangebutton.Size = new System.Drawing.Size(73, 37);
            this.folderchangebutton.TabIndex = 3;
            this.folderchangebutton.Text = "Byt mapp";
            this.folderchangebutton.UseVisualStyleBackColor = true;
            this.folderchangebutton.Click += new System.EventHandler(this.folderchangebutton_Click);
            // 
            // adminbutton
            // 
            this.adminbutton.Location = new System.Drawing.Point(545, 32);
            this.adminbutton.Name = "adminbutton";
            this.adminbutton.Size = new System.Drawing.Size(166, 61);
            this.adminbutton.TabIndex = 4;
            this.adminbutton.Text = "Administrera";
            this.adminbutton.UseVisualStyleBackColor = true;
            this.adminbutton.Click += new System.EventHandler(this.adminbutton_Click);
            // 
            // bookbutton
            // 
            this.bookbutton.Location = new System.Drawing.Point(545, 115);
            this.bookbutton.Name = "bookbutton";
            this.bookbutton.Size = new System.Drawing.Size(166, 62);
            this.bookbutton.TabIndex = 5;
            this.bookbutton.Text = "Bokföra";
            this.bookbutton.UseVisualStyleBackColor = true;
            this.bookbutton.Click += new System.EventHandler(this.bookbutton_Click);
            // 
            // LBuser
            // 
            this.LBuser.FormattingEnabled = true;
            this.LBuser.Location = new System.Drawing.Point(26, 38);
            this.LBuser.Name = "LBuser";
            this.LBuser.Size = new System.Drawing.Size(120, 95);
            this.LBuser.TabIndex = 6;
            this.LBuser.SelectedIndexChanged += new System.EventHandler(this.LBuser_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Användare:";
            // 
            // LBcompany
            // 
            this.LBcompany.FormattingEnabled = true;
            this.LBcompany.Location = new System.Drawing.Point(26, 162);
            this.LBcompany.Name = "LBcompany";
            this.LBcompany.Size = new System.Drawing.Size(120, 95);
            this.LBcompany.TabIndex = 8;
            this.LBcompany.SelectedIndexChanged += new System.EventHandler(this.LBcompany_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Företag";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(186, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Räkenskapsår";
            // 
            // LBfiscal
            // 
            this.LBfiscal.FormattingEnabled = true;
            this.LBfiscal.Location = new System.Drawing.Point(189, 38);
            this.LBfiscal.Name = "LBfiscal";
            this.LBfiscal.Size = new System.Drawing.Size(120, 212);
            this.LBfiscal.TabIndex = 11;
            this.LBfiscal.SelectedIndexChanged += new System.EventHandler(this.LBfiscal_SelectedIndexChanged);
            // 
            // huvudbokbutton
            // 
            this.huvudbokbutton.Location = new System.Drawing.Point(337, 32);
            this.huvudbokbutton.Name = "huvudbokbutton";
            this.huvudbokbutton.Size = new System.Drawing.Size(166, 39);
            this.huvudbokbutton.TabIndex = 12;
            this.huvudbokbutton.Text = "Huvudbok";
            this.huvudbokbutton.UseVisualStyleBackColor = true;
            this.huvudbokbutton.Click += new System.EventHandler(this.huvudbokbutton_Click);
            // 
            // importexportbutton
            // 
            this.importexportbutton.Location = new System.Drawing.Point(545, 204);
            this.importexportbutton.Name = "importexportbutton";
            this.importexportbutton.Size = new System.Drawing.Size(166, 68);
            this.importexportbutton.TabIndex = 13;
            this.importexportbutton.Text = "Importera\r\nexportera";
            this.importexportbutton.UseVisualStyleBackColor = true;
            this.importexportbutton.Click += new System.EventHandler(this.importexportbutton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 450);
            this.Controls.Add(this.importexportbutton);
            this.Controls.Add(this.huvudbokbutton);
            this.Controls.Add(this.LBfiscal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LBcompany);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LBuser);
            this.Controls.Add(this.bookbutton);
            this.Controls.Add(this.adminbutton);
            this.Controls.Add(this.folderchangebutton);
            this.Controls.Add(this.folderlabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.quitbutton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button quitbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label folderlabel;
        private System.Windows.Forms.Button folderchangebutton;
        private System.Windows.Forms.Button adminbutton;
        public System.Windows.Forms.Button bookbutton;
        private System.Windows.Forms.ListBox LBuser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox LBcompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox LBfiscal;
        private System.Windows.Forms.Button huvudbokbutton;
        private System.Windows.Forms.Button importexportbutton;
    }
}

