using System.ComponentModel.DataAnnotations;

namespace PaymentPortal.Data.Models
{
    public class Entity
    {
        [Key]        
        public int Id { get; set; }
        public DateTime CreateDateUtc { get; set; }
    }
}
