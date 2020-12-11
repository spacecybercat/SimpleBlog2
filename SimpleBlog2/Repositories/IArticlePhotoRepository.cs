using SimpleBlog2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleBlog2.Repositories
{
    public interface IArticlePhotoRepository
    {
        ArticlePhotoModel Get(int articlePhotoId);
        IQueryable<ArticlePhotoModel> GetAll();
        void Add(ArticlePhotoModel articlePhoto);
        void Update(int articlePhotoId, ArticlePhotoModel articlePhoto);
        void Delete(int articlePhotoId);
    }
}
