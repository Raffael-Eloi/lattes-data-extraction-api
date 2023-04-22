using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetCompletedOrientationInformationService : IGetDataInformationService
    {
        private List<Orientation>? _completedOrientation;

        private Orientation? _orientation;

        private List<string>? _keyWords;

        private List<KnowledgeArea>? _knowledgeAreasList;

        private KnowledgeArea? _knowledgeArea;

        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            GetDataFromFile(academicResearcher, academicResearcherDocument);
        }

        private void GetDataFromFile(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            _completedOrientation = new();

            XmlNodeList completedOrientationInformation = academicResearcherDocument!.GetElementsByTagName("ORIENTACOES-CONCLUIDAS");

            if (completedOrientationInformation.Count < 0) return;

            foreach (XmlNode element in completedOrientationInformation)
            {
                if (element is null || element.ChildNodes is null || element.ChildNodes.Count == 0) continue;

                foreach (XmlNode allCompletedOrientationElements in element.ChildNodes)
                {
                    _orientation = new();

                    _keyWords = new();

                    _knowledgeAreasList = new();

                    foreach (XmlNode orientationElement in allCompletedOrientationElements.ChildNodes)
                    {
                        if (orientationElement is null) continue;

                        GetBasicData(orientationElement);

                        GetDetails(orientationElement);

                        GetKeyWorkds(orientationElement);

                        GetKnowledgeAreas(orientationElement);
                    }

                    _orientation.KeyWorkds= _keyWords;

                    _orientation.KnowledgeAreas= _knowledgeAreasList;

                    _completedOrientation.Add(_orientation!);
                }
            }

            academicResearcher.CompletedOrientation = _completedOrientation;
        }

        private void GetBasicData(XmlNode orientationElement)
        {
            if (orientationElement.Name is not null && orientationElement.Name == "DADOS-BASICOS-DE-OUTRAS-ORIENTACOES-CONCLUIDAS")
            {
                if (orientationElement.Attributes is null || orientationElement.Attributes.Count == 0) return;

                XmlAttributeCollection allOrientation = orientationElement.Attributes;

                foreach (XmlAttribute orientation in allOrientation)
                {
                    if (orientation is null || string.IsNullOrEmpty(orientation.Name) || string.IsNullOrEmpty(orientation.Value)) continue;

                    if (orientation.Name == "NATUREZA")
                    {
                        _orientation!.NatureOfWork = orientation.Value;
                    }

                    if (orientation.Name == "TITULO")
                    {
                        _orientation!.Title = orientation.Value;
                    }

                    if (orientation.Name == "ANO")
                    {
                        _orientation!.Year = new DateOnly(int.Parse(orientation.Value), 1, 1);
                    }

                    if (orientation.Name == "PAIS")
                    {
                        _orientation!.Country = orientation.Value;
                    }

                    if (orientation.Name == "IDIOMA")
                    {
                        _orientation!.Language = orientation.Value;
                    }
                }
            }
        }

        private void GetDetails(XmlNode orientationElement)
        {
            if (orientationElement.Name is not null && orientationElement.Name == "DETALHAMENTO-DE-OUTRAS-ORIENTACOES-CONCLUIDAS")
            {
                if (orientationElement.Attributes is null || orientationElement.Attributes.Count == 0) return;

                XmlAttributeCollection allOrientation = orientationElement.Attributes;

                foreach (XmlAttribute orientation in allOrientation)
                {
                    if (orientation is null || string.IsNullOrEmpty(orientation.Name) || string.IsNullOrEmpty(orientation.Value)) continue;

                    if (orientation.Name == "NOME-DO-ORIENTADO")
                    {
                        _orientation!.AcademicOrientedFullName = orientation.Value;
                    }

                    if (orientation.Name == "CODIGO-INSTITUICAO")
                    {
                        _orientation!.InstitutionCode = orientation.Value;
                    }

                    if (orientation.Name == "NOME-DA-INSTITUICAO")
                    {
                        _orientation!.InstitutionName = orientation.Value;
                    }
                    
                    if (orientation.Name == "CODIGO-CURSO")
                    {
                        _orientation!.CourseCode = orientation.Value;
                    }
                    
                    if (orientation.Name == "NOME-DO-CURSO")
                    {
                        _orientation!.CourseName = orientation.Value;
                    }
                    
                    if (orientation.Name == "TIPO-DE-ORIENTACAO-CONCLUIDA")
                    {
                        _orientation!.Type = orientation.Value;
                    }
                }
            }
        }

        private void GetKeyWorkds(XmlNode orientationElement)
        {
            if (orientationElement.Name is not null && orientationElement.Name == "PALAVRAS-CHAVE")
            {
                if (orientationElement.Attributes is null || orientationElement.Attributes.Count == 0) return;

                XmlAttributeCollection KeyWorkds = orientationElement.Attributes;

                foreach (XmlAttribute keyWord in KeyWorkds)
                {
                    if (keyWord is null || string.IsNullOrEmpty(keyWord.Name) || string.IsNullOrEmpty(keyWord.Value)) continue;

                    _keyWords!.Add(keyWord.Value);
                }
            }
        }
        
        private void GetKnowledgeAreas(XmlNode orientationElement)
        {
            if (orientationElement.Name is not null && orientationElement.Name == "AREAS-DO-CONHECIMENTO")
            {
                if (orientationElement.ChildNodes is null || orientationElement.ChildNodes.Count == 0) return;

                XmlNodeList allCompletedOrientation = orientationElement.ChildNodes;

                foreach (XmlNode allOrientation in allCompletedOrientation)
                {
                    if (allOrientation.Attributes is null || allOrientation.Attributes.Count == 0) return;

                    _knowledgeArea = new();

                    foreach (XmlAttribute orientation in allOrientation.Attributes)
                    {
                        if (orientation is null || string.IsNullOrEmpty(orientation.Name) || string.IsNullOrEmpty(orientation.Value)) continue;

                        if (orientation.Name == "NOME-GRANDE-AREA-DO-CONHECIMENTO")
                        {
                            _knowledgeArea.Name = orientation.Value;
                        }
                        
                        if (orientation.Name == "NOME-DA-SUB-AREA-DO-CONHECIMENTO")
                        {
                            _knowledgeArea.SubAreaName = orientation.Value;
                        }
                        
                        if (orientation.Name == "NOME-DA-ESPECIALIDADE")
                        {
                            _knowledgeArea.Specialty = orientation.Value;
                        }
                    }

                    _knowledgeAreasList!.Add(_knowledgeArea);
                }
            }
        }
    }
}