using SimpleBlog2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Repositories
{
    public class ArticleCategoryRepository : IArticleCategoryRepository
    {
        private readonly SimpleBlog2Context _context;

        public ArticleCategoryRepository( SimpleBlog2Context context)
        {
            _context = context;
        }

        public ArticleCategoryModel Get(int articleCategoryId)
            => _context.ArticleCategories.SingleOrDefault(x => x.ArticleCategoryId == articleCategoryId);

        public IQueryable<ArticleCategoryModel> GetAll()
            => _context.ArticleCategories;

        public void Add(ArticleCategoryModel articleCategory)
        {
            _context.ArticleCategories.Add(articleCategory);
            _context.SaveChanges();
        }

        public void Update(int articleCategoryId, ArticleCategoryModel articleCategory)
        {
            var result = _context.ArticleCategories.SingleOrDefault(x => x.ArticleCategoryId == articleCategoryId);
            if(result != null)
            {
                result.Name = articleCategory.Name;
                _context.SaveChanges();
            }
        }

        public void Delete(int articleCategoryId)
        {
            var result = _context.ArticleCategories.SingleOrDefault(x => x.ArticleCategoryId == articleCategoryId);
            if(result != null)
            {
                _context.ArticleCategories.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
