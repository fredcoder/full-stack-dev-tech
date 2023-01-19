using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace webapi.Models
{
    public class Product
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^\d+(\.\d{1,2})?$")]
        public float Price { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public string ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}