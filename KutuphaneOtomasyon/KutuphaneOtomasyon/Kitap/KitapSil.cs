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
using EntityLayer;
using System.Data.OleDb;
using KutuphaneOtomasyon.KitapIslemleri;

namespace KutuphaneOtomasyon.Kitap
{
    public partial class KitapSil : Form
    {
        //formun haraket etmesi için gerekli değişkenler
        int Movee;
        int Mouse_X;
        int Mouse_Y;
        OleDbConnection Bgln;
        KitapIslemler Islem = new KitapIslemler();
        public KitapSil()
        {
            InitializeComponent();
        }
        //form yüklenmeye başladığında çalışacak fonksiyon
        private void KitapSil_Load(object sender, EventArgs e)
        {
            //databaseconnection sınıfından database bağlantı adresini aldığımız yapı
            DatabaseConnection Baglantı = new DatabaseConnection();
            Bgln = Baglantı.BaglantiGonder();
            //ödünç verilenler dışında kalan tüm kitapları listeliyoruz ödünç verilen kitapların silme işlemini yapamayız
            dataGridView1.DataSource = Islem.OduncVerilmeyenler();
        }
        //uygulamayı kapatmak için çalışan buton fonksiyonu
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //formun haraketlendirilmesi için gerekli fonksiyon
        private void KitapSil_MouseMove(object sender, MouseEventArgs e)
        {
            //eğer fare haraket halinde ise ve movee 1 e eşitse farenin koordinatları formun koordinatlarına atanır
            if (Movee == 1)
            {
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
        //fare tuşuna basıldığında
        private void KitapSil_MouseDown(object sender, MouseEventArgs e)
        {
            //movee değeri 1 e eşitleniyor ve farenin koordinatları alınıyor
            Movee = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
        //tuşa basılmayı bıraktığı zaman
        private void KitapSil_MouseUp(object sender, MouseEventArgs e)
        {
            //movee değerini 0 yapıyoruz ve haraket işlemi bitiyor
            Movee = 0;
        }

        //kitap işlemlerine geri dönmek için oluşturulan form
        private void button3_Click(object sender, EventArgs e)
        {
            KitapIslemleri.KitapIslemleri kitap = new KitapIslemleri.KitapIslemleri();
            kitap.Show();
            this.Close();
        }
        //datagridview üzerinde silinmek istenen kitaba tıklandığında çalışacak fonksiyon
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //tıklanılan satırdaki değerler eğer boş değilse çalışacak
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                //kullanıcıya silmek isteyip istemediğini soruyoruz
                DialogResult Cevap = MessageBox.Show("Silmek İstediğinizden Emin Misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //eğer kullanıcı ekrana çıkan messagebox üzerindeki evet butonuna basarsa silme işlemi gerçekleşecek
                if (Cevap == DialogResult.Yes)
                {
                    //kitapişlemleri databaselayer katmanından bir nesne oluşturuluyor
                    KitapIslemler SilinecekKitap = new KitapIslemler();
                    dataGridView1.CurrentRow.Selected = true;
                    //tıklanılan satırdaki kitapid değerini silinecekid değişkenine ataması gerçekleşiyor
                    int SilinecekId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["kitapid"].FormattedValue);
                    //aldığımız kitapid yi kitapsil fonksiyona gönderiyoruz ve kitabın silme işlemi gerçekleşirse
                    //ekrana bilgilendirme mesajı veriliyor
                    MessageBox.Show(SilinecekKitap.KitapSil(SilinecekId));
                    //silindikten sonra datagridview tekrardan listelenmesi gerekiyor bilgilerin tazeliği için önemli
                    dataGridView1.DataSource = Islem.OduncVerilmeyenler();
                }
            }
        }
        //isbn barkoduna göre arama işlemi yapmak için kullanıdığım fonksiyon
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textboxın içerisine yazılan her bir metinsel ifade ile isbn değerine göre listeleme yapılmaktadır
            //ve tabiki ödünç verdiğimiz kitapları silmek istemediğimiz için onların listelenmesini istemiyorum
            dataGridView1.DataSource = Islem.IsbnGoreOduncVerilmeyenler(textBox1.Text);
        }

        
    }
}
