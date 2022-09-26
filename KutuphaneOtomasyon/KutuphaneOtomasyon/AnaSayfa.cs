using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KutuphaneOtomasyon.KitapIslemleri;
using KutuphaneOtomasyon.Ogrenci;
using KutuphaneOtomasyon.OduncIslemler;
using KutuphaneOtomasyon.Ceza;
using DatabaseLayer;
using System.Data.OleDb;
using ZedGraph;

namespace KutuphaneOtomasyo
{
    public partial class AnaSayfa : Form
    {
        //formun haraket ettirilmesi için gerekli değerler
        int Movee;
        int Mouse_X;
        int Mouse_Y;
        public AnaSayfa()
        {
            InitializeComponent();
            //ana sayfanın alt kısmında bugünün tarihini ve saati gösteriyoruz
            lbl_Gun.Text = DateTime.Now.ToLongDateString();
            lbl_saat.Text = DateTime.Now.ToLongTimeString();
        }

        private void lbl_Gun_Click(object sender, EventArgs e)
        {

        }
        //her saniyede 1 çalışan timer saatimizi güncelliyor
        private void timer1_Tick(object sender, EventArgs e)
        {
            lbl_Gun.Text = DateTime.Now.ToLongDateString();
            lbl_saat.Text = DateTime.Now.ToLongTimeString();
        }

        //uygulamayı kapat
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //kitap işlemleri aç
        private void button2_Click(object sender, EventArgs e)
        {
            KitapIslemleri kitap = new KitapIslemleri();
            kitap.Show();
            this.Close();
        }
        //form haraket ettirmeyi bıraktığımızda movee değeri 0 a eşitleniyor
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Movee = 0;
        }
        //form haraket ettirilmeye başlandığında movee değeri 1 yapılıp farenin koordinatları alınıyor
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Movee = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        //form haraket ettiğinde
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //movee değeri 1 ise
            if (Movee == 1)
            {
                //farenin koordinatlarını formun koordinatlarına eşitle
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
        //öğrenci işlemleri ana sayfasına gönderir
        private void btn_ogrEkle_Click(object sender, EventArgs e)
        {
            OgrenciIslemleri OgrenciAnaSayfa = new OgrenciIslemleri();
            OgrenciAnaSayfa.Show();
            this.Close();
        }
        //ödünç alma işlemleri sayfasına gönderir
        private void button3_Click(object sender, EventArgs e)
        {
            OduncAlma oduncAlma = new OduncAlma();
            oduncAlma.Show();
            this.Close();
        }
        //ceza işlemleri sayfasına gönderir
        private void button4_Click(object sender, EventArgs e)
        {
            CezaAnasayfa Ceza = new CezaAnasayfa();
            Ceza.Show();
            this.Close();
        }

        //ana sayfa yüklenirken
        private void AnaSayfa_Load(object sender, EventArgs e)
        {
            //bağlantı işlemleri
            DatabaseConnection Bgln = new DatabaseConnection();
            OleDbConnection Baglanti = Bgln.BaglantiGonder();
            //rafid si 21 olan kitaplar ödünç verilmiş kitaplarımızdı rafid si 21 den küçük olan diğer kitaplar verilmeye hazır
            //olan kitaplarımız oluyor bunların sayısını aldığımız sql sorgusu
            OleDbCommand komut = new OleDbCommand("Select COUNT(kitapid) FROM Kitaplar WHERE rafid < 21", Baglanti);
            Baglanti.Open();
            //verilmeye hazır kitaplar değerine sorgudan gelen değeri atıyoruz
            int verilmeyehazirkitaplar = Convert.ToInt32(komut.ExecuteScalar());
            Baglanti.Close();

            //ödünç verilen kitaplarımızın rafid si 21 idi rafid si 21 olan kitapların sayısını sql sorgusu ile çekiyoruz
            OleDbCommand komut2 = new OleDbCommand("Select COUNT(kitapid) FROM Kitaplar WHERE rafid=21", Baglanti);
            Baglanti.Open();
            //çekilen değeri odünç kitaplar değişkenine atıyoruz
            int odunckitaplar = Convert.ToInt32(komut2.ExecuteScalar());
            Baglanti.Close();

            //tüm kitapların sayısını çekiyoruz
            OleDbCommand komut3 = new OleDbCommand("Select COUNT(kitapid) FROM Kitaplar", Baglanti);
            Baglanti.Open();
            //tüm kitap sayısını tüm kitaplar değişkenine atıyoruz
            int tumkitaplar = Convert.ToInt32(komut3.ExecuteScalar());
            Baglanti.Close();

            //graphpane nesnesi üretip zedgraph ın graphpane değerine eşitliyoruz
            GraphPane myPane = zedGraphControl1.GraphPane;
            //grafikte görüntülenecek satırlarımızı dizi halında yazıyoruz
            string[] satir = { "Tüm Kitaplar", "Verilmeye Hazır Kitaplar", "Verilen Kitaplar" };
            double[] kitaplar = { tumkitaplar, verilmeyehazirkitaplar, odunckitaplar };
            //x, y ve zedgraph başlığı bilgileri
            myPane.Title.Text = "Kütüphane Bilgileri";
            myPane.XAxis.Title.Text = "Kitaplar";
            myPane.YAxis.Title.Text = "Kitap Sayısı";
            //grafiğin üst kısmında görünecek bilgilendirme alanı
            myPane.AddPieSlices(kitaplar, new[] { "Tüm Kitaplar : " + tumkitaplar, "Verilmeye Hazır Kitaplar : " + verilmeyehazirkitaplar, "Verilen Kitaplar : " + odunckitaplar, null });
            myPane.Legend.IsVisible = true;
            //bir  grafik eğrisi oluşturuyoruz renklerini belirtiyoruz
            LineItem myLine = myPane.AddCurve(null, null, kitaplar, Color.Aqua);
            //eğrinin renklendirmesi yapılıyor
            myLine.Line.Fill = new Fill(Color.DarkViolet,Color.White,Color.Violet);
            //grafiğin alt kısmında yazılacakları belirtiyoruz yani satır dizisindekileri
            myPane.XAxis.Scale.TextLabels = satir;
            myPane.XAxis.Type = AxisType.Text;
            //grafiğin renklendirmesi yapılıyor
            myPane.Chart.Fill = new Fill(Color.White, Color.FromArgb(255, 255, 166), 90F);
            myPane.Fill = new Fill(Color.FromArgb(250, 250, 255));
            //değişiklikleri zedgraph da yansıtıyoruz
            zedGraphControl1.AxisChange();
        }
    }
}
