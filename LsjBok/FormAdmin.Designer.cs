
namespace LsjBok
{
    partial class FormAdmin
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
            this.createDBbutton = new System.Windows.Forms.Button();
            this.createuserbutton = new System.Windows.Forms.Button();
            this.createcompanybutton = new System.Windows.Forms.Button();
            this.fiscalyearbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // createDBbutton
            // 
            this.createDBbutton.Location = new System.Drawing.Point(492, 12);
            this.createDBbutton.Name = "createDBbutton";
            this.createDBbutton.Size = new System.Drawing.Size(122, 60);
            this.createDBbutton.TabIndex = 0;
            this.createDBbutton.Text = "Skapa databas";
            this.createDBbutton.UseVisualStyleBackColor = true;
            this.createDBbutton.Click += new System.EventHandler(this.createDBbutton_Click);
            // 
            // createuserbutton
            // 
            this.createuserbutton.Location = new System.Drawing.Point(492, 90);
            this.createuserbutton.Name = "createuserbutton";
            this.createuserbutton.Size = new System.Drawing.Size(122, 60);
            this.createuserbutton.TabIndex = 1;
            this.createuserbutton.Text = "Skapa användare";
            this.createuserbutton.UseVisualStyleBackColor = true;
            this.createuserbutton.Click += new System.EventHandler(this.createuserbutton_Click);
            // 
            // createcompanybutton
            // 
            this.createcompanybutton.Location = new System.Drawing.Point(492, 170);
            this.createcompanybutton.Name = "createcompanybutton";
            this.createcompanybutton.Size = new System.Drawing.Size(122, 58);
            this.createcompanybutton.TabIndex = 2;
            this.createcompanybutton.Text = "Skapa företag";
            this.createcompanybutton.UseVisualStyleBackColor = true;
            this.createcompanybutton.Click += new System.EventHandler(this.createcompanybutton_Click);
            // 
            // fiscalyearbutton
            // 
            this.fiscalyearbutton.Location = new System.Drawing.Point(492, 245);
            this.fiscalyearbutton.Name = "fiscalyearbutton";
            this.fiscalyearbutton.Size = new System.Drawing.Size(122, 60);
            this.fiscalyearbutton.TabIndex = 3;
            this.fiscalyearbutton.Text = "Skapa räkenskapsår";
            this.fiscalyearbutton.UseVisualStyleBackColor = true;
            this.fiscalyearbutton.Click += new System.EventHandler(this.fiscalyearbutton_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 450);
            this.Controls.Add(this.fiscalyearbutton);
            this.Controls.Add(this.createcompanybutton);
            this.Controls.Add(this.createuserbutton);
            this.Controls.Add(this.createDBbutton);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button createDBbutton;
        private System.Windows.Forms.Button createuserbutton;
        private System.Windows.Forms.Button createcompanybutton;
        private System.Windows.Forms.Button fiscalyearbutton;
    }
}