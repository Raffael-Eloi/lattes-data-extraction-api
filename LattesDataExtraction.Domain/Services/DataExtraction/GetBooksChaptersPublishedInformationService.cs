using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetBooksChaptersPublishedInformationService : IGetDataInformationService
    {
        private List<BookChapter>? _booksChapters;

        private BookChapter? _bookChapter;

        private List<Author>? _authors;

        private Author? _author;

        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            GetDataFromFile(academicResearcher, academicResearcherDocument);
        }

        private void GetDataFromFile(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            _booksChapters = new();

            XmlNodeList booksChaptersInformation = academicResearcherDocument!.GetElementsByTagName("CAPITULOS-DE-LIVROS-PUBLICADOS");

            if (booksChaptersInformation.Count < 0) return;

            foreach (XmlNode element in booksChaptersInformation)
            {
                if (element is null || element.ChildNodes is null || element.ChildNodes.Count == 0) continue;

                foreach (XmlNode allBookChaptersElements in element.ChildNodes)
                {
                    _bookChapter = new();

                    _authors = new();

                    foreach (XmlNode bookChapterElement in allBookChaptersElements.ChildNodes)
                    {
                        _author = new();

                        if (bookChapterElement is null) continue;

                        GetBookBasicData(bookChapterElement);

                        GetBookDetails(bookChapterElement);

                        GetAuthors(bookChapterElement);
                    }

                    _bookChapter.Authors = _authors;

                    _booksChapters.Add(_bookChapter!);
                }
            }

            academicResearcher.BooksChaptersPublished = _booksChapters;
        }

        private void GetBookBasicData(XmlNode bookChapterElement)
        {
            if (bookChapterElement.Name is not null && bookChapterElement.Name == "DADOS-BASICOS-DO-CAPITULO")
            {
                if (bookChapterElement.Attributes is null || bookChapterElement.Attributes.Count == 0) return;

                XmlAttributeCollection booksChapters = bookChapterElement.Attributes;

                foreach (XmlAttribute bookChapter in booksChapters)
                {
                    if (bookChapter is null || string.IsNullOrEmpty(bookChapter.Name) || string.IsNullOrEmpty(bookChapter.Value)) continue;

                    if (bookChapter.Name == "TIPO")
                    {
                        _bookChapter!.Type = bookChapter.Value;
                    }

                    if (bookChapter.Name == "TITULO-DO-CAPITULO-DO-LIVRO")
                    {
                        _bookChapter!.ChapterTitle = bookChapter.Value;
                    }
                    
                    if (bookChapter.Name == "DOI")
                    {
                        _bookChapter!.DOI = bookChapter.Value;
                    }
                    
                    if (bookChapter.Name == "HOME-PAGE-DO-TRABALHO")
                    {
                        _bookChapter!.HomePageLink = bookChapter.Value;
                    }

                    if (bookChapter.Name == "ANO")
                    {
                        _bookChapter!.Year = new DateOnly(int.Parse(bookChapter.Value), 1, 1);
                    }

                    if (bookChapter.Name == "PAIS-DE-PUBLICACAO")
                    {
                        _bookChapter!.PublisherCountry = bookChapter.Value;
                    }

                    if (bookChapter.Name == "IDIOMA")
                    {
                        _bookChapter!.Language = bookChapter.Value;
                    }
                }
            }
        }

        private void GetBookDetails(XmlNode bookChapterElement)
        {
            if (bookChapterElement.Name is not null && bookChapterElement.Name == "DETALHAMENTO-DO-CAPITULO")
            {
                if (bookChapterElement.Attributes is null || bookChapterElement.Attributes.Count == 0) return;

                XmlAttributeCollection booksChapters = bookChapterElement.Attributes;

                foreach (XmlAttribute bookChapter in booksChapters)
                {
                    if (bookChapter is null || string.IsNullOrEmpty(bookChapter.Name) || string.IsNullOrEmpty(bookChapter.Value)) continue;

                    if (bookChapter.Name == "TITULO-DO-LIVRO")
                    {
                        _bookChapter!.BookTitle = bookChapter.Value;
                    }
                    
                    if (bookChapter.Name == "ORGANIZADORES")
                    {
                        _bookChapter!.Organizers = bookChapter.Value;
                    }

                    if (bookChapter.Name == "PAGINA-INICIAL" && !string.IsNullOrEmpty(bookChapter.Value))
                    {
                        _bookChapter!.InitialPage = int.Parse(bookChapter.Value);
                    }
                    
                    if (bookChapter.Name == "PAGINA-FINAL" && !string.IsNullOrEmpty(bookChapter.Value))
                    {
                        _bookChapter!.FinalPage = int.Parse(bookChapter.Value);
                    }

                    if (bookChapter.Name == "ISBN")
                    {
                        _bookChapter!.ISBN = bookChapter.Value;
                    }

                    if (bookChapter.Name == "CIDADE-DA-EDITORA")
                    {
                        _bookChapter!.PublisherCity = bookChapter.Value;
                    }
                    
                    if (bookChapter.Name == "NOME-DA-EDITORA")
                    {
                        _bookChapter!.PublisherName = bookChapter.Value;
                    }
                }
            }
        }

        private void GetAuthors(XmlNode bookChapterElement)
        {
            if (bookChapterElement.Name is not null && bookChapterElement.Name == "AUTORES")
            {
                if (bookChapterElement.Attributes is null || bookChapterElement.Attributes.Count == 0) return;

                XmlAttributeCollection booksChapters = bookChapterElement.Attributes;

                foreach (XmlAttribute bookChapter in booksChapters)
                {
                    if (bookChapter is null || string.IsNullOrEmpty(bookChapter.Name) || string.IsNullOrEmpty(bookChapter.Value)) continue;

                    if (bookChapter.Name == "NOME-COMPLETO-DO-AUTOR")
                    {
                        _author!.FullName = bookChapter.Value;
                    }

                    if (bookChapter.Name == "NOME-PARA-CITACAO")
                    {
                        _author!.CitationName = bookChapter.Value;
                    }

                    if (bookChapter.Name == "NRO-ID-CNPQ")
                    {
                        _author!.CNPQId = bookChapter.Value;
                    }
                }

                _authors!.Add(_author!);
            }
        }
    }
}