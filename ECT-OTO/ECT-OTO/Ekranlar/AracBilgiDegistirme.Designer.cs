namespace ECT_OTO.Ekranlar
{
    partial class AracBilgiDegistirme
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
            this.lblAracPlaka = new System.Windows.Forms.Label();
            this.txtAranacakAracPlakasi = new System.Windows.Forms.TextBox();
            this.btnAracPlakasiBul = new System.Windows.Forms.Button();
            this.btnIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAracPlaka
            // 
            this.lblAracPlaka.AutoSize = true;
            this.lblAracPlaka.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAracPlaka.Location = new System.Drawing.Point(285, 137);
            this.lblAracPlaka.Name = "lblAracPlaka";
            this.lblAracPlaka.Size = new System.Drawing.Size(269, 25);
            this.lblAracPlaka.TabIndex = 0;
            this.lblAracPlaka.Text = "Lütfen Araç Plakasını Yazınız:";
            // 
            // txtAranacakAracPlakasi
            // 
            this.txtAranacakAracPlakasi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAranacakAracPlakasi.Location = new System.Drawing.Point(337, 170);
            this.txtAranacakAracPlakasi.MaxLength = 11;
            this.txtAranacakAracPlakasi.Name = "txtAranacakAracPlakasi";
            this.txtAranacakAracPlakasi.Size = new System.Drawing.Size(143, 23);
            this.txtAranacakAracPlakasi.TabIndex = 1;
            // 
            // btnAracPlakasiBul
            // 
            this.btnAracPlakasiBul.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnAracPlakasiBul.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAracPlakasiBul.Location = new System.Drawing.Point(337, 201);
            this.btnAracPlakasiBul.Name = "btnAracPlakasiBul";
            this.btnAracPlakasiBul.Size = new System.Drawing.Size(143, 40);
            this.btnAracPlakasiBul.TabIndex = 2;
            this.btnAracPlakasiBul.Text = "BUL";
            this.btnAracPlakasiBul.UseVisualStyleBackColor = false;
            this.btnAracPlakasiBul.Click += new System.EventHandler(this.btnAracPlakasiBul_Click);
            // 
            // btnIptal
            // 
            this.btnIptal.BackColor = System.Drawing.Color.Crimson;
            this.btnIptal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIptal.Location = new System.Drawing.Point(337, 246);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(143, 40);
            this.btnIptal.TabIndex = 3;
            this.btnIptal.Text = "İPTAL";
            this.btnIptal.UseVisualStyleBackColor = false;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // AracBilgiDegistirme
            // 
            this.AcceptButton = this.btnAracPlakasiBul;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 440);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.btnAracPlakasiBul);
            this.Controls.Add(this.txtAranacakAracPlakasi);
            this.Controls.Add(this.lblAracPlaka);
            this.MaximumSize = new System.Drawing.Size(835, 479);
            this.MinimumSize = new System.Drawing.Size(835, 479);
            this.Name = "AracBilgiDegistirme";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AracBilgiDegistirme_FormClosed);
            this.Load += new System.EventHandler(this.AracBilgiDegistirme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblAracPlaka;
        private TextBox txtAranacakAracPlakasi;
        private Button btnAracPlakasiBul;
        private Button btnIptal;
    }
}