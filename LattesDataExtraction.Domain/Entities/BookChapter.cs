namespace LattesDataExtraction.Domain.Entities
{
    public class BookChapter
    {
        public string BookTitle { get; set; } = string.Empty;

        public string ChapterTitle { get; set; } = string.Empty;

        public string Organizers { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public DateOnly Year { get; set; }

        public string Language { get; set; } = string.Empty;

        public string HomePageLink { get; set; } = string.Empty;

        public string DOI { get; set; } = string.Empty;

        public string PublishCountry { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public int InitialPage { get; set; }

        public int finalPage { get; set; }

        public string PublishCity { get; set; } = string.Empty;

        public string PublisherName { get; set; } = string.Empty;

        public IEnumerable<Author>? Authors { get; set; }
    }
}
