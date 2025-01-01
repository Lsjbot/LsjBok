
namespace LsjBok
{
    partial class FormBook
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
            this.components = new System.ComponentModel.Container();
            this.bookbutton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.TBdecription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.TBdate = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.annulbutton = new System.Windows.Forms.Button();
            this.copybutton = new System.Windows.Forms.Button();
            this.changebutton = new System.Windows.Forms.Button();
            this.savemallbutton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.filedropbutton = new System.Windows.Forms.Button();
            this.TBfilename = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.loadmallbutton = new System.Windows.Forms.Button();
            this.CBmall = new System.Windows.Forms.ComboBox();
            this.CBkontosearch = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // bookbutton
            // 
            this.bookbutton.Location = new System.Drawing.Point(12, 707);
            this.bookbutton.Name = "bookbutton";
            this.bookbutton.Size = new System.Drawing.Size(98, 62);
            this.bookbutton.TabIndex = 0;
            this.bookbutton.Text = "Bokför";
            this.bookbutton.UseVisualStyleBackColor = true;
            this.bookbutton.Click += new System.EventHandler(this.bookbutton_Click);
            this.bookbutton.MouseHover += new System.EventHandler(this.bookbutton_MouseHover);
            // 
            // cancelbutton
            // 
            this.cancelbutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.cancelbutton.Location = new System.Drawing.Point(745, 705);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(107, 64);
            this.cancelbutton.TabIndex = 1;
            this.cancelbutton.Text = "Avbryt";
            this.cancelbutton.UseVisualStyleBackColor = false;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // TBdecription
            // 
            this.TBdecription.Location = new System.Drawing.Point(80, 13);
            this.TBdecription.Name = "TBdecription";
            this.TBdecription.Size = new System.Drawing.Size(688, 20);
            this.TBdecription.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Beskrivning";
            // 
            // TBdate
            // 
            this.TBdate.Location = new System.Drawing.Point(80, 48);
            this.TBdate.Name = "TBdate";
            this.TBdate.Size = new System.Drawing.Size(128, 20);
            this.TBdate.TabIndex = 4;
            this.TBdate.TextChanged += new System.EventHandler(this.TBdate_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Datum:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "ÅÅMMDD";
            // 
            // annulbutton
            // 
            this.annulbutton.Location = new System.Drawing.Point(226, 707);
            this.annulbutton.Name = "annulbutton";
            this.annulbutton.Size = new System.Drawing.Size(96, 62);
            this.annulbutton.TabIndex = 7;
            this.annulbutton.Text = "Annullera";
            this.annulbutton.UseVisualStyleBackColor = true;
            this.annulbutton.Click += new System.EventHandler(this.annulbutton_Click);
            // 
            // copybutton
            // 
            this.copybutton.Location = new System.Drawing.Point(328, 707);
            this.copybutton.Name = "copybutton";
            this.copybutton.Size = new System.Drawing.Size(104, 62);
            this.copybutton.TabIndex = 8;
            this.copybutton.Text = "Kopiera";
            this.copybutton.UseVisualStyleBackColor = true;
            this.copybutton.Click += new System.EventHandler(this.copybutton_Click);
            // 
            // changebutton
            // 
            this.changebutton.Location = new System.Drawing.Point(116, 707);
            this.changebutton.Name = "changebutton";
            this.changebutton.Size = new System.Drawing.Size(104, 62);
            this.changebutton.TabIndex = 9;
            this.changebutton.Text = "Ändra";
            this.changebutton.UseVisualStyleBackColor = true;
            this.changebutton.Click += new System.EventHandler(this.changebutton_Click);
            // 
            // savemallbutton
            // 
            this.savemallbutton.Location = new System.Drawing.Point(438, 706);
            this.savemallbutton.Name = "savemallbutton";
            this.savemallbutton.Size = new System.Drawing.Size(99, 62);
            this.savemallbutton.TabIndex = 10;
            this.savemallbutton.Text = "Spara som mall";
            this.savemallbutton.UseVisualStyleBackColor = true;
            this.savemallbutton.Click += new System.EventHandler(this.savemallbutton_Click);
            // 
            // filedropbutton
            // 
            this.filedropbutton.AllowDrop = true;
            this.filedropbutton.Location = new System.Drawing.Point(372, 36);
            this.filedropbutton.Name = "filedropbutton";
            this.filedropbutton.Size = new System.Drawing.Size(213, 59);
            this.filedropbutton.TabIndex = 11;
            this.filedropbutton.Text = "Välj underlagsfil...\r\n... eller släpp fil här.";
            this.filedropbutton.UseVisualStyleBackColor = true;
            this.filedropbutton.Click += new System.EventHandler(this.filedropbutton_Click);
            this.filedropbutton.DragDrop += new System.Windows.Forms.DragEventHandler(this.filedropbutton_DragDrop);
            this.filedropbutton.DragEnter += new System.Windows.Forms.DragEventHandler(this.filedropbutton_DragEnter);
            // 
            // TBfilename
            // 
            this.TBfilename.Location = new System.Drawing.Point(80, 75);
            this.TBfilename.Name = "TBfilename";
            this.TBfilename.Size = new System.Drawing.Size(286, 20);
            this.TBfilename.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Filnamn:";
            // 
            // loadmallbutton
            // 
            this.loadmallbutton.Location = new System.Drawing.Point(543, 707);
            this.loadmallbutton.Name = "loadmallbutton";
            this.loadmallbutton.Size = new System.Drawing.Size(196, 34);
            this.loadmallbutton.TabIndex = 14;
            this.loadmallbutton.Text = "Ladda mall";
            this.loadmallbutton.UseVisualStyleBackColor = true;
            this.loadmallbutton.Click += new System.EventHandler(this.loadmallbutton_Click);
            // 
            // CBmall
            // 
            this.CBmall.FormattingEnabled = true;
            this.CBmall.Location = new System.Drawing.Point(544, 748);
            this.CBmall.Name = "CBmall";
            this.CBmall.Size = new System.Drawing.Size(195, 21);
            this.CBmall.TabIndex = 15;
            this.CBmall.SelectedIndexChanged += new System.EventHandler(this.loadmallbutton_Click);
            // 
            // CBkontosearch
            // 
            this.CBkontosearch.AutoSize = true;
            this.CBkontosearch.Location = new System.Drawing.Point(616, 51);
            this.CBkontosearch.Name = "CBkontosearch";
            this.CBkontosearch.Size = new System.Drawing.Size(112, 17);
            this.CBkontosearch.TabIndex = 16;
            this.CBkontosearch.Text = "Aktivera kontosök";
            this.CBkontosearch.UseVisualStyleBackColor = true;
            // 
            // FormBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 781);
            this.Controls.Add(this.CBkontosearch);
            this.Controls.Add(this.CBmall);
            this.Controls.Add(this.loadmallbutton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TBfilename);
            this.Controls.Add(this.filedropbutton);
            this.Controls.Add(this.savemallbutton);
            this.Controls.Add(this.changebutton);
            this.Controls.Add(this.copybutton);
            this.Controls.Add(this.annulbutton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TBdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TBdecription);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.bookbutton);
            this.Name = "FormBook";
            this.Text = "FormBook";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bookbutton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.TextBox TBdecription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button annulbutton;
        private System.Windows.Forms.Button copybutton;
        private System.Windows.Forms.Button changebutton;
        private System.Windows.Forms.Button savemallbutton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button filedropbutton;
        private System.Windows.Forms.TextBox TBfilename;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button loadmallbutton;
        private System.Windows.Forms.ComboBox CBmall;
        private System.Windows.Forms.CheckBox CBkontosearch;
    }
}