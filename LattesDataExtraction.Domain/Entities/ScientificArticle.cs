namespace LattesDataExtraction.Domain.Entities
{
    public class ScientificArticle
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;
        
        public DateOnly ArticleYear { get; set; }

        public string Language { get; set; } = string.Empty;

        public string DOI { get; set; } = string.Empty;
        
        public string ISSN { get; set; } = string.Empty;
        
        public string Series { get; set; } = string.Empty;
        
        public string Volume { get; set; } = string.Empty;

        public string TitleOfJornalOrMagazine { get; set; } = string.Empty;

        public int InitialPage { get; set; }

        public IEnumerable<Author> Authors { get; set; } = Enumerable.Empty<Author>();
    }
}