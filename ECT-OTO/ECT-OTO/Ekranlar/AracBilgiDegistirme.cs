using ECT__Oto;
using System.Data;

namespace ECT_OTO.Ekranlar
{
    public partial class AracBilgiDegistirme : Form
    {
        public AracBilgiDegistirme()
        {
            InitializeComponent();
        }
        
        Model data = new Model();   
        
        private void btnAracPlakasiBul_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(data.hucreGetir("musteriler","ms_plaka",new string[] {"ms_plaka",txtAranacakAracPlakasi.Text})))

             {
                 if (!string.IsNullOrEmpty(txtAranacakAracPlakasi.Text))
                    {
                        Kayit kyt = new Kayit();
                        kyt._Plaque = txtAranacakAracPlakasi.Text;
                        kyt.Show();
                        this.Hide();
                    }
                  
            }
                 else
                 {
                     MessageBox.Show("Araç sisteme kayıtlı DEĞİL!", "ECT OTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     Kayit frm = new Kayit();
                     frm.Show();
                     this.Hide();
                 }

        }

        private void AracBilgiDegistirme_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void AracBilgiDegistirme_Load(object sender, EventArgs e)
        {
            txtAranacakAracPlakasi.Focus();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Ayarlar ayr = new Ayarlar(1);
            ayr.Show();
            this.Hide();
        }
    }
}
