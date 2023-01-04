using ECT__Oto;

namespace ECT_OTO.Ekranlar
{
    public partial class Giris : Form
    {
        Model data = new Model();

        public Giris()
        {
            InitializeComponent();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            /*if (data.dbControl("ect_oto") == 0)
            {
                Ayarlar DNS = new Ayarlar();
                DNS.dbControl = 0;
                DNS.Show();
                this.Hide();
            }*/
            if (data.dbControl("ect_oto") == 1)
            {
                DateTime bugunTarihi = DateTime.Now;
                DateTime kurulumTarihi = Convert.ToDateTime(data.hucreGetir("kurulum_tarihi", "zaman"));

                TimeSpan ts = bugunTarihi - kurulumTarihi;

                if (string.Equals(data.hucreGetir("kurulum_tarihi", "sifre"), "123456") && ts.Days > 90)
                {
                    btnCikis.Visible = false;
                    btnGiris.Visible = false;
                    resimKutusuGiris.Visible = false;
                    lblMesaj.Visible = true;
                    txtPass.Visible = true;
                    btnGonder.Visible = true;

                    DialogResult dg = new DialogResult();
                    dg = MessageBox.Show("Programı kullanmaya devam edebilmeniz için\n+90 533 930 53 73 no'lu telefondan şifre almanız gerekmektedir!\nŞifre girmek için EVET, çıkış yapmak için HAYIR butonuna basınız!..", "UYARI!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (dg == DialogResult.No)
                    {
                        Application.Exit();
                    }
                }

                string yil = DateTime.Now.Year.ToString();
                string[] seneler = data.al(new string[] { "arac_yili" }, new string[] { "yil_name", yil });

                if (seneler.Length < 1)
                {
                    if (!data.ekle("arac_yili", new string[] { "yil_name" }, new string[] { yil }))
                    {
                        MessageBox.Show("Yeni yıl eklenirken bir hata meydana geldi!\nLütfen sistem yönecinizle irtibata geçiniz.", "ECT OTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Ana_Ekran frm = new Ana_Ekran();
            frm.Show();
            this.Hide();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Giris_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnGonder_Click(object sender, EventArgs e)
        {
            if (string.Equals(txtPass.Text, "10545076!!"))
            {
                if (data.guncelle(new string[] { "kurulum_tarihi", "zamanID", "1" }, new string[] { "sifre", txtPass.Text }))
                {
                    Ana_Ekran frm = new Ana_Ekran();
                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Girdiğiniz şifre yanlıştır!\nLütfen sistem yönecinizle irtibata geçiniz.", "ECT OTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
