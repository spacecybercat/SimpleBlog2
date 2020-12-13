using SimpleBlog2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.ViewModels
{
    public class ArticleIndexViewModel
    {
        public List<ArticleModel> Articles { get; set; }
        public List<ArticlePhotoModel> ArticlePhotos { get; set; }
        public List<ArticleCommentModel> ArticleComments { get; set; }
        public List<ArticleCategoryModel> ArticleCategories { get; set; }
    }
}
