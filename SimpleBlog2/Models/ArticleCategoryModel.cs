using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Models
{
    public class ArticleCategoryModel
    {
        public int ArticleCategoryId { get; set; }
        [Required(ErrorMessage = "Pole Nazwa kategorii jest wymagane.")]
        public string Name { get; set; }
    }
}
