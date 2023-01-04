namespace ECT_OTO.Ekranlar
{
    partial class Ayarlar
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
            this.btnServer = new System.Windows.Forms.Button();
            this.btnAracBilgiDegistir = new System.Windows.Forms.Button();
            this.btnTeknisyenAyar = new System.Windows.Forms.Button();
            this.btnAnaEkran = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnServer
            // 
            this.btnServer.BackColor = System.Drawing.Color.DarkGreen;
            this.btnServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnServer.ForeColor = System.Drawing.Color.Snow;
            this.btnServer.Location = new System.Drawing.Point(12, 17);
            this.btnServer.Name = "btnServer";
            this.btnServer.Size = new System.Drawing.Size(317, 52);
            this.btnServer.TabIndex = 0;
            this.btnServer.Text = "Server Oluşturma";
            this.btnServer.UseVisualStyleBackColor = false;
            this.btnServer.Click += new System.EventHandler(this.btnServer_Click);
            // 
            // btnAracBilgiDegistir
            // 
            this.btnAracBilgiDegistir.BackColor = System.Drawing.Color.Gray;
            this.btnAracBilgiDegistir.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAracBilgiDegistir.Location = new System.Drawing.Point(12, 75);
            this.btnAracBilgiDegistir.Name = "btnAracBilgiDegistir";
            this.btnAracBilgiDegistir.Size = new System.Drawing.Size(317, 150);
            this.btnAracBilgiDegistir.TabIndex = 1;
            this.btnAracBilgiDegistir.Text = "ARAÇ BİLGİLERİNİ DEĞİŞTİR";
            this.btnAracBilgiDegistir.UseVisualStyleBackColor = false;
            this.btnAracBilgiDegistir.Click += new System.EventHandler(this.btnAracBilgiDegistir_Click);
            // 
            // btnTeknisyenAyar
            // 
            this.btnTeknisyenAyar.BackColor = System.Drawing.Color.DarkBlue;
            this.btnTeknisyenAyar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnTeknisyenAyar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTeknisyenAyar.Location = new System.Drawing.Point(12, 231);
            this.btnTeknisyenAyar.Name = "btnTeknisyenAyar";
            this.btnTeknisyenAyar.Size = new System.Drawing.Size(317, 150);
            this.btnTeknisyenAyar.TabIndex = 2;
            this.btnTeknisyenAyar.Text = "TEKNİSYEN AYARLARI";
            this.btnTeknisyenAyar.UseVisualStyleBackColor = false;
            this.btnTeknisyenAyar.Click += new System.EventHandler(this.btnTeknisyenAyar_Click);
            // 
            // btnAnaEkran
            // 
            this.btnAnaEkran.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnAnaEkran.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAnaEkran.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAnaEkran.Location = new System.Drawing.Point(12, 387);
            this.btnAnaEkran.Name = "btnAnaEkran";
            this.btnAnaEkran.Size = new System.Drawing.Size(317, 53);
            this.btnAnaEkran.TabIndex = 4;
            this.btnAnaEkran.Text = "ANA EKRANA DÖN";
            this.btnAnaEkran.UseVisualStyleBackColor = false;
            this.btnAnaEkran.Click += new System.EventHandler(this.btnAnaEkran_Click);
            // 
            // Ayarlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 461);
            this.Controls.Add(this.btnAnaEkran);
            this.Controls.Add(this.btnTeknisyenAyar);
            this.Controls.Add(this.btnAracBilgiDegistir);
            this.Controls.Add(this.btnServer);
            this.MaximumSize = new System.Drawing.Size(358, 500);
            this.MinimumSize = new System.Drawing.Size(358, 500);
            this.Name = "Ayarlar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Eryaman Oto Servis";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Ayarlar_FormClosed);
            this.Load += new System.EventHandler(this.Ayarlar_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnServer;
        private Button btnAracBilgiDegistir;
        private Button btnTeknisyenAyar;
        private Button btnAnaEkran;
    }
}