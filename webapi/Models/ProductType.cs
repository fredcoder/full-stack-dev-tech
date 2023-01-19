using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace webapi.Models
{
    public class ProductType
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}