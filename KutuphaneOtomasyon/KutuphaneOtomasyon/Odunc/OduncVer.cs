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

namespace KutuphaneOtomasyon.Odunc
{
    public partial class OduncVer : Form
    {
        OleDbConnection Baglanti;
        KitapIslemler Islem = new KitapIslemler();
        public OduncVer()
        {
            InitializeComponent();
        }
        //ödünç işlemlerine giden buton fonksiyonu
        private void button3_Click(object sender, EventArgs e)
        {
            OduncIslemler.OduncAlma oduncIslemler = new OduncIslemler.OduncAlma();
            oduncIslemler.Show();
            this.Close();
        }

        //textbox a girilen isbn koduna göre listeleme işlemi yapma
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Islem.IsbnGoreListele(textBox1.Text);
        }

        //ödünç verilmek istenilen kitabın üzerine basıldığında çalışacak fonksiyon
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //eğer seçilen satır boş değilse çalış
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                dataGridView1.CurrentRow.Selected = true;
                //seçilen satırdaki kitapid ifadesini verilenkitapid değerine ataması yapılıyor
                int VerilenKitapid = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["kitapid"].FormattedValue);
                //seçilen kitabın hangi öğrenciye verileceğini belirlediğimiz form olan verileceköğrenci formundan bir nesne türetilir
                VerilecekOgrenci OgrenciSec = new VerilecekOgrenci();
                //türetilen öğrencisec nesnesinin bilgial fonksiyonuna seçmiş olduğumuz kitabın id sini gönderiyoruz
                //gönderdiğimiz formda işlemlerini yapacağımız için
                OgrenciSec.BilgiAl(VerilenKitapid);
                //formu göster
                OgrenciSec.Show();
                this.Close();
            }
        }
        //programı kapat
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //form yüklenirken çalışacak fonksiyon
        private void OduncVer_Load(object sender, EventArgs e)
        {
            //bağlantı işlemlerimiz
            DatabaseConnection Bgln = new DatabaseConnection();
            Baglanti = Bgln.BaglantiGonder();
            //kitapları listele
            dataGridView1.DataSource = Islem.KitapListele();
            
        }
    }
}
