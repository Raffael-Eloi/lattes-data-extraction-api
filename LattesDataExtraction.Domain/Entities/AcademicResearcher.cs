namespace LattesDataExtraction.Domain.Entities
{
    public class AcademicResearcher
    {
        public Guid Id { get; set; }

        public string IdentifierNumber { get; set; } = string.Empty;

        public string LattesId { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string ProfessionalDescription { get; set; } = string.Empty;

        public string CitationName { get; set; } = string.Empty;

        public string CountryOfBirth { get; set; } = string.Empty;

        public string StateOfBirth { get; set; } = string.Empty;

        public string CityOfBirth { get; set; } = string.Empty;

        public string CountryCode { get; set; } = string.Empty;

        public string NationalityCountry { get; set; } = string.Empty;

        public string OrcidId { get; set; } = string.Empty;

        public ProfessionalAddress? ProfessionalAddress { get; set; }

        public IEnumerable<AcademicBackground>? AcademicBackground { get; set; }

        public IEnumerable<ScientificArticle>? PublishedArticles { get; set; }

        public IEnumerable<Book>? BooksPublishedOrOrganized { get; set; }

        public IEnumerable<BookChapter>? BooksChaptersPublished { get; set; }

        public IEnumerable<Event>? WorkAtEvents { get; set; }

        public IEnumerable<BibliographicProduction>? OthersBibliographicProductions { get; set; }

        public IEnumerable<Software>? TechnicalProductions { get; set; }

        public IEnumerable<Orientation>? CompletedOrientation { get; set; }

        public IEnumerable<ComplementaryCourse>? ComplementaryCourses { get; set; }

        public IEnumerable<FinalPaperPanel>? ParticipationInFinalPaperPanel { get; set; }
    }
}