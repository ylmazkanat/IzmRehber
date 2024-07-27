using Microsoft.EntityFrameworkCore;

namespace IzmRehber.Models
{
    public class Rehber
    {

        public string KullaniciAdi {  get; set; }

        public string Sifre {  get; set; }
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Departman { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
    }
}
