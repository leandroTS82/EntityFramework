using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Emails
    {
        public int Id { get; set; }
        [MaxLength(200)]
        public string Nome { get; set; }
        [MaxLength(200)]
        public string Email { get; set; }
    }
}
