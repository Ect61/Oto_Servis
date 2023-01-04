using ECT__Oto;
using System.Data;

namespace ECT_OTO.Ekranlar
{
    public partial class Kayit : Form
    {
        Model data = new Model();
        DataTable dtAracMarka;
        DataTable dtAracModel;
        DataTable dtMusteri;
        public string _Plaque;

        public Kayit()
        {
            InitializeComponent();
        }

        private void veriAl(string plk = null)
        {
            cmbAracTipi.DataSource = data.Cek("arac_tipi");
            cmbAracTipi.ValueMember = "tip_ID";
            cmbAracTipi.DisplayMember = "tip_name";

            cmbAracYili.DataSource = data.Cek("arac_yili"); ;
            cmbAracYili.ValueMember = "yil_ID";
            cmbAracYili.DisplayMember = "yil_name";
            cmbAracYili.Text = "2010";

            cmbMotorHacmi.DataSource = data.Cek("motor_hacmi"); ;
            cmbMotorHacmi.ValueMember = "mh_ID";
            cmbMotorHacmi.DisplayMember = "mh_name";

            cmbAracYakitTuru.DataSource = data.Cek("yakit_turu"); ;
            cmbAracYakitTuru.ValueMember = "yt_ID";
            cmbAracYakitTuru.DisplayMember = "yt_name";

            if (!string.IsNullOrEmpty(plk))
            {
                dtMusteri = data.genel("musteriler", "ms_plaka", plk);

                if (dtMusteri != null)
                {
                    txtAdSoyad.Text = dtMusteri.Rows[0]["ms_adi"].ToString();
                    txtTel.Text = dtMusteri.Rows[0]["ms_tel"].ToString();
                    txtPlaka.Text = dtMusteri.Rows[0]["ms_plaka"].ToString();
                    txtAdres.Text = dtMusteri.Rows[0]["ms_adres"].ToString();
                    txtKilometre.Text = dtMusteri.Rows[0]["kilometresi"].ToString();
                    cmbAracTipi.SelectedValue = dtMusteri.Rows[0]["tip_ID"].ToString();
                    cmbAracMarkasi.SelectedValue = dtMusteri.Rows[0]["mrk_ID"].ToString();
                    cmbAracModeli.SelectedValue = dtMusteri.Rows[0]["md_ID"].ToString();
                    cmbAracYili.SelectedValue = dtMusteri.Rows[0]["yil_ID"].ToString();
                    cmbAracYakitTuru.SelectedValue = dtMusteri.Rows[0]["yt_ID"].ToString();
                    cmbMotorHacmi.SelectedValue = dtMusteri.Rows[0]["mh_ID"].ToString();
                    btnKaydet.Visible = false;
                    btnEdit.Visible = true;
                }
            }
        }

        private void Kayit_Load(object sender, EventArgs e)
        {
            veriAl(_Plaque);
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string[] kolonlar = new string[] { "ms_adi", "ms_tel", "ms_plaka", "ms_adres", "tip_ID", "mrk_ID", "md_ID", "yil_ID", "mh_ID", "kilometresi", "yt_ID" };
            string[] degerler = new string[] { txtAdSoyad.Text, txtTel.Text, txtPlaka.Text, txtAdres.Text, cmbAracTipi.SelectedValue.ToString(), cmbAracMarkasi.SelectedValue.ToString(), cmbAracModeli.SelectedValue.ToString(), cmbAracYili.SelectedValue.ToString(), cmbMotorHacmi.SelectedValue.ToString(), txtKilometre.Text, cmbAracYakitTuru.SelectedValue.ToString() };

            if (data.ekle("musteriler", kolonlar, degerler))
            {
                data.ekle("yapilan_islemler", new string[] {"ms_ID" }, new string[] { data.hucreGetir("musteriler", "ms_ID", "ms_plaka", txtPlaka.Text) });
                MessageBox.Show("Kayıt işlemi başarıyla gerçekleştirildi.", "MÜŞTERİ KAYIT", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AramaDetay frm = new AramaDetay();
                frm.musteri_kimlik = data.hucreGetir("musteriler", "ms_ID", "ms_plaka", txtPlaka.Text);
                frm.Show();
                this.Hide();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_Plaque))
            {
                string[] tablo_kosul = new string[] { "musteriler", "ms_plaka", _Plaque };
                string[] degerler = new string[] { "ms_adi", txtAdSoyad.Text, "ms_tel", txtTel.Text, "ms_plaka", txtPlaka.Text, "ms_adres", txtAdres.Text, "tip_ID", cmbAracTipi.SelectedValue.ToString(), "mrk_ID", cmbAracMarkasi.SelectedValue.ToString(), "md_ID", cmbAracModeli.SelectedValue.ToString(), "yil_ID", cmbAracYili.SelectedValue.ToString(), "mh_ID", cmbMotorHacmi.SelectedValue.ToString(), "kilometresi", txtKilometre.Text, "yt_ID", cmbAracYakitTuru.SelectedValue.ToString(), "eklenme_tarihi", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") };

                if (data.degistir(tablo_kosul, degerler))
                {
                    MessageBox.Show("Değişiklik işlemi başarıyla gerçekleştirildi.", "MÜŞTERİ KAYDI DEĞİŞİKLİĞİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    IslemKayit frm = new IslemKayit();
                    frm.Show();
                    this.Hide();
                }
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Ana_Ekran frm = new Ana_Ekran();
            frm.Show();
            this.Hide();
        }

        private void cmbAracTipi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtAracMarka = data.genel("arac_markasi", "tip_ID", cmbAracTipi.SelectedValue.ToString());
            cmbAracMarkasi.DataSource = dtAracMarka;
            cmbAracMarkasi.ValueMember = "mrk_ID";
            cmbAracMarkasi.DisplayMember = "mrk_name";
        }

        private void cmbAracMarkasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtAracModel = data.genel("arac_modeli", "mrk_ID", cmbAracMarkasi.SelectedValue.ToString());
            cmbAracModeli.DataSource = dtAracModel;
            cmbAracModeli.ValueMember = "md_ID";
            cmbAracModeli.DisplayMember = "md_name";
        }

        private void Kayit_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtAdSoyad_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void txtKilometre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
