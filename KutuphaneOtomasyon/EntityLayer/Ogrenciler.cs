using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    //ekleme silme güncelleme yapacağımız ogrenci bilgilerini bir nesne üzerinde tutmak için entitylayer katmanında ogrenciler sınıfı yazılır.
    public class Ogrenciler
    {
        //access veritabanımızdaki Ogrenciler tablomuzdaki değerleri yazıyoruz
        //ogrencinin numarası 9 haneli olduğu için long değerini veriyorum.
        public long OgrenciNumarasi { get; set; }
        public string OgrenciAdi { get; set; }
        public string OgrenciSoyadi { get; set; }
        public string OgrenciBolum { get; set; }
        //ogrencinin sınıfını string alıyorum çünkü Hazırlık okuyanları da Hazırlık şeklinde veritabanında Görebilmek için
        public string OgrenciSinif { get; set; }
        public string OgrenciMail { get; set; }
        //burada öğrencinin telefonunu long türünde tutabilirdik ama telefon üzerinden bir işlem yapmayacağım için
        //string türünde almaya karar verdim
        public string OgrenciTelefon { get; set; }
    }
}
