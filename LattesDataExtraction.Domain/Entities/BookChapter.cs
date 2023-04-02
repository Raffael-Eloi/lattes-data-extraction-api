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

        public string PublisherCountry { get; set; } = string.Empty;

        public string ISBN { get; set; } = string.Empty;

        public int InitialPage { get; set; }

        public int FinalPage { get; set; }

        public string PublisherCity { get; set; } = string.Empty;

        public string PublisherName { get; set; } = string.Empty;

        public IEnumerable<Author>? Authors { get; set; }
    }
}