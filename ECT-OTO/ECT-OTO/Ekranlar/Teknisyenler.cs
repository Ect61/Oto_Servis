using ECT__Oto;
using System.Windows.Forms;

namespace ECT_OTO.Ekranlar
{
    public partial class Teknisyenler : Form
    {
        
        public Teknisyenler()
        {
            InitializeComponent();
        }

        Model data = new Model();
        private void temizle()
        {
            txtTeknisyenAd.Clear();
            txtTeknisyenAdres.Clear();
            txtTeknisyenTel.Clear();
        }
        private void veriAl()
        {
            dtvTeknisyenler.DataSource = data.genel("teknisyenler");

            dtvTeknisyenler.Columns["tk_ID"].Visible = false;
            dtvTeknisyenler.Columns["tk_ad"].HeaderText = "TEKNİSYEN ADI";
            dtvTeknisyenler.Columns["tk_tel"].HeaderText = "TELEFON";
            dtvTeknisyenler.Columns["tk_adres"].HeaderText = "ADRES";

            dtvTeknisyenler.Columns["tk_ad"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtvTeknisyenler.Columns["tk_tel"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dtvTeknisyenler.Columns["tk_adres"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtvTeknisyenler.Columns["tk_ad"].Width = 200;
            dtvTeknisyenler.Columns["tk_tel"].Width = 125;
            dtvTeknisyenler.Columns["tk_adres"].Width = 372;
            dtvTeknisyenler.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtvTeknisyenler.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;
            dtvTeknisyenler.ClearSelection();
            //dtvTeknisyenler.Rows[0].Selected = true;
            dtvTeknisyenler.ClearSelection();
            if (radioEkle.Checked)
            {
                dtvTeknisyenler.ClearSelection();
                temizle();
            }

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (data.ekle("teknisyenler", new string[] { "tk_ad", "tk_tel", "tk_adres" }, new string[] { txtTeknisyenAd.Text, txtTeknisyenTel.Text, txtTeknisyenAdres.Text }))
            {
                btnKaydet.Enabled = false;
                MessageBox.Show(txtTeknisyenAd.Text + " Adlı Usta Bilgileri Başarıyla Kaydedildi.", "ECT-OTO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Bilgiler Kaydedilirken Bir Hata Meydana Geldi.\nLütfen Bilgi-İşlem Birimiyle İrtibata Geçiniz!..", "ECT-OTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Ayarlar ayar = new Ayarlar(1);
            ayar.Show();
            this.Hide();
            
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            string[] tablo_kosul = new string[] { "teknisyenler", "tk_ID", dtvTeknisyenler.SelectedRows[0].Cells[0].Value.ToString() };
            string[] degerler = new string[] { "tk_ad", txtTeknisyenAd.Text, "tk_tel", txtTeknisyenTel.Text, "tk_adres", txtTeknisyenAdres.Text };

            if (data.degistir(tablo_kosul, degerler))
            {
                MessageBox.Show("Değişiklik işlemi başarıyla gerçekleştirildi.", "TEKNİSYEN KAYDI DEĞİŞİKLİĞİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                veriAl();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            string silinenID = dtvTeknisyenler.SelectedRows[0].Cells["tk_ID"].Value.ToString();
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Silmek istediğinizden emin misiniz?", "UYARI!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                if (data.sil("teknisyenler", "tk_ID", silinenID))
                {
                    veriAl();
                    if (data.guncelle(new string[] { "yapilan_islemler", "tk_ID", silinenID }, new string[] { "tk_ID", "0" }))
                    {
                        MessageBox.Show("Seçtiğiniz Teknisyen Başarıyla Silinmiştir.", "ECT-OTO", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                {
                    MessageBox.Show("Teknisyen Silinirken Bir Hata Oluştu! Lütfen Tekrar Deneyin.", "ECT-OTO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Ayarlar frm = new Ayarlar(1);
            frm.Show();
            this.Hide();
        }

        private void Teknisyenler_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void radioEkle_CheckedChanged(object sender, EventArgs e)
        {
            btnKaydet.Visible = true;
            btnDuzenle.Visible = false;
            btnSil.Visible = false;
            AcceptButton = btnKaydet;
            txtTeknisyenAd.Text = null;
            txtTeknisyenTel.Text = null;
            txtTeknisyenAdres.Text = null;
            dtvTeknisyenler.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
            dtvTeknisyenler.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.MenuHighlight;
            
            temizle();
            

        }

        private void radioDuzenle_CheckedChanged(object sender, EventArgs e)
        {
            btnDuzenle.Visible = true;
            btnKaydet.Visible = false;
            btnSil.Visible = false;
            AcceptButton = btnDuzenle;

            if (dtvTeknisyenler.SelectedCells.Count > 0)
            {
                txtTeknisyenAd.Text = dtvTeknisyenler.SelectedCells[1].Value.ToString();
                txtTeknisyenTel.Text = dtvTeknisyenler.SelectedCells[2].Value.ToString();
                txtTeknisyenAdres.Text = dtvTeknisyenler.SelectedCells[3].Value.ToString();
            }
            dtvTeknisyenler.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
            dtvTeknisyenler.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.HotTrack;
            dtvTeknisyenler.ColumnHeadersDefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.HotTrack;
        }

        private void radioSil_CheckedChanged(object sender, EventArgs e)
        {
            btnDuzenle.Visible = false;
            btnKaydet.Visible = false;
            btnSil.Visible = true;
            AcceptButton = btnSil;

            if (dtvTeknisyenler.SelectedCells.Count > 0)
            {
                txtTeknisyenAd.Text = dtvTeknisyenler.SelectedCells[1].Value.ToString();
                txtTeknisyenTel.Text = dtvTeknisyenler.SelectedCells[2].Value.ToString();
                txtTeknisyenAdres.Text = dtvTeknisyenler.SelectedCells[3].Value.ToString();
            }
            dtvTeknisyenler.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(239, 239, 239);
            dtvTeknisyenler.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.SystemColors.HotTrack;
        }

        private void Teknisyenler_Load(object sender, EventArgs e)
        {
            veriAl();
            temizle();

            
            
          

          
            
        }

        private void dtvTeknisyenler_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dtvTeknisyenler_SelectionChanged(object sender, EventArgs e)
        {
            if (dtvTeknisyenler.SelectedCells.Count > 0)
            {
                txtTeknisyenAd.Text = dtvTeknisyenler.SelectedRows[0].Cells[1].Value.ToString();
                txtTeknisyenTel.Text = dtvTeknisyenler.SelectedRows[0].Cells[2].Value.ToString();
                txtTeknisyenAdres.Text = dtvTeknisyenler.SelectedRows[0].Cells[3].Value.ToString();
                if (radioEkle.Checked)
                {
                    temizle();
                }
            }
        }
    }
}
