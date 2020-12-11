using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Models
{
    [Table("ArticleCategories")]
    public class ArticleCategoryModel
    {
        [Key]
        public int ArticleCategoryId { get; set; }
        [Required(ErrorMessage = "Pole Nazwa kategorii jest wymagane.")]
        [DisplayName("Nazwa kategorii")]
        public string Name { get; set; }
    }
}
