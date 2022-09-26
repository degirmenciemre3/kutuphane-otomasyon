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
using EntityLayer;

namespace KutuphaneOtomasyon.Ogrenci
{
    public partial class OgrenciGuncelle : Form
    {
        OleDbConnection Baglanti;
        OgrencilerDatabaseIslemleri Islem = new OgrencilerDatabaseIslemleri();
        public OgrenciGuncelle()
        {
            InitializeComponent(); 
        }

        //form yüklenirken çalışacak fonksiyon
        private void OgrenciGuncelle_Load(object sender, EventArgs e)
        {
            //bağlantı işlemleri
            DatabaseConnection Bgln = new DatabaseConnection();
            Baglanti = Bgln.BaglantiGonder();
            //datagridview e verileri listele
            dataGridView1.DataSource = Islem.ogrencilistele();
        }

        //öğrenci numarasına göre listelemek için
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textbox boş değilse çalış
            if (textBox1.Text != "")
            {
                //öğrenci numarasına göre listele
                dataGridView1.DataSource = Islem.OgrNoGoreListele(textBox1.Text);
            }
        }
        
        //öğrenci işlemleri ana sayfasına geri dön
        private void button2_Click(object sender, EventArgs e)
        {
            OgrenciIslemleri Geridon = new OgrenciIslemleri();
            Geridon.Show();
            this.Close();
        }

        //listele butonu
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Islem.ogrencilistele();
        }

        //seçilen öğrenci
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //seçilen satır boş değilse
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dataGridView1.CurrentRow.Selected = true;
                //guncellenecek öğrenci Numarasını datagridview'den alıyoruz ve Guncellenecek_Ogrenci değişkenine atıyoruz.
                long Guncellenecek_Ogrenci = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["OgrenciNumarasi"].FormattedValue);
                Baglanti.Open();
                //güncellenecek olan öğrencinin bilgilerini databaseden çekiyoruz.
                OleDbCommand komut = new OleDbCommand("Select * From Ogrenciler where OgrenciNumarasi=" + Guncellenecek_Ogrenci, Baglanti);
                OleDbDataReader Oku = komut.ExecuteReader();
                if (Oku.Read())
                {
                    //çektiğimiz verileri teker teker textboxlara atamasını yapıyoruz
                    txt_OgrenciNumarasi.Text = Oku["OgrenciNumarasi"].ToString();
                    txt_OgrenciAdi.Text = Oku["OgrenciAdi"].ToString();
                    txt_OgrenciSoyadi.Text = Oku["OgrenciSoyadi"].ToString();
                    txt_OgrenciBolumu.Text = Oku["OgrenciBolum"].ToString();
                    txt_OgrenciSinif.Text = Oku["OgrenciSinif"].ToString();
                    txt_OgrenciMaili.Text = Oku["OgrenciMail"].ToString();
                    txt_OgrenciTelefon.Text = Oku["OgrenciTelefon"].ToString();
                }
                Baglanti.Close();
            }
        }

        //güncelle butonu
        private void button5_Click(object sender, EventArgs e)
        {
            //textboxlardan herhangi biri boş ise hata mesajı göster
            if (txt_OgrenciAdi.Text == "" || txt_OgrenciBolumu.Text == "" || txt_OgrenciMaili.Text == "" || txt_OgrenciNumarasi.Text == "" || txt_OgrenciSoyadi.Text == "" || txt_OgrenciSinif.Text == "" ||txt_OgrenciTelefon.Text == "")
            {
                MessageBox.Show("Lütfen Bilgileri Boş Bırakmayınız");
            }
            else
            {
                //kullanıcıya güncellemek isteyip istemediğini soruyoruz
                DialogResult Cevap = MessageBox.Show("Güncellemek İstediğinizden Emin Misiniz?", "Güncelle", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //eğer kullanıcı ekrana çıkan messagebox üzerindeki evet butonuna basarsa güncelleme işlemi gerçekleşecek
                if (Cevap == DialogResult.Yes)
                {
                    //entitylayer katmanından, Ogrenciler nesnesi oluşturuluyor
                    Ogrenciler GuncelleOgrenci = new Ogrenciler();
                    //oluşturulan nesnenin değerlerini textboxdan aldığımız bilgiler ile dolduruyoruz.
                    GuncelleOgrenci.OgrenciNumarasi = Convert.ToInt64(txt_OgrenciNumarasi.Text);
                    GuncelleOgrenci.OgrenciAdi = txt_OgrenciAdi.Text;
                    GuncelleOgrenci.OgrenciSoyadi = txt_OgrenciSoyadi.Text;
                    GuncelleOgrenci.OgrenciBolum = txt_OgrenciBolumu.Text;
                    GuncelleOgrenci.OgrenciSinif = txt_OgrenciSinif.Text;
                    GuncelleOgrenci.OgrenciMail = txt_OgrenciMaili.Text;
                    GuncelleOgrenci.OgrenciTelefon = txt_OgrenciTelefon.Text;
                    //databaselayer katmanından OgrencilerDatabaseIslemleri classından bir nesne türetiyoruz.
                    OgrencilerDatabaseIslemleri Guncelle = new OgrencilerDatabaseIslemleri();
                    //üretilen nesnenin OgrenciGuncelle fonksiyonuna oluşturduğumuz GuncelleOgrenci nesnesini gönderiyoruz
                    //ve böylelikle güncellemek istediğimiz bilgileri nesnemizle beraber göndermiş oluyoruz.
                    //güncelleme yapıldıktan sonra geri dönüş olarak bir string değer geri gönderilecektir bunu da messagebox ile ekrana gösteriyoruz.
                    MessageBox.Show(Guncelle.OgrenciGuncelle(GuncelleOgrenci));
                    //datagridview deki bilgileri güncelle
                    dataGridView1.DataSource = Islem.ogrencilistele();
                }
            }
        }
        
        //uygulamayı kapat
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
