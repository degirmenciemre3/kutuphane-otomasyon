using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using DatabaseLayer;
using EntityLayer;

namespace KutuphaneOtomasyon.Kitap
{
    public partial class KitapGuncelle : Form
    {
        //form içerisinde kullanmak için database bağlantı değişkenimiz
        OleDbConnection Bgln;
        KitapIslemler Islem = new KitapIslemler();
        public KitapGuncelle()
        {
            InitializeComponent(); 
        }
        //bu form yüklendiğinde çalışacak fonksiyon
        private void KitapGuncelle_Load(object sender, EventArgs e)
        {
            //databaseconnection sınıfından bağlantı adresini alıyoruz
            DatabaseConnection Baglantı = new DatabaseConnection();
            Bgln = Baglantı.BaglantiGonder();
            //ödünç verilen kitapların güncelleme işlemi yapılmayacağı için ödünç verilenler dışındakileri listeliyorum
            dataGridView1.DataSource = Islem.OduncVerilmeyenler();
        }

        //kapatma tuşuna basılırsa uygulama komple kapatılacak
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //kitap işlemler ana sayfasına geri dönmek için tıklanılan buton fonksiyonu
        private void button2_Click(object sender, EventArgs e)
        {
            //kitapişlemler formu kullanıcıya gösterilip bu formu kapatıyoruz
            KitapIslemleri.KitapIslemleri GeriDon = new KitapIslemleri.KitapIslemleri();
            GeriDon.Show();
            this.Close();
        }

