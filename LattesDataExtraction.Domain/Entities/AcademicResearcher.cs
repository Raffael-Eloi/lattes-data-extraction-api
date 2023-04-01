﻿namespace LattesDataExtraction.Domain.Entities
{
    public class AcademicResearcher
    {
        public AcademicResearcher()
        {
            ProfessionalAddress = new ProfessionalAddress();
        }

        public Guid Id { get; set; }

        public string IdentifierNumber { get; set; } = string.Empty;

        public string FullName { get; set; } = string.Empty;

        public string ProfessionalDescription { get; set; } = string.Empty;

        public string CitationName { get; set; } = string.Empty;

        public string Nationality { get; set; } = string.Empty;

        public string CountryOfBirth { get; set; } = string.Empty;

        public string StateOfBirth { get; set; } = string.Empty;

        public string CityOfBirth { get; set; } = string.Empty;

        public string CountryCode { get; set; } = string.Empty;

        public string NationalityCountry { get; set; } = string.Empty;

        public string OrcidId { get; set; } = string.Empty;

        public ProfessionalAddress ProfessionalAddress { get; set; }
    }
}