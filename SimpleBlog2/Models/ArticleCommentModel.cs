using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [DisplayName("Podpis")]
        [Required(ErrorMessage = "Pole Podpis jest wymagane.")]
        [MaxLength(50)]
        public string Author { get; set; }

        [DisplayName("Treść komentarza")]
        [Required(ErrorMessage = "Pole Tekst jest wymagane.")]
        [MaxLength(1000)]
        public string Text { get; set; }

        [DisplayName("Data komentarza")]
        public DateTime DateOfPublish { get; set; }
    }
}
