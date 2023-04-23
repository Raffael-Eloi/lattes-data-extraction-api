namespace LattesDataExtraction.Domain.Entities
{
    public class KnowledgeArea
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string SubAreaName { get; set; } = string.Empty;

        public string Specialty { get; set; } = string.Empty;
    }
}