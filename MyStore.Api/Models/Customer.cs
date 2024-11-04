using System;
using System.ComponentModel.DataAnnotations;

namespace MyStore.Api.Models
{
    public class Customer
    {
        [Key]
        public string? CustomerNumber { get; set; } // Made nullable
        [Required]
        [MaxLength(100)]
        public string? Name { get; set; } // Made nullable
        [MaxLength(255)]
        public string? Description { get; set; } // Made nullable
        [MaxLength(100)]
        public string? ContactInformation { get; set; } // Made nullable
        [Required]
        [Range(0, double.MaxValue)]
        public decimal CurrentBalance { get; set; }
        public DateTime? LastTransactionDate { get; set; }
    }
}


// using System;
// using System.ComponentModel.DataAnnotations;

// namespace MyStore.Api.Models
// {
//     public class Customer
//     {
//         [Key]
//         public string CustomerNumber { get; set; }
//         [Required]
//         [MaxLength(100)]
//         public string Name { get; set; }
//         [MaxLength(255)]
//         public string Description { get; set; }
//         [MaxLength(100)]
//         public string ContactInformation { get; set; }
//         [Required]
//         [Range(0, double.MaxValue)]
//         public decimal CurrentBalance { get; set; }
//         public DateTime? LastTransactionDate { get; set; }
//     }
// }