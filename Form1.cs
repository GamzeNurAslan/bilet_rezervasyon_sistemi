namespace GiBiletix
{
    public partial class Form1 : Form
    {
        private Sefer aktifSefer;
        private int secilenKoltukNo = -1;
        private List<Sefer> seferListesi = new List<Sefer>();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxNereden.Items.AddRange(new string[] { "Gaziantep", "İzmir", "Ankara", "İstanbul" });
            comboBoxNereye.Items.AddRange(new string[] { "Gaziantep", "İzmir", "Ankara", "İstanbul" });
        }

        private void sefer_ara_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string nereden = comboBoxNereden.Text;
            string nereye = comboBoxNereye.Text;
            DateTime tarih = dateTimePicker1.Value;

            if (nereden == nereye)
            {
                MessageBox.Show("Nereden ve Nereye aynı olamaz!");
                return;
            }

            if (!checkBoxSehirIci.Checked && !checkBoxSehirDisi.Checked)
            {
                MessageBox.Show("Lütfen şehir içi veya şehir dışı seçin.");
                return;
            }

            Sefer sefer = checkBoxSehirIci.Checked ? new Sehirici() : new Sehirlerarasi();

            sefer.Nereden = nereden;
            sefer.Nereye = nereye;
            sefer.Tarih = tarih;

            aktifSefer = sefer;
            seferListesi.Add(sefer);

            listBox1.Items.Add(sefer.ToString());
        }

        private void koltuk_sec_Click(object sender, EventArgs e)
        {
            if (aktifSefer == null)
            {
                MessageBox.Show("Önce bir sefer arayın.");
                return;
            }

            string input = Microsoft.VisualBasic.Interaction.InputBox(
                "Koltuk numarası giriniz (1-20):",
                "Koltuk Seçimi",
                "1");

            if (int.TryParse(input, out int koltukNo))
            {
                if (koltukNo < 1 || koltukNo > 20)
                {
                    MessageBox.Show("1 ile 20 arasında bir koltuk numarası girin.");
                    return;
                }

                if (aktifSefer.Otobus.KoltukDurumu(koltukNo))
                {
                    MessageBox.Show($"Koltuk {koltukNo} zaten dolu!", "Uyarı");
                    return;
                }

                if (aktifSefer.RezervasyonYap(koltukNo))
                {
                    secilenKoltukNo = koltukNo;
                    MessageBox.Show($"Koltuk {koltukNo} başarıyla seçildi.", "Koltuk Seçimi");
                }
                else
                {
                    MessageBox.Show("Koltuk seçimi başarısız oldu.");
                }
            }
            else
            {
                MessageBox.Show("Geçerli bir sayı girin.");
            }
        }

        private void bileti_yazdir_Click(object sender, EventArgs e)
        {
            if (aktifSefer == null || secilenKoltukNo == -1)
            {
                MessageBox.Show("Lütfen önce sefer ve koltuk seçin.");
                return;
            }

            string ad = textBoxAd.Text.Trim();
            string soyad = textBoxSoyad.Text.Trim();

            if (string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad))
            {
                MessageBox.Show("Ad ve Soyad boş olamaz.");
                return;
            }

            Yolcu yolcu = new Yolcu { Ad = ad, Soyad = soyad };

            Bilet bilet = new Bilet
            {
                Sefer = aktifSefer,
                Yolcu = yolcu,
                KoltukNo = secilenKoltukNo
            };

            listBox2.Items.Add("=== BİLET ===");
            listBox2.Items.Add($"Yolcu: {yolcu.Ad} {yolcu.Soyad}");
            listBox2.Items.Add($"Sefer: {aktifSefer.Nereden} → {aktifSefer.Nereye}");
            listBox2.Items.Add($"Tarih: {aktifSefer.Tarih:dd.MM.yyyy}");
            listBox2.Items.Add($"Koltuk No: {secilenKoltukNo}");
            listBox2.Items.Add("-----------------------------");

            secilenKoltukNo = -1;
            textBoxAd.Clear();
            textBoxSoyad.Clear();
        }

        private void checkBoxSehirIci_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSehirIci.Checked)
            {
                checkBoxSehirDisi.Checked = false;

                string secilenIl = comboBoxNereden.Text;

                if (secilenIl != "")
                {
                    MessageBox.Show("Şehir içi seferler için lütfen önce 'Elazığ' ilini seçin.", "Uyarı");
                    checkBoxSehirIci.Checked = false; 
                    return;
                }

                comboBoxNereden.Items.Clear();
                comboBoxNereye.Items.Clear();

                comboBoxNereden.Items.AddRange(Sehirici.Ilceler.ToArray());
                comboBoxNereye.Items.AddRange(Sehirici.Ilceler.ToArray());
            }
        }

        private void checkBoxSehirDisi_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSehirDisi.Checked)
            {
                checkBoxSehirIci.Checked = false;

                comboBoxNereden.Items.Clear();
                comboBoxNereye.Items.Clear();

                comboBoxNereden.Items.AddRange(Sehirlerarasi.Sehirler.ToArray());
                comboBoxNereye.Items.AddRange(Sehirlerarasi.Sehirler.ToArray());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
