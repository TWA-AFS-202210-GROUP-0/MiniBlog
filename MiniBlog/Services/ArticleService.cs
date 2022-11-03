using MiniBlog.Model;
using MiniBlog.Stores;

public class ArticleService : IArticleService
{
    private IArticleStore articleStore;
    private IUserStore userStore;

    public ArticleService(IArticleStore articleStore, IUserStore userStore)
    {
        this.articleStore = articleStore;
        this.userStore = userStore;
    }

    public List<Article> GetAllArticles()
    {
        return articleStore.GetAll();
    }

    public Article CreateArticle(Article article)
    {
        try
        {
            if (article.UserName != null)
            {
                if (!this.userStore.GetAll().Exists(_ => article.UserName == _.Name))
                {
                    this.userStore.Save(new User(article.UserName));
                }

                this.articleStore.Save(article);
                return article;
            }

            return null;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public Article GetArticleById(Guid id)
    {
        return this.articleStore.GetAll().FirstOrDefault(article => article.Id == id);
    }

}