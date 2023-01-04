using ECT__Oto;
using System.Data;

namespace ECT_OTO.Ekranlar
{
    public partial class IslemKayit : Form
    {
        public IslemKayit()
        {
            InitializeComponent();
        }

        public string _plaque;
        public string _uid;
        DataTable dtYapilanIslemler;
        Model data = new Model();

        private void IslemKayit_Load(object sender, EventArgs e)
        {
            lblPlaka.Text = _plaque;
            veriAl();
        }

        private void veriAl()
        {
            cmbUsta.DataSource = data.Cek("teknisyenler");
            cmbUsta.ValueMember = "tk_ID";
            cmbUsta.DisplayMember = "tk_ad";

            if (!string.IsNullOrEmpty(_uid))
            {
                lblPlaka.Visible = false;
                btnIslemKaydet.Visible = false;
                lblIslem.Visible = false;
                dgvYapilanIslemler.Visible = false;
                grbYapilanIslemler.Visible = true;
                lblTutar.Visible = false;
                lbltutarad.Visible= false;
                //lblAdet.Visible = true;
                //lblBirimFiyat.Visible = true;
                //lblToplam.Visible = true;
                //lblUrun.Visible = true;
                //txtBirimFiyat.Visible = true;
                //txtToplam.Visible = true;
                //txtUrun.Visible = true;
                //adetUpDown.Visible = true;
                btnIslemEdit.Visible = true;
                lblEditPlaka.Visible = true;
                lblPlakaGoster.Visible = true;

                cmbEditPlaka.DataSource = data.BelirliKolonlarıAl(new string[] { "musteriler", "ms_ID", "ms_plaka" });
                cmbEditPlaka.ValueMember = "ms_ID";
                cmbEditPlaka.DisplayMember = "ms_plaka";
                dtYapilanIslemler = data.Cek("yapilan_islemler", "isl_ID", _uid);
                cmbEditPlaka.SelectedValue = dtYapilanIslemler.Rows[0]["ms_ID"].ToString();
                lblPlakaGoster.Text = cmbEditPlaka.Text;

                if (!string.IsNullOrEmpty(dtYapilanIslemler.Rows[0]["sikayet"].ToString())) txtSikayet.Text = dtYapilanIslemler.Rows[0]["sikayet"].ToString();
                if (!string.Equals(dtYapilanIslemler.Rows[0]["adet"].ToString(), "0")) adetUpDown.Value = Convert.ToDecimal(dtYapilanIslemler.Rows[0]["adet"].ToString());
                if (!string.IsNullOrEmpty(dtYapilanIslemler.Rows[0]["yapilan_islem"].ToString())) txtUrun.Text = dtYapilanIslemler.Rows[0]["yapilan_islem"].ToString().ToUpper();
                if (!string.Equals(dtYapilanIslemler.Rows[0]["birim_fiyat"].ToString(), "0")) txtBirimFiyat.Text = dtYapilanIslemler.Rows[0]["birim_fiyat"].ToString();
                if (!string.Equals(dtYapilanIslemler.Rows[0]["tutar"].ToString(), "0")) txtToplam.Text = dtYapilanIslemler.Rows[0]["tutar"].ToString();
                if (!string.Equals(dtYapilanIslemler.Rows[0]["tk_ID"].ToString(), "0")) cmbUsta.SelectedValue = dtYapilanIslemler.Rows[0]["tk_ID"].ToString();
            }
        }

