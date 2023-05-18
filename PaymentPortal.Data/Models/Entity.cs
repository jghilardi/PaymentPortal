using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentPortal.Data.Models
{
    public class Entity
    {
        public int Id { get; set; }
        public DateTime CreateDateUtc { get; set; }
    }
}
