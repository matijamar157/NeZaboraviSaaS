using System.ComponentModel.DataAnnotations;

namespace NeZaboravi.Models
{
    public class Log
    {
        [Key]
        public int Id { get; set; }
        public string Logs { get; set; }
    }
}
