using ECT__Oto;

namespace ECT_OTO.Ekranlar
{
    public partial class Ayarlar : Form
    {
        Model data = new Model();
        int dbControl = 1;

        public Ayarlar(int ctr)
        {
            dbControl = ctr;
            InitializeComponent();

        }


        private void Ayarlar_Load(object sender, EventArgs e)
        {
            if (dbControl == 0)
            {
                btnServer.Enabled = true;
                btnAracBilgiDegistir.Enabled = false;
                btnTeknisyenAyar.Enabled = false;
                
                btnAnaEkran.Enabled = false;
            }
            else
            {
                if (data.baglan())
                {
                    data.baglantiyiKapat();
                    btnServer.Enabled = false;
                }
            }
        }

        private void btnServer_Click(object sender, EventArgs e)
        {
            if (data.dbSetup("ect_oto"))
            {
                MessageBox.Show("Veri Tabanı ve Tablolar Başarılı Bir Şekilde Oluşturuldu !", "KURULUM TAMAMLANDI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnServer.Enabled = false;
                btnAracBilgiDegistir.Enabled = true;
                btnTeknisyenAyar.Enabled = true;
                
                btnAnaEkran.Enabled = true;

                Teknisyenler mainPage = new Teknisyenler();
                mainPage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Veri Tabanı Oluşturulurken Bir Hata ile Karşılaşıldı.", "KURULUM HATASI !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAracBilgiDegistir_Click(object sender, EventArgs e)
        {
            AracBilgiDegistirme frm = new AracBilgiDegistirme();
            frm.Show();
            this.Hide();
        }

        private void btnTeknisyenAyar_Click(object sender, EventArgs e)
        {
            Teknisyenler frm = new Teknisyenler();
            frm.Show();
            this.Hide();
        }

        

        private void btnAnaEkran_Click(object sender, EventArgs e)
        {
            Ana_Ekran frm = new Ana_Ekran();
            frm.Show();
            this.Hide();
        }

        private void Ayarlar_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
