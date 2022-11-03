using MiniBlog.Model;

namespace MiniBlog.Service
{
    public interface IArticleService
    {

        Article Create(Article article);

        Article GetById(Guid id);

        List<Article> getAll();
    }
}
