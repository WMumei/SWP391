﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
    public class WarrantyCard
    {
        

        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ExpiredAt { get; set; }

        public string CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public User? Customer { get; set; }

        public int JewelryId { get; set; }
        [ForeignKey("JewelryId")]
        public Jewelry Jewelry { get; set; } = null!;

        [Required]
        public string SalesStaffId { get; set; }
        [ForeignKey("SalesStaffId")]
        public User? SalesStaff { get; set; }
    }
}
