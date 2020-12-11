using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Models
{
    public class ArticlePhotoModel
    {
        public int ArticlePhotoId { get; set; }
        public int ArticleId { get; set; }
        public string FileName { get; set; }
    }
}
