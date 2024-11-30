using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Ecommerce_Web_API.DTOs
{
    public class CategoryUpdateDto
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Category name must be between 2 to 50 characters")]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(200, MinimumLength = 5, ErrorMessage = "Category description must be between 5 to 200 characters")]
        public string CategoryDescription { get; set; } = string.Empty;
    }
}