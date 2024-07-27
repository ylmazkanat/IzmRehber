using Microsoft.EntityFrameworkCore;

namespace IzmRehber.Models
{
    public class Rehber
    {

        
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Departman { get; set; }
        public string Email { get; set; }
        public string Tel { get; set; }
    }
}
