using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Models
{
    public class ArticleCommentRateModel
    {
        public int ArticleCommentRateId { get; set; }
        public int ArticleCommentId { get; set; }
        public int Value { get; set; }
    }
}
