using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    //ödünç işlemlerini yapabilmemiz için gerekli sınıfımız
    public class OduncHaraketleri
    {
        //oduncid birincil anahtar
        public int oduncid { get; set; }
        //kitapid ikincil anahtar
        public int kitapid { get; set; }
        //öğrenci numarası ikincil anahtar
        public long OgrenciNumarasi { get; set; }
        //alınıp verilme işlemleri tarihsel düzeyde yapılmalı
        public DateTime aldigitarih { get; set; }
        public DateTime verdigitarih { get; set; }
        //kitabın durumunu boolean olarak kaydediyoruz (ödünç verildi / alındı)
        public Boolean durum { set; get; }
    }
}
