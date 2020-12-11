using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBlog2.Models;

namespace SimpleBlog2.Repositories
{
    public class ArticlePhotoRepository : IArticlePhotoRepository
    {
        private readonly SimpleBlog2Context _context;

        public ArticlePhotoRepository(SimpleBlog2Context context)
        {
            _context = context;
        }

        public ArticlePhotoModel Get(int articlePhotoId)
            => _context.ArticlePhotos.SingleOrDefault(x => x.ArticlePhotoId == articlePhotoId);

        public IQueryable<ArticlePhotoModel> GetAll()
            => _context.ArticlePhotos;

        public void Add(ArticlePhotoModel articlePhoto)
        {
            _context.ArticlePhotos.Add(articlePhoto);
            _context.SaveChanges();
        }

        public void Update(int articlePhotoId, ArticlePhotoModel articlePhoto)
        {
            var result = _context.ArticlePhotos.SingleOrDefault(x => x.ArticlePhotoId == articlePhotoId);
            if(result != null)
            {
                result.FileName = articlePhoto.FileName;
                _context.SaveChanges();
            }
        }

        public void Delete(int articlePhotoId)
        {
            var result = _context.ArticlePhotos.SingleOrDefault(x => x.ArticlePhotoId == articlePhotoId);
            if(result != null)
            {
                _context.ArticlePhotos.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
