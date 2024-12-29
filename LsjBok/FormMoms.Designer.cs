
namespace LsjBok
{
    partial class FormMoms
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
            this.LBfiscal = new System.Windows.Forms.ListBox();
            this.LBperiod = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.makeperiodbutton = new System.Windows.Forms.Button();
            this.momsxmlbutton = new System.Windows.Forms.Button();
            this.momsbookbutton = new System.Windows.Forms.Button();
            this.momspaybutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LBfiscal
            // 
            this.LBfiscal.FormattingEnabled = true;
            this.LBfiscal.Location = new System.Drawing.Point(16, 24);
            this.LBfiscal.Name = "LBfiscal";
            this.LBfiscal.Size = new System.Drawing.Size(105, 160);
            this.LBfiscal.TabIndex = 0;
            this.LBfiscal.SelectedIndexChanged += new System.EventHandler(this.LBfiscal_SelectedIndexChanged);
            // 
            // LBperiod
            // 
            this.LBperiod.FormattingEnabled = true;
            this.LBperiod.Location = new System.Drawing.Point(16, 207);
            this.LBperiod.Name = "LBperiod";
            this.LBperiod.Size = new System.Drawing.Size(105, 173);
            this.LBperiod.TabIndex = 1;
            this.LBperiod.SelectedIndexChanged += new System.EventHandler(this.LBperiod_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Räkenskapsår";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Momsperiod";
            // 
            // makeperiodbutton
            // 
            this.makeperiodbutton.Enabled = false;
            this.makeperiodbutton.Location = new System.Drawing.Point(3, 386);
            this.makeperiodbutton.Name = "makeperiodbutton";
            this.makeperiodbutton.Size = new System.Drawing.Size(118, 23);
            this.makeperiodbutton.TabIndex = 4;
            this.makeperiodbutton.Text = "Skapa momsperioder";
            this.makeperiodbutton.UseVisualStyleBackColor = true;
            this.makeperiodbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // momsxmlbutton
            // 
            this.momsxmlbutton.Location = new System.Drawing.Point(3, 444);
            this.momsxmlbutton.Name = "momsxmlbutton";
            this.momsxmlbutton.Size = new System.Drawing.Size(118, 53);
            this.momsxmlbutton.TabIndex = 5;
            this.momsxmlbutton.Text = "Skapa momsrapport åt Skatteverket";
            this.momsxmlbutton.UseVisualStyleBackColor = true;
            this.momsxmlbutton.Click += new System.EventHandler(this.momsxmlbutton_Click);
            // 
            // momsbookbutton
            // 
            this.momsbookbutton.Location = new System.Drawing.Point(3, 513);
            this.momsbookbutton.Name = "momsbookbutton";
            this.momsbookbutton.Size = new System.Drawing.Size(118, 50);
            this.momsbookbutton.TabIndex = 6;
            this.momsbookbutton.Text = "Bokför momsrapport";
            this.momsbookbutton.UseVisualStyleBackColor = true;
            this.momsbookbutton.Click += new System.EventHandler(this.momsbookbutton_Click);
            // 
            // momspaybutton
            // 
            this.momspaybutton.Location = new System.Drawing.Point(3, 582);
            this.momspaybutton.Name = "momspaybutton";
            this.momspaybutton.Size = new System.Drawing.Size(118, 44);
            this.momspaybutton.TabIndex = 7;
            this.momspaybutton.Text = "Bokför momsbetalning";
            this.momspaybutton.UseVisualStyleBackColor = true;
            this.momspaybutton.Click += new System.EventHandler(this.momspaybutton_Click);
            // 
            // FormMoms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 761);
            this.Controls.Add(this.momspaybutton);
            this.Controls.Add(this.momsbookbutton);
            this.Controls.Add(this.momsxmlbutton);
            this.Controls.Add(this.makeperiodbutton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBperiod);
            this.Controls.Add(this.LBfiscal);
            this.Name = "FormMoms";
            this.Text = "FormMoms";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBfiscal;
        private System.Windows.Forms.ListBox LBperiod;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button makeperiodbutton;
        private System.Windows.Forms.Button momsxmlbutton;
        private System.Windows.Forms.Button momsbookbutton;
        private System.Windows.Forms.Button momspaybutton;
    }
}