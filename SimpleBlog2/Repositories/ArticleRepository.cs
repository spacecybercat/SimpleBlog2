using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBlog2.Models;

namespace SimpleBlog2.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly SimpleBlog2Context _context;

        public ArticleRepository(SimpleBlog2Context context)
        {
            _context = context;
        }

        public ArticleModel Get(int articleId)
            => _context.Articles.SingleOrDefault(x => x.ArticleId == articleId);

        public IQueryable<ArticleModel> GetAll()
            => _context.Articles;

        public void Add(ArticleModel article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
        }
            
        public void Update(int articleId, ArticleModel article)
        {
            var result = _context.Articles.SingleOrDefault(x => x.ArticleId == articleId);
            if(result != null)
            {
                result.CategoryId = article.CategoryId;
                result.DateOfPublish = article.DateOfPublish;
                result.Text = article.Text;
                result.Title = article.Title;

                _context.SaveChanges();
            }
        }

        public void Delete(int articleId)
        {
            var result = _context.Articles.SingleOrDefault(x => x.ArticleId == articleId);
            if(result !=null)
            {
                _context.Articles.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
