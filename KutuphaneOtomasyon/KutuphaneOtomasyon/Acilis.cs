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

namespace KutuphaneOtomasyon
{
    public partial class Acilis : Form
    {
        public Acilis()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        bool islem = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //eğer işlem değeri false ise
            if (islem == false)
            {
                //formun opaklığını 0.009 ile arttır (formun opaklığı ilk başta 0 olarak belirledik  form ayarlarında)
                this.Opacity += 0.009;
            }
            //form opaklığı 1 e ulaştığında
            if (this.Opacity == 1.0)
            {
                //işlem değişkenini true yap
                islem = true;   
            }
            //eğer işlem değeri true ise
            if (islem== true)
            {
                //formun opaklığını 0.009 azalt
                this.Opacity -= 0.009;
                //eğer form opaklığı 0 a ulaşırsa
                if (this.Opacity == 0.0)
                {
                    //ana sayfayı göster
                    AnaSayfa Getir = new AnaSayfa();
                    Getir.Show();
                    //timer ı durdur
                    timer1.Enabled = false;
                    //ve bu formu gizliyoruz bu form ana formumuz olduğu için bunu kapatırsak program kapanır
                    //kapatmak yerine gizliyoruz
                    this.Hide();
                }
            }
        }
    }
}
