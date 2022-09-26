using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DatabaseLayer;
using System.Data.OleDb;

namespace KutuphaneOtomasyon.Kitap
{
    public partial class KitapDetaylar : Form
    {
        //detayları listelenecek kitabın id sini bu form çağırılırken gönderilmesi gerekiyor
        int kitapid;
        //bu form çağırılırken gönderilen ID değişkeni
        public KitapDetaylar(int ID)
        {
            InitializeComponent();
            //gönderilen ID değişkenini bu form içinde kullanabilmek için kitapid değişkenine atamasını yapıyoruz
            kitapid = ID;
        }

        //bu form yüklenirken çalışacak fonksiyon
        private void KitapDetaylar_Load(object sender, EventArgs e)
        {
            //database connection sınıfından database bağlantı cümlesini almak için oluşturduğumuz yapı
            DatabaseConnection Bgln = new DatabaseConnection();
            OleDbConnection Baglanti = Bgln.BaglantiGonder();
            //kitabın detaylarını database üzerinden çekebilmemize yarayan sql kodu bu kodta birden fazla tabloyu listelemek için inner join komutu kullanılmıştır
            OleDbDataAdapter komut = new OleDbDataAdapter("Select kitapid,OgrenciAdi,OgrenciSoyadi,OgrenciTelefon,aldigitarih,verdigitarih From OduncHaraketleri INNER JOIN Ogrenciler ON OduncHaraketleri.OgrenciNumarasi = Ogrenciler.OgrenciNumarasi where kitapid="+ kitapid, Baglanti);
            Baglanti.Open();
            //deneme bloğu
            try
            {
                //databaseden çekilen verilerin datagridviewde listelenmesi işlemi
                DataTable tablo = new DataTable();
                komut.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception hata)
            {
                //bir hata ile karşılaşırsak kullanıcı bilgilendirilecek
                MessageBox.Show(hata.ToString());
            }
            Baglanti.Close();
        }

        //çarpı işaretine basıldığı zaman uygulamanın kapatılmasını sağlayan buton fonksiyonu
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //kitaplar ana sayfasına geri dönmek için oluşturulan buton fonksiyonu
        private void button3_Click(object sender, EventArgs e)
        {
            KitapIslemleri.KitapIslemleri KitapAna = new KitapIslemleri.KitapIslemleri();
            KitapAna.Show();
            this.Close();
        }
    }
}
