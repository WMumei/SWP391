﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace JewelryProductionOrder.Models.ViewModels
{
    public class MaterialSetVM
    {
        public Jewelry Jewelry { get; set; }
        //public MaterialSet MaterialSet { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> MaterialList { get; set; }
        [DisplayName("Weight")]
        public double Weight { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> GemstoneList { get; set; }
        public Material Material { get; set; }
        public Gemstone Gemstone { get; set; }
    }
}
