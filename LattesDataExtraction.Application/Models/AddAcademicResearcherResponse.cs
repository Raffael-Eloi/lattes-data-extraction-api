using Flunt.Notifications;

namespace LattesDataExtraction.Application.Models
{
    public class AddAcademicResearcherResponse : Notifiable<Notification>
    {
        public Guid AcademicResearcherId { get; set; }

        public bool Success => IsValid;
    }
}