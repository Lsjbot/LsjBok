
namespace LsjBok
{
    partial class FormBokslut
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
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.RBnobook = new System.Windows.Forms.RadioButton();
            this.RByesbook = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TBrorelseresultat = new System.Windows.Forms.TextBox();
            this.TBresultatbokdisp = new System.Windows.Forms.TextBox();
            this.TBbokdisp = new System.Windows.Forms.TextBox();
            this.TBskattesats = new System.Windows.Forms.TextBox();
            this.TBskatt = new System.Windows.Forms.TextBox();
            this.TBefterskatt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.TBresultatfinans = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RBnomoms = new System.Windows.Forms.RadioButton();
            this.momsbutton = new System.Windows.Forms.Button();
            this.RByesmoms = new System.Windows.Forms.RadioButton();
            this.label11 = new System.Windows.Forms.Label();
            this.RBnodisp = new System.Windows.Forms.RadioButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.aterforandebutton = new System.Windows.Forms.Button();
            this.CBaterforande = new System.Windows.Forms.ComboBox();
            this.avsattningbutton = new System.Windows.Forms.Button();
            this.TBavsattning = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.RByesdisp = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label16 = new System.Windows.Forms.Label();
            this.RBnodiscount = new System.Windows.Forms.RadioButton();
            this.label15 = new System.Windows.Forms.Label();
            this.RByesdiscount = new System.Windows.Forms.RadioButton();
            this.updatebutton = new System.Windows.Forms.Button();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.RBnobalance = new System.Windows.Forms.RadioButton();
            this.label18 = new System.Windows.Forms.Label();
            this.RByesbalance = new System.Windows.Forms.RadioButton();
            this.bookprofitbutton = new System.Windows.Forms.Button();
            this.closeyearbutton = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.TBskattejust = new System.Windows.Forms.TextBox();
            this.TBskatteunderlag = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // LBfiscal
            // 
            this.LBfiscal.FormattingEnabled = true;
            this.LBfiscal.Location = new System.Drawing.Point(772, 17);
            this.LBfiscal.Name = "LBfiscal";
            this.LBfiscal.Size = new System.Drawing.Size(120, 212);
            this.LBfiscal.TabIndex = 13;
            this.LBfiscal.SelectedIndexChanged += new System.EventHandler(this.LBfiscal_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(779, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Räkenskapsår";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Har du bokfört alla årets affärshändelser?";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.RBnobook);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RByesbook);
            this.panel1.Location = new System.Drawing.Point(12, 9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(327, 51);
            this.panel1.TabIndex = 15;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // RBnobook
            // 
            this.RBnobook.AutoSize = true;
            this.RBnobook.Checked = true;
            this.RBnobook.Location = new System.Drawing.Point(251, 31);
            this.RBnobook.Name = "RBnobook";
            this.RBnobook.Size = new System.Drawing.Size(41, 17);
            this.RBnobook.TabIndex = 1;
            this.RBnobook.TabStop = true;
            this.RBnobook.Text = "Nej";
            this.RBnobook.UseVisualStyleBackColor = true;
            this.RBnobook.CheckedChanged += new System.EventHandler(this.RBnobook_CheckedChanged);
            // 
            // RByesbook
            // 
            this.RByesbook.AutoSize = true;
            this.RByesbook.Location = new System.Drawing.Point(251, 8);
            this.RByesbook.Name = "RByesbook";
            this.RByesbook.Size = new System.Drawing.Size(37, 17);
            this.RByesbook.TabIndex = 0;
            this.RByesbook.Text = "JA";
            this.RByesbook.UseVisualStyleBackColor = true;
            this.RByesbook.CheckedChanged += new System.EventHandler(this.RByesbook_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(359, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Årets resultat före skatt:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(359, 217);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Skattesats:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(359, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Skatt på årets resultat:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(359, 281);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Resultat efter skatt:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(359, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(217, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = "Resultat före bokslutsdispositioner och skatt:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(359, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "Bokslutsdispositioner:";
            // 
            // TBrorelseresultat
            // 
            this.TBrorelseresultat.Location = new System.Drawing.Point(586, 6);
            this.TBrorelseresultat.Name = "TBrorelseresultat";
            this.TBrorelseresultat.Size = new System.Drawing.Size(161, 20);
            this.TBrorelseresultat.TabIndex = 22;
            // 
            // TBresultatbokdisp
            // 
            this.TBresultatbokdisp.Location = new System.Drawing.Point(586, 113);
            this.TBresultatbokdisp.Name = "TBresultatbokdisp";
            this.TBresultatbokdisp.Size = new System.Drawing.Size(161, 20);
            this.TBresultatbokdisp.TabIndex = 23;
            // 
            // TBbokdisp
            // 
            this.TBbokdisp.Location = new System.Drawing.Point(586, 87);
            this.TBbokdisp.Name = "TBbokdisp";
            this.TBbokdisp.Size = new System.Drawing.Size(161, 20);
            this.TBbokdisp.TabIndex = 24;
            // 
            // TBskattesats
            // 
            this.TBskattesats.Location = new System.Drawing.Point(586, 217);
            this.TBskattesats.Name = "TBskattesats";
            this.TBskattesats.Size = new System.Drawing.Size(60, 20);
            this.TBskattesats.TabIndex = 25;
            // 
            // TBskatt
            // 
            this.TBskatt.Location = new System.Drawing.Point(586, 247);
            this.TBskatt.Name = "TBskatt";
            this.TBskatt.Size = new System.Drawing.Size(161, 20);
            this.TBskatt.TabIndex = 26;
            // 
            // TBefterskatt
            // 
            this.TBefterskatt.Location = new System.Drawing.Point(586, 281);
            this.TBefterskatt.Name = "TBefterskatt";
            this.TBefterskatt.Size = new System.Drawing.Size(161, 20);
            this.TBefterskatt.TabIndex = 27;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(653, 223);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 13);
            this.label9.TabIndex = 28;
            this.label9.Text = "%";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(359, 13);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Rörelseresultat";
            // 
            // TBresultatfinans
            // 
            this.TBresultatfinans.Location = new System.Drawing.Point(586, 33);
            this.TBresultatfinans.Name = "TBresultatfinans";
            this.TBresultatfinans.Size = new System.Drawing.Size(161, 20);
            this.TBresultatfinans.TabIndex = 30;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MistyRose;
            this.panel2.Controls.Add(this.RBnomoms);
            this.panel2.Controls.Add(this.momsbutton);
            this.panel2.Controls.Add(this.RByesmoms);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Location = new System.Drawing.Point(12, 67);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(327, 91);
            this.panel2.TabIndex = 31;
            // 
            // RBnomoms
            // 
            this.RBnomoms.AutoSize = true;
            this.RBnomoms.Checked = true;
            this.RBnomoms.Location = new System.Drawing.Point(251, 26);
            this.RBnomoms.Name = "RBnomoms";
            this.RBnomoms.Size = new System.Drawing.Size(41, 17);
            this.RBnomoms.TabIndex = 18;
            this.RBnomoms.TabStop = true;
            this.RBnomoms.Text = "Nej";
            this.RBnomoms.UseVisualStyleBackColor = true;
            this.RBnomoms.CheckedChanged += new System.EventHandler(this.RBnobook_CheckedChanged);
            // 
            // momsbutton
            // 
            this.momsbutton.Location = new System.Drawing.Point(31, 53);
            this.momsbutton.Name = "momsbutton";
            this.momsbutton.Size = new System.Drawing.Size(137, 23);
            this.momsbutton.TabIndex = 16;
            this.momsbutton.Text = "Deklarera moms";
            this.momsbutton.UseVisualStyleBackColor = true;
            this.momsbutton.Click += new System.EventHandler(this.momsbutton_Click);
            // 
            // RByesmoms
            // 
            this.RByesmoms.AutoSize = true;
            this.RByesmoms.Location = new System.Drawing.Point(251, 3);
            this.RByesmoms.Name = "RByesmoms";
            this.RByesmoms.Size = new System.Drawing.Size(37, 17);
            this.RByesmoms.TabIndex = 15;
            this.RByesmoms.Text = "JA";
            this.RByesmoms.UseVisualStyleBackColor = true;
            this.RByesmoms.CheckedChanged += new System.EventHandler(this.RByesbook_CheckedChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 20);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(182, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Har du momsdeklarerat alla perioder?";
            // 
            // RBnodisp
            // 
            this.RBnodisp.AutoSize = true;
            this.RBnodisp.Checked = true;
            this.RBnodisp.Location = new System.Drawing.Point(250, 29);
            this.RBnodisp.Name = "RBnodisp";
            this.RBnodisp.Size = new System.Drawing.Size(41, 17);
            this.RBnodisp.TabIndex = 15;
            this.RBnodisp.TabStop = true;
            this.RBnodisp.Text = "Nej";
            this.RBnodisp.UseVisualStyleBackColor = true;
            this.RBnodisp.CheckedChanged += new System.EventHandler(this.RBnobook_CheckedChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.MistyRose;
            this.panel3.Controls.Add(this.aterforandebutton);
            this.panel3.Controls.Add(this.CBaterforande);
            this.panel3.Controls.Add(this.avsattningbutton);
            this.panel3.Controls.Add(this.TBavsattning);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.RByesdisp);
            this.panel3.Controls.Add(this.RBnodisp);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Location = new System.Drawing.Point(12, 324);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(327, 142);
            this.panel3.TabIndex = 32;
            // 
            // aterforandebutton
            // 
            this.aterforandebutton.Location = new System.Drawing.Point(125, 102);
            this.aterforandebutton.Name = "aterforandebutton";
            this.aterforandebutton.Size = new System.Drawing.Size(119, 37);
            this.aterforandebutton.TabIndex = 23;
            this.aterforandebutton.Text = "Bokför återförande";
            this.aterforandebutton.UseVisualStyleBackColor = true;
            this.aterforandebutton.Click += new System.EventHandler(this.aterforandebutton_Click);
            // 
            // CBaterforande
            // 
            this.CBaterforande.FormattingEnabled = true;
            this.CBaterforande.Location = new System.Drawing.Point(114, 75);
            this.CBaterforande.Name = "CBaterforande";
            this.CBaterforande.Size = new System.Drawing.Size(199, 21);
            this.CBaterforande.TabIndex = 22;
            this.CBaterforande.SelectedIndexChanged += new System.EventHandler(this.CBaterforande_SelectedIndexChanged);
            // 
            // avsattningbutton
            // 
            this.avsattningbutton.Location = new System.Drawing.Point(14, 102);
            this.avsattningbutton.Name = "avsattningbutton";
            this.avsattningbutton.Size = new System.Drawing.Size(94, 37);
            this.avsattningbutton.TabIndex = 21;
            this.avsattningbutton.Text = "Bokför avsättning";
            this.avsattningbutton.UseVisualStyleBackColor = true;
            this.avsattningbutton.Click += new System.EventHandler(this.avsattningbutton_Click);
            // 
            // TBavsattning
            // 
            this.TBavsattning.Location = new System.Drawing.Point(14, 76);
            this.TBavsattning.Name = "TBavsattning";
            this.TBavsattning.Size = new System.Drawing.Size(94, 20);
            this.TBavsattning.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(150, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(62, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Återförande";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(17, 59);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 13);
            this.label13.TabIndex = 18;
            this.label13.Text = "Ny avsättning";
            // 
            // RByesdisp
            // 
            this.RByesdisp.AutoSize = true;
            this.RByesdisp.Location = new System.Drawing.Point(250, 6);
            this.RByesdisp.Name = "RByesdisp";
            this.RByesdisp.Size = new System.Drawing.Size(37, 17);
            this.RByesdisp.TabIndex = 17;
            this.RByesdisp.Text = "JA";
            this.RByesdisp.UseVisualStyleBackColor = true;
            this.RByesdisp.CheckedChanged += new System.EventHandler(this.RByesbook_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(11, 13);
            this.label12.MaximumSize = new System.Drawing.Size(200, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(182, 26);
            this.label12.TabIndex = 17;
            this.label12.Text = "Har du bokfört eventuella ändringar i periodiseringsfonder?";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MistyRose;
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.RBnodiscount);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.RByesdiscount);
            this.panel4.Location = new System.Drawing.Point(12, 253);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(327, 65);
            this.panel4.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(11, 35);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(174, 13);
            this.label16.TabIndex = 15;
            this.label16.Text = "(avskrivningar, periodiseringar etc. )";
            // 
            // RBnodiscount
            // 
            this.RBnodiscount.AutoSize = true;
            this.RBnodiscount.Checked = true;
            this.RBnodiscount.Location = new System.Drawing.Point(251, 31);
            this.RBnodiscount.Name = "RBnodiscount";
            this.RBnodiscount.Size = new System.Drawing.Size(41, 17);
            this.RBnodiscount.TabIndex = 1;
            this.RBnodiscount.TabStop = true;
            this.RBnodiscount.Text = "Nej";
            this.RBnodiscount.UseVisualStyleBackColor = true;
            this.RBnodiscount.CheckedChanged += new System.EventHandler(this.RBnobook_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(12, 21);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(176, 13);
            this.label15.TabIndex = 14;
            this.label15.Text = "Har du gjort alla bokslutsbokningar?";
            // 
            // RByesdiscount
            // 
            this.RByesdiscount.AutoSize = true;
            this.RByesdiscount.Location = new System.Drawing.Point(251, 8);
            this.RByesdiscount.Name = "RByesdiscount";
            this.RByesdiscount.Size = new System.Drawing.Size(37, 17);
            this.RByesdiscount.TabIndex = 0;
            this.RByesdiscount.Text = "JA";
            this.RByesdiscount.UseVisualStyleBackColor = true;
            this.RByesdiscount.CheckedChanged += new System.EventHandler(this.RByesbook_CheckedChanged);
            // 
            // updatebutton
            // 
            this.updatebutton.Location = new System.Drawing.Point(772, 236);
            this.updatebutton.Name = "updatebutton";
            this.updatebutton.Size = new System.Drawing.Size(120, 23);
            this.updatebutton.TabIndex = 33;
            this.updatebutton.Text = "Uppdatera";
            this.updatebutton.UseVisualStyleBackColor = true;
            this.updatebutton.Click += new System.EventHandler(this.updatebutton_Click);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.MistyRose;
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.RBnobalance);
            this.panel5.Controls.Add(this.label18);
            this.panel5.Controls.Add(this.RByesbalance);
            this.panel5.Location = new System.Drawing.Point(12, 164);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(327, 83);
            this.panel5.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(11, 35);
            this.label17.MaximumSize = new System.Drawing.Size(200, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(187, 26);
            this.label17.TabIndex = 15;
            this.label17.Text = "( t.ex. ska saldot i konto 1930 matcha vad du faktiskt har på banken) )";
            // 
            // RBnobalance
            // 
            this.RBnobalance.AutoSize = true;
            this.RBnobalance.Checked = true;
            this.RBnobalance.Location = new System.Drawing.Point(251, 31);
            this.RBnobalance.Name = "RBnobalance";
            this.RBnobalance.Size = new System.Drawing.Size(41, 17);
            this.RBnobalance.TabIndex = 1;
            this.RBnobalance.TabStop = true;
            this.RBnobalance.Text = "Nej";
            this.RBnobalance.UseVisualStyleBackColor = true;
            this.RBnobalance.CheckedChanged += new System.EventHandler(this.RBnobook_CheckedChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 21);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(210, 13);
            this.label18.TabIndex = 14;
            this.label18.Text = "Har du stämt av alla tillgångar och skulder?";
            // 
            // RByesbalance
            // 
            this.RByesbalance.AutoSize = true;
            this.RByesbalance.Location = new System.Drawing.Point(251, 8);
            this.RByesbalance.Name = "RByesbalance";
            this.RByesbalance.Size = new System.Drawing.Size(37, 17);
            this.RByesbalance.TabIndex = 0;
            this.RByesbalance.Text = "JA";
            this.RByesbalance.UseVisualStyleBackColor = true;
            this.RByesbalance.CheckedChanged += new System.EventHandler(this.RByesbook_CheckedChanged);
            // 
            // bookprofitbutton
            // 
            this.bookprofitbutton.Enabled = false;
            this.bookprofitbutton.Location = new System.Drawing.Point(362, 311);
            this.bookprofitbutton.Name = "bookprofitbutton";
            this.bookprofitbutton.Size = new System.Drawing.Size(385, 65);
            this.bookprofitbutton.TabIndex = 34;
            this.bookprofitbutton.Text = "Bokför årets resultat och beräknade skatt";
            this.bookprofitbutton.UseVisualStyleBackColor = true;
            this.bookprofitbutton.Click += new System.EventHandler(this.bookprofitbutton_Click);
            // 
            // closeyearbutton
            // 
            this.closeyearbutton.Enabled = false;
            this.closeyearbutton.Location = new System.Drawing.Point(362, 396);
            this.closeyearbutton.Name = "closeyearbutton";
            this.closeyearbutton.Size = new System.Drawing.Size(385, 67);
            this.closeyearbutton.TabIndex = 35;
            this.closeyearbutton.Text = "Stäng räkenskapsår";
            this.closeyearbutton.UseVisualStyleBackColor = true;
            this.closeyearbutton.Click += new System.EventHandler(this.closeyearbutton_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(359, 154);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(153, 13);
            this.label19.TabIndex = 36;
            this.label19.Text = "Skattemässiga justeringar (prel)";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(362, 184);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(123, 13);
            this.label20.TabIndex = 37;
            this.label20.Text = "Beskattningsbart resultat";
            // 
            // TBskattejust
            // 
            this.TBskattejust.Location = new System.Drawing.Point(586, 146);
            this.TBskattejust.Name = "TBskattejust";
            this.TBskattejust.Size = new System.Drawing.Size(161, 20);
            this.TBskattejust.TabIndex = 38;
            // 
            // TBskatteunderlag
            // 
            this.TBskatteunderlag.Location = new System.Drawing.Point(586, 177);
            this.TBskatteunderlag.Name = "TBskatteunderlag";
            this.TBskatteunderlag.Size = new System.Drawing.Size(161, 20);
            this.TBskatteunderlag.TabIndex = 39;
            // 
            // FormBokslut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 655);
            this.Controls.Add(this.TBskatteunderlag);
            this.Controls.Add(this.TBskattejust);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.closeyearbutton);
            this.Controls.Add(this.bookprofitbutton);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.updatebutton);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.TBresultatfinans);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TBefterskatt);
            this.Controls.Add(this.TBskatt);
            this.Controls.Add(this.TBskattesats);
            this.Controls.Add(this.TBbokdisp);
            this.Controls.Add(this.TBresultatbokdisp);
            this.Controls.Add(this.TBrorelseresultat);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.LBfiscal);
            this.Controls.Add(this.label4);
            this.Name = "FormBokslut";
            this.Text = "FormBokslut";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox LBfiscal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton RBnobook;
        private System.Windows.Forms.RadioButton RByesbook;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TBrorelseresultat;
        private System.Windows.Forms.TextBox TBresultatbokdisp;
        private System.Windows.Forms.TextBox TBbokdisp;
        private System.Windows.Forms.TextBox TBskattesats;
        private System.Windows.Forms.TextBox TBskatt;
        private System.Windows.Forms.TextBox TBefterskatt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TBresultatfinans;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button momsbutton;
        private System.Windows.Forms.RadioButton RBnodisp;
        private System.Windows.Forms.RadioButton RByesmoms;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RadioButton RBnomoms;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.RadioButton RByesdisp;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox CBaterforande;
        private System.Windows.Forms.Button avsattningbutton;
        private System.Windows.Forms.TextBox TBavsattning;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button aterforandebutton;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.RadioButton RBnodiscount;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.RadioButton RByesdiscount;
        private System.Windows.Forms.Button updatebutton;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.RadioButton RBnobalance;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton RByesbalance;
        private System.Windows.Forms.Button bookprofitbutton;
        private System.Windows.Forms.Button closeyearbutton;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox TBskattejust;
        private System.Windows.Forms.TextBox TBskatteunderlag;
    }
}