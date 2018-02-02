using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Drawing.Drawing2D;//2 Adet Kütüphanemiz mevcut
using System.Drawing.Imaging;



namespace NüfusCüzdanı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string vesikalik = "";
        bool temizle = true;
        Bitmap bm;//Bitmap(Resim demek) Yeni bir örneğini başlatır Bitmap belirtilen mevcut görüntü sınıfından
        Bitmap vbm;//Bitmap(Resim demek) Yeni bir örneğini başlatır Bitmap belirtilen mevcut görüntü sınıfından
        private void Form1_Load(object sender, EventArgs e)
        {
            bm = new Bitmap(Properties.Resources.erkek_bos_kimlik);//Burası Debug DenemeÖzelÇokluDersPropertiesve Resources'in içinde "erkek_bos_kimli"k adında resimimizi çağırıyoruz nasıl Properties/En altta Tolgahan isminde
            vbm = new Bitmap(Properties.Resources.kisi, 83, 99);//İkinci resim Propertiesve Resources'in içinde "kisi" adında resimimizi çağırıyoruz nasıl Properties/En altta Tolgahan isminde
            Graphics grafik;//Burada grafik methodumuzu kullanıyoruz
            grafik = pictureBox1.CreateGraphics();
            grafik.DrawImage(vbm, 134, 39);
            CmbxCinsiyet.Text = "Erkek";
            CmbxMedeniHali.Text = "BEKAR";
            CmbxDin.Text = "İSLAM";
            CmbxKan.Text = "A";
            pictureBox1.Image = bm;
            veri_gir();
        }
        private void veri_gir()
        {
            Graphics grafic;
            grafic = pictureBox1.CreateGraphics();
            Brush fırca = new SolidBrush(Color.Black);
            Font yazı = new Font("Palatino Linotype", 7, FontStyle.Bold);
            grafic.DrawString(TxtVersiyonno.Text, new Font("Palatino Linotype", 8, FontStyle.Bold), fırca, 60, 143);
            grafic.DrawString("No  " + TxtNo.Text, new Font("Palatino Linotype", 8, FontStyle.Bold), fırca, 130, 143);
            grafic.DrawString(TxtTcKimlikNo.Text, new Font("Palatino Linotype", 8, FontStyle.Bold), fırca, 64, 167);
            grafic.DrawString(TxtSoyad.Text, yazı, fırca, 64, 188);
            grafic.DrawString(TxtAdı.Text, yazı, fırca, 64, 210);
            grafic.DrawString(TxtBabaAdı.Text, yazı, fırca, 64, 234);
            grafic.DrawString(TxtAnaAdı.Text, yazı, fırca, 64, 253);
            grafic.DrawString(CmbxDogumYeri.Text, yazı, fırca, 20, 281);
            grafic.DrawString(TxtDogumTarihi.Text, yazı, fırca, 125, 281);
            grafic.DrawString(CmbxMedeniHali.Text, yazı, fırca, 260, 22);
            grafic.DrawString(CmbxDin.Text, yazı, fırca, 320, 22);
            grafic.DrawString(CmbxKan.Text, yazı, fırca, 390, 22);
            grafic.DrawString(Cmbxİl.Text, yazı, fırca, 257, 48);
            grafic.DrawString(Txtİlce.Text, yazı, fırca, 355, 48);
            grafic.DrawString(TxtMahalle.Text, yazı, fırca, 260, 74);
            grafic.DrawString(TxtCiltNo.Text, yazı, fırca, 261, 99);
            grafic.DrawString(TxtAileSıraNo.Text, yazı, fırca, 325, 99);
            grafic.DrawString(TxtSıraNo.Text, yazı, fırca, 392, 99);
            grafic.DrawString(TxtVerildigiyer.Text, yazı, fırca, 257, 125);
            grafic.DrawString(TxtVerilisiNedeni.Text, yazı, fırca, 355, 125);
            grafic.DrawString(TxtKayıtNo.Text, yazı, fırca, 257, 149);
            grafic.DrawString(TxtVerilisTarih.Text, yazı, fırca, 355, 149);
            grafic.DrawString(TxtVerenKisi.Text + "\n     V.H.K.İ", yazı, fırca, 270, 190);
            grafic.DrawString(TxtMudur.Text + "\n   Nüfus Müdürü a.\n    NÜFUS ŞEFİ", yazı, fırca, 320, 210);
            if (vbm != null)
            {
                grafic.DrawImage(vbm, 134, 39);
            }
        }

        private void BtnResimEkle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ac = new OpenFileDialog();
            ac.Title = "Aç";
            ac.Filter = "Png Dosyaları|*.png|Bmp Dosyaları|*.bmp|Jpg Dosyaları|*.jpg|Tüm Dosyalar|*.*";
            if (ac.ShowDialog() == DialogResult.OK)
            {
                TxtVesika.Text = ac.SafeFileName;
                vesikalik = ac.FileName;
                PictureBox ves = new PictureBox();
                ves.Image = Image.FromFile(ac.FileName);
                vbm = new Bitmap(ves.Image, 83, 99);
                if (BtnÖnizle.Text == "Önizle")
                {
                    BtnÖnizle.PerformClick();
                }
                //pictureBox2.Image = Image.FromFile(ac.FileName);
            }
        }

        private void BtnÖnizle_Click(object sender, EventArgs e)
        {
             if (temizle == true)
            {
                BtnÖnizle.Text = "Temizle";
                temizle = false;

            }
            else
            {
                BtnÖnizle.Text = "Önizle";
                pictureBox1.Image = Properties.Resources.erkek_bos_kimlik;
                temizle = true;

            }
            veri_gir();
          
        
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog kaydet = new SaveFileDialog();
            kaydet.Title = "Kaydet";
            kaydet.Filter = "Png Dosyaları|*.png|Bmp Dosyaları|*.bmp|Jpg Dosyaları|*.jpg|Tüm Dosyalar|*.*";
            if (kaydet.ShowDialog() == DialogResult.OK)
            {
                Graphics grafic;
                grafic = Graphics.FromImage(pictureBox1.Image);
                Brush fırca = new SolidBrush(Color.Black);
                Font yazı = new Font("Palatino Linotype", 7, FontStyle.Bold);
                grafic.DrawString(TxtVersiyonno.Text, new Font("Palatino Linotype", 8, FontStyle.Bold), fırca, 60, 143);
                grafic.DrawString("No  " + TxtNo.Text, new Font("Palatino Linotype", 8, FontStyle.Bold), fırca, 130, 143);
                grafic.DrawString(TxtTcKimlikNo.Text, new Font("Palatino Linotype", 8, FontStyle.Bold), fırca, 64, 167);
                grafic.DrawString(TxtSoyad.Text, yazı, fırca, 64, 188);
                grafic.DrawString(TxtAdı.Text, yazı, fırca, 64, 210);
                grafic.DrawString(TxtBabaAdı.Text, yazı, fırca, 64, 234);
                grafic.DrawString(TxtAnaAdı.Text, yazı, fırca, 64, 253);
                grafic.DrawString(CmbxDogumYeri.Text, yazı, fırca, 20, 281);
                grafic.DrawString(TxtDogumTarihi.Text, yazı, fırca, 125, 281);
                grafic.DrawString(CmbxMedeniHali.Text, yazı, fırca, 260, 22);
                grafic.DrawString(CmbxDin.Text, yazı, fırca, 320, 22);
                grafic.DrawString(CmbxKan.Text, yazı, fırca, 390, 22);
                grafic.DrawString(Cmbxİl.Text, yazı, fırca, 257, 48);
                grafic.DrawString(Txtİlce.Text, yazı, fırca, 355, 48);
                grafic.DrawString(TxtMahalle.Text, yazı, fırca, 260, 74);
                grafic.DrawString(TxtCiltNo.Text, yazı, fırca, 261, 99);
                grafic.DrawString(TxtAileSıraNo.Text, yazı, fırca, 325, 99);
                grafic.DrawString(TxtSıraNo.Text, yazı, fırca, 392, 99);
                grafic.DrawString(TxtVerildigiyer.Text, yazı, fırca, 257, 125);
                grafic.DrawString(TxtVerilisiNedeni.Text, yazı, fırca, 355, 125);
                grafic.DrawString(TxtKayıtNo.Text, yazı, fırca, 257, 149);
                grafic.DrawString(TxtVerilisTarih.Text, yazı, fırca, 355, 149);
                grafic.DrawString(TxtVerenKisi.Text + "\n     V.H.K.İ", yazı, fırca, 270, 190);
                grafic.DrawString(TxtMudur.Text + "\n   Nüfus Müdürü a.\n    NÜFUS ŞEFİ", yazı, fırca, 320, 210);
                if (vbm != null)
                {
                    grafic.DrawImage(vbm, 134, 39);
                }
                bm.Save(kaydet.FileName, ImageFormat.Jpeg);
                MessageBox.Show("Kimlik kaydedildi.", "Kimlik Oluşturucu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BtnÇıkış_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
