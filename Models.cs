
namespace SampleMySqlEfCore
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationDate { get; set; }
    }
    
    public class BookDTO
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public DateTime PublicationDate { get; set; }

    }
}
