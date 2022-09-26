using KutuphaneOtomasyo;
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
using DatabaseLayer;
using System.Data.OleDb;
using KutuphaneOtomasyon.OduncIslemler;
using KutuphaneOtomasyon.Ceza;


namespace KutuphaneOtomasyon.Ogrenci
{
    public partial class OgrenciIslemleri : Form
    {
        //form haraketleri için gerekli değerlerimiz
        int Movee;
        int Mouse_X;
        int Mouse_Y;
        OleDbConnection Baglanti;
        OgrencilerDatabaseIslemleri Islem = new OgrencilerDatabaseIslemleri();
        public OgrenciIslemleri()
        {
            InitializeComponent();
        }
        //form yüklenirken çalışacak fonksiyon
        private void OgrenciIslemleri_Load(object sender, EventArgs e)
        {
            //bağlantı işlemleri
            DatabaseConnection Bgln = new DatabaseConnection();
            Baglanti = Bgln.BaglantiGonder();
            dataGridView1.DataSource = Islem.ogrencilistele();
        }
        //uygulamayı kapat
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //anasayfaya git
        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            AnaSayfa Home = new AnaSayfa();
            Home.Show();
            this.Close();
        }
        //kitap işlemleri ekranına git
        private void button2_Click(object sender, EventArgs e)
        {
            KitapIslemleri.KitapIslemleri kitap = new KitapIslemleri.KitapIslemleri();
            kitap.Show();
            this.Close();
        }

        //formun haraket ettirmeyi bıraktığımızda movee değerini 0 a eşitliyoruz
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Movee = 0;
        }
        //fare haraket ettiği sürece
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            //eğer movee değeri 1 ise
            if (Movee == 1)
            {
                //farenin koordinatlarını formun koordinatlarına eşitle
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
        //form haraket ettirmeye başlanacağı zaman farenin kordinatları alınır ve movee 1 e eşitlenir
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            Movee = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
        //öğrenci ekleme formu
        private void button3_Click(object sender, EventArgs e)
        {
            OgrenciEkle EkleForm = new OgrenciEkle();
            //ekleme formu ayrı bir pencere olarak açılacak fakat öğrenci işlemleri formu kapatılmayacaktır
            EkleForm.Show();
        }

        //öğrenci sil formu
        private void button4_Click(object sender, EventArgs e)
        {
            OgrenciSil ogrenciSil = new OgrenciSil();
            ogrenciSil.Show();
            this.Close();
        }

        //öğrenci güncelle formu
        private void button5_Click(object sender, EventArgs e)
        {
            OgrenciGuncelle ogrenciGuncelle = new OgrenciGuncelle();
            ogrenciGuncelle.Show();
            this.Close();
        }

        //ödünç işlemleri formu
        private void button6_Click(object sender, EventArgs e)
        {
            OduncAlma oduncAlma = new OduncAlma();
            oduncAlma.Show();
            this.Close();
        }

        //ceza işlemleri formu
        private void button7_Click(object sender, EventArgs e)
        {
            CezaAnasayfa Ceza = new CezaAnasayfa();
            Ceza.Show();
            this.Close();
        }

        
    }
}
