using System.ComponentModel.DataAnnotations;

namespace SpendSmart.Models
{
    public class Depense
    {
        public int Id { get; set; }
        public decimal Prix { get; set; }

        [Required]
        public string? Description { get; set; }
    }
}
