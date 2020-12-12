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

        public ArticleController(IArticleRepository articleRepository, IArticleCategoryRepository articleCategoryRepository, IArticlePhotoRepository articlePhotoRepository)
        {
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
            _articlePhotoRepository = articlePhotoRepository;
        }


        // GET: Article
        public ActionResult Index()
        {
            return View(_articleRepository.GetAll());
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            return View(_articleRepository.Get(id));
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
            return View(_articleRepository.Get(id));
        }

        // POST: Article/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticleModel articleModel)
        {
            _articleRepository.Update(id, articleModel);
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
            return RedirectToAction(nameof(Index));
        }
    }
}