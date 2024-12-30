
namespace LsjBok
{
    partial class FormVerifikatlista
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
            this.updatebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // updatebutton
            // 
            this.updatebutton.Location = new System.Drawing.Point(689, -1);
            this.updatebutton.Name = "updatebutton";
            this.updatebutton.Size = new System.Drawing.Size(113, 23);
            this.updatebutton.TabIndex = 0;
            this.updatebutton.Text = "Uppdatera";
            this.updatebutton.UseVisualStyleBackColor = true;
            this.updatebutton.Click += new System.EventHandler(this.updatebutton_Click);
            // 
            // FormVerifikatlista
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 816);
            this.Controls.Add(this.updatebutton);
            this.Name = "FormVerifikatlista";
            this.Text = "FormVerifikatlista";
            this.ResizeEnd += new System.EventHandler(this.FormVerifikatlista_ResizeEnd);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button updatebutton;
    }
}