﻿namespace MiniBlog.Controllers
{
    using System;
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;
    using MiniBlog.Model;
    using MiniBlog.Services;
    using MiniBlog.Stores;

    [ApiController]
    [Route("[controller]")]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleStore _articleStore;
        private readonly IUserStore _userStore;
        private IArticleService _articleService;
        public ArticleController(IArticleStore articleStore, IUserStore userStore, IArticleService articleService)
        {
            _articleStore = articleStore;
            _userStore = userStore;
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
             return Created($"/article/{article.Id}", _articleService.Create(article));
        }

        [HttpGet("{id}")]
        public Article GetById(Guid id)
        {
            var foundArticle =
                _articleStore.GetAll().FirstOrDefault(article => article.Id == id);
            return foundArticle;
        }
    }
}