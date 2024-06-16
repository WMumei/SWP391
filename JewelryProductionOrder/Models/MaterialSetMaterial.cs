using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
    [PrimaryKey(nameof(MaterialId), nameof(MaterialSetId))]
    public class MaterialSetMaterial
    {
        public int MaterialId { get; set; }
        [ForeignKey("MaterialId")]
        public Material Material { get; set; }
        public int MaterialSetId { get; set; }
        [ForeignKey("MaterialSetId")]
        public MaterialSet MaterialSet { get; set; }
        public decimal Weight { get; set; }
    }
}
