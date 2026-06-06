using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Models
{
   public class CategoryDTO
    {
        public int ProductCategoryID { get; set; }

        [Required, NotNull]
        public string Name { get; set; }

    }
}
