using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using KutuphaneOtomasyo;
using EntityLayer;
using DatabaseLayer;

namespace KutuphaneOtomasyon.Kitap
{
    public partial class KitapEkle : Form
    {
        //bu formun haraket ettirilmesi için gerekli değişkenler
        //bu form haraket ettirilmiyor çünkü bu formun özelliklerini none yaptığım için formun kenarlıkları görünmüyor
        int Movee;
        int Mouse_X;
        int Mouse_Y;
        //database bağlanmak için kullancağımız değişken
        OleDbConnection Baglan;
        public KitapEkle()
        {
            InitializeComponent();
        }
        //bu form yüklenirken çalışacak fonksiyon
        private void KitapEkle_Load(object sender, EventArgs e)
        {
            //databaseconnection sınıfından bağlantı adresi alınıyor
            DatabaseConnection Bgln = new DatabaseConnection();
            Baglan = Bgln.BaglantiGonder();
            Baglan.Open();
            //türler tablosundaki tüm bilgiler çekiliyor
            OleDbCommand komut = new OleDbCommand("Select *from Tur", Baglan);
            OleDbDataReader turoku = komut.ExecuteReader();
            //çekilen tüm tür bilgileri satır satır okuma işlemi yapılıyor
            while (turoku.Read())
            {
                //alınan tür bilgilerini bir string üzerinde tutuyoruz
                string turad = turoku["turad"].ToString();
                //aldığımız tür bilgilerini combobox içerisne ekliyoruz
                cmb_tur.Items.Add(turad);
            }
            //okuma işlemi kapatılıyor
            turoku.Close();

            //yazarlar bilgilerinin tümü veritabanından çekiliyor
            OleDbCommand komut2 = new OleDbCommand("Select *from Yazarlar", Baglan);
            OleDbDataReader yazaroku = komut2.ExecuteReader();
            while (yazaroku.Read())
            {
                //alınan yazarlar bilgileri teker teker combobox a ekleniyor
                string yazaradi = yazaroku["yazaradi"].ToString();
                string yazarsoyadi = yazaroku["yazarsoyadi"].ToString();
                cmb_yazar.Items.Add(yazaradi + " " + yazarsoyadi);
            }
            //okuma işlemi kapatılıyor
            yazaroku.Close();
            //raflar bilgisi veritabanından çekiliyor
            OleDbCommand komut3 = new OleDbCommand("Select *from Raflar", Baglan);
            OleDbDataReader rafoku = komut3.ExecuteReader();
            while (rafoku.Read())
            {
                //raf bilgileri combobox a ekleniyor
                string rafadi = rafoku["rafadi"].ToString();
                string bulundugukat = rafoku["bulundugukat"].ToString();
                cmb_raf.Items.Add(rafadi + " " + bulundugukat);
            }
            //okuma işlemi kapatılıyor
            rafoku.Close();
            //açılan bağlantı kapatıldı
            Baglan.Close();
        }
        //bu forumu kapatmak için kullanılan buton
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //geri dönme işlemi de bu forumu kapatılarak gerçekleştilir
        private void btn_geridon_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //kitap ekleme butonu fonksiyonu
        private void btn_kitap_ekle_Click(object sender, EventArgs e)
        {
            //eğer textboxlar ve comboboxlardan herhangi biri boş ise ekrana hata mesajı veriyoruz
            if (txt_isbn.Text == "" || txt_kitapad.Text == "" || txt_sayfasayisi.Text == "" || txt_yayinevi.Text == "" || cmb_raf.Text == "" || cmb_tur.Text == "" || cmb_yazar.Text == "")
            {
                MessageBox.Show("Lütfen Alanları Boş Bırakmadığınızdan Emin Olunuz");
            }
            else
            {
                //tüm alanlar dolu ise kitaplar nesnesinden bir yenikitap nesnesi türetiliyor
                //ekleyeceğimiz kitabın bilgilerini bu nesne üzerinden aktaracağız
                Kitaplar YeniKitap = new Kitaplar();
                //textboxdaki ve comboboxdaki bilgileri teker teker oluşturduğumuz kitap nesnesinin bilgilerine atamasını yapıyoruz
                YeniKitap.kitapad = txt_kitapad.Text;
                YeniKitap.isbn = Convert.ToInt32(txt_isbn.Text.ToString());
                YeniKitap.rafid = Convert.ToInt32(cmb_raf.SelectedIndex) + 1;
                YeniKitap.sayfasayisi = Convert.ToInt32(txt_sayfasayisi.Text);
                YeniKitap.yayinevi = txt_yayinevi.Text;
                YeniKitap.yazarid = Convert.ToInt32(cmb_yazar.SelectedIndex) + 1;
                YeniKitap.turid = Convert.ToInt32(cmb_tur.SelectedIndex) + 1;
                //kitap işlemler sınıfından ekle nesnesi türetiliyor
                KitapIslemler Ekle = new KitapIslemler();
                //ekle nesnesinin kitapekle fonksiyonuna oluşturduğumuz kitap nesnesini gönderiyoruz
                //daha sonrasinda bir hata ile karşılaşırsak ya da başarılı olursa işlem bize bilgilendirme mesajı göndereceği için
                //bu mesajı string türüne atıyoruz daha sonra bu mesajı messagebox üzerinden kullanıcıya gösteriyoruz
                string mesaj = Ekle.KitapEkle(YeniKitap);
                MessageBox.Show(mesaj);
                //ekleme işlemi gerçekleştikten sonra daha sonraki eklemeler için 
            }
        }

        //forumun haraket edebilmesi için oluşturduğum fonksiyon
        //eğer kullanıcı mouse tuşuna basmayı bırakırsa movee değişkenini 0 a eşitliyoruz
        private void KitapEkle_MouseUp(object sender, MouseEventArgs e)
        {
            Movee = 0;
        }
        //kullanıcı faresini haraket ettirdiği sürece çalışacak fonksiyon
        private void KitapEkle_MouseMove(object sender, MouseEventArgs e)
        {
            //eğer movee hala 1 işe farenin masaüstündeki konumunu alıp formun konumuna eşitliyoruz
            if (Movee == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
        //kullanıcı farenin tuşuna bastığında movee değişkenini 1 eşitliyoruz ve farenin konumunu alıyoruz
        private void KitapEkle_MouseDown(object sender, MouseEventArgs e)
        {
            Movee = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        
    }
}
