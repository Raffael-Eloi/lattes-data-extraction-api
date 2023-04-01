using LattesDataExtraction.Domain.Enums;

namespace LattesDataExtraction.Domain.Entities
{
    public class AcademicBackground
    {
        public AcademicBackgroundType AcademicBackgroundType { get; set; }
        
        public string CourseName { get; set; } = string.Empty;

        public string CourseCode { get; set; } = string.Empty;

        public string CourseStatus { get; set; } = string.Empty;

        public string AreaCourseCode { get; set; } = string.Empty;

        public string InstituitionName { get; set; } = string.Empty;

        public string InstituitionCode { get; set; } = string.Empty;

        public DateOnly StartYear { get; set; }

        public DateOnly EndYear { get; set; }

        public string FinalPaperTitle { get; set; } = string.Empty;

        public string AdvisorName { get; set; } = string.Empty;
    }
}