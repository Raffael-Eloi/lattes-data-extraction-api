using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetOrientationInProgressInformationService : IGetDataInformationService
    {
        private List<Orientation>? _orientationInProgressList;

        private Orientation? _orientationInProgress;

        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            GetDataFromFile(academicResearcher, academicResearcherDocument);
        }

        private void GetDataFromFile(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            _orientationInProgressList = new();

            XmlNodeList orientationInProgressInformation = academicResearcherDocument!.GetElementsByTagName("ORIENTACOES-EM-ANDAMENTO");

            if (orientationInProgressInformation.Count < 0) return;

            foreach (XmlNode element in orientationInProgressInformation)
            {
                if (element is null || element.ChildNodes is null || element.ChildNodes.Count == 0) continue;

                foreach (XmlNode allOrientationInProgressElements in element.ChildNodes)
                {
                    _orientationInProgress = new();

                    foreach (XmlNode orientationInProgressElement in allOrientationInProgressElements.ChildNodes)
                    {
                        if (orientationInProgressElement is null) continue;

                        GetBasicData(orientationInProgressElement);

                        GetDetails(orientationInProgressElement);
                    }

                    _orientationInProgressList.Add(_orientationInProgress!);
                }
            }

            academicResearcher.OrientationInProgress = _orientationInProgressList;
        }

        private void GetBasicData(XmlNode orientationInProgressElement)
        {
            if (orientationInProgressElement.Name is not null && orientationInProgressElement.Name == "DADOS-BASICOS-DA-ORIENTACAO-EM-ANDAMENTO-DE-INICIACAO-CIENTIFICA")
            {
                if (orientationInProgressElement.Attributes is null || orientationInProgressElement.Attributes.Count == 0) return;

                XmlAttributeCollection allOrientationInProgress = orientationInProgressElement.Attributes;

                foreach (XmlAttribute orientationInProgress in allOrientationInProgress)
                {
                    if (orientationInProgress is null || string.IsNullOrEmpty(orientationInProgress.Name) || string.IsNullOrEmpty(orientationInProgress.Value)) continue;

                    if (orientationInProgress.Name == "NATUREZA")
                    {
                        _orientationInProgress!.NatureOfWork = orientationInProgress.Value;
                    }

                    if (orientationInProgress.Name == "TITULO-DO-TRABALHO")
                    {
                        _orientationInProgress!.Title = orientationInProgress.Value;
                    }

                    if (orientationInProgress.Name == "ANO")
                    {
                        _orientationInProgress!.Year = new DateOnly(int.Parse(orientationInProgress.Value), 1, 1);
                    }

                    if (orientationInProgress.Name == "PAIS")
                    {
                        _orientationInProgress!.Country = orientationInProgress.Value;
                    }

                    if (orientationInProgress.Name == "IDIOMA")
                    {
                        _orientationInProgress!.Language = orientationInProgress.Value;
                    }
                }
            }
        }

        private void GetDetails(XmlNode orientationInProgressElement)
        {
            if (orientationInProgressElement.Name is not null && orientationInProgressElement.Name == "DETALHAMENTO-DA-ORIENTACAO-EM-ANDAMENTO-DE-INICIACAO-CIENTIFICA")
            {
                if (orientationInProgressElement.Attributes is null || orientationInProgressElement.Attributes.Count == 0) return;

                XmlAttributeCollection allOrientationInProgress = orientationInProgressElement.Attributes;

                foreach (XmlAttribute orientationInProgress in allOrientationInProgress)
                {
                    if (orientationInProgress is null || string.IsNullOrEmpty(orientationInProgress.Name) || string.IsNullOrEmpty(orientationInProgress.Value)) continue;

                    if (orientationInProgress.Name == "NOME-DO-ORIENTANDO")
                    {
                        _orientationInProgress!.AcademicOrientedFullName = orientationInProgress.Value;
                    }

                    if (orientationInProgress.Name == "CODIGO-INSTITUICAO")
                    {
                        _orientationInProgress!.InstitutionCode = orientationInProgress.Value;
                    }

                    if (orientationInProgress.Name == "NOME-INSTITUICAO")
                    {
                        _orientationInProgress!.InstitutionName = orientationInProgress.Value;
                    }

                    if (orientationInProgress.Name == "CODIGO-CURSO")
                    {
                        _orientationInProgress!.CourseCode = orientationInProgress.Value;
                    }

                    if (orientationInProgress.Name == "NOME-CURSO")
                    {
                        _orientationInProgress!.CourseName = orientationInProgress.Value;
                    }
                }
            }
        }
    }
}