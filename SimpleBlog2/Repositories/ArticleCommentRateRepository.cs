using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBlog2.Models;

namespace SimpleBlog2.Repositories
{
    public class ArticleCommentRateRepository : IArticleCommentRateRepository
    {
        private readonly SimpleBlog2Context _context;

        public ArticleCommentRateRepository(SimpleBlog2Context context)
        {
            _context = context;
        }

        public ArticleCommentRateModel Get(int articleCommentRateId)
            => _context.ArticleCommentRates.SingleOrDefault(x => x.ArticleCommentRateId == articleCommentRateId);

        public IQueryable<ArticleCommentRateModel> GetAll()
            => _context.ArticleCommentRates;

        public void Add(ArticleCommentRateModel articleCommentRate)
        {
            _context.ArticleCommentRates.Add(articleCommentRate);
            _context.SaveChanges();
        }

        public void Update(int articleCommentRateId, ArticleCommentRateModel articleCommentRate)
        {
            var result = _context.ArticleCommentRates.SingleOrDefault(x => x.ArticleCommentRateId == articleCommentRateId);
            if(result != null)
            {
                result.Value = articleCommentRate.Value;
                _context.SaveChanges();
            }
        }

        public void Delete(int articleCommentRateId)
        {
            var result = _context.ArticleCommentRates.SingleOrDefault(x => x.ArticleCommentRateId == articleCommentRateId);
            if(result != null)
            {
                _context.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