        private void btnIslemKaydet_Click(object sender, EventArgs e)
        {
            string str_adet = " ";
            string str_urun = " ";
            string str_birimFiyat = " ";
            string str_Toplam = " ";
            string[] kolon = new string[] { "ms_ID", "sikayet", "yapilan_islem", "adet", "birim_fiyat", "tk_ID", "tutar", "teknisyen_ad" };
            int durum = 0;
            string kimlik = data.hucreGetir("musteriler", "ms_ID", new string[] { "ms_plaka", lblPlaka.Text });

            for (int i = 0; i < dgvYapilanIslemler.Rows.Count - 1; i++)
            {
                if (dgvYapilanIslemler.Rows[i].Cells[0].Value != null) str_adet = dgvYapilanIslemler.Rows[i].Cells[0].Value.ToString(); else str_adet = "0";
                if (dgvYapilanIslemler.Rows[i].Cells[1].Value != null) str_urun = dgvYapilanIslemler.Rows[i].Cells[1].Value.ToString();
                if (dgvYapilanIslemler.Rows[i].Cells[2].Value != null) str_birimFiyat = dgvYapilanIslemler.Rows[i].Cells[2].Value.ToString(); else str_birimFiyat = "0";
                if (dgvYapilanIslemler.Rows[i].Cells[3].Value != null) str_Toplam = dgvYapilanIslemler.Rows[i].Cells[3].Value.ToString(); else str_Toplam = "0";
                string[] deger = new string[] { kimlik, txtSikayet.Text, str_urun, str_adet, str_birimFiyat, cmbUsta.SelectedValue.ToString(), str_Toplam, cmbUsta.Text };

                if (data.ekle("yapilan_islemler", kolon, deger))
                {
                    durum++;
                }
                else
                {
                    MessageBox.Show("Kayıt işlemi esnasında bir hata meydana geldi!\nLütfen sistem sorumlusu ile iletişime geçiniz..", "HATALI İŞLEM!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (durum > 0)
            {
                MessageBox.Show("Kayıt işlemi başarıyla gerçekleştirildi.", "İŞLEM KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Ana_Ekran frm = new Ana_Ekran();
                frm.Show();
                this.Hide();
            }
        }

        private void btnIslemEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_uid))
            {                
                string[] tablo_kosul = new string[] { "yapilan_islemler", "isl_ID", _uid };
                string[] degerler = new string[] { "ms_ID", cmbEditPlaka.SelectedValue.ToString(), "sikayet", txtSikayet.Text, "yapilan_islem", txtUrun.Text, "adet", Convert.ToString(adetUpDown.Value), "birim_fiyat", txtBirimFiyat.Text, "tk_ID", cmbUsta.SelectedValue.ToString(), "tutar", txtToplam.Text, "teknisyen_ad", cmbUsta.Text };

                if (data.degistir(tablo_kosul, degerler))
                {
                    MessageBox.Show("Değişiklik işlemi başarıyla gerçekleştirildi.", "İŞLEM KAYDI DEĞİŞİKLİĞİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Ana_Ekran ana = new Ana_Ekran();
                    ana.Show();
                    this.Hide();
                }
            }
        }

        private void btnIslemVazgec_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_uid))
            {
                Ana_Ekran ana = new Ana_Ekran();
                ana.Show();
                this.Hide();
            }
            else
            {
                AramaDetay arm = new AramaDetay();
                arm.musteri_kimlik = dtYapilanIslemler.Rows[0]["ms_ID"].ToString();
                arm.Show();
                this.Hide();
            }
        }

        private void dgvYapilanIslemler_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double toplam = 0;
            for (int i = 0; i < dgvYapilanIslemler.Rows.Count; ++i)
            {
                dgvYapilanIslemler.Rows[i].Cells["toplam"].Value = Convert.ToInt32(dgvYapilanIslemler.Rows[i].Cells["adet"].Value) * Convert.ToInt32(dgvYapilanIslemler.Rows[i].Cells["birimFiyat"].Value);
                toplam += (Convert.ToDouble(dgvYapilanIslemler.Rows[i].Cells[3].Value));
                lblTutar.Text = toplam.ToString();
            }
        }

        private void dgvYapilanIslemler_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvYapilanIslemler.CurrentCell.ColumnIndex == 0 || dgvYapilanIslemler.CurrentCell.ColumnIndex == 2)
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= new KeyPressEventHandler(OtherRowCell_KeyPress);
                    tb.KeyPress += new KeyPressEventHandler(RowCell_KeyPress);
                }
            }
            else
            {
                TextBox tb = e.Control as TextBox;
                if (tb != null)
                {
                    tb.KeyPress -= new KeyPressEventHandler(RowCell_KeyPress);
                    tb.KeyPress += new KeyPressEventHandler(OtherRowCell_KeyPress);
                }
            }
        }

        private void RowCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void OtherRowCell_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void IslemKayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void adetUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBirimFiyat.Text))
            {
                txtToplam.Text = Convert.ToString(adetUpDown.Value * Convert.ToDecimal(txtBirimFiyat.Text));
            }
        }

        private void txtBirimFiyat_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBirimFiyat.Text))
            txtToplam.Text = Convert.ToString(adetUpDown.Value * Convert.ToDecimal(txtBirimFiyat.Text));
        }

        private void txtBirimFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
