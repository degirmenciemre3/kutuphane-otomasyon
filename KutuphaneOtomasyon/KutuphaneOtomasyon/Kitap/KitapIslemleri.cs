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
using KutuphaneOtomasyo;
using System.Data.OleDb;
using KutuphaneOtomasyon.Kitap;
using KutuphaneOtomasyon.Ogrenci;
using KutuphaneOtomasyon.OduncIslemler;
using KutuphaneOtomasyon.Ceza;

namespace KutuphaneOtomasyon.KitapIslemleri
{
    public partial class KitapIslemleri : Form
    {
        //formun haraket etmesi için gerekli değişkenlerimiz
        int Movee;
        int Mouse_X;
        int Mouse_Y;
        KitapIslemler Islem = new KitapIslemler();
        public KitapIslemleri()
        {
            InitializeComponent();
        }
        //uygulamayı kapatmak için kullandığımız buton fonksiyonu
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //anasayfaya dönecek butonun fonksiyonu
        private void btn_anasayfa_Click(object sender, EventArgs e)
        {
            AnaSayfa ana = new AnaSayfa();
            ana.Show();
            this.Close();
        }
        //kitap ekleme formunu görüntülemek için oluşturulan fonksiyon
        private void btn_kitapekle_Click(object sender, EventArgs e)
        {
            KitapEkle ekle = new KitapEkle();
            ekle.Show();
        }
        //formun haraketi için gerekli fonksiyon
        //kullanıcı farenin tuşuna basmayı bırakırsa movee değeri 0 a eşitlenecek
        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            Movee = 0;
        }
        //farenin tuşu basılı ise movee değişkeni 1 e eşitlenecek ve farenin masaüstü konumu değişkenler içerisinde tutulacak
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            Movee = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
        //fare haraket halindeyken
        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            //eğer moveee değeri 1 ise farenin pozisyonu formun koordinatlarına eşitlenerek haraket ettiriliyor
            if (Movee == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
        //ogrenci işlemleri için oluşturulan fonksiyon
        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciIslemleri OgrenciAnaSayfa = new OgrenciIslemleri();
            OgrenciAnaSayfa.Show();
            this.Close();
        }
        //kitap sil formu için
        private void button3_Click(object sender, EventArgs e)
        {
            KitapSil kitapSil = new KitapSil();
            kitapSil.Show();
            this.Close();
        }
        //kitap güncelleme formu için
        private void button4_Click(object sender, EventArgs e)
        {
            KitapGuncelle kitapGuncelle = new KitapGuncelle();
            kitapGuncelle.Show();
            this.Close();
        }
        //ödünç alma formu için
        private void button5_Click(object sender, EventArgs e)
        {
            OduncAlma oduncAlma = new OduncAlma();
            oduncAlma.Show();
            this.Close();
        }
        //bu form yüklenirken çalışan fonksiyon
        private void KitapIslemleri_Load(object sender, EventArgs e)
        {
            //databaseconnection sınıfındaki bağlantı adresini almak için kullandığımız yapı
            DatabaseConnection Bgln = new DatabaseConnection();
            OleDbConnection Baglanti = Bgln.BaglantiGonder();
            //tüm kitapları listele
            dataGridView1.DataSource = Islem.KitapListele();
            //renklendirme işlemleri
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Blue;
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
            dataGridView1.EnableHeadersVisualStyles = false;
        }
        //datagridview üzerindeki satırlara tıklandığı zaman çalışacak
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //eğer tıklanan değer boş bir değer değilse çalışsın
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dataGridView1.CurrentRow.Selected = true;
                //tıklama yapılan satırdaki kitapid yi int türünde kitapid ye eşitliyoruz
                int kitapid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["kitapid"].FormattedValue);
                //aldığımız kitapid yi kitapdetaylar formuna gönderiyoruz ve kitabın detaylarını orada listeliyoruz
                KitapDetaylar Detay = new KitapDetaylar(kitapid);
                //detay formu görüntüleniyor
                Detay.Show();
                //bulunduğumuz form kapatılıyor
                this.Close();

            }
        }
        //ceza bilgileri formunu açmak için çalıştırılan button fonksiyonu
        private void button6_Click(object sender, EventArgs e)
        {
            CezaAnasayfa Ceza = new CezaAnasayfa();
            Ceza.Show();
            this.Close();
        }
    }
}
