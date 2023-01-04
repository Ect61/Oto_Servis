namespace ECT_OTO.Ekranlar
{
    partial class Teknisyenler
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblTeknikAd = new System.Windows.Forms.Label();
            this.lblTeknikTel = new System.Windows.Forms.Label();
            this.lblTeknikAdres = new System.Windows.Forms.Label();
            this.txtTeknisyenAd = new System.Windows.Forms.TextBox();
            this.txtTeknisyenTel = new System.Windows.Forms.TextBox();
            this.txtTeknisyenAdres = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.dtvTeknisyenler = new System.Windows.Forms.DataGridView();
            this.radioEkle = new System.Windows.Forms.RadioButton();
            this.radioDuzenle = new System.Windows.Forms.RadioButton();
            this.radioSil = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dtvTeknisyenler)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTeknikAd
            // 
            this.lblTeknikAd.AutoSize = true;
            this.lblTeknikAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTeknikAd.Location = new System.Drawing.Point(229, 350);
            this.lblTeknikAd.Name = "lblTeknikAd";
            this.lblTeknikAd.Size = new System.Drawing.Size(106, 16);
            this.lblTeknikAd.TabIndex = 0;
            this.lblTeknikAd.Text = "Teknisyen Adı";
            // 
            // lblTeknikTel
            // 
            this.lblTeknikTel.AutoSize = true;
            this.lblTeknikTel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTeknikTel.Location = new System.Drawing.Point(229, 385);
            this.lblTeknikTel.Name = "lblTeknikTel";
            this.lblTeknikTel.Size = new System.Drawing.Size(60, 16);
            this.lblTeknikTel.TabIndex = 1;
            this.lblTeknikTel.Text = "Telefon";
            // 
            // lblTeknikAdres
            // 
            this.lblTeknikAdres.AutoSize = true;
            this.lblTeknikAdres.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTeknikAdres.Location = new System.Drawing.Point(229, 420);
            this.lblTeknikAdres.Name = "lblTeknikAdres";
            this.lblTeknikAdres.Size = new System.Drawing.Size(48, 16);
            this.lblTeknikAdres.TabIndex = 2;
            this.lblTeknikAdres.Text = "Adres";
            // 
            // txtTeknisyenAd
            // 
            this.txtTeknisyenAd.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTeknisyenAd.Location = new System.Drawing.Point(371, 349);
            this.txtTeknisyenAd.MaxLength = 50;
            this.txtTeknisyenAd.Name = "txtTeknisyenAd";
            this.txtTeknisyenAd.Size = new System.Drawing.Size(300, 22);
            this.txtTeknisyenAd.TabIndex = 3;
            // 
            // txtTeknisyenTel
            // 
            this.txtTeknisyenTel.Location = new System.Drawing.Point(371, 384);
            this.txtTeknisyenTel.MaxLength = 11;
            this.txtTeknisyenTel.Name = "txtTeknisyenTel";
            this.txtTeknisyenTel.Size = new System.Drawing.Size(300, 22);
            this.txtTeknisyenTel.TabIndex = 4;
            // 
            // txtTeknisyenAdres
            // 
            this.txtTeknisyenAdres.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTeknisyenAdres.Location = new System.Drawing.Point(371, 420);
            this.txtTeknisyenAdres.MaxLength = 500;
            this.txtTeknisyenAdres.Multiline = true;
            this.txtTeknisyenAdres.Name = "txtTeknisyenAdres";
            this.txtTeknisyenAdres.Size = new System.Drawing.Size(300, 102);
            this.txtTeknisyenAdres.TabIndex = 5;
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnKaydet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnKaydet.Location = new System.Drawing.Point(371, 542);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(301, 45);
            this.btnKaydet.TabIndex = 6;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnIptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIptal.Location = new System.Drawing.Point(18, 542);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(301, 45);
            this.btnIptal.TabIndex = 7;
            this.btnIptal.Text = "İPTAL";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnDuzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDuzenle.Location = new System.Drawing.Point(370, 542);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(301, 45);
            this.btnDuzenle.TabIndex = 8;
            this.btnDuzenle.Text = "DÜZENLE";
            this.btnDuzenle.UseVisualStyleBackColor = false;
            this.btnDuzenle.Visible = false;
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSil.Location = new System.Drawing.Point(371, 542);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(301, 45);
            this.btnSil.TabIndex = 9;
            this.btnSil.Text = "SİL";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Visible = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // dtvTeknisyenler
            // 
            this.dtvTeknisyenler.AllowUserToAddRows = false;
            this.dtvTeknisyenler.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dtvTeknisyenler.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtvTeknisyenler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtvTeknisyenler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtvTeknisyenler.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtvTeknisyenler.BackgroundColor = System.Drawing.Color.SlateGray;
            this.dtvTeknisyenler.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dtvTeknisyenler.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3, 8, 3, 8);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.MenuHighlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtvTeknisyenler.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtvTeknisyenler.ColumnHeadersHeight = 40;
            this.dtvTeknisyenler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(239)))), ((int)(((byte)(239)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.LightBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtvTeknisyenler.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtvTeknisyenler.EnableHeadersVisualStyles = false;
            this.dtvTeknisyenler.GridColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dtvTeknisyenler.Location = new System.Drawing.Point(0, 0);
            this.dtvTeknisyenler.MultiSelect = false;
            this.dtvTeknisyenler.Name = "dtvTeknisyenler";
            this.dtvTeknisyenler.ReadOnly = true;
            this.dtvTeknisyenler.RowHeadersVisible = false;
            this.dtvTeknisyenler.RowHeadersWidth = 4;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.Padding = new System.Windows.Forms.Padding(3);
            this.dtvTeknisyenler.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dtvTeknisyenler.RowTemplate.Height = 25;
            this.dtvTeknisyenler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtvTeknisyenler.Size = new System.Drawing.Size(697, 321);
            this.dtvTeknisyenler.TabIndex = 10;
            this.dtvTeknisyenler.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.dtvTeknisyenler_ColumnAdded);
            this.dtvTeknisyenler.SelectionChanged += new System.EventHandler(this.dtvTeknisyenler_SelectionChanged);
            // 
            // radioEkle
            // 
            this.radioEkle.AutoSize = true;
            this.radioEkle.Checked = true;
            this.radioEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioEkle.Location = new System.Drawing.Point(18, 351);
            this.radioEkle.Name = "radioEkle";
            this.radioEkle.Size = new System.Drawing.Size(118, 20);
            this.radioEkle.TabIndex = 11;
            this.radioEkle.TabStop = true;
            this.radioEkle.Text = "Teknisyen Ekle";
            this.radioEkle.UseVisualStyleBackColor = true;
            this.radioEkle.CheckedChanged += new System.EventHandler(this.radioEkle_CheckedChanged);
            // 
            // radioDuzenle
            // 
            this.radioDuzenle.AutoSize = true;
            this.radioDuzenle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioDuzenle.Location = new System.Drawing.Point(18, 385);
            this.radioDuzenle.Name = "radioDuzenle";
            this.radioDuzenle.Size = new System.Drawing.Size(140, 20);
            this.radioDuzenle.TabIndex = 12;
            this.radioDuzenle.Text = "Teknisyen Düzenle";
            this.radioDuzenle.UseVisualStyleBackColor = true;
            this.radioDuzenle.CheckedChanged += new System.EventHandler(this.radioDuzenle_CheckedChanged);
            // 
            // radioSil
            // 
            this.radioSil.AutoSize = true;
            this.radioSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.radioSil.Location = new System.Drawing.Point(18, 419);
            this.radioSil.Name = "radioSil";
            this.radioSil.Size = new System.Drawing.Size(106, 20);
            this.radioSil.TabIndex = 13;
            this.radioSil.Text = "Teknisyen Sil";
            this.radioSil.UseVisualStyleBackColor = true;
            this.radioSil.CheckedChanged += new System.EventHandler(this.radioSil_CheckedChanged);
            // 
            // Teknisyenler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 602);
            this.Controls.Add(this.radioSil);
            this.Controls.Add(this.radioDuzenle);
            this.Controls.Add(this.radioEkle);
            this.Controls.Add(this.dtvTeknisyenler);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtTeknisyenAdres);
            this.Controls.Add(this.txtTeknisyenTel);
            this.Controls.Add(this.txtTeknisyenAd);
            this.Controls.Add(this.lblTeknikAdres);
            this.Controls.Add(this.lblTeknikTel);
            this.Controls.Add(this.lblTeknikAd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MaximumSize = new System.Drawing.Size(713, 641);
            this.MinimumSize = new System.Drawing.Size(713, 641);
            this.Name = "Teknisyenler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TEKNİSYENLER";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Teknisyenler_FormClosed);
            this.Load += new System.EventHandler(this.Teknisyenler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtvTeknisyenler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblTeknikAd;
        private Label lblTeknikTel;
        private Label lblTeknikAdres;
        private TextBox txtTeknisyenAd;
        private TextBox txtTeknisyenTel;
        private TextBox txtTeknisyenAdres;
        private Button btnKaydet;
        private Button btnIptal;
        private Button btnDuzenle;
        private Button btnSil;
        private DataGridView dtvTeknisyenler;
        private RadioButton radioEkle;
        private RadioButton radioDuzenle;
        private RadioButton radioSil;
    }
}