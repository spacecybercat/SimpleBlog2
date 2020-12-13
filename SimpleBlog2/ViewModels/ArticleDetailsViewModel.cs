using SimpleBlog2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.ViewModels
{
    public class ArticleDetailsViewModel
    {
        public ArticleModel Article { get; set; }
        public ArticlePhotoModel ArticlePhoto { get; set; }
        public List<ArticleCategoryModel> ArticleCategories { get; set; }
        public List<ArticleCommentModel> ArticleComments { get; set; }
        public ArticleCommentModel NewComment { get; set; }
    }
}
