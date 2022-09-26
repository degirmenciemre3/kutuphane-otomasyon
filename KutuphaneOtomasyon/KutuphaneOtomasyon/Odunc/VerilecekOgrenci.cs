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

namespace KutuphaneOtomasyon.Odunc
{
    public partial class VerilecekOgrenci : Form
    {
        OduncHaraketleri Odunc = new OduncHaraketleri();
        OgrencilerDatabaseIslemleri Islem = new OgrencilerDatabaseIslemleri();
        OleDbConnection Baglanti;
        //formun yapıcı metotu
        public VerilecekOgrenci()
        {
            InitializeComponent();
            //bağlantı işlemleri
            DatabaseConnection Bgln = new DatabaseConnection();
            Baglanti = Bgln.BaglantiGonder();
            //ogrencileri listele
            dataGridView1.DataSource = Islem.ogrencilistele();
        }

        //hangi kitabı öğrenceye vereceğimizi bilmek için ödünçver formundan alacağımız kitapid
        public void BilgiAl(int kitapid)
        {
            //gelen değeri oluşturduğumuz odunc nesnesinin kitapid sine ataması yapılıyor
            Odunc.kitapid = kitapid;
        }

        //kitap seçme ekranına geri dönmek için geri dön butonu fonksiyonu
        private void button3_Click(object sender, EventArgs e)
        {
            OduncVer geridon = new OduncVer();
            geridon.Show();
            this.Close();
        }

        //uygulamayı kapat
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //öğrenci numarasına göre listeleme
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Islem.OgrNoGoreListele(textBox1.Text);
        }

        //öğrenci seçme işlemi
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //seçilen satır boş değil ise çalış
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                //odunç vermek için ödünç işlemlerinden bir nesne türetiyoruz
                OduncDatabaseIslemleri OduncVer = new OduncDatabaseIslemleri();
                dataGridView1.CurrentRow.Selected = true;
                //seçilen öğrencinin öğrenci numarasını verileceköğrencino ya ata
                long VerilecekOgrenciNo = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["OgrenciNumarasi"].FormattedValue);
                Odunc.OgrenciNumarasi = VerilecekOgrenciNo;
                //alınan tarihi bugünün tarihi olarak belirliyoruz
                Odunc.aldigitarih = Convert.ToDateTime(DateTime.Now.ToString("d"));
                //ödünç işlemleri nesnesinin ödünçver methoduna oluşturduğumuz ödünç nesnesini gönderiyoruz
                MessageBox.Show(OduncVer.OduncVer(Odunc));
                //ödünç işlemleri ana sayfasına geri gönderiyoruz
                OduncIslemler.OduncAlma geridon = new OduncIslemler.OduncAlma();
                //formu görüntüle
                geridon.Show();
                this.Close();
            }
        }
    }
}
