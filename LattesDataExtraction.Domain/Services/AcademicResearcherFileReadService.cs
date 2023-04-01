using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services
{
    internal class AcademicResearcherFileReadService : IAcademicResearcherFileReadService
    {
        private XmlDocument? _academicResearcherDocument;

        private AcademicResearch? _academicResearch;

        public AcademicResearch? GetAcademicInformation(string academicResearcherFile)
        {
            LoadXmlFile(academicResearcherFile);

            GetCurriculumInformationIfExist();

            return _academicResearch;
        }

        private void LoadXmlFile(string academicResearcherFile)
        {
            _academicResearcherDocument = new();

            _academicResearcherDocument.Load(academicResearcherFile);
        }

        private void GetCurriculumInformationIfExist()
        {
            _academicResearch = new();

            XmlNodeList curriculumVitaeInformation = _academicResearcherDocument.GetElementsByTagName("CURRICULO-VITAE");
            
            if (curriculumVitaeInformation.Count < 0) return;

            foreach (XmlNode element in curriculumVitaeInformation)
            {
                if (element.Attributes != null && element.Attributes.Count > 0)
                {
                    XmlAttribute? identifierNumber = element.Attributes["NUMERO-IDENTIFICADOR"];

                    if (identifierNumber != null)
                    {
                        _academicResearch.IdentifierNumber = identifierNumber.Value;
                    }
                }

            }
        }
    }
}