using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Models
{
    public class ArticleModel
    {
        public int ArticleId { get; set; }
        public string AuthorId { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Pole Tytuł jest wymagane.")]
        [MaxLength(200)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Pole Tekst jest wymagane.")]
        public string Text { get; set; }
        [Required(ErrorMessage = "Pole Data publikacji jest wymagane.")]
        public DateTime DateOfPublish { get; set; }
    }
}
