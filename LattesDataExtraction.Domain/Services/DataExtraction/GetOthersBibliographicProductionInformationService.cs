using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetOthersBibliographicProductionInformationService : IGetDataInformationService
    {
        private List<BibliographicProduction>? _bibliographicProductionList;

        private BibliographicProduction? _bibliographicProduction;

        private List<Author>? _authors;

        private Author? _author;

        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            GetDataFromFile(academicResearcher, academicResearcherDocument);
        }

        private void GetDataFromFile(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            _bibliographicProductionList = new();

            XmlNodeList othersBibliographicProductionInformation = academicResearcherDocument!.GetElementsByTagName("DEMAIS-TIPOS-DE-PRODUCAO-BIBLIOGRAFICA");

            if (othersBibliographicProductionInformation.Count < 0) return;

            foreach (XmlNode element in othersBibliographicProductionInformation)
            {
                if (element is null || element.ChildNodes is null || element.ChildNodes.Count == 0) continue;

                foreach (XmlNode bibliographicProductionElements in element.ChildNodes)
                {
                    _bibliographicProduction = new();

                    _authors = new();

                    foreach (XmlNode bibliographicProduction in bibliographicProductionElements.ChildNodes)
                    {
                        _author = new();

                        if (bibliographicProduction is null) continue;

                        GetBasicData(bibliographicProduction);

                        GetAuthors(bibliographicProduction);
                    }

                    _bibliographicProduction.Authors = _authors;

                    _bibliographicProductionList.Add(_bibliographicProduction!);
                }
            }

            academicResearcher.OthersBibliographicProductions = _bibliographicProductionList;
        }

        private void GetBasicData(XmlNode bibliographicProductionElement)
        {
            if (bibliographicProductionElement.Name is not null && bibliographicProductionElement.Name == "DADOS-BASICOS-DE-OUTRA-PRODUCAO")
            {
                if (bibliographicProductionElement.Attributes is null || bibliographicProductionElement.Attributes.Count == 0) return;

                XmlAttributeCollection bibliographicProduction = bibliographicProductionElement.Attributes;

                foreach (XmlAttribute eachBibliographicProduction in bibliographicProduction)
                {
                    if (eachBibliographicProduction is null || string.IsNullOrEmpty(eachBibliographicProduction.Name) || string.IsNullOrEmpty(eachBibliographicProduction.Value)) continue;

                    if (eachBibliographicProduction.Name == "NATUREZA")
                    {
                        _bibliographicProduction!.NatureOfWork = eachBibliographicProduction.Value;
                    }

                    if (eachBibliographicProduction.Name == "TITULO")
                    {
                        _bibliographicProduction!.Title = eachBibliographicProduction.Value;
                    }

                    if (eachBibliographicProduction.Name == "ANO")
                    {
                        _bibliographicProduction!.Year = new DateOnly(int.Parse(eachBibliographicProduction.Value), 1, 1);
                    }

                    if (eachBibliographicProduction.Name == "PAIS-DE-PUBLICACAO")
                    {
                        _bibliographicProduction!.Country = eachBibliographicProduction.Value;
                    }

                    if (eachBibliographicProduction.Name == "IDIOMA")
                    {
                        _bibliographicProduction!.Language = eachBibliographicProduction.Value;
                    }

                    if (eachBibliographicProduction.Name == "HOME-PAGE-DO-TRABALHO")
                    {
                        _bibliographicProduction!.HomePageLink = eachBibliographicProduction.Value;
                    }
                }
            }
        }

        private void GetAuthors(XmlNode bibliographicProductionElement)
        {
            if (bibliographicProductionElement.Name is not null && bibliographicProductionElement.Name == "AUTORES")
            {
                if (bibliographicProductionElement.Attributes is null || bibliographicProductionElement.Attributes.Count == 0) return;

                XmlAttributeCollection bibliographicProduction = bibliographicProductionElement.Attributes;

                foreach (XmlAttribute eachBibliographicProduction in bibliographicProduction)
                {
                    if (eachBibliographicProduction is null || string.IsNullOrEmpty(eachBibliographicProduction.Name) || string.IsNullOrEmpty(eachBibliographicProduction.Value)) continue;

                    if (eachBibliographicProduction.Name == "NOME-COMPLETO-DO-AUTOR")
                    {
                        _author!.FullName = eachBibliographicProduction.Value;
                    }

                    if (eachBibliographicProduction.Name == "NOME-PARA-CITACAO")
                    {
                        _author!.CitationName = eachBibliographicProduction.Value;
                    }

                    if (eachBibliographicProduction.Name == "NRO-ID-CNPQ")
                    {
                        _author!.CNPQId = eachBibliographicProduction.Value;
                    }
                }

                _authors!.Add(_author!);
            }
        }
    }
}