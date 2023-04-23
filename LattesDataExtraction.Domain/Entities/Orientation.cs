namespace LattesDataExtraction.Domain.Entities
{
    public class Orientation
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string NatureOfWork { get; set; } = string.Empty;
        
        public string Country { get; set; } = string.Empty;
        
        public string Language { get; set; } = string.Empty;

        public DateOnly Year { get; set; }

        public string AcademicOrientedFullName { get; set; } = string.Empty;

        public string InstitutionCode { get; set; } = string.Empty;

        public string InstitutionName { get; set; } = string.Empty;

        public string CourseCode { get; set; } = string.Empty;

        public string CourseName { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public IEnumerable<KeyWord> KeyWords { get; set; } = Enumerable.Empty<KeyWord>();
        
        public IEnumerable<KnowledgeArea> KnowledgeAreas { get; set; } = Enumerable.Empty<KnowledgeArea>();
    }
}