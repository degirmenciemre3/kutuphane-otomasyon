using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer;
using DatabaseLayer;

namespace KutuphaneOtomasyon.Ogrenci
{
    public partial class OgrenciEkle : Form
    {
        //formun haraketi için gerekli değerler
        int Movee;
        int Mouse_X;
        int Mouse_Y;
        public OgrenciEkle()
        {
            InitializeComponent();
            //form açılırken comboboxların içerisinin sınıf isimleri ile dolmasını sağlıyoruz
            //burada kendimiz sınıf isimlerini verdik fakat
            //burada eklenmeyen bir sınıf daha olursa kullanıcı tarafından el ile girilebilir.
            cmb_sinif.Items.Add("Hazırlık");
            cmb_sinif.Items.Add("1. Sınıf");
            cmb_sinif.Items.Add("2. Sınıf");
            cmb_sinif.Items.Add("3. Sınıf");
            cmb_sinif.Items.Add("4. Sınıf");
            cmb_sinif.Items.Add("Yüksek Lisans");
        }

        //formu kapat
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //ekle butonu
        private void btn_kitap_ekle_Click(object sender, EventArgs e)
        {
            //eğer girilmeyen bir değer varsa ekrana bir mesaj ver
            if (txt_ogrencinumarasi.Text == "" || txt_Ogrenciadi.Text == "" || txt_ogrenciSoyadi.Text == "" || txt_ogrenciBolum.Text == "" || cmb_sinif.Text == "" || txt_ogrenciMail.Text == "" || txt_ogrenciTelefon.Text == "")
            {
                MessageBox.Show("Lütfen Alanları Boş Bırakmadığınızdan Emin Olunuz");
            }
            //tüm bilgiler dolu ise
            else
            {
                //yeni öğrenci adında bir nesne türet
                Ogrenciler YeniOgrenci = new Ogrenciler();
                //ve girilen bilgileri bu nesnenin içerisine ata
                YeniOgrenci.OgrenciAdi = txt_Ogrenciadi.Text;
                YeniOgrenci.OgrenciSoyadi = txt_ogrenciSoyadi.Text;
                YeniOgrenci.OgrenciTelefon = txt_ogrenciTelefon.Text;
                YeniOgrenci.OgrenciBolum = txt_ogrenciBolum.Text;
                YeniOgrenci.OgrenciSinif = cmb_sinif.Text;
                YeniOgrenci.OgrenciMail = txt_ogrenciMail.Text;
                YeniOgrenci.OgrenciNumarasi = Convert.ToInt64(txt_ogrencinumarasi.Text);
                //ekleme işlemini yapacağımız ogrenciekle nesnesini oluşturuyoruz
                OgrencilerDatabaseIslemleri OgrenciEkle = new OgrencilerDatabaseIslemleri();
                //işlemin sonucunda eğer bir hata çıkarsa bunu görüntülemek için sonuç değerine atama yapıyoruz
                string sonuc = OgrenciEkle.OgrenciEkle(YeniOgrenci);
                //ekrana sonuç değerini gösteriyoruz hata mesajı ya da onay mesajı verecektir
                MessageBox.Show(sonuc);
                //tüm işlemler bittikden sonra tüm textboxların içerisini boşaltıyoruz
                txt_ogrencinumarasi.Text = "";
                txt_Ogrenciadi.Text = "";
                txt_ogrenciSoyadi.Text = "";
                txt_ogrenciBolum.Text = "";
                cmb_sinif.Text = "";
                txt_ogrenciMail.Text = "";
                txt_ogrenciTelefon.Text = "";
            }
        }

        //formun haraket ettirilmesi için
        //farenin tuşuna basmayı bırakırsak movee değerini 0 a eşitle
        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            Movee = 0;
        }

        //fare haraket ettiği sürece
        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            //eğer moveee 1 e eşitse
            if (Movee == 1)
            {
                //farenin koordinatları formun kordinatlarına eşitlenir
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
        //fare tuşuna basıldığında
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            //movee değeri 1 olur ve farenin koordinatları alınır
            Movee = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }

        private void OgrenciEkle_Load(object sender, EventArgs e)
        {

        }
    }
}
