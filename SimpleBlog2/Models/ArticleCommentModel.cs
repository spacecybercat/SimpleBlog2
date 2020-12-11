using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Models
{
    [Table("ArticleComments")]
    public class ArticleCommentModel
    {
        [Key]
        public int ArticleCommentId { get; set; }
        public int ArticleId { get; set; }

        [Required(ErrorMessage = "Pole Podpis jest wymagane.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Pole Tekst jest wymagane.")]
        [MaxLength(1000)]
        public string Text { get; set; }

        public DateTime DateOfPublish { get; set; }
    }
}
