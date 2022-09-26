using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.OleDb;
using System.Data;

namespace DatabaseLayer
{
    public class CezaIslemleri
    {
        //veritabanı bağlantısı için databaseconnection sınıfından bir nesne oluşturuyoruz
        DatabaseConnection Bgln = new DatabaseConnection();
        //CezaIslemleri classında kullanmak için bağlantı adında bir Oledb bağlantı değişkeni oluşturdum
        OleDbConnection Baglanti;
        //bu class içerisinde kullanmak için oledb komutlarını yazabildiğim bir nesne türettim
        OleDbCommand Komut = new OleDbCommand();
        //ceza ekleme fonksiyonumuz
        public string CezaEkleme(CezaBilgileri Ceza)
        {
            //veritabanı işlemleri yapılmadan önce denememiz gerekiyor bir hata ile karşılaşmamak için
            try
            {
                //bağlantı nesnesini databaseconnection'daki bağlantı adresimize yönlendiriyoruz
                Baglanti = Bgln.BaglantiGonder();
                //database bağlantısını açıyoruz
                Baglanti.Open();
                //fonksiyon içerisinde kullanmak için lond türünde ogrenci numarası değişkeni tanımladım
                long OgrenciNumarasi;
                //Oduncharaketleri tablosundan öğrencinumarasını çekiyorum.Çünkü fonksiyon içerisinde bunu kullanacağım
                OleDbCommand komut2 = new OleDbCommand("Select OgrenciNumarasi From OduncHaraketleri where oduncid="+Ceza.oduncid, Baglanti);
                //yazdığım komut2 yi veritabanında execute ediyorum
                OleDbDataReader OgrenciNoOku = komut2.ExecuteReader();
                //execute işlemini satır satır okumak için while döngüsü açıyorum
                while (OgrenciNoOku.Read())
                {
                    //okunan ogrencinumarasını daha önce tanımladığım ogrencinumarası değişkenine atıyorum
                    OgrenciNumarasi = Convert.ToInt64(OgrenciNoOku["OgrenciNumarasi"]);
                    //fonksiyon ile gönderilen ceza nesnesinin ogrenci numarasını buradan aldığım değere göre atıyorum
                    Ceza.OgrenciNumarasi = OgrenciNumarasi;
                }
                //ogrenci numarası okuması bittikten sonra okuma işlemini kapatıyorum
                OgrenciNoOku.Close();
                //classın başında tanımladığım komut nesnesinin bağlantı adresinin Databaseconnection dan gelen bağlantı olduğunu söylüyorum
                Komut.Connection = Baglanti;
                //cezabilgileri tablosuna ekleme işlemini yapacağım sql sorgu metnimi komut nesnesinin commandtext öğresine atıyorum
                Komut.CommandText = "INSERT INTO CezaBilgileri(oduncid,OgrenciNumarasi,gecikmesuresi,cezamiktari) VALUES(@p1,@p2,@p3,@p4)";
                //sql sorgumun içerisinde bulunan parametrelerimizin ne olduğunu söylüyorum
                Komut.Parameters.AddWithValue("@p1", Ceza.oduncid);
                Komut.Parameters.AddWithValue("@p2", Ceza.OgrenciNumarasi);
                Komut.Parameters.AddWithValue("@p3", Ceza.gecikmesuresi);
                Komut.Parameters.AddWithValue("@p4", Ceza.cezamiktari);
                //yazdığım cezabilgileri ekleme sql sorgumu çalıştırıyorum
                Komut.ExecuteNonQuery();
                //bağlantıyı herhangi bir sorunla karşılaşmamak için kapatıyorum
                Baglanti.Close();
                //işlem başarılı bir şekilde gerçekleşirse geriye string değerinde başarılı olduğunu döndürüyorum
                return "Ceza İşlemi Başarılı";
            }
            //eğer bağlantı esnasında ya da sql sorgu sırasında bir hata ile karşılaşılırsa bu blok çalışacak
            catch (Exception e)
            {
                //aldığımız hatayı string türüne çevirip kullanıcı ekranında göstermek için geri gönderiyoruz
                string hata = e.ToString();
                //geri gönderdik
                return hata;
            }
        }
        
        //ceza bilgileri listele
        public DataTable CezaListele()
        {
            Baglanti = Bgln.BaglantiGonder();
            OleDbDataAdapter komut = new OleDbDataAdapter("Select OgrenciAdi,OgrenciSoyadi,OgrenciTelefon,OgrenciMail,gecikmesuresi,cezamiktari from CezaBilgileri INNER JOIN Ogrenciler ON CezaBilgileri.OgrenciNumarasi = Ogrenciler.OgrenciNumarasi", Baglanti);
            //bağlantı açılıyor
            Baglanti.Open();
            //database üzerinden çektiğimiz bilgileri DataTable'a doldurma işlemi
            DataTable tablo = new DataTable();
            komut.Fill(tablo);
            //bağlantı kapatıldı
            Baglanti.Close();
            return tablo;
        }
    }
}
