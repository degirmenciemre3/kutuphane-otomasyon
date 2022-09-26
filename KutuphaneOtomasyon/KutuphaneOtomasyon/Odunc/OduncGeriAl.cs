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

namespace KutuphaneOtomasyon.Odunc
{
    public partial class OduncGeriAl : Form
    {
        OleDbConnection Baglanti;
        public OduncGeriAl()
        {
            InitializeComponent();
        }
        //uygulamayı kapatmak için kullandığım fonksiyon
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //geri dön butonuna basıldığında çalışacak fonksiyon ve açılacak form
        private void button3_Click(object sender, EventArgs e)
        {
            OduncIslemler.OduncAlma geridon = new OduncIslemler.OduncAlma();
            geridon.Show();
            this.Close();
        }
        //bu form yüklenirken çalışacak fonksiyon
        private void OduncGeriAl_Load(object sender, EventArgs e)
        {
            //database connection sınıfındaki baglantı adresini aldığımız yapı
            DatabaseConnection bgln = new DatabaseConnection();
            Baglanti = bgln.BaglantiGonder();
            //ödünç verilen kitapların listelenmesi için gerekli sql sorgumuz durumu burada false yani teslim edilmemiş olanlar listeleniyor sadece
            OleDbDataAdapter komut = new OleDbDataAdapter("Select oduncid,kitapad,OgrenciAdi,OgrenciSoyadi,OgrenciTelefon,aldigitarih,durum From ((OduncHaraketleri INNER JOIN Kitaplar ON OduncHaraketleri.kitapid = Kitaplar.kitapid) INNER JOIN Ogrenciler ON OduncHaraketleri.OgrenciNumarasi = Ogrenciler.OgrenciNumarasi) where durum = false", Baglanti);
            //geri alınacak kitabın yeni bir rafa yerleştirilmesi gerekmektedir bunun için kütüphanede bulunan rafları comboboxin içerisine ekliyoruz
            OleDbCommand komut3 = new OleDbCommand("Select *from Raflar", Baglanti);
            Baglanti.Open();
            OleDbDataReader rafoku = komut3.ExecuteReader();
            try
            {
                DataTable tablo = new DataTable();
                komut.Fill(tablo);
                dataGridView1.DataSource = tablo;

                while (rafoku.Read())
                {
                    string rafadi = rafoku["rafadi"].ToString();
                    string bulundugukat = rafoku["bulundugukat"].ToString();
                    cmb_raf.Items.Add(rafadi + " " + bulundugukat);
                }
                rafoku.Close();
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());

            }
            Baglanti.Close();
        }

