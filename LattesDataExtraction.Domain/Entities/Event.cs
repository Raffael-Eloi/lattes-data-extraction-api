namespace LattesDataExtraction.Domain.Entities
{
    public class Event
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;

        public string WorkTitle { get; set; } = string.Empty;

        public string NatureOfWork { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public string AnnalsTitle { get; set; } = string.Empty;

        public int InitialPage { get; set; }

        public int FinalPage { get; set; }
        
        public string PublisherCity { get; set; } = string.Empty;

        public string Classification { get; set; } = string.Empty;

        public string HomePageLink { get; set; } = string.Empty;

        public DateOnly WorkYear { get; set; }
        
        public DateOnly RealizationYear { get; set; }

        public IEnumerable<Author> Authors { get; set; } = Enumerable.Empty<Author>();
    }
}