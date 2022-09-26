using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using System.Data.OleDb;

namespace DatabaseLayer
{
    public class OduncDatabaseIslemleri
    {
        //sınıf içerisinde kullanılacak database bağlantı değişkeni
        OleDbConnection Baglanti;
        //databaseconnection sınıfından türettiğimiz Bgln nesnesi
        DatabaseConnection Bgln = new DatabaseConnection();
        //sınıf içerisinde kullanmak ve sql komutlarını belirttiğimiz komut nesnesi
        OleDbCommand Komut = new OleDbCommand();

        //ödünç vermek için kullandığımız fonksiyon ve bu fonksiyon oduncharaketleri sınıfından odunc nesnesini parametre olarak alıyor
        public string OduncVer(OduncHaraketleri Odunc)
        {
            //bir hata ile karşılaşmamak için kullandığımız try bloğu
            try
            {
                //bağlantı adresinin databaseconnection sınıfındaki adres olduğunu belirtiyoruz
                Baglanti = Bgln.BaglantiGonder();
                //bağlantı açılıyor
                Baglanti.Open();
                //komut parametresinin bağlantı adresi olarak bağlantı nesnesini bullanmasını belirtiyoruz
                Komut.Connection = Baglanti;
                //sql üzerinde çalıştırmak istediğimiz sql kodumuzu komut değişkeninin commandtextine atıyoruz
                Komut.CommandText = "INSERT INTO OduncHaraketleri(kitapid,OgrenciNumarasi,aldigitarih) VALUES(@p2,@p3,@p4)";
                //sql komut textimizin içinde bulunan parametrelerin neye eşit olduğunu belirtiyoruz
                Komut.Parameters.AddWithValue("@p2", Odunc.kitapid);
                Komut.Parameters.AddWithValue("@p3", Odunc.OgrenciNumarasi);
                Komut.Parameters.AddWithValue("@p4", Odunc.aldigitarih);
                //yazdığımız sql kodun database ortamında execute edilmesini istiyoruz
                Komut.ExecuteNonQuery();
                //bağlantıyı kapatıyoruz
                Baglanti.Close();
                //başka bir hata ile karşılaşmamak için kullandığımız try bloğu
                try
                {
                    //ödünç verdiğimiz kitabın rafid sini 21 e eşitliyoruz çünkü
                    //raflar tablomuzda 21 id koduna eşit gelen text şudur "Ödünç Verildi" bunu kitap üzerinde belirtmek için kitabın
                    //rafid sini değiştiriyoruz bu sayede kullanıcı bu kitabın ödünç verildiğini ekranında görebilecek
                    string sorgu = "Update Kitaplar SET rafid= @p1 where kitapid= @p2";
                    //yazdığımız sorguyu komut değişkenine atıyoruz
                    OleDbCommand komut = new OleDbCommand(sorgu, Baglanti);
                    //rafid sini 21 yapıyoruz 
                    komut.Parameters.AddWithValue("@p1", 21);
                    //hangi kitabın rafid sini değiştirmek istediğimizi belirtiyoruz
                    komut.Parameters.AddWithValue("@p2", Odunc.kitapid);
                    //bağlantı açılıyor
                    Baglanti.Open();
                    //komut işlemi database üzerinde execute ediliyor
                    komut.ExecuteNonQuery();
                    //bağlantı kapatıldı
                    Baglanti.Close();
                    //kullanıcı bilgilendirmek için bir mesaj geri döndürüldü
                    return "Başarılı";
                }
                //hata ile karşılaşırsak çalışacak blok
                catch (Exception hata)
                {
                    //karşılaşılan hatanın ne olduğunu kullanıcı ekranına gönderiyoruz
                    return hata.ToString();
                }
                
            }
            //daha önceki yaptığımız işlemde hata alırsak diye
            catch (Exception e)
            {
                //aldığımız hatayı kullanıcı ekranına gönderiyoruz
                return e.ToString();
            }
        }
        
