using ECT__Oto;

namespace ECT_OTO.Ekranlar
{
    public partial class Ana_Ekran : Form
    {
        Model data = new Model();

        public Ana_Ekran()
        {
            InitializeComponent();
        }

        private void btnKayit_Click(object sender, EventArgs e)
        {
            Kayit frm = new Kayit();
            frm.Show();
            this.Hide();
        }

        private void btnArama_Click(object sender, EventArgs e)
        {
            Arama frm = new Arama();
            frm.Show();
            this.Hide();
        }

        private void btnAyar_Click(object sender, EventArgs e)
        {
            Ayarlar frm = new Ayarlar(1);
            frm.Show();
            this.Hide();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Giris frm = new Giris();
            frm.Show();
            this.Hide();
        }

        private void Ana_Ekran_Load(object sender, EventArgs e)
        {
            //data.ECT__Oto("localhost", "root", "", "ect_oto");
        }

        private void Ana_Ekran_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
