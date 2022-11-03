using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MiniBlog.Model;
using MiniBlog.Stores;

namespace MiniBlog.Services
{
    public interface IArticleService
    {
        public Article Create(Article article);
        public List<Article> List();
        public Article GetById(Guid id);
    }
}
