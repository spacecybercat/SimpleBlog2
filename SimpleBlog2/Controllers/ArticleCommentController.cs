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
    public class ArticleCommentController : Controller
    {
        private readonly IArticleCommentRepository _articleCommentRepository;
        private readonly IArticleRepository _articleRepository;

        public ArticleCommentController(IArticleCommentRepository articleCommentRepository, IArticleRepository articleRepository)
        {
            _articleCommentRepository = articleCommentRepository;
            _articleRepository = articleRepository;
        }

        // GET: ArticleComment
        public ActionResult Index()
        {
            var viewModel = new ArticleCommentManageViewModel { ArticleComments = _articleCommentRepository.GetAll().ToList(), Articles = _articleRepository.GetAll().ToList() };
            return View(viewModel);
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

        //// POST: ArticleComment/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(ArticleCommentModel articleComment)
        //{
        //    _articleCommentRepository.Add(articleComment);
        //    return RedirectToAction("Details", "Article", new { id = articleComment.ArticleId});
        //}

        // POST: ArticleComment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleDetailsViewModel viewModel)
        {
            _articleCommentRepository.Add(viewModel);
            return RedirectToAction("Details", "Article", new { id = viewModel.NewComment.ArticleId });
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