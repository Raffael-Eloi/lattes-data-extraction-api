namespace LattesDataExtraction.Domain.Entities
{
    public class Software
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string NatureOfWork { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;
        
        public string Language { get; set; } = string.Empty;
        
        public string Purpose { get; set; } = string.Empty;
        
        public string Platform { get; set; } = string.Empty;
        
        public string Availability { get; set; } = string.Empty;
        
        public string FinancingInstituition { get; set; } = string.Empty;

        public DateOnly Year { get; set; }

        public IEnumerable<Author> Authors { get; set; } = Enumerable.Empty<Author>();
    }
}