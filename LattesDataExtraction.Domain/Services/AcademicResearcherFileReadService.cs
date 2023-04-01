using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services
{
    internal class AcademicResearcherFileReadService : IAcademicResearcherFileReadService
    {
        public AcademicResearch? GetAcademicInformation(string academicResearcherFile)
        {
            XmlDocument document = new XmlDocument();

            document.Load(academicResearcherFile);

            var academicResearch = new AcademicResearch();

            XmlNodeList curriculumVitaeInformation = document.GetElementsByTagName("CURRICULO-VITAE");

            for (int i = 0; i < curriculumVitaeInformation.Count; i++)
            {
                string identifierNumber = curriculumVitaeInformation[i].Attributes["NUMERO-IDENTIFICADOR"].Value;
                academicResearch.IdentifierNumber = identifierNumber;
            }

            return academicResearch;
        }
    }
}