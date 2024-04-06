
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
            this.label1 = new System.Windows.Forms.Label();
            this.TBconnectionstring = new System.Windows.Forms.TextBox();
            this.openclosefybutton = new System.Windows.Forms.Button();
            this.updatecompanybutton = new System.Windows.Forms.Button();
            this.closebutton = new System.Windows.Forms.Button();
            this.backupDBbutton = new System.Windows.Forms.Button();
            this.deleteDBbutton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // createDBbutton
            // 
            this.createDBbutton.Location = new System.Drawing.Point(492, 59);
            this.createDBbutton.Name = "createDBbutton";
            this.createDBbutton.Size = new System.Drawing.Size(122, 60);
            this.createDBbutton.TabIndex = 0;
            this.createDBbutton.Text = "Skapa databas";
            this.createDBbutton.UseVisualStyleBackColor = true;
            this.createDBbutton.Click += new System.EventHandler(this.createDBbutton_Click);
            // 
            // createuserbutton
            // 
            this.createuserbutton.Location = new System.Drawing.Point(492, 137);
            this.createuserbutton.Name = "createuserbutton";
            this.createuserbutton.Size = new System.Drawing.Size(122, 60);
            this.createuserbutton.TabIndex = 1;
            this.createuserbutton.Text = "Skapa användare";
            this.createuserbutton.UseVisualStyleBackColor = true;
            this.createuserbutton.Click += new System.EventHandler(this.createuserbutton_Click);
            // 
            // createcompanybutton
            // 
            this.createcompanybutton.Location = new System.Drawing.Point(492, 217);
            this.createcompanybutton.Name = "createcompanybutton";
            this.createcompanybutton.Size = new System.Drawing.Size(122, 58);
            this.createcompanybutton.TabIndex = 2;
            this.createcompanybutton.Text = "Skapa företag";
            this.createcompanybutton.UseVisualStyleBackColor = true;
            this.createcompanybutton.Click += new System.EventHandler(this.createcompanybutton_Click);
            // 
            // fiscalyearbutton
            // 
            this.fiscalyearbutton.Location = new System.Drawing.Point(492, 292);
            this.fiscalyearbutton.Name = "fiscalyearbutton";
            this.fiscalyearbutton.Size = new System.Drawing.Size(122, 60);
            this.fiscalyearbutton.TabIndex = 3;
            this.fiscalyearbutton.Text = "Skapa räkenskapsår";
            this.fiscalyearbutton.UseVisualStyleBackColor = true;
            this.fiscalyearbutton.Click += new System.EventHandler(this.fiscalyearbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(192, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Connectionstring för att skapa databas:";
            // 
            // TBconnectionstring
            // 
            this.TBconnectionstring.Location = new System.Drawing.Point(40, 25);
            this.TBconnectionstring.Name = "TBconnectionstring";
            this.TBconnectionstring.Size = new System.Drawing.Size(424, 20);
            this.TBconnectionstring.TabIndex = 5;
            // 
            // openclosefybutton
            // 
            this.openclosefybutton.Enabled = false;
            this.openclosefybutton.Location = new System.Drawing.Point(362, 292);
            this.openclosefybutton.Name = "openclosefybutton";
            this.openclosefybutton.Size = new System.Drawing.Size(124, 60);
            this.openclosefybutton.TabIndex = 6;
            this.openclosefybutton.Text = "Öppna/stäng räkenskapsår";
            this.openclosefybutton.UseVisualStyleBackColor = true;
            // 
            // updatecompanybutton
            // 
            this.updatecompanybutton.Enabled = false;
            this.updatecompanybutton.Location = new System.Drawing.Point(362, 217);
            this.updatecompanybutton.Name = "updatecompanybutton";
            this.updatecompanybutton.Size = new System.Drawing.Size(124, 58);
            this.updatecompanybutton.TabIndex = 7;
            this.updatecompanybutton.Text = "Uppdatera företag";
            this.updatecompanybutton.UseVisualStyleBackColor = true;
            // 
            // closebutton
            // 
            this.closebutton.Location = new System.Drawing.Point(492, 389);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(122, 49);
            this.closebutton.TabIndex = 8;
            this.closebutton.Text = "Stäng";
            this.closebutton.UseVisualStyleBackColor = true;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // backupDBbutton
            // 
            this.backupDBbutton.Location = new System.Drawing.Point(362, 59);
            this.backupDBbutton.Name = "backupDBbutton";
            this.backupDBbutton.Size = new System.Drawing.Size(124, 60);
            this.backupDBbutton.TabIndex = 9;
            this.backupDBbutton.Text = "Säkerhetskopiera databas";
            this.backupDBbutton.UseVisualStyleBackColor = true;
            this.backupDBbutton.Click += new System.EventHandler(this.backupDBbutton_Click);
            // 
            // deleteDBbutton
            // 
            this.deleteDBbutton.BackColor = System.Drawing.Color.Pink;
            this.deleteDBbutton.Location = new System.Drawing.Point(215, 59);
            this.deleteDBbutton.Name = "deleteDBbutton";
            this.deleteDBbutton.Size = new System.Drawing.Size(141, 60);
            this.deleteDBbutton.TabIndex = 10;
            this.deleteDBbutton.Text = "Radera databas";
            this.deleteDBbutton.UseVisualStyleBackColor = false;
            this.deleteDBbutton.Click += new System.EventHandler(this.deleteDBbutton_Click);
            // 
            // FormAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 450);
            this.Controls.Add(this.deleteDBbutton);
            this.Controls.Add(this.backupDBbutton);
            this.Controls.Add(this.closebutton);
            this.Controls.Add(this.updatecompanybutton);
            this.Controls.Add(this.openclosefybutton);
            this.Controls.Add(this.TBconnectionstring);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fiscalyearbutton);
            this.Controls.Add(this.createcompanybutton);
            this.Controls.Add(this.createuserbutton);
            this.Controls.Add(this.createDBbutton);
            this.Name = "FormAdmin";
            this.Text = "FormAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createDBbutton;
        private System.Windows.Forms.Button createuserbutton;
        private System.Windows.Forms.Button createcompanybutton;
        private System.Windows.Forms.Button fiscalyearbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBconnectionstring;
        private System.Windows.Forms.Button openclosefybutton;
        private System.Windows.Forms.Button updatecompanybutton;
        private System.Windows.Forms.Button closebutton;
        private System.Windows.Forms.Button backupDBbutton;
        private System.Windows.Forms.Button deleteDBbutton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}