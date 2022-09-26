using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KutuphaneOtomasyo;
using KutuphaneOtomasyon.Ogrenci;
using KutuphaneOtomasyon.OduncIslemler;
using DatabaseLayer;
using System.Data.OleDb;

namespace KutuphaneOtomasyon.Ceza
{
    public partial class CezaAnasayfa : Form
    {
        CezaIslemleri Islem = new CezaIslemleri();
        public CezaAnasayfa()
        {
            InitializeComponent();
        }
        //form üzerinde çarpı işaretine basıldığında direk tüm uygulamayı kapatmasını sağlıyoruz
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //anasayfaya gitmek için kullandığımız buton
        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            //anasayfa form nesnesi oluşturuluyor
            AnaSayfa anaSayfa = new AnaSayfa();
            //oluşturduğumuz nesneyi görüntüle
            anaSayfa.Show();
            //bulunduğumuz formu kapat
            this.Close();
        }
        //kitapişlemlerini görüntüleyeceğimiz buton işlemi
        private void button2_Click(object sender, EventArgs e)
        {
            //kitapişlemleri nesnesi oluşturluyor burada kitapişlemlerinin iki kez yazılmasının nedeni
            //proje içerisinde daha önceden oluşturduğum dosya isimlerini daha sonradan değiştirdiğim için
            //kod olarak değiştiremedim bu şekilde kalmasına neden oldu
            KitapIslemleri.KitapIslemleri kitapIslemleri = new KitapIslemleri.KitapIslemleri();
            //oluşturduğumuz nesneyi görüntülüyoruz
            kitapIslemleri.Show();
            //bulunduğumuz form kapatılıyor
            this.Close();
        }

        //öğrenci işlemlerinin görüntülemek için kullandığımız buton fonksiyonu
        private void btn_ogrEkle_Click(object sender, EventArgs e)
        {
            OgrenciIslemleri Ogrenci = new OgrenciIslemleri();
            Ogrenci.Show();
            this.Close();
        }
        //ödünç işlemleri görüntüleme
        private void button3_Click(object sender, EventArgs e)
        {
            OduncAlma odunc = new OduncAlma();
            odunc.Show();
            this.Close();
        }
        //bu form yüklenirken çalışmasını istediğimiz fonksiyon
        private void CezaAnasayfa_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Islem.CezaListele();
        }
    }
}
