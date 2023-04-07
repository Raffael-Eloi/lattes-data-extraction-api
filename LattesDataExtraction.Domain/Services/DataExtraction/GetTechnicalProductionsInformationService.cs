using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetTechnicalProductionsInformationService : IGetDataInformationService
    {
        private List<Software>? _softwares;

        private Software? _software;

        private List<Author>? _authors;

        private Author? _author;

        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            GetDataFromFile(academicResearcher, academicResearcherDocument);
        }

        private void GetDataFromFile(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            _softwares = new();

            XmlNodeList technicalProductionsInformation = academicResearcherDocument!.GetElementsByTagName("PRODUCAO-TECNICA");

            if (technicalProductionsInformation.Count < 0) return;

            foreach (XmlNode element in technicalProductionsInformation)
            {
                if (element is null || element.ChildNodes is null || element.ChildNodes.Count == 0) continue;

                foreach (XmlNode allTechnicalProductionElements in element.ChildNodes)
                {
                    _software = new();

                    _authors = new();

                    foreach (XmlNode technicalProduction in allTechnicalProductionElements.ChildNodes)
                    {
                        _author = new();

                        if (technicalProduction is null) continue;

                        GetBasicData(technicalProduction);

                        GetDetails(technicalProduction);

                        GetAuthors(technicalProduction);
                    }

                    _software.Authors = _authors;

                    _softwares.Add(_software!);
                }
            }

            academicResearcher.TechnicalProductions = _softwares;
        }

        private void GetBasicData(XmlNode technicalProductionElement)
        {
            if (technicalProductionElement.Name is not null && technicalProductionElement.Name == "DADOS-BASICOS-DO-SOFTWARE")
            {
                if (technicalProductionElement.Attributes is null || technicalProductionElement.Attributes.Count == 0) return;

                XmlAttributeCollection technicalProductions = technicalProductionElement.Attributes;

                foreach (XmlAttribute technicalProduction in technicalProductions)
                {
                    if (technicalProduction is null || string.IsNullOrEmpty(technicalProduction.Name) || string.IsNullOrEmpty(technicalProduction.Value)) continue;

                    if (technicalProduction.Name == "NATUREZA")
                    {
                        _software!.NatureOfWork = technicalProduction.Value;
                    }

                    if (technicalProduction.Name == "TITULO-DO-SOFTWARE")
                    {
                        _software!.Title = technicalProduction.Value;
                    }

                    if (technicalProduction.Name == "ANO")
                    {
                        _software!.Year = new DateOnly(int.Parse(technicalProduction.Value), 1, 1);
                    }

                    if (technicalProduction.Name == "PAIS")
                    {
                        _software!.Country = technicalProduction.Value;
                    }

                    if (technicalProduction.Name == "IDIOMA")
                    {
                        _software!.Language = technicalProduction.Value;
                    }
                }
            }
        }

        private void GetDetails(XmlNode technicalProductionElement)
        {
            if (technicalProductionElement.Name is not null && technicalProductionElement.Name == "DETALHAMENTO-DO-SOFTWARE")
            {
                if (technicalProductionElement.Attributes is null || technicalProductionElement.Attributes.Count == 0) return;

                XmlAttributeCollection technicalProductions = technicalProductionElement.Attributes;

                foreach (XmlAttribute technicalProduction in technicalProductions)
                {
                    if (technicalProduction is null || string.IsNullOrEmpty(technicalProduction.Name) || string.IsNullOrEmpty(technicalProduction.Value)) continue;

                    if (technicalProduction.Name == "FINALIDADE")
                    {
                        _software!.Purpose = technicalProduction.Value;
                    }

                    if (technicalProduction.Name == "PLATAFORMA")
                    {
                        _software!.Platform = technicalProduction.Value;
                    }

                    if (technicalProduction.Name == "DISPONIBILIDADE")
                    {
                        _software!.Availability = technicalProduction.Value;
                    }

                    if (technicalProduction.Name == "INSTITUICAO-FINANCIADORA")
                    {
                        _software!.FinancingInstituition = technicalProduction.Value;
                    }
                }
            }
        }

        private void GetAuthors(XmlNode technicalProductionElement)
        {
            if (technicalProductionElement.Name is not null && technicalProductionElement.Name == "AUTORES")
            {
                if (technicalProductionElement.Attributes is null || technicalProductionElement.Attributes.Count == 0) return;

                XmlAttributeCollection technicalProductions = technicalProductionElement.Attributes;

                foreach (XmlAttribute technicalProduction in technicalProductions)
                {
                    if (technicalProduction is null || string.IsNullOrEmpty(technicalProduction.Name) || string.IsNullOrEmpty(technicalProduction.Value)) continue;

                    if (technicalProduction.Name == "NOME-COMPLETO-DO-AUTOR")
                    {
                        _author!.FullName = technicalProduction.Value;
                    }

                    if (technicalProduction.Name == "NOME-PARA-CITACAO")
                    {
                        _author!.CitationName = technicalProduction.Value;
                    }

                    if (technicalProduction.Name == "NRO-ID-CNPQ")
                    {
                        _author!.CNPQId = technicalProduction.Value;
                    }
                }

                _authors!.Add(_author!);
            }
        }
    }
}