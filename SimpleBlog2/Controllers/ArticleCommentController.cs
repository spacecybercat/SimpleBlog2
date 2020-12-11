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
    public class ArticleCommentController : Controller
    {
        private readonly IArticleCommentRepository _articleCommentRepository;

        public ArticleCommentController(IArticleCommentRepository articleCommentRepository)
        {
            _articleCommentRepository = articleCommentRepository;
        }

        // GET: ArticleComment
        public ActionResult Index()
        {
            return View(_articleCommentRepository.GetAll());
        }

        // GET: ArticleComment/Details/5
        public ActionResult Details(int id)
        {
            return View(_articleCommentRepository.Get(id));
        }

        // GET: ArticleComment/Create
        public ActionResult Create()
        {
            return View(new ArticleCommentModel());
        }

        // POST: ArticleComment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleCommentModel articleComment)
        {
            _articleCommentRepository.Add(articleComment);
            return RedirectToAction(nameof(Index));
        }

        // GET: ArticleComment/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_articleCommentRepository.Get(id));
        }

        // POST: ArticleComment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ArticleCommentModel articleComment)
        {
            _articleCommentRepository.Update(id, articleComment);
            return RedirectToAction(nameof(Index));
        }

        // GET: ArticleComment/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_articleCommentRepository.Get(id));
        }

        // POST: ArticleComment/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ArticleCommentModel articleComment)
        {
            _articleCommentRepository.Delete(id, articleComment);
            return RedirectToAction(nameof(Index));
        }
    }
}