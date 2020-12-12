using SimpleBlog2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.ViewModels
{
    public class ArticleCreateViewModel
    {
        public ArticleModel Article { get; set; }
        public IQueryable<ArticleCategoryModel> ArticleCategories { get; set; }
        public ArticlePhotoModel ArticlePhoto { get; set; }
    }
}
