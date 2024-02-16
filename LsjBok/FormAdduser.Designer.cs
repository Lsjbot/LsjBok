
namespace LsjBok
{
    partial class FormAdduser
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
            this.TBpw1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TBpw2 = new System.Windows.Forms.TextBox();
            this.createbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(56, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Namn";
            // 
            // TBnamn
            // 
            this.TBnamn.Location = new System.Drawing.Point(115, 27);
            this.TBnamn.Name = "TBnamn";
            this.TBnamn.Size = new System.Drawing.Size(290, 20);
            this.TBnamn.TabIndex = 1;
            this.TBnamn.TextChanged += new System.EventHandler(this.TBnamn_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(46, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lösenord:";
            // 
            // TBpw1
            // 
            this.TBpw1.Location = new System.Drawing.Point(115, 59);
            this.TBpw1.Name = "TBpw1";
            this.TBpw1.Size = new System.Drawing.Size(142, 20);
            this.TBpw1.TabIndex = 3;
            this.TBpw1.TextChanged += new System.EventHandler(this.TBpw1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Upprepa lösenord";
            // 
            // TBpw2
            // 
            this.TBpw2.Location = new System.Drawing.Point(115, 93);
            this.TBpw2.Name = "TBpw2";
            this.TBpw2.PasswordChar = '*';
            this.TBpw2.Size = new System.Drawing.Size(142, 20);
            this.TBpw2.TabIndex = 5;
            this.TBpw2.TextChanged += new System.EventHandler(this.TBpw2_TextChanged);
            // 
            // createbutton
            // 
            this.createbutton.Enabled = false;
            this.createbutton.Location = new System.Drawing.Point(115, 184);
            this.createbutton.Name = "createbutton";
            this.createbutton.Size = new System.Drawing.Size(138, 36);
            this.createbutton.TabIndex = 6;
            this.createbutton.Text = "Skapa";
            this.createbutton.UseVisualStyleBackColor = true;
            this.createbutton.Click += new System.EventHandler(this.createbutton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(312, 184);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(93, 36);
            this.cancelbutton.TabIndex = 7;
            this.cancelbutton.Text = "Avbryt";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // FormAdduser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 232);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.createbutton);
            this.Controls.Add(this.TBpw2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TBpw1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBnamn);
            this.Controls.Add(this.label1);
            this.Name = "FormAdduser";
            this.Text = "FormAdduser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBnamn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TBpw1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBpw2;
        private System.Windows.Forms.Button createbutton;
        private System.Windows.Forms.Button cancelbutton;
    }
}