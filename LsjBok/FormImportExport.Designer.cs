
namespace LsjBok
{
    partial class FormImportExport
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
            this.closebutton = new System.Windows.Forms.Button();
            this.importbutton = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // closebutton
            // 
            this.closebutton.Location = new System.Drawing.Point(517, 383);
            this.closebutton.Name = "closebutton";
            this.closebutton.Size = new System.Drawing.Size(75, 38);
            this.closebutton.TabIndex = 0;
            this.closebutton.Text = "Stäng";
            this.closebutton.UseVisualStyleBackColor = true;
            this.closebutton.Click += new System.EventHandler(this.closebutton_Click);
            // 
            // importbutton
            // 
            this.importbutton.Location = new System.Drawing.Point(416, 29);
            this.importbutton.Name = "importbutton";
            this.importbutton.Size = new System.Drawing.Size(195, 56);
            this.importbutton.TabIndex = 1;
            this.importbutton.Text = "Importera SIE-fil";
            this.importbutton.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(293, 267);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // FormImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.importbutton);
            this.Controls.Add(this.closebutton);
            this.Name = "FormImportExport";
            this.Text = "FormImportExport";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closebutton;
        private System.Windows.Forms.Button importbutton;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}