        //verdiğimiz odunç kitabı geri almak için kullandığımız fonksiyonumuz
        //bu fonksiyon oduncharaketleri sınıfından bir nesne ve int türünde bir rafid değişkenini parametre olarak alır
        public string OduncGeriAl(OduncHaraketleri Odunc, int rafid)
        {
            //bir hata ile karşılaşmamak için kullandığımız try bloğu
            try
            {
                //databaseconnection sınıfından bağlantı adresimizi alıyoruz ve Bağlantı değişkenine atıyoruz 
                Baglanti = Bgln.BaglantiGonder();
                //bağlantı açılıyor
                Baglanti.Open();
                //geri alacağımız kitabın idsini bulmak için bu değişkenini kullanacağız
                int Kitapid;
                //fonksiyonla birlikte bize gönderilen odunc sınıfındaki oduncid değerine göre oduncharaketleri tablosundan verileri çekiyoruz
                OleDbCommand komut2 = new OleDbCommand("Select * From OduncHaraketleri where oduncid=" + Odunc.oduncid, Baglanti);
                
                OleDbDataReader KitapNoOku = komut2.ExecuteReader();
                //yazdığımız sql kodu satır satır oku
                while (KitapNoOku.Read())
                {
                    //okunan kitapid yi belirttiğimiz int türündeki kitapid ye ataması gerçekleşiyor
                    Kitapid = Convert.ToInt32(KitapNoOku["kitapid"]);
                    //aldığımız kitapid yi fonksiyonla bize gönderilen odunc nesnesinin kitapid parametresine ataması gerçekleşiyor
                    Odunc.kitapid = Kitapid;
                }
                //kitap okuma işlemi kapatılıyor
                KitapNoOku.Close();
                //bağlantı kapatıldı
                Baglanti.Close();

                //daha sonra oduncharaketlerindeki bilgileri güncelliyoruz
                string sorgu = "Update OduncHaraketleri SET verdigitarih= @p1,durum=@p2 where oduncid= @p3";
                OleDbCommand komut3 = new OleDbCommand(sorgu, Baglanti);
                //fonksiyonla bize gönderilen bilgileri parametre olarak sql sorgu cümleciğine atıyoruz
                komut3.Parameters.AddWithValue("@p1", Odunc.verdigitarih);
                komut3.Parameters.AddWithValue("@p2", true);
                komut3.Parameters.AddWithValue("@p3", Odunc.oduncid);
                //bağlantı açılıyor
                Baglanti.Open();
                //komut işlemi database üzerinde execute ediliyor
                komut3.ExecuteNonQuery();
                //bağlantı kapatıldı
                Baglanti.Close();
                //başka bir deneme bloğu açıyoruz
                try
                {
                    //odunc geri alınacak kitabın güncelleştirme işlemi yapılıyor
                    string sorgu2 = "Update Kitaplar SET rafid= @p1 where kitapid= @p2";
                    OleDbCommand komut = new OleDbCommand(sorgu2, Baglanti);
                    //odunc alınırken yerleştirilmek istenen rafın id sini fonksiyonla birlikte almıştık
                    //aldığımız rafid yi aldığımız kitabın rafid sini güncelliyoruz
                    komut.Parameters.AddWithValue("@p1", rafid);
                    komut.Parameters.AddWithValue("@p2", Odunc.kitapid);
                    //bağlantı açılıyor
                    Baglanti.Open();
                    //database ortamında sql işlemi execute ediliyor
                    komut.ExecuteNonQuery();
                    //bağlantı kapatılıyor
                    Baglanti.Close();
                    //kullanıcı bilgilendirmesi için geriye bir bilgilendirme mesajı gönderiliyor
                    return "Kitap Alındı";
                }
                //hata ile karşılaşırsak
                catch (Exception hata)
                {
                    //kullanıcı hata mesajı ile bilgilendiriliyor
                    return hata.ToString();
                }
            }
            //kullanıcı hata mesajı ile bilgilendirmek için 
            catch (Exception hata)
            {
                return hata.ToString();
            }
        }
    }
}
