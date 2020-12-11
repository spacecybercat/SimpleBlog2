using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Models
{
    [Table("Articles")]
    public class ArticleModel
    {
        [Key]
        public int ArticleId { get; set; }
        public string AuthorId { get; set; }
        public int CategoryId { get; set; }

        [DisplayName("Tytuł")]
        [Required(ErrorMessage = "Pole Tytuł jest wymagane.")]
        [MaxLength(200)]
        public string Title { get; set; }

        [DisplayName("Treść")]
        [Required(ErrorMessage = "Pole Treść jest wymagane.")]
        public string Text { get; set; }

        [DisplayName("Data publikacji")]
        [Required(ErrorMessage = "Pole Data publikacji jest wymagane.")]
        public DateTime DateOfPublish { get; set; }
    }
}
