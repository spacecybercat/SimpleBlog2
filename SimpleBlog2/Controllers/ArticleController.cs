using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog2.Models;
using SimpleBlog2.Repositories;
using SimpleBlog2.ViewModels;

namespace SimpleBlog2.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IArticlePhotoRepository _articlePhotoRepository;
        private readonly IArticleCommentRepository _articleCommentRepository;

        public ArticleController(IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository, IArticlePhotoRepository articlePhotoRepository, IArticleCommentRepository articleCommentRepository)
        {
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
            _articlePhotoRepository = articlePhotoRepository;
            _articleCommentRepository = articleCommentRepository;
        }


        // GET: Article
        public ActionResult Index()
        {
            var viewModel = new ArticleIndexViewModel { Articles = _articleRepository.GetAll().ToList(), ArticlePhotos = _articlePhotoRepository.GetAll().ToList(), ArticleComments = _articleCommentRepository.GetAll().ToList(), ArticleCategories = _articleCategoryRepository.GetAll().ToList() };
            return View(viewModel);
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = new ArticleDetailsViewModel { Article = _articleRepository.Get(id), ArticlePhoto = _articlePhotoRepository.GetByArticleId(id), ArticleCategories = _articleCategoryRepository.GetAll().ToList(), ArticleComments = _articleCommentRepository.GetAllForArticle(id).ToList() };
            return View(viewModel);
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            var viewModel = new ArticleCreateViewModel { Article = new ArticleModel(), ArticleCategories = _articleCategoryRepository.GetAll()};
            return View(viewModel);
        }

        // POST: Article/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleCreateViewModel viewModel)
        {
            _articleRepository.Add(viewModel.Article);
            _articlePhotoRepository.Add(viewModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = new ArticleCreateViewModel { Article = _articleRepository.Get(id), ArticleCategories = _articleCategoryRepository.GetAll(), ArticlePhoto = _articlePhotoRepository.GetByArticleId(id) };
            return View(viewModel);
        }

        // POST: Article/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleCreateViewModel viewModel)
        {
            _articleRepository.Update(viewModel);
            return RedirectToAction(nameof(Index));
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_articleRepository.Get(id));
        }

        // POST: Article/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ArticleModel articleModel)
        {
            _articleRepository.Delete(id);
            _articlePhotoRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}