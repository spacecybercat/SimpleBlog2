using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using SimpleBlog2.Models;
using SimpleBlog2.ViewModels;

namespace SimpleBlog2.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly SimpleBlog2Context _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ArticleRepository(SimpleBlog2Context context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
            
        public void Update(ArticleCreateViewModel viewModel)
        {
            var result = _context.Articles.SingleOrDefault(x => x.ArticleId == viewModel.Article.ArticleId);
            if(result != null)
            {
                result.CategoryId = viewModel.Article.CategoryId;
                result.DateOfPublish = viewModel.Article.DateOfPublish;
                result.Text = viewModel.Article.Text;
                result.Title = viewModel.Article.Title;
                _context.SaveChanges();
            }
            if(viewModel.ArticlePhoto != null)
            {
                var resultPhoto = _context.ArticlePhotos.SingleOrDefault(x => x.ArticleId == viewModel.Article.ArticleId);
                if (resultPhoto != null)
                {
                    //delete ArticlePhoto from /images/Articles
                    var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/Articles", resultPhoto.FileName);
                    if (System.IO.File.Exists(imagePath))
                        System.IO.File.Delete(imagePath);
                    //delete ArticlePhoto from DB
                    _context.ArticlePhotos.Remove(resultPhoto);
                    _context.SaveChanges();

                    viewModel.ArticlePhoto.ArticleId = viewModel.Article.ArticleId;
                    viewModel.ArticlePhoto.FileName = viewModel.ArticlePhoto.PhotoFile.FileName;

                    //Save ArticlePhoto to /images/Articles/
                    string wwwRootPath = _webHostEnvironment.WebRootPath;
                    string fileName = Path.GetFileNameWithoutExtension(viewModel.ArticlePhoto.FileName);
                    string fileExtension = Path.GetExtension(viewModel.ArticlePhoto.FileName);
                    viewModel.ArticlePhoto.FileName = fileName = fileName + DateTime.Now.ToString("yymmssffff") + fileExtension;
                    string filePath = Path.Combine(wwwRootPath + "/images/Articles", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        viewModel.ArticlePhoto.PhotoFile.CopyTo(fileStream);
                    }
                    //Insert ArticlePhoto into DB
                    _context.Add(viewModel.ArticlePhoto);
                    _context.SaveChanges();
                }
            }
        }

        public void Delete(int articleId)
        {
            var result = _context.Articles.SingleOrDefault(x => x.ArticleId == articleId);
            if(result != null)
            {
                _context.Articles.Remove(result);
                _context.SaveChanges();
            }
        }
    }
}
