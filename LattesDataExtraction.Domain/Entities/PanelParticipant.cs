namespace LattesDataExtraction.Domain.Entities
{
    public class PanelParticipant
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string FullName { get; set; } = string.Empty;

        public string CitationName { get; set; } = string.Empty;

        public string CNPQId { get; set; } = string.Empty;
    }
}