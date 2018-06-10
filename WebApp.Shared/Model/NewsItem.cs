namespace WebApp.Shared.Model
{
    public class NewsItem
    {
        public NewsItem()
        {
            
        }

        public NewsItem(int id, string title, string content)
        {
            Id = id;
            Title = title;
            Content = content;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Likes { get; set; }
    }
}