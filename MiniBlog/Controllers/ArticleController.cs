namespace MiniBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Services;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private ArticleService _articleService;
        
        public ArticleController(ArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public List<Article> List()
        {
            return _articleService.List();
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {
            var newArticle = _articleService.Create(article);
            var actionName = nameof(GetById);
            var routeValue = new { id = newArticle.Id };
            return CreatedAtAction(actionName, routeValue, newArticle);

        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            return _articleService.GetByID(id);
        }
    }
}