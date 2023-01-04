using ECT__Oto;

namespace ECT_OTO.Ekranlar
{
    public partial class Arama : Form
    {
        public Arama()
        {
            InitializeComponent();
            txtPlakaAra.Select();
        }

        Model data = new Model();

        private void btnIslemAra_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPlakaAra.Text))
            {
                string[] mevcutmu = new string[] { "ms_plaka", txtPlakaAra.Text };

                if (data.kayitSayisi("musteriler", mevcutmu) != 0)
                {
                    AramaDetay frm = new AramaDetay();
                    frm.musteri_kimlik = data.hucreGetir("musteriler", "ms_ID", new string[] { "ms_plaka", txtPlakaAra.Text });
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    Kayit frm2 = new Kayit();
                    frm2.txtPlaka.Text = txtPlakaAra.Text;
                    frm2.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Arama yapmak lütfen araç plakasını giriniz!..", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAnaEkranaGit_Click(object sender, EventArgs e)
        {
            Ana_Ekran frm = new Ana_Ekran();
            frm.Show();
            this.Hide();
        }

        private void Arama_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
