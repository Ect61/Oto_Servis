namespace ECT_OTO.Ekranlar
{
    partial class Arama
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
            this.btnIslemAra = new System.Windows.Forms.Button();
            this.btnAnaEkranaGit = new System.Windows.Forms.Button();
            this.txtPlakaAra = new System.Windows.Forms.TextBox();
            this.lblAramaMesaji = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIslemAra
            // 
            this.btnIslemAra.BackColor = System.Drawing.Color.Gold;
            this.btnIslemAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnIslemAra.Location = new System.Drawing.Point(304, 151);
            this.btnIslemAra.Name = "btnIslemAra";
            this.btnIslemAra.Size = new System.Drawing.Size(176, 88);
            this.btnIslemAra.TabIndex = 0;
            this.btnIslemAra.Text = "İŞLEM ARA";
            this.btnIslemAra.UseVisualStyleBackColor = false;
            this.btnIslemAra.Click += new System.EventHandler(this.btnIslemAra_Click);
            // 
            // btnAnaEkranaGit
            // 
            this.btnAnaEkranaGit.BackColor = System.Drawing.Color.Crimson;
            this.btnAnaEkranaGit.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAnaEkranaGit.Location = new System.Drawing.Point(304, 278);
            this.btnAnaEkranaGit.Name = "btnAnaEkranaGit";
            this.btnAnaEkranaGit.Size = new System.Drawing.Size(176, 88);
            this.btnAnaEkranaGit.TabIndex = 1;
            this.btnAnaEkranaGit.Text = "ANA EKRANA GİT";
            this.btnAnaEkranaGit.UseVisualStyleBackColor = false;
            this.btnAnaEkranaGit.Click += new System.EventHandler(this.btnAnaEkranaGit_Click);
            // 
            // txtPlakaAra
            // 
            this.txtPlakaAra.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPlakaAra.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPlakaAra.Location = new System.Drawing.Point(304, 82);
            this.txtPlakaAra.Name = "txtPlakaAra";
            this.txtPlakaAra.Size = new System.Drawing.Size(176, 26);
            this.txtPlakaAra.TabIndex = 2;
            // 
            // lblAramaMesaji
            // 
            this.lblAramaMesaji.AutoSize = true;
            this.lblAramaMesaji.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAramaMesaji.Location = new System.Drawing.Point(196, 49);
            this.lblAramaMesaji.Name = "lblAramaMesaji";
            this.lblAramaMesaji.Size = new System.Drawing.Size(413, 20);
            this.lblAramaMesaji.TabIndex = 3;
            this.lblAramaMesaji.Text = "Lütfen işlemlerini görmek istediğiniz aracın plakasını giriniz";
            // 
            // Arama
            // 
            this.AcceptButton = this.btnIslemAra;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 457);
            this.Controls.Add(this.lblAramaMesaji);
            this.Controls.Add(this.txtPlakaAra);
            this.Controls.Add(this.btnAnaEkranaGit);
            this.Controls.Add(this.btnIslemAra);
            this.MaximumSize = new System.Drawing.Size(800, 496);
            this.MinimumSize = new System.Drawing.Size(800, 496);
            this.Name = "Arama";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EcT";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Arama_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnIslemAra;
        private Button btnAnaEkranaGit;
        private TextBox txtPlakaAra;
        private Label lblAramaMesaji;
    }
}