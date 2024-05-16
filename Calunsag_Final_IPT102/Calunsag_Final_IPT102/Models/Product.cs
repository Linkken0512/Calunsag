using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Calunsag_Final_IPT102.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [MaxLength(100)]
        public string ProductName { get; set; } = "";
        [MaxLength(100)]
        public string Brand { get; set; } = "";
        [MaxLength(100)]
        public string Category { get; set; } = "";
        [Precision(16, 2)]
        public string Price { get; set; } = "";
        public string Description { get; set; } = "";
        [MaxLength(100)]
        public string ImageFileName { get; set; } = "";
        public DateTime CreatedAt { get; set; }
    }
}
