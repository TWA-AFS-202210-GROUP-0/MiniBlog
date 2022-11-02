namespace MiniBlog.Services
{
    using MiniBlog.Model;

    public interface IArticleService
    {
        public Article Create(Article article);
    }
}