using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace FullStackDev.Models
{
    public class Product
    {

        public string Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public bool Active { get; set; }

        [JsonIgnore]
        public string ProductTypeId { get; set; }

        public virtual ProductType ProductType { get; set; }
    }
}