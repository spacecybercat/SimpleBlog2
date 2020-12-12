using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SimpleBlog2.Models;
using SimpleBlog2.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace SimpleBlog2.Repositories
{
    public class ArticlePhotoRepository : IArticlePhotoRepository
    {
        private readonly SimpleBlog2Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ArticlePhotoRepository(SimpleBlog2Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
        public void Add(ArticleCreateViewModel viewModel)
        {
            viewModel.ArticlePhoto.ArticleId = viewModel.Article.ArticleId;
            viewModel.ArticlePhoto.FileName = viewModel.ArticlePhoto.PhotoFile.FileName;

            //Save ArticlePhoto to /images/Articles/
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(viewModel.ArticlePhoto.FileName);
            string fileExtension = Path.GetExtension(viewModel.ArticlePhoto.FileName);
            viewModel.ArticlePhoto.FileName = fileName = fileName + DateTime.Now.ToString("yymmssffff") + fileExtension;
            string filePath = Path.Combine(wwwRootPath + "/images/Articles", fileName);
            using(var fileStream = new FileStream(filePath, FileMode.Create))
            {
                viewModel.ArticlePhoto.PhotoFile.CopyToAsync(fileStream);
            }

            //Insert ArticlePhoto into DB
            _context.Add(viewModel.ArticlePhoto);
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

        public void Delete(int articleId)
        {
            var result = _context.ArticlePhotos.SingleOrDefault(x => x.ArticleId == articleId);
            if(result != null)
            {
                //delete ArticlePhoto from /images/Articles
                var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/Articles", result.FileName);
                if (System.IO.File.Exists(imagePath))
                    System.IO.File.Delete(imagePath);
                //delete ArticlePhoto from DB
                _context.ArticlePhotos.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