        //geri alınacak kitabın üzerine tıklandığında çalışcak fonksiyon
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //tıklanan satırdaki aldığı tarih değişkenini ilk önce bir tarihsel değişkene atamasını yapıyoruz
            DateTime aldigitarih = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells["aldigitarih"].FormattedValue);
            //eğer kullanıcı yerleştirilecek rafı girmezse ekrana bir hata mesajı verilerek uyarılacak
            if (cmb_raf.Text == "")
            {
                MessageBox.Show("Lütfen Geri Alınan Kitabın Yerleşecek Rafını Seçin");
            }
            else
            {
                //eğer geri alınacak kitabın alındığı tarihin üzerinden 15 gün geçtiyse bir ceza işlemi uygulanması lazım
                if (aldigitarih.AddDays(15) < DateTime.Today)
                {
                    //bunun için geçen her bir günün hesabını tarihsel olarak hesaplanması yapılmıştır
                    int fazlagun = Convert.ToInt32((DateTime.Today - aldigitarih.AddDays(15)).TotalDays);
                    //kullanıcı bu ceza hakkında bilgilendirilme yapılıyor "Bu tutarı ödemek istiyor musunuz" şeklinde
                    DialogResult Cevap = MessageBox.Show("Tutar ="+fazlagun+" Onaylıyor Musunuz ?","Cezai İşlem Uygulanacaktır",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
                    //eğer kullanıcı ödemek isterse evet butonuna basılacak ve bu fonksiyon çalışacak
                    if (Cevap == DialogResult.Yes)
                    {
                        //eğer tıklanan satırda bir değer yoksa çalışmayacak
                        if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                        {
                            //tıklanan satırdaki ödünçid değeri bir değişkene atanıyor
                            dataGridView1.CurrentRow.Selected = true;
                            int oduncid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["oduncid"].FormattedValue);
                            //cezabilgileri entity katmanından bir sınıf oluşturuluyor işlemler bu sınıf üzerinden yapılacak
                            CezaBilgileri Ceza = new CezaBilgileri();
                            //cezaişlemlerinin kayıt edilmesi için database katmanından bir nesne türetiliyor
                            CezaIslemleri CezaEkle = new CezaIslemleri();
                            //satırdaki bilgileri oluşturduğumuz nesnenin değişkenlerine atamasını yapıyoruz
                            Ceza.oduncid = oduncid;
                            Ceza.gecikmesuresi = fazlagun;
                            Ceza.cezamiktari = fazlagun;
                            //ceza ekleme fonksiyonunu çağırıyoruz ve ekrana bilgilendirme mesajı veriyoruz
                            MessageBox.Show(CezaEkle.CezaEkleme(Ceza));

                            //geri aldığımızı belirtmek için ödünç haraketleri tablosunda bir güncelleme yapmamız gerekecek
                            OduncHaraketleri odunc = new OduncHaraketleri();
                            OduncDatabaseIslemleri OduncGeriAl = new OduncDatabaseIslemleri();
                            //geri aldığımız tarihi odunç nesnesi bilgilerine atamasını yapıyoruz
                            //geri aldığımız tarih bugün olduğu için bugünün tarihini acceess de kullandığım formata dönüştürüp atama işlemini yapıyorum
                            odunc.verdigitarih = Convert.ToDateTime(DateTime.Now.ToString("d"));
                            odunc.oduncid = oduncid;
                            odunc.aldigitarih = aldigitarih;
                            //seçilen rafid si ni alıyorum
                            //burada comboboxın indexi 0 indisinden başladığı ve benim veritabanımda 1 den başladığı için +1 ekleme işlemi yapıyorum
                            int rafid = Convert.ToInt32(cmb_raf.SelectedIndex) + 1;
                            //ödünç geri alma işlemi yapılıyor ve kullanıcı bilgilendiriliyor
                            MessageBox.Show(OduncGeriAl.OduncGeriAl(odunc, rafid));
                            //ödünç alma işlemi bittikten sonra odunçişlemlerinin olduğu ana sayfaya yönlendiriyoruz
                            OduncIslemler.OduncAlma OduncAnaSayfa = new OduncIslemler.OduncAlma();
                            OduncAnaSayfa.Show();
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Yanlış Satır Seçildi");
                        }
                    }
                }
                else
                {
                    //eğer geri alınacak kitabın bir ceza tutarı yoksa direk geri alma işlemi gerçekleştiriliyor
                    //yukardaki adımlarla aynı işlem uygulanmıştır.
                    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                    {
                        dataGridView1.CurrentRow.Selected = true;
                        int oduncid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["oduncid"].FormattedValue);
                        OduncHaraketleri odunc = new OduncHaraketleri();
                        OduncDatabaseIslemleri OduncGeriAl = new OduncDatabaseIslemleri();
                        odunc.verdigitarih = Convert.ToDateTime(DateTime.Now.ToString("d"));
                        odunc.oduncid = oduncid;
                        odunc.aldigitarih = aldigitarih;
                        int rafid = Convert.ToInt32(cmb_raf.SelectedIndex) + 1;
                        MessageBox.Show(OduncGeriAl.OduncGeriAl(odunc, rafid));
                        OduncIslemler.OduncAlma OduncAnaSayfa = new OduncIslemler.OduncAlma();
                        OduncAnaSayfa.Show();
                        this.Close();
                    }
                }
                
            }
            
        }
        //kitabı ödünç alan kişinin numarasına göre arama işlemi yapmak için kullandığım fonksiyon
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //database üzerinde arama yaparken LIKE komutunu kullanıyorum çünkü kullanıcı tarafından öğrenci numarasının bir kısmı girildiğinde bile arama işlemini ona göre yapmasını istiyorum
            OleDbDataAdapter komut = new OleDbDataAdapter("Select oduncid,kitapid,kitapad,OgrenciNumarasi,OgrenciAdi,aldigitarih from OduncHaraketleri where OgrenciNumarasi LIKE '" + textBox1.Text + "%'", Baglanti);
            Baglanti.Open();
            try
            {
                DataTable tablo = new DataTable();
                komut.Fill(tablo);
                dataGridView1.DataSource = tablo;
            }
            catch (Exception hata)
            {
                MessageBox.Show(hata.ToString());

            }
            Baglanti.Close();
        }
    }
}
