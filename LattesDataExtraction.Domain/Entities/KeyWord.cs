namespace LattesDataExtraction.Domain.Entities
{
    public class KeyWord
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; } = string.Empty;
    }
}