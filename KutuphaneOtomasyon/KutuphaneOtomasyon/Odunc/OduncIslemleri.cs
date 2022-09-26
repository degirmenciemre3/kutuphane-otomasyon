using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KutuphaneOtomasyon.Kitap;
using KutuphaneOtomasyon.Ogrenci;
using KutuphaneOtomasyon.Odunc;
using KutuphaneOtomasyon.Ceza;
using KutuphaneOtomasyo;
using DatabaseLayer;
using System.Data.OleDb;

namespace KutuphaneOtomasyon.OduncIslemler
{
    public partial class OduncAlma : Form
    {
        //formu haraket ettirmemize yardımcı olacak değişkenlerimiz
        int Movee;
        int Mouse_X;
        int Mouse_Y;
        OleDbConnection Baglanti;
        public OduncAlma()
        {
            InitializeComponent();
        }
        //öğrenci işlemlerine giden buttonumuz
        private void btn_ogrEkle_Click(object sender, EventArgs e)
        {
            OgrenciIslemleri ogrenciIslemleri = new OgrenciIslemleri();
            ogrenciIslemleri.Show();
            this.Close();
        }
        //kitap işlemlerine giden butonumuz
        private void button2_Click(object sender, EventArgs e)
        {
            KitapIslemleri.KitapIslemleri kitapIslemleri = new KitapIslemleri.KitapIslemleri();
            kitapIslemleri.Show();
            this.Close();
        }
        //ana sayfaya giden butonumuz
        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            AnaSayfa anaSayfa = new AnaSayfa();
            anaSayfa.Show();
            this.Close();
        }
        //formu haraket etirmek için gerekli fonksiyonumuz, fare haraket ettiği sürece çalışıcak
        private void OduncAlma_MouseMove(object sender, MouseEventArgs e)
        {
            //movee değeri 1 e eşit olduğu sürece farenin konumunu formun konumuna eşitliyoruz bu sayade formumu haraket ediyor
            if (Movee == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
        //farenin tuşuna basıldığında koordinatlarını alıp movee değerini 1 e eşitliyoruz
        private void OduncAlma_MouseDown(object sender, MouseEventArgs e)
        {
            Movee = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
        //farenin tuşuna basmayı bıraktığımızda movee değerini 0 a eşitliyoruz ve haraket durmuş oluyor
        private void OduncAlma_MouseUp(object sender, MouseEventArgs e)
        {
            Movee = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        //ödünç verme işlemleri için button fonksiyonumuz
        private void button4_Click(object sender, EventArgs e)
        {
            OduncVer oduncver = new OduncVer();
            oduncver.Show();
            this.Close();
        }
        //uygulamayı kapat
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //ödünç kitapları geri alacağımız button fonksiyonumuz
        private void button5_Click(object sender, EventArgs e)
        {
            OduncGeriAl Gerial = new OduncGeriAl();
            Gerial.Show();
            this.Close();
        }
        //bu form yüklendiği esnada ekranda görüntülenecek verilerin fonksiyonu
        private void OduncAlma_Load(object sender, EventArgs e)
        {
            //databaselayer katmanından bir  bgln öğesi oluşturuluyor
            DatabaseConnection bgln = new DatabaseConnection();
            //oluşturulan bgln nesnesinin bağlantı gönder fonksiyonu ile birlikte bağlantı adresimizi çekiyoruz
            Baglanti = bgln.BaglantiGonder();
            //ödünç işlemleri, kitaplar ve öğrenciler tablolarını inner join ile bağlayan bir sorgu yazıyoruz
            OleDbDataAdapter komut = new OleDbDataAdapter("Select oduncid,kitapad,OgrenciAdi,OgrenciSoyadi,OgrenciTelefon,aldigitarih,verdigitarih,durum From ((OduncHaraketleri INNER JOIN Kitaplar ON OduncHaraketleri.kitapid = Kitaplar.kitapid) INNER JOIN Ogrenciler ON OduncHaraketleri.OgrenciNumarasi = Ogrenciler.OgrenciNumarasi)", Baglanti);
            //bağlantı açılıyor
            Baglanti.Open();
            try
            {
                //yapılan sorguları datagridview de listelemek için datatable oluşturuyoruz
                DataTable tablo = new DataTable();
                //oluşturulan tabloyu veritabanından gelen verilerle dolduruyoruz
                komut.Fill(tablo);
                dataGridView1.DataSource = tablo;
                //ödünç işlemlerinin tarhilendirmesine göre renklendirmesini yaptığımız renklendirme fonksiyonunu çağırıyoruz
                renklendirme();
            }
            catch (Exception hata)
            {
                //hata alırsak ekrana yansıtıyoruz
                MessageBox.Show(hata.ToString());

            }
            Baglanti.Close();
        }

        //datagridview renklendirme fonksiyonumuz
        public void renklendirme()
        {
            //tüm satırları dönen bir for döngüsü
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //eğer teslim edildi mi alanı true ise direk bulunan satırı yeşil yap diyorum
                //çünkü teslim edilen kitaplar yeşil olmasını istiyoruz
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[7].Value) == true)
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                }
                else
                {
                    //teslim alınan tarih üstünden 15 gün geçtiyse ve hala teslim edilmediyse bulunan satırı kırmızı yapıyoruz
                    if (Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value).AddDays(15) < DateTime.Today)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                    }
                    //teslim alınan tarih üstünden 13 gün geçtiyse teslim tarihine yaklaştığı için sarı şekilde gösterilecek
                    //burada karşılaştırma yaparken teslim alınan tarihe 15 gün ekleyip bugünden 2 gün sonraki tarih ile karşılaştırıyorum
                    //2 gün sonra 15 gün olacağı anlamına geliyor
                    else if (Convert.ToDateTime(dataGridView1.Rows[i].Cells[5].Value).AddDays(15) < DateTime.Today.AddDays(2))
                    {

                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    //yukarıdaki hiçbir koşulu sağlamıyorsa yani kritik bir durum yoksa teslim tarihine daha varsa yeşil olarak listelenmesini istiyoruz
                    else
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                    }
                }
                //datagridview in birkaç renklendirilmesini burada yapıyorum arka plan renkleri ve seçili satırın renklenmesi gibi detaylar
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dataGridView1.EnableHeadersVisualStyles = false;

            }
        }
        //cezabilgileri formunun gösterileceği buton fonksiyonumuz
        private void button6_Click(object sender, EventArgs e)
        {
            CezaAnasayfa Ceza = new CezaAnasayfa();
            Ceza.Show();
            this.Close();
        }
    }
}
