using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetWorkAtEventsInformationService : IGetDataInformationService
    {
        private List<Event>? _events;

        private Event? _event;

        private List<Author>? _authors;

        private Author? _author;

        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            GetDataFromFile(academicResearcher, academicResearcherDocument);
        }

        private void GetDataFromFile(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            _events = new();

            XmlNodeList workAtEventsInformation = academicResearcherDocument!.GetElementsByTagName("TRABALHOS-EM-EVENTOS");

            if (workAtEventsInformation.Count < 0) return;

            foreach (XmlNode element in workAtEventsInformation)
            {
                if (element is null || element.ChildNodes is null || element.ChildNodes.Count == 0) continue;

                foreach (XmlNode allWorkAtEventElements in element.ChildNodes)
                {
                    _event = new();

                    _authors = new();

                    foreach (XmlNode workAtEventElement in allWorkAtEventElements.ChildNodes)
                    {
                        _author = new();

                        if (workAtEventElement is null) continue;

                        GetEventBasicData(workAtEventElement);

                        GetEventDetails(workAtEventElement);

                        GetAuthors(workAtEventElement);
                    }

                    _event.Authors = _authors;

                    _events.Add(_event!);
                }
            }

            academicResearcher.WorkAtEvents = _events;
        }

        private void GetEventBasicData(XmlNode workAtEventElement)
        {
            if (workAtEventElement.Name is not null && workAtEventElement.Name == "DADOS-BASICOS-DO-TRABALHO")
            {
                if (workAtEventElement.Attributes is null || workAtEventElement.Attributes.Count == 0) return;

                XmlAttributeCollection events = workAtEventElement.Attributes;

                foreach (XmlAttribute @event in events)
                {
                    if (@event is null || string.IsNullOrEmpty(@event.Name) || string.IsNullOrEmpty(@event.Value)) continue;

                    if (@event.Name == "NATUREZA")
                    {
                        _event!.NatureOfWork = @event.Value;
                    }

                    if (@event.Name == "TITULO-DO-TRABALHO")
                    {
                        _event!.WorkTitle = @event.Value;
                    }

                    if (@event.Name == "ANO-DO-TRABALHO")
                    {
                        _event!.WorkYear = new DateOnly(int.Parse(@event.Value), 1, 1);
                    }

                    if (@event.Name == "PAIS-DO-EVENTO")
                    {
                        _event!.Country = @event.Value;
                    }

                    if (@event.Name == "IDIOMA")
                    {
                        _event!.Language = @event.Value;
                    }

                    if (@event.Name == "HOME-PAGE-DO-TRABALHO")
                    {
                        _event!.HomePageLink = @event.Value;
                    }
                }
            } 
        }

        private void GetEventDetails(XmlNode workAtEventElement)
        {
            if (workAtEventElement.Name is not null && workAtEventElement.Name == "DETALHAMENTO-DO-TRABALHO")
            {
                if (workAtEventElement.Attributes is null || workAtEventElement.Attributes.Count == 0) return;

                XmlAttributeCollection events = workAtEventElement.Attributes;

                foreach (XmlAttribute @event in events)
                {
                    if (@event is null || string.IsNullOrEmpty(@event.Name) || string.IsNullOrEmpty(@event.Value)) continue;

                    if (@event.Name == "CLASSIFICACAO-DO-EVENTO")
                    {
                        _event!.Classification = @event.Value;
                    }

                    if (@event.Name == "NOME-DO-EVENTO")
                    {
                        _event!.Name = @event.Value;
                    }

                    if (@event.Name == "CIDADE-DO-EVENTO")
                    {
                        _event!.City = @event.Value;
                    }

                    if (@event.Name == "ANO-DE-REALIZACAO")
                    {
                        _event!.RealizationYear = new DateOnly(int.Parse(@event.Value), 1, 1);
                    }
                    
                    if (@event.Name == "TITULO-DOS-ANAIS-OU-PROCEEDINGS")
                    {
                        _event!.AnnalsTitle = @event.Value;
                    }

                    if (@event.Name == "PAGINA-INICIAL")
                    {
                        _event!.InitialPage = int.Parse(@event.Value);
                    }
                    
                    if (@event.Name == "PAGINA-FINAL")
                    {
                        _event!.FinalPage = int.Parse(@event.Value);
                    }

                    if (@event.Name == "CIDADE-DA-EDITORA")
                    {
                        _event!.PublisherCity = @event.Value;
                    }
                }
            }
        }

        private void GetAuthors(XmlNode workAtEventElement)
        {
            if (workAtEventElement.Name is not null && workAtEventElement.Name == "AUTORES")
            {
                if (workAtEventElement.Attributes is null || workAtEventElement.Attributes.Count == 0) return;

                XmlAttributeCollection events = workAtEventElement.Attributes;

                foreach (XmlAttribute @event in events)
                {
                    if (@event is null || string.IsNullOrEmpty(@event.Name) || string.IsNullOrEmpty(@event.Value)) continue;

                    if (@event.Name == "NOME-COMPLETO-DO-AUTOR")
                    {
                        _author!.FullName = @event.Value;
                    }

                    if (@event.Name == "NOME-PARA-CITACAO")
                    {
                        _author!.CitationName = @event.Value;
                    }

                    if (@event.Name == "NRO-ID-CNPQ")
                    {
                        _author!.CNPQId = @event.Value;
                    }
                }

                _authors!.Add(_author!);
            }
        }
    }
}