using System.ComponentModel.DataAnnotations;

namespace NeZaboravi.Models
{
    public class Artikl
    {
        [Key]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Ducan { get; set; }
        public string Username { get; set; }

    }
}
