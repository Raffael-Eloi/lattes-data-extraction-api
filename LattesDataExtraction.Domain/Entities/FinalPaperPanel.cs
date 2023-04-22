namespace LattesDataExtraction.Domain.Entities
{
    public class FinalPaperPanel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Title { get; set; } = string.Empty;

        public string NatureOfWork { get; set; } = string.Empty;

        public DateOnly Year { get; set; }

        public string Country { get; set; } = string.Empty;

        public string Language { get; set; } = string.Empty;

        public string CandidateFullName { get; set; } = string.Empty;

        public string InstitutionCode { get; set; } = string.Empty;

        public string InstitutionName { get; set; } = string.Empty;

        public string CourseCode { get; set; } = string.Empty;

        public string CourseName { get; set; } = string.Empty;

        public IEnumerable<PanelParticipant> Participants { get; set; } = Enumerable.Empty<PanelParticipant>();

        public IEnumerable<KnowledgeArea> KnowledgeAreas { get; set; } = Enumerable.Empty<KnowledgeArea>();
    }
}