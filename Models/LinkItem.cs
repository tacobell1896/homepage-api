namespace HomePageApi.Models;
    public class LinkItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Href { get; set; }
        public long CategoryId { get; set; }
    }