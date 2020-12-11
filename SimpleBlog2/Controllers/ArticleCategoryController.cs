using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog2.Models;
using SimpleBlog2.Repositories;

namespace SimpleBlog2.Controllers
{
    public class ArticleCategoryController : Controller
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryController(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        // GET: ArticleCategory
        public ActionResult Index()
        {
            return View(_articleCategoryRepository.GetAll());
        }

        // GET: ArticleCategory/Details/5
        public ActionResult Details(int id)
        {
            return View(_articleCategoryRepository.Get(id));
        }

        // GET: ArticleCategory/Create
        public ActionResult Create()
        {
            return View(new ArticleCategoryModel());
        }

        // POST: ArticleCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleCategoryModel articleCategory)
        {
            _articleCategoryRepository.Add(articleCategory);
            return RedirectToAction(nameof(Index));
        }

        // GET: ArticleCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_articleCategoryRepository.Get(id));
        }

        // POST: ArticleCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticleCategoryModel articleCategory)
        {
            _articleCategoryRepository.Update(id, articleCategory);
            return RedirectToAction(nameof(Index));
        }

        // GET: ArticleCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_articleCategoryRepository.Get(id));
        }

        // POST: ArticleCategory/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            _articleCategoryRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}