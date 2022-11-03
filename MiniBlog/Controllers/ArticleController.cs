namespace MiniBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Service;
    using MiniBlog.Stores;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {

       private IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [HttpGet]
        public List<Article> List()
        {
            return _articleService.getAll();
        }

        [HttpPost]
        public ActionResult<Article> Create(Article article)
        {

            _articleService.Create(article);
            return new CreatedResult("created article", article);
        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            return _articleService.GetById(id);
        }
    }
}