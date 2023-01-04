namespace ECT_OTO.Ekranlar
{
    partial class Kayit
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
            this.lblAdSoyad = new System.Windows.Forms.Label();
            this.lblAracMarkasi = new System.Windows.Forms.Label();
            this.txtAdSoyad = new System.Windows.Forms.TextBox();
            this.lblTel = new System.Windows.Forms.Label();
            this.lblAracModeli = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.cmbAracModeli = new System.Windows.Forms.ComboBox();
            this.lblAdres = new System.Windows.Forms.Label();
            this.lblAracYili = new System.Windows.Forms.Label();
            this.txtAdres = new System.Windows.Forms.TextBox();
            this.cmbAracYili = new System.Windows.Forms.ComboBox();
            this.cmbMotorHacmi = new System.Windows.Forms.ComboBox();
            this.lblMotorHacmi = new System.Windows.Forms.Label();
            this.cmbAracYakitTuru = new System.Windows.Forms.ComboBox();
            this.lblAracYakitTuru = new System.Windows.Forms.Label();
            this.cmbAracMarkasi = new System.Windows.Forms.ComboBox();
            this.lblKilometre = new System.Windows.Forms.Label();
            this.txtKilometre = new System.Windows.Forms.TextBox();
            this.txtPlaka = new System.Windows.Forms.TextBox();
            this.lblPlaka = new System.Windows.Forms.Label();
            this.cmbAracTipi = new System.Windows.Forms.ComboBox();
            this.lblAracTipi = new System.Windows.Forms.Label();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAdSoyad
            // 
            this.lblAdSoyad.AutoSize = true;
            this.lblAdSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAdSoyad.Location = new System.Drawing.Point(18, 29);
            this.lblAdSoyad.Name = "lblAdSoyad";
            this.lblAdSoyad.Size = new System.Drawing.Size(107, 25);
            this.lblAdSoyad.TabIndex = 0;
            this.lblAdSoyad.Text = "Adı Soyadı";
            // 
            // lblAracMarkasi
            // 
            this.lblAracMarkasi.AutoSize = true;
            this.lblAracMarkasi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAracMarkasi.Location = new System.Drawing.Point(455, 29);
            this.lblAracMarkasi.Name = "lblAracMarkasi";
            this.lblAracMarkasi.Size = new System.Drawing.Size(127, 25);
            this.lblAracMarkasi.TabIndex = 1;
            this.lblAracMarkasi.Text = "Araç Markası";
            // 
            // txtAdSoyad
            // 
            this.txtAdSoyad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAdSoyad.Location = new System.Drawing.Point(21, 57);
            this.txtAdSoyad.MaxLength = 20;
            this.txtAdSoyad.Name = "txtAdSoyad";
            this.txtAdSoyad.Size = new System.Drawing.Size(321, 23);
            this.txtAdSoyad.TabIndex = 2;
            this.txtAdSoyad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAdSoyad_KeyPress);
            // 
            // lblTel
            // 
            this.lblTel.AutoSize = true;
            this.lblTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTel.Location = new System.Drawing.Point(18, 94);
            this.lblTel.Name = "lblTel";
            this.lblTel.Size = new System.Drawing.Size(78, 25);
            this.lblTel.TabIndex = 3;
            this.lblTel.Text = "Telefon";
            // 
            // lblAracModeli
            // 
            this.lblAracModeli.AutoSize = true;
            this.lblAracModeli.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAracModeli.Location = new System.Drawing.Point(455, 94);
            this.lblAracModeli.Name = "lblAracModeli";
            this.lblAracModeli.Size = new System.Drawing.Size(116, 25);
            this.lblAracModeli.TabIndex = 4;
            this.lblAracModeli.Text = "Araç Modeli";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(21, 122);
            this.txtTel.MaxLength = 11;
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(321, 23);
            this.txtTel.TabIndex = 5;
            this.txtTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTel_KeyPress);
            // 
            // cmbAracModeli
            // 
            this.cmbAracModeli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAracModeli.FormattingEnabled = true;
            this.cmbAracModeli.Location = new System.Drawing.Point(459, 122);
            this.cmbAracModeli.Name = "cmbAracModeli";
            this.cmbAracModeli.Size = new System.Drawing.Size(321, 23);
            this.cmbAracModeli.TabIndex = 6;
            // 
            // lblAdres
            // 
            this.lblAdres.AutoSize = true;
            this.lblAdres.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAdres.Location = new System.Drawing.Point(18, 159);
            this.lblAdres.Name = "lblAdres";
            this.lblAdres.Size = new System.Drawing.Size(64, 25);
            this.lblAdres.TabIndex = 7;
            this.lblAdres.Text = "Adres";
            // 
            // lblAracYili
            // 
            this.lblAracYili.AutoSize = true;
            this.lblAracYili.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAracYili.Location = new System.Drawing.Point(455, 159);
            this.lblAracYili.Name = "lblAracYili";
            this.lblAracYili.Size = new System.Drawing.Size(83, 25);
            this.lblAracYili.TabIndex = 8;
            this.lblAracYili.Text = "Araç Yılı";
            // 
            // txtAdres
            // 
            this.txtAdres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAdres.Location = new System.Drawing.Point(21, 187);
            this.txtAdres.Multiline = true;
            this.txtAdres.Name = "txtAdres";
            this.txtAdres.Size = new System.Drawing.Size(321, 86);
            this.txtAdres.TabIndex = 9;
            // 
            // cmbAracYili
            // 
            this.cmbAracYili.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAracYili.FormattingEnabled = true;
            this.cmbAracYili.Location = new System.Drawing.Point(459, 188);
            this.cmbAracYili.Name = "cmbAracYili";
            this.cmbAracYili.Size = new System.Drawing.Size(321, 23);
            this.cmbAracYili.TabIndex = 10;
            // 
            // cmbMotorHacmi
            // 
            this.cmbMotorHacmi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMotorHacmi.FormattingEnabled = true;
            this.cmbMotorHacmi.Location = new System.Drawing.Point(459, 253);
            this.cmbMotorHacmi.Name = "cmbMotorHacmi";
            this.cmbMotorHacmi.Size = new System.Drawing.Size(321, 23);
            this.cmbMotorHacmi.TabIndex = 12;
            // 
            // lblMotorHacmi
            // 
            this.lblMotorHacmi.AutoSize = true;
            this.lblMotorHacmi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblMotorHacmi.Location = new System.Drawing.Point(455, 224);
            this.lblMotorHacmi.Name = "lblMotorHacmi";
            this.lblMotorHacmi.Size = new System.Drawing.Size(122, 25);
            this.lblMotorHacmi.TabIndex = 11;
            this.lblMotorHacmi.Text = "Motor Hacmi";
            // 
            // cmbAracYakitTuru
            // 
            this.cmbAracYakitTuru.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAracYakitTuru.FormattingEnabled = true;
            this.cmbAracYakitTuru.Location = new System.Drawing.Point(459, 318);
            this.cmbAracYakitTuru.Name = "cmbAracYakitTuru";
            this.cmbAracYakitTuru.Size = new System.Drawing.Size(321, 23);
            this.cmbAracYakitTuru.TabIndex = 14;
            // 
            // lblAracYakitTuru
            // 
            this.lblAracYakitTuru.AutoSize = true;
            this.lblAracYakitTuru.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAracYakitTuru.Location = new System.Drawing.Point(455, 289);
            this.lblAracYakitTuru.Name = "lblAracYakitTuru";
            this.lblAracYakitTuru.Size = new System.Drawing.Size(147, 25);
            this.lblAracYakitTuru.TabIndex = 13;
            this.lblAracYakitTuru.Text = "Araç Yakıt Türü";
            // 
            // cmbAracMarkasi
            // 
            this.cmbAracMarkasi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAracMarkasi.FormattingEnabled = true;
            this.cmbAracMarkasi.Location = new System.Drawing.Point(459, 57);
            this.cmbAracMarkasi.Name = "cmbAracMarkasi";
            this.cmbAracMarkasi.Size = new System.Drawing.Size(321, 23);
            this.cmbAracMarkasi.TabIndex = 15;
            this.cmbAracMarkasi.SelectedIndexChanged += new System.EventHandler(this.cmbAracMarkasi_SelectedIndexChanged);
            // 
            // lblKilometre
            // 
            this.lblKilometre.AutoSize = true;
            this.lblKilometre.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblKilometre.Location = new System.Drawing.Point(455, 354);
            this.lblKilometre.Name = "lblKilometre";
            this.lblKilometre.Size = new System.Drawing.Size(108, 25);
            this.lblKilometre.TabIndex = 16;
            this.lblKilometre.Text = "Kilometresi";
            // 
            // txtKilometre
            // 
            this.txtKilometre.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtKilometre.Location = new System.Drawing.Point(459, 383);
            this.txtKilometre.MaxLength = 6;
            this.txtKilometre.Name = "txtKilometre";
            this.txtKilometre.Size = new System.Drawing.Size(321, 29);
            this.txtKilometre.TabIndex = 17;
            this.txtKilometre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKilometre_KeyPress);
            // 
            // txtPlaka
            // 
            this.txtPlaka.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlaka.Location = new System.Drawing.Point(21, 318);
            this.txtPlaka.MaxLength = 9;
            this.txtPlaka.Name = "txtPlaka";
            this.txtPlaka.Size = new System.Drawing.Size(321, 23);
            this.txtPlaka.TabIndex = 19;
            // 
            // lblPlaka
            // 
            this.lblPlaka.AutoSize = true;
            this.lblPlaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPlaka.Location = new System.Drawing.Point(18, 289);
            this.lblPlaka.Name = "lblPlaka";
            this.lblPlaka.Size = new System.Drawing.Size(61, 25);
            this.lblPlaka.TabIndex = 18;
            this.lblPlaka.Text = "Plaka";
            // 
            // cmbAracTipi
            // 
            this.cmbAracTipi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAracTipi.FormattingEnabled = true;
            this.cmbAracTipi.Location = new System.Drawing.Point(21, 383);
            this.cmbAracTipi.Name = "cmbAracTipi";
            this.cmbAracTipi.Size = new System.Drawing.Size(321, 23);
            this.cmbAracTipi.TabIndex = 21;
            this.cmbAracTipi.SelectedIndexChanged += new System.EventHandler(this.cmbAracTipi_SelectedIndexChanged);
            // 
            // lblAracTipi
            // 
            this.lblAracTipi.AutoSize = true;
            this.lblAracTipi.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAracTipi.Location = new System.Drawing.Point(18, 354);
            this.lblAracTipi.Name = "lblAracTipi";
            this.lblAracTipi.Size = new System.Drawing.Size(90, 25);
            this.lblAracTipi.TabIndex = 20;
            this.lblAracTipi.Text = "Araç Tipi";
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.LimeGreen;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnKaydet.Location = new System.Drawing.Point(21, 423);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(321, 59);
            this.btnKaydet.TabIndex = 22;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.Orange;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnEdit.Location = new System.Drawing.Point(21, 423);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(321, 59);
            this.btnEdit.TabIndex = 23;
            this.btnEdit.Text = "DEĞİŞTİR";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.Crimson;
            this.btnIptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIptal.Location = new System.Drawing.Point(459, 423);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(321, 59);
            this.btnIptal.TabIndex = 24;
            this.btnIptal.Text = "İPTAL";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // Kayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 516);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.cmbAracTipi);
            this.Controls.Add(this.lblAracTipi);
            this.Controls.Add(this.txtPlaka);
            this.Controls.Add(this.lblPlaka);
            this.Controls.Add(this.txtKilometre);
            this.Controls.Add(this.lblKilometre);
            this.Controls.Add(this.cmbAracMarkasi);
            this.Controls.Add(this.cmbAracYakitTuru);
            this.Controls.Add(this.lblAracYakitTuru);
            this.Controls.Add(this.cmbMotorHacmi);
            this.Controls.Add(this.lblMotorHacmi);
            this.Controls.Add(this.cmbAracYili);
            this.Controls.Add(this.txtAdres);
            this.Controls.Add(this.lblAracYili);
            this.Controls.Add(this.lblAdres);
            this.Controls.Add(this.cmbAracModeli);
            this.Controls.Add(this.txtTel);
            this.Controls.Add(this.lblAracModeli);
            this.Controls.Add(this.lblTel);
            this.Controls.Add(this.txtAdSoyad);
            this.Controls.Add(this.lblAracMarkasi);
            this.Controls.Add(this.lblAdSoyad);
            this.MaximumSize = new System.Drawing.Size(821, 555);
            this.MinimumSize = new System.Drawing.Size(821, 555);
            this.Name = "Kayit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcT MÜŞTERİ KAYIT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Kayit_FormClosed);
            this.Load += new System.EventHandler(this.Kayit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblAdSoyad;
        private Label lblAracMarkasi;
        private TextBox txtAdSoyad;
        private Label lblTel;
        private Label lblAracModeli;
        private TextBox txtTel;
        private ComboBox cmbAracModeli;
        private Label lblAdres;
        private Label lblAracYili;
        private TextBox txtAdres;
        private ComboBox cmbAracYili;
        private ComboBox cmbMotorHacmi;
        private Label lblMotorHacmi;
        private ComboBox cmbAracYakitTuru;
        private Label lblAracYakitTuru;
        private ComboBox cmbAracMarkasi;
        private Label lblKilometre;
        private TextBox txtKilometre;
        private Label lblPlaka;
        private ComboBox cmbAracTipi;
        private Label lblAracTipi;
        private Button btnKaydet;
        private Button btnEdit;
        private Button btnIptal;
        public TextBox txtPlaka;
    }
}