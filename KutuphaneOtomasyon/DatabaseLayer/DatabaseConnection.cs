using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace DatabaseLayer
{
    public class DatabaseConnection
    {
        //Program çalışmaya başladığı anda çalışan Program.cs classından Application.StartupPath yani programın başlatıldığı
        //path uzantısını pathAl fonksiyonu ile alıyoruz
        public static string AppPath;
        public void pathAl(string path)
        {
            AppPath = path;
        }
        //aldığımız AppPath ile access veritabanımıza bağlantı cümlemizi string değişkenine atıyoruz.
        //iki farklı baglantı yolu kullanmamın nedeni biri setup için geçerli yol diğeri sln dosyası için geçerli.

        //sln dosyası için bağlantı adresi.
        String BaglantiAdresi = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+ AppPath + "\\..\\..\\..\\Veritabanı\\KutuphaneDatabase.accdb";

        //setup için bağlantı adresi.
        //String BaglantiAdresi = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + AppPath + "\\Veritabanı\\KutuphaneDatabase.accdb";

        //baglantımızı diğer classlar içerisinde kullanmak için baglantıgonder fonksiyonunu kullanıyoruz
        //diğer classlar tarafından bu fonksiyon çağırıldığı zaman oluşturduğumuz veritabanı bağlantımızı çağırılan yere gönderiyoruz.
        public OleDbConnection BaglantiGonder()
        {
            OleDbConnection Baglanti = new OleDbConnection(BaglantiAdresi);
            return Baglanti;
        }
    }
}
