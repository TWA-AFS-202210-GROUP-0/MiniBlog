namespace MiniBlog.Services
{
    using MiniBlog.Model;

    public interface IArticleService
    {
        Article Create(Article article);
        List<Article> List();
        Article GetByID(Guid id);
    }
}