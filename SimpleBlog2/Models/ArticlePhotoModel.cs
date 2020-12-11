using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Models
{
    [Table("ArticlePhotos")]
    public class ArticlePhotoModel
    {
        [Key]
        public int ArticlePhotoId { get; set; }
        public int ArticleId { get; set; }
        public string FileName { get; set; }
    }
}
