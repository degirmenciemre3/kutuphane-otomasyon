using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    //ceza işlemleri için kullanacağımız cezabilgileri sınıfımız
    public class CezaBilgileri
    {
        //odunçid si birincil anahtar
        public int oduncid { get; set; }
        //öğrenci numarasını long türünde alıyoruz çünkü 9 haneli
        public long OgrenciNumarasi { get; set; }
        //geçikme süresini listelemek istiyoruz
        public int gecikmesuresi { get; set; }
        //gecikme süresi için ne kadar ücret kesildiğini veritabanında tutuyoruz
        public int cezamiktari { get; set; }
    }
}
