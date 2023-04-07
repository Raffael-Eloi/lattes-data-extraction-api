namespace LattesDataExtraction.Domain.Entities
{
    public class BibliographicProduction
    {
        public string Title { get; set; } = string.Empty;

        public string NatureOfWork { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;
        
        public string HomePageLink { get; set; } = string.Empty;

        public DateOnly Year { get; set; }

        public IEnumerable<Author> Authors { get; set; }
    }
}