namespace OpenseaBlzui.Models
{
    public class ArticleInfo
    {
        public int ArticleId { get; set; }

        public string Titile { get; set; }

        public string Text { get; set; }

        public string CreateUser { get; set; }

        public DateTime? CreateDate { get; set; }

        public string UpdateUser { get; set; }

        public DateTime? UpdateDate { get; set; }
    }
}
