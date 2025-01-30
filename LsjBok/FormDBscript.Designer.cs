
namespace LsjBok
{
    partial class FormDBscript
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
            this.scriptbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // scriptbutton
            // 
            this.scriptbutton.Location = new System.Drawing.Point(293, 306);
            this.scriptbutton.Name = "scriptbutton";
            this.scriptbutton.Size = new System.Drawing.Size(193, 69);
            this.scriptbutton.TabIndex = 0;
            this.scriptbutton.Text = "Skapa SQL-fil med alla bokföringsdata";
            this.scriptbutton.UseVisualStyleBackColor = true;
            this.scriptbutton.Click += new System.EventHandler(this.scriptbutton_Click);
            // 
            // FormDBscript
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scriptbutton);
            this.Name = "FormDBscript";
            this.Text = "FormDBscript";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button scriptbutton;
    }
}