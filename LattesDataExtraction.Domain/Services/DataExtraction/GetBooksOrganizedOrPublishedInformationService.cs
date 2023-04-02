using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetBooksOrganizedOrPublishedInformationService : IGetDataInformationService
    {
        private List<Book>? _books;

        private Book? _book;

        private List<Author>? _authors;

        private Author? _author;

        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            GetDataFromFile(academicResearcher, academicResearcherDocument);
        }

        private void GetDataFromFile(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            _books = new();

            XmlNodeList booksOrganizedOrPublishedInformation = academicResearcherDocument!.GetElementsByTagName("LIVROS-PUBLICADOS-OU-ORGANIZADOS");

            if (booksOrganizedOrPublishedInformation.Count < 0) return;

            foreach (XmlNode element in booksOrganizedOrPublishedInformation)
            {
                if (element is null || element.ChildNodes is null || element.ChildNodes.Count == 0) continue;

                foreach (XmlNode allBookElements in element.ChildNodes)
                {
                    _book = new();

                    _authors = new();

                    foreach (XmlNode bookElement in allBookElements.ChildNodes)
                    {
                        _author = new();

                        if (bookElement is null) continue;

                        GetBookBasicData(bookElement);

                        GetBookDetails(bookElement);

                        GetAuthors(bookElement);
                        
                    }

                    _book.Authors = _authors;

                    _books.Add(_book!);
                }
            }

            academicResearcher.BooksPublishedOrOrganized = _books;
        }

        private void GetBookBasicData(XmlNode bookElement)
        {
            if (bookElement.Name is not null && bookElement.Name == "DADOS-BASICOS-DO-LIVRO")
            {
                if (bookElement.Attributes is null || bookElement.Attributes.Count == 0) return;

                XmlAttributeCollection books = bookElement.Attributes;

                foreach (XmlAttribute book in books)
                {
                    if (book is null || string.IsNullOrEmpty(book.Name) || string.IsNullOrEmpty(book.Value)) continue;

                    if (book.Name == "TIPO")
                    {
                        _book!.Type = book.Value;
                    }

                    if (book.Name == "NATUREZA")
                    {
                        _book!.Origin = book.Value;
                    }

                    if (book.Name == "TITULO-DO-LIVRO")
                    {
                        _book!.Title = book.Value;
                    }

                    if (book.Name == "ANO")
                    {
                        _book!.Year = new DateOnly(int.Parse(book.Value), 1, 1);
                    }

                    if (book.Name == "PAIS-DE-PUBLICACAO")
                    {
                        _book!.PublishCountry = book.Value;
                    }
                    
                    if (book.Name == "IDIOMA")
                    {
                        _book!.Language = book.Value;
                    }
                }
            }
        }

        private void GetBookDetails(XmlNode bookElement)
        {
            if (bookElement.Name is not null && bookElement.Name == "DETALHAMENTO-DO-LIVRO")
            {
                if (bookElement.Attributes is null || bookElement.Attributes.Count == 0) return;

                XmlAttributeCollection books = bookElement.Attributes;

                foreach (XmlAttribute book in books)
                {
                    if (book is null || string.IsNullOrEmpty(book.Name) || string.IsNullOrEmpty(book.Value)) continue;

                    if (book.Name == "NUMERO-DE-VOLUMES")
                    {
                        _book!.NumberOfVolumes = int.Parse(book.Value);
                    }

                    if (book.Name == "NUMERO-DE-PAGINAS")
                    {
                        _book!.NumberOfPages = int.Parse(book.Value);
                    }

                    if (book.Name == "CIDADE-DA-EDITORA")
                    {
                        _book!.PublishCity = book.Value;
                    }
                }
            }
        }

        private void GetAuthors(XmlNode bookElement)
        {
            if (bookElement.Name is not null && bookElement.Name == "AUTORES")
            {
                if (bookElement.Attributes is null || bookElement.Attributes.Count == 0) return;

                XmlAttributeCollection books = bookElement.Attributes;

                foreach (XmlAttribute book in books)
                {
                    if (book is null || string.IsNullOrEmpty(book.Name) || string.IsNullOrEmpty(book.Value)) continue;

                    if (book.Name == "NOME-COMPLETO-DO-AUTOR")
                    {
                        _author!.FullName = book.Value;
                    }

                    if (book.Name == "NOME-PARA-CITACAO")
                    {
                        _author!.CitationName = book.Value;
                    }

                    if (book.Name == "NRO-ID-CNPQ")
                    {
                        _author!.CNPQId = book.Value;
                    }
                }

                _authors!.Add(_author!);
            }
        }
    }
}