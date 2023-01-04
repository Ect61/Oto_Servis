namespace ECT_OTO.Ekranlar
{
    partial class Ana_Ekran
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
            this.tarihSaat = new System.Windows.Forms.DateTimePicker();
            this.resimKutusuAnaEkran = new System.Windows.Forms.PictureBox();
            this.btnKayit = new System.Windows.Forms.Button();
            this.btnArama = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.btnAyar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.resimKutusuAnaEkran)).BeginInit();
            this.SuspendLayout();
            // 
            // tarihSaat
            // 
            this.tarihSaat.Location = new System.Drawing.Point(12, 12);
            this.tarihSaat.Name = "tarihSaat";
            this.tarihSaat.Size = new System.Drawing.Size(196, 23);
            this.tarihSaat.TabIndex = 0;
            // 
            // resimKutusuAnaEkran
            // 
            this.resimKutusuAnaEkran.Location = new System.Drawing.Point(227, 12);
            this.resimKutusuAnaEkran.Name = "resimKutusuAnaEkran";
            this.resimKutusuAnaEkran.Size = new System.Drawing.Size(548, 494);
            this.resimKutusuAnaEkran.TabIndex = 1;
            this.resimKutusuAnaEkran.TabStop = false;
            // 
            // btnKayit
            // 
            this.btnKayit.BackColor = System.Drawing.Color.Yellow;
            this.btnKayit.Location = new System.Drawing.Point(12, 56);
            this.btnKayit.Name = "btnKayit";
            this.btnKayit.Size = new System.Drawing.Size(196, 108);
            this.btnKayit.TabIndex = 2;
            this.btnKayit.Text = "YENİ KAYIT";
            this.btnKayit.UseVisualStyleBackColor = false;
            this.btnKayit.Click += new System.EventHandler(this.btnKayit_Click);
            // 
            // btnArama
            // 
            this.btnArama.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnArama.Location = new System.Drawing.Point(12, 170);
            this.btnArama.Name = "btnArama";
            this.btnArama.Size = new System.Drawing.Size(196, 108);
            this.btnArama.TabIndex = 3;
            this.btnArama.Text = "İŞLEM ARAMA";
            this.btnArama.UseVisualStyleBackColor = false;
            this.btnArama.Click += new System.EventHandler(this.btnArama_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.Color.Crimson;
            this.btnCikis.Location = new System.Drawing.Point(12, 398);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(196, 108);
            this.btnCikis.TabIndex = 5;
            this.btnCikis.Text = "KULLANICI ÇIKIŞ";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // btnAyar
            // 
            this.btnAyar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnAyar.Location = new System.Drawing.Point(12, 284);
            this.btnAyar.Name = "btnAyar";
            this.btnAyar.Size = new System.Drawing.Size(196, 108);
            this.btnAyar.TabIndex = 4;
            this.btnAyar.Text = "AYARLAR";
            this.btnAyar.UseVisualStyleBackColor = false;
            this.btnAyar.Click += new System.EventHandler(this.btnAyar_Click);
            // 
            // Ana_Ekran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 518);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnAyar);
            this.Controls.Add(this.btnArama);
            this.Controls.Add(this.btnKayit);
            this.Controls.Add(this.resimKutusuAnaEkran);
            this.Controls.Add(this.tarihSaat);
            this.MaximumSize = new System.Drawing.Size(816, 557);
            this.MinimumSize = new System.Drawing.Size(816, 557);
            this.Name = "Ana_Ekran";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ana_Ekran_FormClosed);
            this.Load += new System.EventHandler(this.Ana_Ekran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.resimKutusuAnaEkran)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DateTimePicker tarihSaat;
        private PictureBox resimKutusuAnaEkran;
        private Button btnKayit;
        private Button btnArama;
        private Button btnCikis;
        private Button btnAyar;
    }
}