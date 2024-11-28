using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_Ecommerce_Web_API.DTOs
{
    public class CategoryCreateDto
    {
        [Required(ErrorMessage = "Category name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Category name must be atleast 2 characters long!")]
        public string CategoryName { get; set; } = string.Empty;

        [StringLength(150, ErrorMessage = "Category description can not exceed 150 characters!")]
        public string CategoryDescription { get; set; } = string.Empty;
    }
}