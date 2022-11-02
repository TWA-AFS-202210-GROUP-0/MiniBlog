using MiniBlog.Model;

public interface IArticleService
{
    Article CreateArticle(Article article);
    List<Article> GetAllArticles();
    Article GetArticleById(Guid id);
}