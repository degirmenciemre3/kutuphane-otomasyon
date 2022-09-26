using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using EntityLayer;
using System.Data;

namespace DatabaseLayer
{
    public class OgrencilerDatabaseIslemleri
    {
        //databaseconnection sınıfında bulunan database bağlantı adresini bu sınıfta kullanmak için databaseconnection sınıfından bir nesne oluşturuluyor
        DatabaseConnection Bgln = new DatabaseConnection();
        //sınıf içerisinde kullanmak için bağlantı nesnesi tanımlanıyor
        OleDbConnection Baglanti;
        //sınıf içerisinde kullanmak için komut nesnesi tanımlanıyor
        OleDbCommand Komut = new OleDbCommand();

        //öğrenci silme fonksiyonu parametre olarak silinecek öğrencinin numarasını alıyor
        public string OgrenciSil(long OgrenciNumarasi)
        {
            //hata ile karşılaşırsak diye try bloğu
            try
            {
                //bağlantı adresi tanımlaması
                Baglanti = Bgln.BaglantiGonder();
                //bağlantı açılıyor
                Baglanti.Open();
                //komut değişkenin kullanmasını istediğimiz bağlantı adresini belirtiyoruz
                Komut.Connection = Baglanti;
                //sql komutumuzu yazıyoruz burada silmek istediğimiz öğrenciyi numarasına göre silme işlemi sql kodu olarak yazıldı
                Komut.CommandText = "delete from Ogrenciler where OgrenciNumarasi=" + OgrenciNumarasi + "";
                //sql komutu database ortamında çalıştırıldı
                Komut.ExecuteNonQuery();
                //bağlantı kapatıldı
                Baglanti.Close();
                //kullanıcı silme işlemi sonrasında başarılı şeklinde bilgilendirildi
                return "Ogrenci Silme İslemi Başarılı";
            }
            //hata ile karşılaşılırsa çalışacak blok
            catch (Exception hata)
            {
                //hatayı kullanıcıye geri gönderiyoruz
                return hata.ToString();
            }
        }

        //öğrenci ekleme fonksiyonumuz parametre olarak öğrenciler nesnesini alıyor eklenecek öğrenci bilgileri bu nesne,
        //üzerinden elimize ulaşıyor
        public string OgrenciEkle(Ogrenciler ogrenciler)
        {
            //denem bloğumuz
            try
            {
                //bağlantı adresleri ataması
                Baglanti = Bgln.BaglantiGonder();
                //bağlantı açıldı
                Baglanti.Open();
                //kout değişkeninin hangi bğalantıyı kullanması gerektiğini belirtiyoruz
                Komut.Connection = Baglanti;
                //ekleme işlemini database ortamında yapacak kodumuzun texti
                Komut.CommandText = "INSERT INTO Ogrenciler(OgrenciNumarasi,OgrenciAdi,OgrenciSoyadi,OgrenciBolum,OgrenciSinif,OgrenciMail,OgrenciTelefon) VALUES(@p1,@p2,@p3,@p4,@p5,@p7,@p8)";
                //fonksiyona gönderilen ogrenci nesnesindeki bilgileri parametre olarak komut texin içerisine atıyoruz
                Komut.Parameters.AddWithValue("@p1", ogrenciler.OgrenciNumarasi);
                Komut.Parameters.AddWithValue("@p2", ogrenciler.OgrenciAdi);
                Komut.Parameters.AddWithValue("@p3", ogrenciler.OgrenciSoyadi);
                Komut.Parameters.AddWithValue("@p4", ogrenciler.OgrenciBolum);
                Komut.Parameters.AddWithValue("@p5", ogrenciler.OgrenciSinif);
                Komut.Parameters.AddWithValue("@p7", ogrenciler.OgrenciMail);
                Komut.Parameters.AddWithValue("@p8", ogrenciler.OgrenciTelefon);
                //yazdığımız komutu database ortamında çalıştırıyoruz
                Komut.ExecuteNonQuery();
                //bağlantıyı kapatıyoruz
                Baglanti.Close();
                //kullanıcıyı bilgilendiriyoruz
                return "Ogrenci Ekleme İşlemi Başarılı";
            }
            //hata ile karşılaşırsak
            catch (Exception e)
            {
                //hatayı kullanıcıya gönderiyoruz
                string hata = e.ToString();
                return hata;
            }
        }
        //öğrenci güncelleme fonksiyonu
        //güncellenecek öğrenci bilgileri öğrenciler sınıfından türetilen öğrenciler nesnesi içerisinden
        //bu fonksiyona parametre olarak gönderiliyor
        public string OgrenciGuncelle(Ogrenciler ogrenciler)
        {
            //deneme bloğumuz
            try
            {
                //bağlantı adresinin atanması
                Baglanti = Bgln.BaglantiGonder();
                //güncelleme yapacağımız öğrencinin numarasına göre güncellenecek bilgileri belirtiyoruz
                string sorgu = "Update Ogrenciler SET OgrenciAdi= @p1,OgrenciSoyadi= @p2,OgrenciBolum= @p3, OgrenciSinif= @p4, OgrenciMail= @p5,OgrenciTelefon= @p6 where OgrenciNumarasi= @p7";
                OleDbCommand Komut = new OleDbCommand(sorgu, Baglanti);
                Komut.Parameters.AddWithValue("@p1", ogrenciler.OgrenciAdi);
                Komut.Parameters.AddWithValue("@p2", ogrenciler.OgrenciSoyadi);
                Komut.Parameters.AddWithValue("@p3", ogrenciler.OgrenciBolum);
                Komut.Parameters.AddWithValue("@p4", ogrenciler.OgrenciSinif);
                Komut.Parameters.AddWithValue("@p5", ogrenciler.OgrenciMail);
                Komut.Parameters.AddWithValue("@p6", ogrenciler.OgrenciTelefon);
                Komut.Parameters.AddWithValue("@p7", ogrenciler.OgrenciNumarasi);
                //bağlantı açılıyor
                Baglanti.Open();
                //komut database ortamında execute ediliyor
                Komut.ExecuteNonQuery();
                //bağlantı kapatılıyor
                Baglanti.Close();
                //kullanıcı bilgilendirilmek için geriye bir string ifade gönderiyoruz
                return "Bilgiler Güncellendi";
            }
            //hata bloğu
            catch (Exception hata)
            {
                //karşılaşılan hatayı kullanıcıya gönderir
                return hata.ToString();
            }
        }

        //öğrenci numarasına göre listele
        public DataTable OgrNoGoreListele(string ogrencino)
        {
            Baglanti = Bgln.BaglantiGonder();
            OleDbDataAdapter komut = new OleDbDataAdapter("Select * from Ogrenciler where OgrenciNumarasi LIKE '" + ogrencino + "%'", Baglanti);
            Baglanti.Open();
            DataTable tablo = new DataTable();
            komut.Fill(tablo);
            Baglanti.Close();
            return tablo;
        }

        //tüm öğrencileri listele
        public DataTable ogrencilistele()
        {
            Baglanti = Bgln.BaglantiGonder();
            //tüm öğrencileri veritabanından çek
            OleDbDataAdapter komut = new OleDbDataAdapter("Select * from Ogrenciler", Baglanti);
            Baglanti.Open();
            //çekilen verileri datatable değişkeni olan tabloya aktar
            DataTable tablo = new DataTable();
            komut.Fill(tablo);
            Baglanti.Close();
            //tabloyu kullanacağımız yere geri gönder
            return tablo;
        }
    }
}
