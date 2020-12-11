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
    public class ArticlePhotoController : Controller
    {
        private readonly IArticlePhotoRepository _articlePhotoRepository;

        public ArticlePhotoController(IArticlePhotoRepository articlePhotoRepository)
        {
            _articlePhotoRepository = articlePhotoRepository;
        }

        // GET: ArticlePhoto
        public ActionResult Index()
        {
            return View(_articlePhotoRepository.GetAll());
        }

        // GET: ArticlePhoto/Details/5
        public ActionResult Details(int id)
        {
            return View(_articlePhotoRepository.Get(id));
        }

        // GET: ArticlePhoto/Create
        public ActionResult Create()
        {
            return View(new ArticlePhotoModel());
        }

        // POST: ArticlePhoto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticlePhotoModel articlePhoto)
        {
            _articlePhotoRepository.Add(articlePhoto);
            return RedirectToAction(nameof(Index));
        }

        // GET: ArticlePhoto/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_articlePhotoRepository.Get(id));
        }

        // POST: ArticlePhoto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticlePhotoModel articlePhoto)
        {
            _articlePhotoRepository.Update(id, articlePhoto);
            return RedirectToAction(nameof(Index));
        }

        // GET: ArticlePhoto/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_articlePhotoRepository.Get(id));
        }

        // POST: ArticlePhoto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ArticlePhotoModel articlePhoto)
        {
            _articlePhotoRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}