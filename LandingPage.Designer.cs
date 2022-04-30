
namespace Crypyography
{
    partial class LandingPage
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
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cboxOption = new System.Windows.Forms.ComboBox();
            this.btnProceed = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tControl = new System.Windows.Forms.TabControl();
            this.ChooseFile = new System.Windows.Forms.TabPage();
            this.lblLogOff = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.rbPhoto = new System.Windows.Forms.RadioButton();
            this.rbRar = new System.Windows.Forms.RadioButton();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.rbFolder = new System.Windows.Forms.RadioButton();
            this.btnChooseFile = new System.Windows.Forms.Button();
            this.lblChoosenFile = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Encrypt = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.photoBoxEn = new System.Windows.Forms.PictureBox();
            this.txtFileEn = new System.Windows.Forms.TextBox();
            this.txtFilePathEn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnDoneEn = new System.Windows.Forms.Button();
            this.btnCancelEn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEn = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtRepeatKeyEn = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKeyEn = new System.Windows.Forms.TextBox();
            this.cboxDeleteEn = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Decrypt = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblDe = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.browseDe = new System.Windows.Forms.Button();
            this.cboxDeleteDe = new System.Windows.Forms.CheckBox();
            this.txtKeyDe = new System.Windows.Forms.TextBox();
            this.btnCancelDe = new System.Windows.Forms.Button();
            this.btnDoneDe = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFileDe = new System.Windows.Forms.TextBox();
            this.txtFilePathDe = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Admin = new System.Windows.Forms.TabPage();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridViewDelete = new System.Windows.Forms.DataGridView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtUserDeleteId = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblUserCount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.tControl.SuspendLayout();
            this.ChooseFile.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Encrypt.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoBoxEn)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.Decrypt.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Admin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDelete)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.CausesValidation = false;
            this.label1.Location = new System.Drawing.Point(19, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "CryptographyApp";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.SystemColors.Menu;
            this.flowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(6, 33);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(729, 10);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(208, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Encrypt, Decrypt file with CryptographyApp";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // cboxOption
            // 
            this.cboxOption.FormattingEnabled = true;
            this.cboxOption.Items.AddRange(new object[] {
            "Encrypt",
            "Decrypt"});
            this.cboxOption.Location = new System.Drawing.Point(48, 246);
            this.cboxOption.Name = "cboxOption";
            this.cboxOption.Size = new System.Drawing.Size(121, 21);
            this.cboxOption.TabIndex = 6;
            this.cboxOption.Text = "Choose Option";
            this.cboxOption.SelectedIndexChanged += new System.EventHandler(this.cboxOption_SelectedIndexChanged);
            // 
            // btnProceed
            // 
            this.btnProceed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProceed.Location = new System.Drawing.Point(533, 293);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(98, 32);
            this.btnProceed.TabIndex = 7;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(637, 293);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 32);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tControl
            // 
            this.tControl.Controls.Add(this.ChooseFile);
            this.tControl.Controls.Add(this.Encrypt);
            this.tControl.Controls.Add(this.Decrypt);
            this.tControl.Controls.Add(this.Admin);
            this.tControl.Location = new System.Drawing.Point(15, 12);
            this.tControl.Name = "tControl";
            this.tControl.SelectedIndex = 0;
            this.tControl.Size = new System.Drawing.Size(752, 428);
            this.tControl.TabIndex = 9;
            // 
            // ChooseFile
            // 
            this.ChooseFile.BackColor = System.Drawing.SystemColors.Control;
            this.ChooseFile.Controls.Add(this.lblLogOff);
            this.ChooseFile.Controls.Add(this.groupBox3);
            this.ChooseFile.Controls.Add(this.cboxOption);
            this.ChooseFile.Controls.Add(this.btnChooseFile);
            this.ChooseFile.Controls.Add(this.btnCancel);
            this.ChooseFile.Controls.Add(this.lblChoosenFile);
            this.ChooseFile.Controls.Add(this.btnProceed);
            this.ChooseFile.Controls.Add(this.label2);
            this.ChooseFile.Controls.Add(this.flowLayoutPanel1);
            this.ChooseFile.Controls.Add(this.label1);
            this.ChooseFile.Controls.Add(this.label4);
            this.ChooseFile.Location = new System.Drawing.Point(4, 22);
            this.ChooseFile.Name = "ChooseFile";
            this.ChooseFile.Padding = new System.Windows.Forms.Padding(3);
            this.ChooseFile.Size = new System.Drawing.Size(744, 402);
            this.ChooseFile.TabIndex = 0;
            this.ChooseFile.Text = "Choose File";
            // 
            // lblLogOff
            // 
            this.lblLogOff.AutoSize = true;
            this.lblLogOff.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLogOff.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLogOff.Location = new System.Drawing.Point(685, 9);
            this.lblLogOff.Name = "lblLogOff";
            this.lblLogOff.Size = new System.Drawing.Size(40, 13);
            this.lblLogOff.TabIndex = 13;
            this.lblLogOff.Text = "Log off";
            this.lblLogOff.Click += new System.EventHandler(this.lblLogOff_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.rbPhoto);
            this.groupBox3.Controls.Add(this.rbRar);
            this.groupBox3.Controls.Add(this.rbFile);
            this.groupBox3.Controls.Add(this.rbFolder);
            this.groupBox3.Location = new System.Drawing.Point(48, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(528, 91);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Attachment Type";
            // 
            // rbPhoto
            // 
            this.rbPhoto.AutoSize = true;
            this.rbPhoto.Location = new System.Drawing.Point(6, 42);
            this.rbPhoto.Name = "rbPhoto";
            this.rbPhoto.Size = new System.Drawing.Size(53, 17);
            this.rbPhoto.TabIndex = 13;
            this.rbPhoto.TabStop = true;
            this.rbPhoto.Text = "Photo";
            this.rbPhoto.UseVisualStyleBackColor = true;
            this.rbPhoto.CheckedChanged += new System.EventHandler(this.rbPhoto_CheckedChanged);
            // 
            // rbRar
            // 
            this.rbRar.AutoSize = true;
            this.rbRar.Location = new System.Drawing.Point(6, 65);
            this.rbRar.Name = "rbRar";
            this.rbRar.Size = new System.Drawing.Size(42, 17);
            this.rbRar.TabIndex = 12;
            this.rbRar.TabStop = true;
            this.rbRar.Text = "Rar";
            this.rbRar.UseVisualStyleBackColor = true;
            this.rbRar.CheckedChanged += new System.EventHandler(this.rbRar_CheckedChanged);
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Location = new System.Drawing.Point(6, 19);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(65, 17);
            this.rbFile.TabIndex = 10;
            this.rbFile.TabStop = true;
            this.rbFile.Text = "Text File";
            this.rbFile.UseVisualStyleBackColor = true;
            this.rbFile.CheckedChanged += new System.EventHandler(this.rbFile_CheckedChanged);
            // 
            // rbFolder
            // 
            this.rbFolder.AutoSize = true;
            this.rbFolder.Location = new System.Drawing.Point(93, 19);
            this.rbFolder.Name = "rbFolder";
            this.rbFolder.Size = new System.Drawing.Size(54, 17);
            this.rbFolder.TabIndex = 11;
            this.rbFolder.TabStop = true;
            this.rbFolder.Text = "Folder";
            this.rbFolder.UseVisualStyleBackColor = true;
            this.rbFolder.CheckedChanged += new System.EventHandler(this.rbFolder_CheckedChanged);
            // 
            // btnChooseFile
            // 
            this.btnChooseFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnChooseFile.FlatAppearance.BorderSize = 50;
            this.btnChooseFile.Location = new System.Drawing.Point(48, 217);
            this.btnChooseFile.Name = "btnChooseFile";
            this.btnChooseFile.Size = new System.Drawing.Size(75, 23);
            this.btnChooseFile.TabIndex = 9;
            this.btnChooseFile.Text = "Choose File";
            this.btnChooseFile.UseVisualStyleBackColor = true;
            this.btnChooseFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblChoosenFile
            // 
            this.lblChoosenFile.AutoSize = true;
            this.lblChoosenFile.Location = new System.Drawing.Point(129, 222);
            this.lblChoosenFile.Name = "lblChoosenFile";
            this.lblChoosenFile.Size = new System.Drawing.Size(83, 13);
            this.lblChoosenFile.TabIndex = 8;
            this.lblChoosenFile.Text = "No File selected";
            this.lblChoosenFile.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.lblChoosenFile.Click += new System.EventHandler(this.lblChoosenFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(159, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Select file(s) from local computer";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Encrypt
            // 
            this.Encrypt.BackColor = System.Drawing.SystemColors.Control;
            this.Encrypt.Controls.Add(this.groupBox6);
            this.Encrypt.Controls.Add(this.btnDoneEn);
            this.Encrypt.Controls.Add(this.btnCancelEn);
            this.Encrypt.Controls.Add(this.groupBox1);
            this.Encrypt.Location = new System.Drawing.Point(4, 22);
            this.Encrypt.Name = "Encrypt";
            this.Encrypt.Padding = new System.Windows.Forms.Padding(3);
            this.Encrypt.Size = new System.Drawing.Size(744, 402);
            this.Encrypt.TabIndex = 1;
            this.Encrypt.Text = "Encrypt";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.photoBoxEn);
            this.groupBox6.Controls.Add(this.txtFileEn);
            this.groupBox6.Controls.Add(this.txtFilePathEn);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Location = new System.Drawing.Point(21, 15);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(366, 378);
            this.groupBox6.TabIndex = 13;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Encryption";
            // 
            // photoBoxEn
            // 
            this.photoBoxEn.Location = new System.Drawing.Point(32, 104);
            this.photoBoxEn.Name = "photoBoxEn";
            this.photoBoxEn.Size = new System.Drawing.Size(295, 258);
            this.photoBoxEn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.photoBoxEn.TabIndex = 15;
            this.photoBoxEn.TabStop = false;
            // 
            // txtFileEn
            // 
            this.txtFileEn.Location = new System.Drawing.Point(21, 96);
            this.txtFileEn.Multiline = true;
            this.txtFileEn.Name = "txtFileEn";
            this.txtFileEn.Size = new System.Drawing.Size(317, 276);
            this.txtFileEn.TabIndex = 14;
            this.txtFileEn.TextChanged += new System.EventHandler(this.txtFileEn_TextChanged);
            // 
            // txtFilePathEn
            // 
            this.txtFilePathEn.BackColor = System.Drawing.SystemColors.Control;
            this.txtFilePathEn.Location = new System.Drawing.Point(18, 48);
            this.txtFilePathEn.Multiline = true;
            this.txtFilePathEn.Name = "txtFilePathEn";
            this.txtFilePathEn.Size = new System.Drawing.Size(317, 32);
            this.txtFilePathEn.TabIndex = 0;
            this.txtFilePathEn.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(26, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "File:";
            // 
            // btnDoneEn
            // 
            this.btnDoneEn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoneEn.Location = new System.Drawing.Point(540, 362);
            this.btnDoneEn.Name = "btnDoneEn";
            this.btnDoneEn.Size = new System.Drawing.Size(98, 32);
            this.btnDoneEn.TabIndex = 10;
            this.btnDoneEn.Text = "Done";
            this.btnDoneEn.UseVisualStyleBackColor = true;
            this.btnDoneEn.Click += new System.EventHandler(this.btnDoneEn_Click);
            // 
            // btnCancelEn
            // 
            this.btnCancelEn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelEn.Location = new System.Drawing.Point(644, 362);
            this.btnCancelEn.Name = "btnCancelEn";
            this.btnCancelEn.Size = new System.Drawing.Size(98, 32);
            this.btnCancelEn.TabIndex = 9;
            this.btnCancelEn.Text = "Cancel";
            this.btnCancelEn.UseVisualStyleBackColor = true;
            this.btnCancelEn.Click += new System.EventHandler(this.btnCancelEn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEncrypt);
            this.groupBox1.Controls.Add(this.lblEn);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.txtRepeatKeyEn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtKeyEn);
            this.groupBox1.Controls.Add(this.cboxDeleteEn);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(392, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 236);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Encryption Key";
            // 
            // lblEn
            // 
            this.lblEn.AutoSize = true;
            this.lblEn.Location = new System.Drawing.Point(107, 164);
            this.lblEn.Name = "lblEn";
            this.lblEn.Size = new System.Drawing.Size(16, 13);
            this.lblEn.TabIndex = 12;
            this.lblEn.Text = "...";
            this.lblEn.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.Location = new System.Drawing.Point(26, 154);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.browseEn_Click);
            // 
            // txtRepeatKeyEn
            // 
            this.txtRepeatKeyEn.Location = new System.Drawing.Point(26, 97);
            this.txtRepeatKeyEn.Name = "txtRepeatKeyEn";
            this.txtRepeatKeyEn.Size = new System.Drawing.Size(240, 20);
            this.txtRepeatKeyEn.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Repeat Key:";
            // 
            // txtKeyEn
            // 
            this.txtKeyEn.Location = new System.Drawing.Point(26, 48);
            this.txtKeyEn.Name = "txtKeyEn";
            this.txtKeyEn.Size = new System.Drawing.Size(240, 20);
            this.txtKeyEn.TabIndex = 2;
            this.txtKeyEn.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // cboxDeleteEn
            // 
            this.cboxDeleteEn.AutoSize = true;
            this.cboxDeleteEn.Location = new System.Drawing.Point(26, 193);
            this.cboxDeleteEn.Name = "cboxDeleteEn";
            this.cboxDeleteEn.Size = new System.Drawing.Size(185, 17);
            this.cboxDeleteEn.TabIndex = 0;
            this.cboxDeleteEn.Text = "Delete original file after encryption";
            this.cboxDeleteEn.UseVisualStyleBackColor = true;
            this.cboxDeleteEn.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Key:";
            // 
            // Decrypt
            // 
            this.Decrypt.BackColor = System.Drawing.SystemColors.Control;
            this.Decrypt.Controls.Add(this.groupBox4);
            this.Decrypt.Controls.Add(this.btnCancelDe);
            this.Decrypt.Controls.Add(this.btnDoneDe);
            this.Decrypt.Controls.Add(this.groupBox2);
            this.Decrypt.Location = new System.Drawing.Point(4, 22);
            this.Decrypt.Name = "Decrypt";
            this.Decrypt.Size = new System.Drawing.Size(744, 402);
            this.Decrypt.TabIndex = 2;
            this.Decrypt.Text = "Decrypt";
            this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblDe);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.browseDe);
            this.groupBox4.Controls.Add(this.cboxDeleteDe);
            this.groupBox4.Controls.Add(this.txtKeyDe);
            this.groupBox4.Location = new System.Drawing.Point(378, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(350, 154);
            this.groupBox4.TabIndex = 10;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Decryption Key";
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(107, 88);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(16, 13);
            this.lblDe.TabIndex = 13;
            this.lblDe.Text = "...";
            this.lblDe.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Enter Key:";
            // 
            // browseDe
            // 
            this.browseDe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.browseDe.Location = new System.Drawing.Point(26, 83);
            this.browseDe.Name = "browseDe";
            this.browseDe.Size = new System.Drawing.Size(75, 23);
            this.browseDe.TabIndex = 12;
            this.browseDe.Text = "Decrypt";
            this.browseDe.UseVisualStyleBackColor = true;
            this.browseDe.Click += new System.EventHandler(this.browseDe_Click);
            // 
            // cboxDeleteDe
            // 
            this.cboxDeleteDe.AutoSize = true;
            this.cboxDeleteDe.Location = new System.Drawing.Point(26, 123);
            this.cboxDeleteDe.Name = "cboxDeleteDe";
            this.cboxDeleteDe.Size = new System.Drawing.Size(185, 17);
            this.cboxDeleteDe.TabIndex = 0;
            this.cboxDeleteDe.Text = "Delete original file after decryption";
            this.cboxDeleteDe.UseVisualStyleBackColor = true;
            // 
            // txtKeyDe
            // 
            this.txtKeyDe.Location = new System.Drawing.Point(26, 48);
            this.txtKeyDe.Name = "txtKeyDe";
            this.txtKeyDe.Size = new System.Drawing.Size(240, 20);
            this.txtKeyDe.TabIndex = 2;
            // 
            // btnCancelDe
            // 
            this.btnCancelDe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelDe.Location = new System.Drawing.Point(630, 356);
            this.btnCancelDe.Name = "btnCancelDe";
            this.btnCancelDe.Size = new System.Drawing.Size(98, 32);
            this.btnCancelDe.TabIndex = 9;
            this.btnCancelDe.Text = "Cancel";
            this.btnCancelDe.UseVisualStyleBackColor = true;
            this.btnCancelDe.Click += new System.EventHandler(this.btnCancelDe_Click);
            // 
            // btnDoneDe
            // 
            this.btnDoneDe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoneDe.Location = new System.Drawing.Point(526, 356);
            this.btnDoneDe.Name = "btnDoneDe";
            this.btnDoneDe.Size = new System.Drawing.Size(98, 32);
            this.btnDoneDe.TabIndex = 8;
            this.btnDoneDe.Text = "Done";
            this.btnDoneDe.UseVisualStyleBackColor = true;
            this.btnDoneDe.Click += new System.EventHandler(this.btnDoneDe_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtFileDe);
            this.groupBox2.Controls.Add(this.txtFilePathDe);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(21, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(351, 373);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Decryption";
            // 
            // txtFileDe
            // 
            this.txtFileDe.Location = new System.Drawing.Point(21, 96);
            this.txtFileDe.Multiline = true;
            this.txtFileDe.Name = "txtFileDe";
            this.txtFileDe.Size = new System.Drawing.Size(315, 257);
            this.txtFileDe.TabIndex = 11;
            // 
            // txtFilePathDe
            // 
            this.txtFilePathDe.BackColor = System.Drawing.SystemColors.Control;
            this.txtFilePathDe.Location = new System.Drawing.Point(18, 48);
            this.txtFilePathDe.Multiline = true;
            this.txtFilePathDe.Name = "txtFilePathDe";
            this.txtFilePathDe.Size = new System.Drawing.Size(315, 32);
            this.txtFilePathDe.TabIndex = 6;
            this.txtFilePathDe.TextChanged += new System.EventHandler(this.txtFilePath_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(26, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "File:";
            // 
            // Admin
            // 
            this.Admin.BackColor = System.Drawing.SystemColors.Control;
            this.Admin.Controls.Add(this.btnDelete);
            this.Admin.Controls.Add(this.dataGridViewDelete);
            this.Admin.Controls.Add(this.groupBox5);
            this.Admin.Location = new System.Drawing.Point(4, 22);
            this.Admin.Name = "Admin";
            this.Admin.Size = new System.Drawing.Size(744, 402);
            this.Admin.TabIndex = 3;
            this.Admin.Text = "Admin";
            // 
            // btnDelete
            // 
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.Location = new System.Drawing.Point(13, 218);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 10;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridViewDelete
            // 
            this.dataGridViewDelete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDelete.Location = new System.Drawing.Point(13, 247);
            this.dataGridViewDelete.Name = "dataGridViewDelete";
            this.dataGridViewDelete.Size = new System.Drawing.Size(647, 153);
            this.dataGridViewDelete.TabIndex = 7;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.txtUserDeleteId);
            this.groupBox5.Controls.Add(this.btnClear);
            this.groupBox5.Controls.Add(this.btnSearch);
            this.groupBox5.Controls.Add(this.lblUserCount);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label3);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Location = new System.Drawing.Point(13, 29);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(361, 169);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            // 
            // txtUserDeleteId
            // 
            this.txtUserDeleteId.Location = new System.Drawing.Point(68, 73);
            this.txtUserDeleteId.Name = "txtUserDeleteId";
            this.txtUserDeleteId.Size = new System.Drawing.Size(109, 20);
            this.txtUserDeleteId.TabIndex = 7;
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnClear.Location = new System.Drawing.Point(280, 140);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 8;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearch.Location = new System.Drawing.Point(172, 140);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Show all users";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblUserCount
            // 
            this.lblUserCount.AutoSize = true;
            this.lblUserCount.Location = new System.Drawing.Point(117, 51);
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new System.Drawing.Size(12, 13);
            this.lblUserCount.TabIndex = 2;
            this.lblUserCount.Text = "x";
            this.lblUserCount.Click += new System.EventHandler(this.lblUserCount_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 76);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(36, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "userId";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "User Management";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(22, 51);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 3;
            this.label12.Text = "Registered users:";
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEncrypt.Location = new System.Drawing.Point(26, 125);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 13;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 475);
            this.Controls.Add(this.tControl);
            this.Name = "LandingPage";
            this.Text = "LandingPage";
            this.Load += new System.EventHandler(this.LandingPage_Load_1);
            this.tControl.ResumeLayout(false);
            this.ChooseFile.ResumeLayout(false);
            this.ChooseFile.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Encrypt.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.photoBoxEn)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Decrypt.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Admin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDelete)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ComboBox cboxOption;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TabPage ChooseFile;
        private System.Windows.Forms.TabPage Encrypt;
        private System.Windows.Forms.Button btnChooseFile;
        private System.Windows.Forms.Label lblChoosenFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox cboxDeleteEn;
        private System.Windows.Forms.TabPage Decrypt;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtKeyEn;
        private System.Windows.Forms.TextBox txtRepeatKeyEn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnDoneEn;
        private System.Windows.Forms.Button btnCancelEn;
        private System.Windows.Forms.Button btnCancelDe;
        private System.Windows.Forms.Button btnDoneDe;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtKeyDe;
        private System.Windows.Forms.CheckBox cboxDeleteDe;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.RadioButton rbFolder;
        private System.Windows.Forms.TextBox txtFilePathEn;
        private System.Windows.Forms.TextBox txtFilePathDe;
        private System.Windows.Forms.RadioButton rbRar;
        private System.Windows.Forms.RadioButton rbPhoto;
        private System.Windows.Forms.Label lblEn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Button browseDe;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label lblUserCount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.DataGridView dataGridViewDelete;
        private System.Windows.Forms.TextBox txtUserDeleteId;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        public System.Windows.Forms.TabPage Admin;
        public System.Windows.Forms.TabControl tControl;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtFileDe;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtFileEn;
        private System.Windows.Forms.Label lblLogOff;
        private System.Windows.Forms.PictureBox photoBoxEn;
        private System.Windows.Forms.Button btnEncrypt;
    }
}