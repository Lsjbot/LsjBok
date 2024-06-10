namespace HQAccounting.Models
{
    partial class AddEditCustomerForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnInduvidual = new System.Windows.Forms.RadioButton();
            this.rbtnCorporation = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.MaskedTextBox();
            this.labelOrgNumber = new System.Windows.Forms.Label();
            this.txtCompanyNumber = new System.Windows.Forms.MaskedTextBox();
            this.labelVatNumber = new System.Windows.Forms.Label();
            this.txtVatNumber = new System.Windows.Forms.MaskedTextBox();
            this.labelPersonalNumber = new System.Windows.Forms.Label();
            this.txtPersonalNumber = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCustomerId = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPhoneNumber = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtPaymentTerms = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtOverdueInterest = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtDelivery = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.txtName);
            this.flowLayoutPanel1.Controls.Add(this.labelOrgNumber);
            this.flowLayoutPanel1.Controls.Add(this.txtCompanyNumber);
            this.flowLayoutPanel1.Controls.Add(this.labelVatNumber);
            this.flowLayoutPanel1.Controls.Add(this.txtVatNumber);
            this.flowLayoutPanel1.Controls.Add(this.labelPersonalNumber);
            this.flowLayoutPanel1.Controls.Add(this.txtPersonalNumber);
            this.flowLayoutPanel1.Controls.Add(this.label5);
            this.flowLayoutPanel1.Controls.Add(this.txtCustomerId);
            this.flowLayoutPanel1.Controls.Add(this.label6);
            this.flowLayoutPanel1.Controls.Add(this.txtAddress);
            this.flowLayoutPanel1.Controls.Add(this.label7);
            this.flowLayoutPanel1.Controls.Add(this.txtPostalCode);
            this.flowLayoutPanel1.Controls.Add(this.label8);
            this.flowLayoutPanel1.Controls.Add(this.txtCity);
            this.flowLayoutPanel1.Controls.Add(this.label9);
            this.flowLayoutPanel1.Controls.Add(this.txtContact);
            this.flowLayoutPanel1.Controls.Add(this.label10);
            this.flowLayoutPanel1.Controls.Add(this.txtEmail);
            this.flowLayoutPanel1.Controls.Add(this.label11);
            this.flowLayoutPanel1.Controls.Add(this.txtPhoneNumber);
            this.flowLayoutPanel1.Controls.Add(this.label12);
            this.flowLayoutPanel1.Controls.Add(this.txtPaymentTerms);
            this.flowLayoutPanel1.Controls.Add(this.label13);
            this.flowLayoutPanel1.Controls.Add(this.txtOverdueInterest);
            this.flowLayoutPanel1.Controls.Add(this.label14);
            this.flowLayoutPanel1.Controls.Add(this.txtDelivery);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(485, 962);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnInduvidual);
            this.groupBox2.Controls.Add(this.rbtnCorporation);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 70);
            this.groupBox2.TabIndex = 33;
            this.groupBox2.TabStop = false;
            // 
            // rbtnInduvidual
            // 
            this.rbtnInduvidual.AutoSize = true;
            this.rbtnInduvidual.Location = new System.Drawing.Point(244, 28);
            this.rbtnInduvidual.Name = "rbtnInduvidual";
            this.rbtnInduvidual.Size = new System.Drawing.Size(93, 21);
            this.rbtnInduvidual.TabIndex = 1;
            this.rbtnInduvidual.TabStop = true;
            this.rbtnInduvidual.Text = "Privatkund";
            this.rbtnInduvidual.UseVisualStyleBackColor = true;
            this.rbtnInduvidual.CheckedChanged += new System.EventHandler(this.rbtnPrivate_CheckedChanged);
            // 
            // rbtnCorporation
            // 
            this.rbtnCorporation.AutoSize = true;
            this.rbtnCorporation.Checked = true;
            this.rbtnCorporation.Location = new System.Drawing.Point(23, 28);
            this.rbtnCorporation.Name = "rbtnCorporation";
            this.rbtnCorporation.Size = new System.Drawing.Size(113, 21);
            this.rbtnCorporation.TabIndex = 0;
            this.rbtnCorporation.TabStop = true;
            this.rbtnCorporation.Text = "Företagskund";
            this.rbtnCorporation.UseVisualStyleBackColor = true;
            this.rbtnCorporation.CheckedChanged += new System.EventHandler(this.rbtnCompany_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Namn";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(3, 96);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(400, 23);
            this.txtName.TabIndex = 3;
            // 
            // labelOrgNumber
            // 
            this.labelOrgNumber.AutoSize = true;
            this.labelOrgNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOrgNumber.Location = new System.Drawing.Point(3, 122);
            this.labelOrgNumber.Name = "labelOrgNumber";
            this.labelOrgNumber.Size = new System.Drawing.Size(88, 17);
            this.labelOrgNumber.TabIndex = 4;
            this.labelOrgNumber.Text = "Org-nummer";
            // 
            // txtCompanyNumber
            // 
            this.txtCompanyNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCompanyNumber.Location = new System.Drawing.Point(3, 142);
            this.txtCompanyNumber.Name = "txtCompanyNumber";
            this.txtCompanyNumber.Size = new System.Drawing.Size(400, 23);
            this.txtCompanyNumber.TabIndex = 5;
            // 
            // labelVatNumber
            // 
            this.labelVatNumber.AutoSize = true;
            this.labelVatNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVatNumber.Location = new System.Drawing.Point(3, 168);
            this.labelVatNumber.Name = "labelVatNumber";
            this.labelVatNumber.Size = new System.Drawing.Size(91, 17);
            this.labelVatNumber.TabIndex = 6;
            this.labelVatNumber.Text = "VAT-nummer";
            // 
            // txtVatNumber
            // 
            this.txtVatNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVatNumber.Location = new System.Drawing.Point(3, 188);
            this.txtVatNumber.Name = "txtVatNumber";
            this.txtVatNumber.Size = new System.Drawing.Size(400, 23);
            this.txtVatNumber.TabIndex = 7;
            // 
            // labelPersonalNumber
            // 
            this.labelPersonalNumber.AutoSize = true;
            this.labelPersonalNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPersonalNumber.Location = new System.Drawing.Point(3, 214);
            this.labelPersonalNumber.Name = "labelPersonalNumber";
            this.labelPersonalNumber.Size = new System.Drawing.Size(104, 17);
            this.labelPersonalNumber.TabIndex = 8;
            this.labelPersonalNumber.Text = "Personnummer";
            this.labelPersonalNumber.Visible = false;
            // 
            // txtPersonalNumber
            // 
            this.txtPersonalNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonalNumber.Location = new System.Drawing.Point(3, 234);
            this.txtPersonalNumber.Name = "txtPersonalNumber";
            this.txtPersonalNumber.Size = new System.Drawing.Size(400, 23);
            this.txtPersonalNumber.TabIndex = 9;
            this.txtPersonalNumber.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 260);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Kundnummer";
            // 
            // txtCustomerId
            // 
            this.txtCustomerId.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCustomerId.Location = new System.Drawing.Point(3, 280);
            this.txtCustomerId.Name = "txtCustomerId";
            this.txtCustomerId.ReadOnly = true;
            this.txtCustomerId.Size = new System.Drawing.Size(400, 23);
            this.txtCustomerId.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(3, 306);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 17);
            this.label6.TabIndex = 12;
            this.label6.Text = "Postadress";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Location = new System.Drawing.Point(3, 326);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(400, 23);
            this.txtAddress.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(3, 352);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "Postnummer";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPostalCode.Location = new System.Drawing.Point(3, 372);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(400, 23);
            this.txtPostalCode.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 398);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 17);
            this.label8.TabIndex = 16;
            this.label8.Text = "Stad";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCity.Location = new System.Drawing.Point(3, 418);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(400, 23);
            this.txtCity.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 444);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "Kontaktperson";
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContact.Location = new System.Drawing.Point(3, 464);
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(400, 23);
            this.txtContact.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 490);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 17);
            this.label10.TabIndex = 20;
            this.label10.Text = "E-post";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Location = new System.Drawing.Point(3, 510);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(400, 23);
            this.txtEmail.TabIndex = 21;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(3, 536);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(107, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Telefonnummer";
            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhoneNumber.Location = new System.Drawing.Point(3, 556);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.Size = new System.Drawing.Size(400, 23);
            this.txtPhoneNumber.TabIndex = 23;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(3, 582);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(161, 17);
            this.label12.TabIndex = 24;
            this.label12.Text = "Betalningsvillkor (dagar)";
            // 
            // txtPaymentTerms
            // 
            this.txtPaymentTerms.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaymentTerms.Location = new System.Drawing.Point(3, 602);
            this.txtPaymentTerms.Name = "txtPaymentTerms";
            this.txtPaymentTerms.Size = new System.Drawing.Size(400, 23);
            this.txtPaymentTerms.TabIndex = 25;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(3, 628);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(103, 17);
            this.label13.TabIndex = 26;
            this.label13.Text = "Dröjsmålsränta";
            // 
            // txtOverdueInterest
            // 
            this.txtOverdueInterest.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOverdueInterest.Location = new System.Drawing.Point(3, 648);
            this.txtOverdueInterest.Name = "txtOverdueInterest";
            this.txtOverdueInterest.Size = new System.Drawing.Size(400, 23);
            this.txtOverdueInterest.TabIndex = 27;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 674);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 17);
            this.label14.TabIndex = 28;
            this.label14.Text = "Leverans";
            // 
            // txtDelivery
            // 
            this.txtDelivery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDelivery.Location = new System.Drawing.Point(3, 694);
            this.txtDelivery.Name = "txtDelivery";
            this.txtDelivery.Size = new System.Drawing.Size(400, 23);
            this.txtDelivery.TabIndex = 29;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 723);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(400, 70);
            this.groupBox1.TabIndex = 32;
            this.groupBox1.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(244, 22);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 30);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "Avbryt";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(23, 22);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 30);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "Spara";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // AddEditCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 962);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "AddEditCustomerForm";
            this.Text = "Kund";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.RadioButton rbtnCorporation;
        private System.Windows.Forms.RadioButton rbtnInduvidual;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox txtName;
        private System.Windows.Forms.Label labelOrgNumber;
        private System.Windows.Forms.MaskedTextBox txtCompanyNumber;
        private System.Windows.Forms.Label labelVatNumber;
        private System.Windows.Forms.MaskedTextBox txtVatNumber;
        private System.Windows.Forms.Label labelPersonalNumber;
        private System.Windows.Forms.MaskedTextBox txtPersonalNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox txtCustomerId;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox txtAddress;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtPostalCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox txtCity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox txtContact;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox txtEmail;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox txtPhoneNumber;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox txtPaymentTerms;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.MaskedTextBox txtOverdueInterest;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.MaskedTextBox txtDelivery;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}