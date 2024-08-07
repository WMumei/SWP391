﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
    //[PrimaryKey(nameof(MaterialId), nameof(MaterialSetId))]
    public class MaterialSetMaterial
    {
        public int MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        public Material Material { get; set; }
        public int MaterialSetId { get; set; }
        [ForeignKey("MaterialSetId")]
        public MaterialSet MaterialSet { get; set; }
        [Range(0.001, double.MaxValue)]
        public decimal Weight { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
