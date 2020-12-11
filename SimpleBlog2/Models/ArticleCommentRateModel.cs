using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Models
{
    [Table("ArticleCommentRates")]
    public class ArticleCommentRateModel
    {
        [Key]
        public int ArticleCommentRateId { get; set; }
        public int ArticleCommentId { get; set; }
        public int Value { get; set; }
    }
}
