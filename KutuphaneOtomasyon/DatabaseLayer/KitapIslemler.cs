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
    public class KitapIslemler
    {
        //databaseconnection sınıfından bir nesne türetiyoruz
        DatabaseConnection Bgln = new DatabaseConnection();
        //bu sınıfta kullanmak için bir bağlantı değişkeni tanımlıyoruz
        OleDbConnection Baglanti;
        //bu sınıfta kullanmak için bir komu nesnesi türetiyoruz
        OleDbCommand Komut = new OleDbCommand();
        
        //kitap silme fonksiyonumuz ve silinecek id yi parametre olarak alıyor
        public string KitapSil(int id)
        {
            //herhangi bir sorunla karşılaşmamak için try bloğuna başvuruyoruz
            try
            {
                //sınıfın içinde bulunan bağlantı değişkenimize databaseconnectiondaki bağlantı adresinin atamasını gerçekleştirdik
                Baglanti = Bgln.BaglantiGonder();
                //bağlantı açıldı
                Baglanti.Open();
                //komut değişkeninin bağlantı noktasının bağlantı değişkeni olduğunu belirtiyoruz
                Komut.Connection = Baglanti; 
                //yapılacak sql işleminin string halini yazıyoruz kitapid sine göre silme yapacağız
                Komut.CommandText = "delete from Kitaplar where kitapid=" + id + "";
                //yazdığımız sql sorgusunu execute ediyoruz
                Komut.ExecuteNonQuery();
                //hata almamak için bağlantıyı kapatıyoruz
                Baglanti.Close();
                //kullanıcıyı bilgilendirmek için geriye bir mesaj bilgisi gönderiyoruz
                return "Kitap Silme İslemi Basarılı";
            }
            //bir hata ile karşılaşırsak çalışacak blok
            catch (Exception hata)
            {
                //hatayı string türüne dönüştürüp geri gönderiyoruz
                return hata.ToString();
            }
            
        }

        //kitap ekleme fonksiyonumuz eklenecek kitabın bilgilerini entitylayer katmanında oluşturduğumuz
        //kitaplar nesnesi üzerinde işlem yapacağız o yüzden bu fonksiyonumuz parametre olarak kitaplar nesnesini içermekte
        public string KitapEkle(Kitaplar kitap)
        {
            //herhangi bir sorunla karşılaşmamak için try bloğuna başvuruyoruz
            try
            {
                //bağlantı nesnesine databaseconnection sınıfından bağlantı adresinin atamasını gerçekleştiriyoruz
                Baglanti = Bgln.BaglantiGonder();
                //bağlantı açıldı
                Baglanti.Open();
                //komut nesnesinin bağlantı adresinin ne olacağını belirtiyoruz
                Komut.Connection = Baglanti;
                //yapacağımız sql işlemini komut nesnesinin commant textine atamasını gerçekleştiriyoruz
                Komut.CommandText = "INSERT INTO Kitaplar(turid,kitapad,yazarid,sayfasayisi,isbn,rafid,yayinevi) VALUES(@p1,@p2,@p3,@p4,@p5,@p7,@p8)";
                //textin içerisinde bulunan parametrelerin ne olduğunu belirtiyoruz
                Komut.Parameters.AddWithValue("@p1", kitap.turid);
                Komut.Parameters.AddWithValue("@p2", kitap.kitapad);
                Komut.Parameters.AddWithValue("@p3", kitap.yazarid);
                Komut.Parameters.AddWithValue("@p4", kitap.sayfasayisi);
                Komut.Parameters.AddWithValue("@p5", kitap.isbn);
                Komut.Parameters.AddWithValue("@p7", kitap.rafid);
                Komut.Parameters.AddWithValue("@p8", kitap.yayinevi);
                //database üzerinde sql sorgumuzu çalıştırıyoruz
                Komut.ExecuteNonQuery();
                //bağlantı kapatıldı
                Baglanti.Close();
                //kullanıcıyı bilgilendirmek için geriye bir mesaj gönderildi
                return "Başarılı";
            }
            //hata alırsak çalışacak blok
            catch (Exception e)
            {
                //alınan hatayı stringe çevirip geri gönderiyoruz
                string hata = e.ToString();
                return hata;
            }
        }

        //kitap güncelleme fonksiyonumuz güncellencek kitabı kitaplar sınıfından oluşturulan kitap nesnesi
        //ile bize gönderiliyor
        public String KitapGuncelle(Kitaplar kitap)
        {
            //hata ile karşılaşmamak adına try bloğu kullanıyoruz
            try
            {
                //databaseconnection sınıfından bağlantı adresi alınıyor
                Baglanti = Bgln.BaglantiGonder();
                //yapılacak sql sorgusunu string olarak belirttim
                string sorgu = "Update Kitaplar SET turid= @p1,kitapad= @p2,yazarid= @p3, sayfasayisi= @p4, isbn= @p5,rafid= @p6,yayinevi= @p7 where kitapid= @p8";
                //belirtilen sorgunun komut üzerine gönderiliyor ve hangi bağlantı adresini kullanması gerektiği yazılır
                OleDbCommand komut = new OleDbCommand(sorgu, Baglanti);
                //sorgu içerisinde kullanılan parametrelerin neye eşit olduğunu yazıyoruz
                komut.Parameters.AddWithValue("@p1", kitap.turid);
                komut.Parameters.AddWithValue("@p2", kitap.kitapad);
                komut.Parameters.AddWithValue("@p3", kitap.yazarid);
                komut.Parameters.AddWithValue("@p4", kitap.sayfasayisi);
                komut.Parameters.AddWithValue("@p5", kitap.isbn);
                komut.Parameters.AddWithValue("@p6", kitap.rafid);
                komut.Parameters.AddWithValue("@p7", kitap.yayinevi);
                komut.Parameters.AddWithValue("@p8", kitap.kitapid);
                //bağlantı açılıyor
                Baglanti.Open();
                //database üzerinde sql işlemi yapılıyor
                komut.ExecuteNonQuery();
                //bağlantı kapatılıyor
                Baglanti.Close();
                //kullanıcı bilgilendiriliyor
               return "Bilgiler Güncellendi";
            }
            //hata ile karşılaşırsak çalışacak blok
            catch (Exception hata)
            {
                //kullanıcı hata mesajı ile bilgilendiriliyor
                return hata.ToString();
            }
        }

        //kitapları listele
        public DataTable KitapListele()
        {
            Baglanti = Bgln.BaglantiGonder();
            //kitapları bulunduğu raflara yazarların isimlerine ve türlerin adlarına göre listelemek istiyoruz
            //bunun için 3 tabloyu inner join ile birleştiriyoruz
            OleDbDataAdapter komut = new OleDbDataAdapter("Select kitapid,isbn,kitapad,yazaradi,yazarsoyadi,turad,rafadi,bulundugukat,yayinevi From (((Kitaplar INNER JOIN Yazarlar ON Kitaplar.yazarid = Yazarlar.yazarid) INNER JOIN Tur ON Kitaplar.turid = Tur.turid) INNER JOIN Raflar ON Kitaplar.rafid = Raflar.Rafid)", Baglanti);
            Baglanti.Open();
            //getirilen verilerin datagridview de listelenme işlemi
            DataTable tablo = new DataTable();
            komut.Fill(tablo);
            Baglanti.Close();
            return tablo;
        }

        //isbn koduna göre listele
        public DataTable IsbnGoreListele(string isbn)
        {
            Baglanti = Bgln.BaglantiGonder();
            //kitap isbn koduna göre listeliyoruz fakat textbox da isbn barkodunun ilk 3 hanesi girilmiş olsa bile ona benzer sonuçların
            //listelenmesini istediğimiz için sql tarafında like ifadesini kullandım
            OleDbDataAdapter komut = new OleDbDataAdapter("Select kitapid,isbn,kitapad,yazaradi,yazarsoyadi,turad,rafadi,bulundugukat,yayinevi From (((Kitaplar INNER JOIN Yazarlar ON Kitaplar.yazarid = Yazarlar.yazarid) INNER JOIN Tur ON Kitaplar.turid = Tur.turid) INNER JOIN Raflar ON Kitaplar.rafid = Raflar.Rafid) Where isbn LIKE '" + isbn + "%'", Baglanti);
            Baglanti.Open();
            //veritabanından çekilen verilerin datatable'a aktarılması
            DataTable tablo = new DataTable();
            komut.Fill(tablo);
            Baglanti.Close();
            return tablo;
        }

        //ödünç verilmeyen kitapları listele
        public DataTable OduncVerilmeyenler()
        {
            Baglanti = Bgln.BaglantiGonder();
            //sql üzerinden silinebilecek kitapları listelemek için oluşturduğumuz sorgu. Burada ödünç verilen kitaplar listelenmiyor
            OleDbDataAdapter komut = new OleDbDataAdapter("Select kitapid,isbn,kitapad,yazaradi,yazarsoyadi,turad,rafadi,bulundugukat,yayinevi From (((Kitaplar INNER JOIN Yazarlar ON Kitaplar.yazarid = Yazarlar.yazarid) INNER JOIN Tur ON Kitaplar.turid = Tur.turid) INNER JOIN Raflar ON Kitaplar.rafid = Raflar.Rafid) where rafadi <> 'Ödünç Verildi'", Baglanti);
            Baglanti.Open();
            //alınan database verileri datagridview üzerinde listeleniyor
            DataTable tablo = new DataTable();
            komut.Fill(tablo);
            Baglanti.Close();
            return tablo;
        }

        //isbn koduna göre ödünç verilmeyen kitapları listele
        public DataTable IsbnGoreOduncVerilmeyenler(string isbn)
        {
            Baglanti = Bgln.BaglantiGonder();
            //textboxın içerisine yazılan her bir metinsel ifade ile isbn değerine göre listeleme yapılmaktadır
            //burada sql komutu olarak LIKE ifadesini kullandım çünkü kullanıcı isbn barkodunun yarısını bile girse ona göre listelemesi istiyorum
            OleDbDataAdapter komut = new OleDbDataAdapter("Select kitapid,isbn,kitapad,yazaradi,yazarsoyadi,turad,rafadi,bulundugukat,yayinevi From (((Kitaplar INNER JOIN Yazarlar ON Kitaplar.yazarid = Yazarlar.yazarid) INNER JOIN Tur ON Kitaplar.turid = Tur.turid) INNER JOIN Raflar ON Kitaplar.rafid = Raflar.Rafid) Where isbn LIKE '" + isbn + "%' AND (rafadi <> 'Ödünç Verildi')", Baglanti);
            Baglanti.Open();
            //verileri datagridview de listeliyorum
            DataTable tablo = new DataTable();
            komut.Fill(tablo);
            Baglanti.Close();
            return tablo;
        }
    }
}
