using MiniBlog.Model;

namespace MiniBlog.Stores
{
    public class MockArticleStore : IArticleStore
    {
        public List<Article> Articles { get; set; } = new List<Article>();

        public Article Save(Article article)
        {
            this.Articles.Add(article);
            return article;
        }

        public List<Article> GetAll()
        {
            return this.Articles;
        }

        public bool Delete(Article articles)
        {
            return this.Articles.Remove(articles);
        }
    }
}