        //listele butonu
        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Islem.OduncVerilmeyenler();
        }
        //datagridview üzerinden herhangi bir satıra tıklandığında çalışacak fonksiyon
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //eğer tıklanılan satırdaki bilgiler boş değilse çalışsın
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dataGridView1.CurrentRow.Selected = true;
                //guncellenecek kitap id sini datagridview'den alıyoruz ve Guncellenecekid değişkenine atıyoruz.
                int Guncellenecekid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["kitapid"].FormattedValue);
                //comboboxların içerisini database de bulunanan yazarlar ile dolduruyoruz
                Bgln.Open();
                OleDbCommand komut2 = new OleDbCommand("Select *from Yazarlar", Bgln);
                OleDbDataReader yazaroku = komut2.ExecuteReader();
                while (yazaroku.Read())
                {
                    
                    string yazaradi = yazaroku["yazaradi"].ToString();
                    string yazarsoyadi = yazaroku["yazarsoyadi"].ToString();
                    cmb_yazar.Items.Add(yazaradi + " " + yazarsoyadi);
                }
                yazaroku.Close();
                //cmb_tur comboboxın içini database de bulunan tur bilgileri ile dolduruyoruz
                OleDbCommand komut = new OleDbCommand("Select *from Tur", Bgln);
                OleDbDataReader turoku = komut.ExecuteReader();
                while (turoku.Read())
                {
                   
                    string turad = turoku["turad"].ToString();
                    cmb_tur.Items.Add(turad);
                }
                turoku.Close();
                //cmb_raf comboboxun içini raflar bilgisini dolduruyoruz
                OleDbCommand komut3 = new OleDbCommand("Select *from Raflar", Bgln);
                OleDbDataReader rafoku = komut3.ExecuteReader();
                while (rafoku.Read())
                {
                    
                    string rafadi = rafoku["rafadi"].ToString();
                    string bulundugukat = rafoku["bulundugukat"].ToString();
                    cmb_raf.Items.Add(rafadi + " " + bulundugukat);
                }
                rafoku.Close();
                //güncellenecek olan kitabın bilgilerini databaseden çekiyoruz.
                OleDbCommand komut4 = new OleDbCommand("Select kitapid,isbn,kitapad,yazarid,turid,rafid,yayinevi,sayfasayisi From Kitaplar where kitapid="+Guncellenecekid, Bgln);
                OleDbDataReader Oku = komut4.ExecuteReader();
                if (Oku.Read())
                {
                    //database den gelen bilgileri form içerisindeki texboxların içeriğine yazdırıyoruz
                    txt_kitapid.Text = Oku["kitapid"].ToString();
                    txt_isbn.Text = Oku["isbn"].ToString();
                    txt_kitapad.Text = Oku["kitapad"].ToString();
                    int yazarid = Convert.ToInt32(Oku["yazarid"]);
                    int turid = Convert.ToInt32(Oku["turid"]);
                    int rafid = Convert.ToInt32(Oku["rafid"]);
                    txt_yayinevi.Text = Oku["yayinevi"].ToString();
                    txt_sayfasayisi.Text = Oku["sayfasayisi"].ToString();
                    //rafid -1 dememin nedeni comboboxda indexleme işlemi 0 dan başladığı için ve veritabanında da 1 den başladığı için
                    //1 eksiltmem gerekiyordu
                    cmb_raf.SelectedIndex = (rafid - 1);
                    cmb_tur.SelectedIndex = (turid-1);
                    cmb_yazar.SelectedIndex = (yazarid-1);
                } 
                Bgln.Close();
            }
        }
        //güncelle butonu
        private void button5_Click(object sender, EventArgs e)
        {
            //textboxların içeriğinin boş ise ekrana hata mesajı veriliyor
            if (txt_isbn.Text == "" || txt_kitapad.Text == "" || txt_kitapid.Text== "" || txt_sayfasayisi.Text == "" || txt_yayinevi.Text == "" || cmb_raf.Text == "" || cmb_tur.Text == "" || cmb_yazar.Text == "")
            {
                MessageBox.Show("Lütfen Alanları Boş Bırakmayın");
            }
            else
            {
                //kullanıcıya güncellemek isteyip istemediğini soruyoruz
                DialogResult Cevap = MessageBox.Show("Güncellemek İstediğinizden Emin Misiniz?", "Güncelle", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //eğer kullanıcı ekrana çıkan messagebox üzerindeki evet butonuna basarsa güncelleme işlemi gerçekleşecek
                if (Cevap == DialogResult.Yes)
                {
                    //entitylayer katmanından, kitaplar nesnesi oluşturuluyor
                    Kitaplar GuncelleKitap = new Kitaplar();
                    //oluşturulan nesnenin değerlerini textbox ve comboboxlardan aldığımız bilgiler ile dolduruyoruz.
                    GuncelleKitap.turid = cmb_tur.SelectedIndex + 1;
                    GuncelleKitap.kitapad = txt_kitapad.Text;
                    GuncelleKitap.yazarid = cmb_yazar.SelectedIndex + 1;
                    GuncelleKitap.sayfasayisi = Convert.ToInt32(txt_sayfasayisi.Text);
                    GuncelleKitap.isbn = Convert.ToInt32(txt_isbn.Text);
                    GuncelleKitap.rafid = cmb_raf.SelectedIndex + 1;
                    GuncelleKitap.yayinevi = txt_yayinevi.Text;
                    GuncelleKitap.kitapid = Convert.ToInt32(txt_kitapid.Text);
                    //databaselayer katmanından kitapislemler classından bir nesne türetiyoruz.
                    KitapIslemler Guncelle = new KitapIslemler();
                    //üretilen nesnenin kitapguncelle fonksiyonuna oluşturduğumuz kitaplar nesnesini gönderiyoruz
                    //ve böylelikle güncellemek istediğimiz bilgileri nesnemizle beraber göndermiş oluyoruz.
                    //güncelleme yapıldıktan sonra geri dönüş olarak bir string değer geri gönderilecektir bunu da messagebox ile ekrana gösteriyoruz.
                    MessageBox.Show(Guncelle.KitapGuncelle(GuncelleKitap));
                    //datagridview deki bilgileri güncelle
                    dataGridView1.DataSource = Islem.OduncVerilmeyenler();
                }
                
            }
        }
        //isbn barkoduna göre arama yapmak için textboxa girilen her bir sayı için çalışacak fonksiyon
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //eğer textbox boş değilse çalışacak
            if (textBox1.Text != "")
            {
                //isbn barkoduna göre ödünç verilmeyen kitapların listelenmesi
                dataGridView1.DataSource = Islem.IsbnGoreOduncVerilmeyenler(textBox1.Text);
            }
        }

        
    }
}
