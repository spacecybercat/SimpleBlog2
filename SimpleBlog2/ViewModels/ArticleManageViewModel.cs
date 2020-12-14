using SimpleBlog2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.ViewModels
{
    public class ArticleManageViewModel
    {
        public List<ArticleModel> ArticleList { get; set; }
        public List<ArticleCategoryModel> ArticleCategoryList { get; set; }
    }
}
