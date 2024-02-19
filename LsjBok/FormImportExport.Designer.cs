
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
            this.label1 = new System.Windows.Forms.Label();
            this.exportbutton = new System.Windows.Forms.Button();
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
            this.importbutton.Location = new System.Drawing.Point(446, 29);
            this.importbutton.Name = "importbutton";
            this.importbutton.Size = new System.Drawing.Size(165, 56);
            this.importbutton.TabIndex = 1;
            this.importbutton.Text = "Importera SIE-fil";
            this.importbutton.UseVisualStyleBackColor = true;
            this.importbutton.Click += new System.EventHandler(this.importbutton_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(24, 29);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(395, 267);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 65);
            this.label1.TabIndex = 3;
            this.label1.Text = "Begränsningar vid SIE-import:\r\nHanterar bara en verifikatserie.\r\nHanterar inte ob" +
    "jekt.\r\nHanterar inte #BTRANS och #RTRANS\r\nHanterar inte utländsk valuta eller ol" +
    "ika enheter\r\n";
            // 
            // exportbutton
            // 
            this.exportbutton.Location = new System.Drawing.Point(446, 104);
            this.exportbutton.Name = "exportbutton";
            this.exportbutton.Size = new System.Drawing.Size(165, 59);
            this.exportbutton.TabIndex = 4;
            this.exportbutton.Text = "Exportera SIE-fil \r\n(valt räkenskapsår)";
            this.exportbutton.UseVisualStyleBackColor = true;
            this.exportbutton.Click += new System.EventHandler(this.exportbutton_Click);
            // 
            // FormImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 450);
            this.Controls.Add(this.exportbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.importbutton);
            this.Controls.Add(this.closebutton);
            this.Name = "FormImportExport";
            this.Text = "FormImportExport";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button closebutton;
        private System.Windows.Forms.Button importbutton;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button exportbutton;
    }
}