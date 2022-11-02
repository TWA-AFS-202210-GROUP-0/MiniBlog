namespace MiniBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Stores;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private IArticleStore articleStore;
        private IUserStore userStore;
        private IArticleService articleService;

        public ArticleController(IArticleStore articleStore, IUserStore userStore, IArticleService articleService)
        {
            this.articleStore = articleStore;
            this.userStore = userStore;
            this.articleService = articleService;
        }

        [HttpGet]
        public ActionResult<List<Article>> List()
        {
            var articles = this.articleService.GetAllArticles();
            return articles == null ? NoContent() : Ok(articles);
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            var newArticle = this.articleService.CreateArticle(article);

            var actionName = nameof(GetById);
            var routeValue = new { id = newArticle.Id };
            return newArticle != null ? CreatedAtAction(actionName, routeValue, newArticle) : StatusCode(500);
        }

        [HttpGet("{id}")]
        public ActionResult<Article> GetById(Guid id)
        {
            var foundArticle = this.articleService.GetArticleById(id);
            return foundArticle == null ? NotFound() : Ok(foundArticle);
        }
    }
}