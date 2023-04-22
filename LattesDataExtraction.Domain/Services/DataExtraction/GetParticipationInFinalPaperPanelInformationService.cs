using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetParticipationInFinalPaperPanelInformationService : IGetDataInformationService
    {
        private List<FinalPaperPanel>? _finalPaperPanelList;

        private FinalPaperPanel? _finalPaperPanel;

        private List<PanelParticipant>? _participants;

        private List<KnowledgeArea>? _knowledgeAreasList;

        private KnowledgeArea? _knowledgeArea;

        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            GetDataFromFile(academicResearcher, academicResearcherDocument);
        }

        private void GetDataFromFile(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            _finalPaperPanelList = new();

            XmlNodeList participationInFinalPaperPanelInformation = academicResearcherDocument!.GetElementsByTagName("PARTICIPACAO-EM-BANCA-TRABALHOS-CONCLUSAO");

            if (participationInFinalPaperPanelInformation.Count < 0) return;

            foreach (XmlNode element in participationInFinalPaperPanelInformation)
            {
                if (element is null || element.ChildNodes is null || element.ChildNodes.Count == 0) continue;

                foreach (XmlNode allFinalPaperPanelsElements in element.ChildNodes)
                {
                    _finalPaperPanel = new();

                    _participants = new();

                    _knowledgeAreasList = new();

                    foreach (XmlNode finalPaperPanel in allFinalPaperPanelsElements.ChildNodes)
                    {
                        if (finalPaperPanel is null) continue;

                        GetBasicData(finalPaperPanel);

                        GetDetails(finalPaperPanel);

                        GetParticipants(finalPaperPanel);

                        GetKnowledgeAreas(finalPaperPanel);
                    }

                    _finalPaperPanel.Participants = _participants;

                    _finalPaperPanel.KnowledgeAreas = _knowledgeAreasList;

                    _finalPaperPanelList.Add(_finalPaperPanel!);
                }
            }

            academicResearcher.ParticipationOnFinalPaperPanel = _finalPaperPanelList;
        }

        private void GetBasicData(XmlNode finalPaperPanelElement)
        {
            if (finalPaperPanelElement.Name is not null && finalPaperPanelElement.Name == "DADOS-BASICOS-DA-PARTICIPACAO-EM-BANCA-DE-GRADUACAO")
            {
                if (finalPaperPanelElement.Attributes is null || finalPaperPanelElement.Attributes.Count == 0) return;

                XmlAttributeCollection allFinalPaperPanel = finalPaperPanelElement.Attributes;

                foreach (XmlAttribute finalPaperPanel in allFinalPaperPanel)
                {
                    if (finalPaperPanel is null || string.IsNullOrEmpty(finalPaperPanel.Name) || string.IsNullOrEmpty(finalPaperPanel.Value)) continue;

                    if (finalPaperPanel.Name == "NATUREZA")
                    {
                        _finalPaperPanel!.NatureOfWork = finalPaperPanel.Value;
                    }

                    if (finalPaperPanel.Name == "TITULO")
                    {
                        _finalPaperPanel!.Title = finalPaperPanel.Value;
                    }

                    if (finalPaperPanel.Name == "ANO")
                    {
                        _finalPaperPanel!.Year = new DateOnly(int.Parse(finalPaperPanel.Value), 1, 1);
                    }

                    if (finalPaperPanel.Name == "PAIS")
                    {
                        _finalPaperPanel!.Country = finalPaperPanel.Value;
                    }

                    if (finalPaperPanel.Name == "IDIOMA")
                    {
                        _finalPaperPanel!.Language = finalPaperPanel.Value;
                    }
                }
            }
        }

        private void GetDetails(XmlNode finalPaperPanelElement)
        {
            if (finalPaperPanelElement.Name is not null && finalPaperPanelElement.Name == "DETALHAMENTO-DA-PARTICIPACAO-EM-BANCA-DE-GRADUACAO")
            {
                if (finalPaperPanelElement.Attributes is null || finalPaperPanelElement.Attributes.Count == 0) return;

                XmlAttributeCollection allFinalPaperPanel = finalPaperPanelElement.Attributes;

                foreach (XmlAttribute finalPaperPanel in allFinalPaperPanel)
                {
                    if (finalPaperPanel is null || string.IsNullOrEmpty(finalPaperPanel.Name) || string.IsNullOrEmpty(finalPaperPanel.Value)) continue;

                    if (finalPaperPanel.Name == "NOME-DO-CANDIDATO")
                    {
                        _finalPaperPanel!.CandidateFullName = finalPaperPanel.Value;
                    }

                    if (finalPaperPanel.Name == "CODIGO-INSTITUICAO")
                    {
                        _finalPaperPanel!.InstitutionCode = finalPaperPanel.Value;
                    }

                    if (finalPaperPanel.Name == "NOME-INSTITUICAO")
                    {
                        _finalPaperPanel!.InstitutionName = finalPaperPanel.Value;
                    }

                    if (finalPaperPanel.Name == "CODIGO-CURSO")
                    {
                        _finalPaperPanel!.CourseCode = finalPaperPanel.Value;
                    }

                    if (finalPaperPanel.Name == "NOME-CURSO")
                    {
                        _finalPaperPanel!.CourseName = finalPaperPanel.Value;
                    }
                }
            }
        }

        private void GetParticipants(XmlNode finalPaperPanelElement)
        {
            PanelParticipant participant = new();

            if (finalPaperPanelElement.Name is not null && finalPaperPanelElement.Name == "PARTICIPANTE-BANCA")
            {
                if (finalPaperPanelElement.Attributes is null || finalPaperPanelElement.Attributes.Count == 0) return;

                XmlAttributeCollection allFinalPaperPanel = finalPaperPanelElement.Attributes;

                foreach (XmlAttribute finalPaperPanel in allFinalPaperPanel)
                {
                    if (finalPaperPanel is null || string.IsNullOrEmpty(finalPaperPanel.Name) || string.IsNullOrEmpty(finalPaperPanel.Value)) continue;

                    if (finalPaperPanel.Name == "NOME-COMPLETO-DO-PARTICIPANTE-DA-BANCA")
                    {
                        participant.FullName = finalPaperPanel.Value;
                    }

                    if (finalPaperPanel.Name == "NOME-PARA-CITACAO-DO-PARTICIPANTE-DA-BANCA")
                    {
                        participant.CitationName = finalPaperPanel.Value;
                    }

                    if (finalPaperPanel.Name == "NRO-ID-CNPQ")
                    {
                        participant.CNPQId = finalPaperPanel.Value;
                    }
                }

                _participants!.Add(participant);
            }
        }

        private void GetKnowledgeAreas(XmlNode finalPaperPanelElement)
        {
            if (finalPaperPanelElement.Name is not null && finalPaperPanelElement.Name == "AREAS-DO-CONHECIMENTO")
            {
                if (finalPaperPanelElement.ChildNodes is null || finalPaperPanelElement.ChildNodes.Count == 0) return;

                XmlNodeList allFinalPaperPanelElements = finalPaperPanelElement.ChildNodes;

                foreach (XmlNode allFinalPaperPanel in allFinalPaperPanelElements)
                {
                    if (allFinalPaperPanel.Attributes is null || allFinalPaperPanel.Attributes.Count == 0) return;

                    _knowledgeArea = new();

                    foreach (XmlAttribute finalPaperPanel in allFinalPaperPanel.Attributes)
                    {
                        if (finalPaperPanel is null || string.IsNullOrEmpty(finalPaperPanel.Name) || string.IsNullOrEmpty(finalPaperPanel.Value)) continue;

                        if (finalPaperPanel.Name == "NOME-GRANDE-AREA-DO-CONHECIMENTO")
                        {
                            _knowledgeArea.Name = finalPaperPanel.Value;
                        }

                        if (finalPaperPanel.Name == "NOME-DA-SUB-AREA-DO-CONHECIMENTO")
                        {
                            _knowledgeArea.SubAreaName = finalPaperPanel.Value;
                        }

                        if (finalPaperPanel.Name == "NOME-DA-ESPECIALIDADE")
                        {
                            _knowledgeArea.Specialty = finalPaperPanel.Value;
                        }
                    }

                    _knowledgeAreasList!.Add(_knowledgeArea);
                }
            }
        }
    }
}