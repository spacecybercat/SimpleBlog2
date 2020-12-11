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
    public class ArticleCommentRateController : Controller
    {
        private readonly IArticleCommentRateRepository _articleCommentRateRepository;

        public ArticleCommentRateController(IArticleCommentRateRepository articleCommentRateRepository)
        {
            _articleCommentRateRepository = articleCommentRateRepository;
        }

        // GET: ArticleCommentRate
        public ActionResult Index()
        {
            return View(_articleCommentRateRepository.GetAll());
        }

        // GET: ArticleCommentRate/Details/5
        public ActionResult Details(int id)
        {
            return View(_articleCommentRateRepository.Get(id));
        }

        // GET: ArticleCommentRate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ArticleCommentRate/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleCommentRateModel articleCommentRate)
        {
            _articleCommentRateRepository.Add(articleCommentRate);
            return RedirectToAction(nameof(Index));
        }

        // GET: ArticleCommentRate/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_articleCommentRateRepository.Get(id));
        }

        // POST: ArticleCommentRate/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticleCommentRateModel articleCommentRate)
        {
            _articleCommentRateRepository.Update(id, articleCommentRate);
            return RedirectToAction(nameof(Index));
        }

        // GET: ArticleCommentRate/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_articleCommentRateRepository.Get(id));
        }

        // POST: ArticleCommentRate/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ArticleCommentRateModel articleCommentRate)
        {
            _articleCommentRateRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}