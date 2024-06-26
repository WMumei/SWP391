﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
	public class ProductionRequest
	{
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public String? Address { get; set; }
        public String? Status { get; set; }
        public int Quantity { get; set; }

        public string? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public User? Customer { get; set; }

        public string? DesignStaffId { get; set; }
        [ForeignKey("DesignStaffId")]
        public User? DesignStaff { get; set; }

        public string? ProductionStaffId { get; set; }
        [ForeignKey("ProductionStaffId")]
        public User? ProductionStaff { get; set; }

        public string? SalesStaffId { get; set; }
        [ForeignKey("SalesStaffId")]
        public User? SalesStaff { get; set; }

        public QuotationRequest? QuotationRequest { get; set; }

        public List<Jewelry> Jewelries { get; } = [];

    }
}
