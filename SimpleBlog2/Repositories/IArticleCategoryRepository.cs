using SimpleBlog2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Repositories
{
    public interface IArticleCategoryRepository
    {
        ArticleCategoryModel Get(int articleCategoryId);
        IQueryable<ArticleCategoryModel> GetAll();
        void Add(ArticleCategoryModel articleCategory);
        void Update(int articleCategoryId, ArticleCategoryModel articleCategory);
        void Delete(int articleCategoryId);
    }
}
