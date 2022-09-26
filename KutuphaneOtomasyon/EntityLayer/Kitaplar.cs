using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    //ekleme silme güncelleme yapacağımız kitaplar bilgilerini bir nesne üzerinde tutmak için entitylayer katmanında kitaplar sınıfı yazılır.
    public class Kitaplar
    {
        //kitapid birincil anahtar
        public int kitapid { get; set; }
        //turid ikincil anahtar
        public int turid { get; set; }
        public string kitapad { get; set; }
        //yazarid ikincil anahtar
        public int yazarid { get; set; }
        public int sayfasayisi { get; set; }
        //her kitabın kendine özgü bir isbn barkodu vardır isbn barkodunu birincil anahtar yapmadım
        //cünkü bu kütüphanede stok sistemi yok aynı kitaptan birkaç tane olabilir ve farklı raflarda listelenebilir
        //bu yüzden aynı kitaptan birkaç tane girebilmemiz gerekiyordu bu yüzden isbn barkodu burada sadece bir değişken oldu
        public int isbn { get; set; }
        //rafid ikincil anahtar
        public int rafid { get; set; }
        public string yayinevi { get; set; }
    }
}
