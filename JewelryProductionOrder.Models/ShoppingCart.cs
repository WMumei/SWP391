using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JewelryProductionOrder.Models
{
    public class ShoppingCart
    {
        public int Id { get; set; }
        public int BaseDesignId { get; set; }
        [ForeignKey("BaseDesignId")]
        [ValidateNever]
        public BaseDesign BaseDesign { get; set; }
        [Range(1, 1000, ErrorMessage = "Please enter a value between 1 and 1000")]
        public int Quantity { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        [ValidateNever]
        public User User { get; set; }

    }
}
