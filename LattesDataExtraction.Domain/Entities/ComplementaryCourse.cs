namespace LattesDataExtraction.Domain.Entities
{
    public class ComplementaryCourse
    {
        public string Name { get; set; } = string.Empty;
        
        public string Code { get; set; } = string.Empty;
        
        public string Status { get; set; } = string.Empty;

        public DateOnly StartYear { get; set; }

        public DateOnly EndYear { get; set; }

        public int DurationInHours { get; set; }

        public string InstitutionName { get; set; } = string.Empty;

        public string InstitutionCode { get; set; } = string.Empty;
    }
}