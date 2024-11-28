using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Ecommerce_Web_API.DTOs
{
    public class CategoryUpdateDto
    {
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; } = string.Empty;
    }
}