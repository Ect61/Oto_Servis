using ECT__Oto;
using System;
using System.Data;

namespace ECT_OTO.Ekranlar
{
    public partial class AramaDetay : Form
    {
        public AramaDetay()
        {
            InitializeComponent();
        }

        public string musteri_kimlik = string.Empty;
        DataTable dtIslem;
        DataTable dtUsta;
        DataTable dtPlakalar;
        Model data = new Model();
        public string dgvCmbValue = string.Empty;

        private void AramaDetay_Load(object sender, EventArgs e)
        {
            veriAl(musteri_kimlik);
        }

        private void veriAl(string ms_no)
        {
            WindowState = FormWindowState.Maximized;
            dgvAramaDetay.DataSource = null;
            dgvAramaDetay.Columns.Clear();
            dtIslem = data.genel("yapilan_islemler", "ms_ID", ms_no);
            dtIslem.Columns.Add("ms_plaka");
            dtIslem.Columns.Add("tk_ad");
            dtUsta = data.genel("teknisyenler");
            dtPlakalar = data.BelirliKolonlarıAl(new string[] { "musteriler", "ms_ID", "ms_plaka" });


            for (int j = 0; j < dtIslem.Rows.Count; j++)
            {
                if (!string.Equals(dtIslem.Rows[j][6].ToString(), "0"))
                {
                    dtIslem.Rows[j]["tk_ad"] = dtUsta.Select("tk_ID='" + dtIslem.Rows[j][6].ToString() + "'")[0]["tk_ad"]; // tk_ID
                }
                if (!string.Equals(dtIslem.Rows[j][1].ToString(), "0"))
                {
                    dtIslem.Rows[j]["ms_plaka"] = dtPlakalar.Select("ms_ID='" + dtIslem.Rows[j][1].ToString() + "'")[0]["ms_plaka"]; // ms_ID
                }
            }
            dgvAramaDetay.DataSource = dtIslem;
            dgvAramaDetay.Columns[0].Visible = false;
            dgvAramaDetay.Columns[1].HeaderText = "MÜŞTERİ ID";
            dgvAramaDetay.Columns[2].HeaderText = "ŞİKAYET";
            dgvAramaDetay.Columns[3].HeaderText = "YAPILAN İŞLEMLER";
            dgvAramaDetay.Columns[4].HeaderText = "ADET";
            dgvAramaDetay.Columns[5].HeaderText = "BİRİM FİYAT";
            dgvAramaDetay.Columns[6].HeaderText = "TEKNİSYEN ID"; // 
            dgvAramaDetay.Columns[7].HeaderText = "TUTAR";
            dgvAramaDetay.Columns[8].HeaderText = "İŞLEM TARİHİ";
            dgvAramaDetay.Columns[9].Visible = false;
            dgvAramaDetay.Columns[10].HeaderText = "PLAKA";
            dgvAramaDetay.Columns[11].HeaderText = "TEKNİSYEN ADI"; //
            dgvAramaDetay.Columns[1].Visible = false;
            dgvAramaDetay.Columns[6].Visible = false;
            dgvAramaDetay.Columns["ms_plaka"].DisplayIndex = 1;
            dgvAramaDetay.Columns["tk_ad"].DisplayIndex = 6;

            dgvAramaDetay.Columns["adet"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAramaDetay.Columns["birim_fiyat"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAramaDetay.Columns["tutar"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAramaDetay.Columns["ms_plaka"].Width = 130;
            dgvAramaDetay.Columns["yapilan_islem"].Width = 200;
            dgvAramaDetay.Columns["adet"].Width = 60;
            dgvAramaDetay.Columns["birim_fiyat"].Width = 90;
            dgvAramaDetay.Columns["tk_ID"].Width = 150;
            dgvAramaDetay.Columns["tutar"].Width = 85;
            dgvAramaDetay.Columns["tarih"].Width = 130;
            dgvAramaDetay.Columns["adet"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAramaDetay.Columns["birim_fiyat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAramaDetay.Columns["tutar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvAramaDetay.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAramaDetay.CellBorderStyle = DataGridViewCellBorderStyle.RaisedHorizontal;

            dgvAramaDetay.Rows[0].Selected = true;
            btnYazdir.Visible = true;
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            printDocument1.DocumentName = dgvAramaDetay.Rows[0].Cells[10].Value.ToString() + "Plakalı Araç İşlem Kaydı";
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Font myFont;
            SolidBrush sbrush = new SolidBrush(Color.Black);
            Pen myPen = new Pen(Color.Black);

            int y = 80;
            int boyut = dgvAramaDetay.Rows.Count;
            for (int k = 0; k < boyut; k++)
            {
                myFont = new Font("Calibri", 10, FontStyle.Bold);
                e.Graphics.DrawString("PLAKA", myFont, sbrush, 80, y);
                e.Graphics.DrawString("ŞİKAYET", myFont, sbrush, 80, y + 20);
                e.Graphics.DrawString("YAPILAN İŞLEMLER", myFont, sbrush, 80, y + 40);
                e.Graphics.DrawString("ADET", myFont, sbrush, 80, y + 60);
                e.Graphics.DrawString("BİRİM FİYAT", myFont, sbrush, 80, y + 80);
                e.Graphics.DrawString("TEKNİSYEN ADI", myFont, sbrush, 80, y + 100);
                e.Graphics.DrawString("TUTAR", myFont, sbrush, 80, y + 120);
                e.Graphics.DrawString("İŞLEM TARİHİ", myFont, sbrush, 80, y + 140);

                myFont = new Font("Calibri", 10);
                e.Graphics.DrawString(dgvAramaDetay.Rows[k].Cells["ms_plaka"].Value.ToString(), myFont, sbrush, 220, y);
                e.Graphics.DrawString(dgvAramaDetay.Rows[k].Cells["sikayet"].Value.ToString(), myFont, sbrush, 220, y + 20);
                e.Graphics.DrawString(dgvAramaDetay.Rows[k].Cells["yapilan_islem"].Value.ToString(), myFont, sbrush, 220, y + 40);
                e.Graphics.DrawString(dgvAramaDetay.Rows[k].Cells["adet"].Value.ToString(), myFont, sbrush, 220, y + 60);
                e.Graphics.DrawString(dgvAramaDetay.Rows[k].Cells["birim_fiyat"].Value.ToString(), myFont, sbrush, 220, y + 80);
                e.Graphics.DrawString(dgvAramaDetay.Rows[k].Cells["tk_ad"].Value.ToString(), myFont, sbrush, 220, y + 100);
                e.Graphics.DrawString(dgvAramaDetay.Rows[k].Cells["tutar"].Value.ToString(), myFont, sbrush, 220, y + 120);
                e.Graphics.DrawString(dgvAramaDetay.Rows[k].Cells["tarih"].Value.ToString(), myFont, sbrush, 220, y + 140);

                e.Graphics.DrawLine(myPen, 80, y + 168, 360, y + 168); // Burası alta çizgi çekiyor
                y += 184;
            }
        }
    

        private void AramaDetay_FormClosed(object sender, FormClosedEventArgs e)
        {
            Ana_Ekran frm = new Ana_Ekran();
            frm.Show();
            this.Hide();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            IslemKayit iFrm = new IslemKayit();
            iFrm._uid = dgvAramaDetay.SelectedRows[0].Cells[0].Value.ToString();
            iFrm.Show();
            this.Hide();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            IslemKayit iFrm = new IslemKayit();
            iFrm._plaque = dgvAramaDetay.SelectedRows[0].Cells["ms_plaka"].Value.ToString();
            iFrm.Show();
            this.Hide();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();
            dialog = MessageBox.Show("Silmek istediğinizden emin misiniz?", "UYARI!!!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dialog == DialogResult.Yes)
            {
                if (dgvAramaDetay.Rows.Count == 1)
                {
                    string[] tablo_kosul = new string[] { "yapilan_islemler", "isl_ID", dgvAramaDetay.SelectedRows[0].Cells[0].Value.ToString() };
                    string[] degerler = new string[] { "ms_ID", dgvAramaDetay.SelectedRows[0].Cells[1].Value.ToString(), "sikayet", "", "yapilan_islem", "", "adet", "0", "birim_fiyat", "0", "tk_ID", "0", "tutar", "0" };

                    if (data.degistir(tablo_kosul, degerler))
                    {
                        MessageBox.Show("Bu müşteriye ait yapılan işlem tamamen kaldırılamaz. Araçla ilgilenen teknik servis personelinin ADI kalmak zorundadır.", "İŞLEM KALDIRMA!!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        veriAl(musteri_kimlik);
                        dgvAramaDetay.Refresh();
                    }
                }
                else
                {
                    if (data.sil("yapilan_islemler", "isl_ID", dgvAramaDetay.SelectedRows[0].Cells[0].Value.ToString()))
                    {
                        MessageBox.Show("Silme işlemi başarıyla gerçekleştirildi.", "İŞLEM KALDIRMA", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        veriAl(musteri_kimlik);
                        dgvAramaDetay.Refresh();
                    }
                }
            }
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            Ana_Ekran frm = new Ana_Ekran();
            frm.Show();
            this.Hide();
        }
    }
}
