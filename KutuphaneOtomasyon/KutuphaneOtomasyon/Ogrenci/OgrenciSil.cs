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

namespace KutuphaneOtomasyon.Ogrenci
{
    public partial class OgrenciSil : Form
    {
        //formun haraket ettirilmesi için gerekli değişkenler ve access bağlantı değişkeni
        static OleDbConnection Baglanti;
        OgrencilerDatabaseIslemleri Islem = new OgrencilerDatabaseIslemleri();
        int Movee;
        int Mouse_X;
        int Mouse_Y;
        public OgrenciSil()
        {
            InitializeComponent();
        }
        //form load fonksiyonu
        private void OgrenciSil_Load(object sender, EventArgs e)
        {
            //bağlantı işlemleri
            DatabaseConnection Bgln = new DatabaseConnection();
            Baglanti = Bgln.BaglantiGonder();
            //tüm öğrencileri datagridview de listele
            dataGridView1.DataSource = Islem.ogrencilistele();
        }
        //uygulamayı kapat
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        //öğrenci işlmelerine geri dön
        private void button3_Click(object sender, EventArgs e)
        {
            OgrenciIslemleri ogrenciIslemleri = new OgrenciIslemleri();
            ogrenciIslemleri.Show();
            this.Close();
        }
        //öğrenci numarasına göre listele
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textbox boş değilse çalış
            if (textBox1.Text != "")
            {
                //öğrenci numarasına göre listele
                dataGridView1.DataSource = Islem.OgrNoGoreListele(textBox1.Text);
            }
        }
        //silinmek istenen öğrencinin seçilmesi
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //seçilen satır boş değil ise
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
            {
                //kullanıcıya silmek isteyip istemediğini soruyoruz
                DialogResult Cevap = MessageBox.Show("Silmek İstediğinizden Emin Misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                //eğer kullanıcı ekrana çıkan messagebox üzerindeki evet butonuna basarsa silme işlemi gerçekleşecek
                if (Cevap == DialogResult.Yes)
                {
                    //öğrenci işlemlerinden bir nesne türettik
                    OgrencilerDatabaseIslemleri OgrenciIslem = new OgrencilerDatabaseIslemleri();
                    dataGridView1.CurrentRow.Selected = true;
                    //seçilen satırdaki öğrenci numarası değişkenini silinecek numara değişkenine atıyoruz
                    long SilinecekNumara = Convert.ToInt64(dataGridView1.Rows[e.RowIndex].Cells["OgrenciNumarasi"].FormattedValue);
                    //öğrenciişlemleri nesnesine aldığımız öğrenci numarasını gönderiyoruz ve bi hata olursa kullanıcıya gösteriyoruz
                    MessageBox.Show(OgrenciIslem.OgrenciSil(SilinecekNumara));
                    //silindikten sonra tekrardan datagridview de tüm öğrencileri listeliyoruz ve bu sayede liste güncel olmuş oluyor
                    dataGridView1.DataSource = Islem.ogrencilistele();
                }
            }
        }

        //fare haraket ettirdiğinde
        private void OgrenciSil_MouseMove(object sender, MouseEventArgs e)
        {
            //movee 1 e eşit ise
            if (Movee == 1)
            {
                //farenin koordinatlarını formun koordinatlarına eşitle
                this.SetDesktopLocation(MousePosition.X - Mouse_X, MousePosition.Y - Mouse_Y);
            }
        }
        //formu haraket ettirmeyi bırakacağımız zaman movee değeri 0 a eşitliyoruz
        private void OgrenciSil_MouseUp(object sender, MouseEventArgs e)
        {
            Movee = 0;
        }
        //formu haraket ettireceğimzi zaman movee değerini 1 e eşitliyoruz farenin koordinatlarını alıyoruz
        private void OgrenciSil_MouseDown(object sender, MouseEventArgs e)
        {
            Movee = 1;
            Mouse_X = e.X;
            Mouse_Y = e.Y;
        }
    }
}
