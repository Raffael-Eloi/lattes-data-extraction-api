using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetPublishedArticlesInformationService : IGetDataInformationService
    {
        private List<ScientificArticle>? _scientificArticles;

        private ScientificArticle? _scientificArticle;

        private List<Author>? _authors;

        private Author? _author;

        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            GetDataFromFile(academicResearcher, academicResearcherDocument);
        }

        private void GetDataFromFile(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            _scientificArticles = new();

            XmlNodeList publishedArticlesInformation = academicResearcherDocument!.GetElementsByTagName("ARTIGO-PUBLICADO");

            if (publishedArticlesInformation.Count < 0) return;

            foreach (XmlNode element in publishedArticlesInformation)
            {
                _scientificArticle = new();

                _authors = new();

                if (element.ChildNodes is null || element.ChildNodes.Count == 0) continue;

                foreach (XmlNode articleElement in element.ChildNodes)
                {
                    _author = new();

                    if (articleElement is null) continue;

                    GetArticleBasicData(articleElement);

                    GetArticleDetail(articleElement);

                    GetAuthor(articleElement);

                    _scientificArticle.Authors = _authors;
                }

                _scientificArticles.Add(_scientificArticle!);
            }

            academicResearcher.PublishedArticles = _scientificArticles;
        }

        private void GetArticleBasicData(XmlNode articleElement)
        {
            if (articleElement.Name is not null && articleElement.Name == "DADOS-BASICOS-DO-ARTIGO")
            {
                if (articleElement.Attributes is null || articleElement.Attributes.Count == 0) return;

                XmlAttributeCollection articles = articleElement.Attributes;

                foreach (XmlAttribute article in articles)
                {
                    if (article is null || string.IsNullOrEmpty(article.Name) || string.IsNullOrEmpty(article.Value)) continue;

                    if (article.Name == "TITULO-DO-ARTIGO")
                    {
                        _scientificArticle!.Title = article.Value;
                    }

                    if (article.Name == "ANO-DO-ARTIGO")
                    {
                        _scientificArticle!.ArticleYear = new DateOnly(int.Parse(article.Value), 1, 1);
                    }

                    if (article.Name == "IDIOMA")
                    {
                        _scientificArticle!.Language = article.Value;
                    }

                    if (article.Name == "DOI")
                    {
                        _scientificArticle!.DOI = article.Value;
                    }
                }
            }
        }

        private void GetArticleDetail(XmlNode articleElement)
        {
            if (articleElement.Name is not null && articleElement.Name == "DETALHAMENTO-DO-ARTIGO")
            {
                if (articleElement.Attributes is null || articleElement.Attributes.Count == 0) return;

                XmlAttributeCollection articles = articleElement.Attributes;

                foreach (XmlAttribute article in articles)
                {
                    if (article is null || string.IsNullOrEmpty(article.Name) || string.IsNullOrEmpty(article.Value)) continue;

                    if (article.Name == "TITULO-DO-PERIODICO-OU-REVISTA")
                    {
                        _scientificArticle!.TitleOfJornalOrMagazine = article.Value;
                    }

                    if (article.Name == "ISSN")
                    {
                        _scientificArticle!.ISSN = article.Value;
                    }

                    if (article.Name == "VOLUME")
                    {
                        _scientificArticle!.Volume = article.Value;
                    }

                    if (article.Name == "SERIE")
                    {
                        _scientificArticle!.Series = article.Value;
                    }

                    if (article.Name == "PAGINA-INICIAL")
                    {
                        _scientificArticle!.InitialPage = int.Parse(article.Value);
                    }
                }
            }
        }
        private void GetAuthor(XmlNode articleElement) 
        {
            if (articleElement.Name is not null && articleElement.Name == "AUTORES")
            {
                if (articleElement.Attributes is null || articleElement.Attributes.Count == 0) return;

                XmlAttributeCollection articles = articleElement.Attributes;

                foreach (XmlAttribute article in articles)
                {
                    if (article is null || string.IsNullOrEmpty(article.Name) || string.IsNullOrEmpty(article.Value)) continue;

                    if (article.Name == "NOME-COMPLETO-DO-AUTOR")
                    {
                        _author!.FullName = article.Value;
                    }

                    if (article.Name == "NOME-PARA-CITACAO")
                    {
                        _author!.CitationName = article.Value;
                    }

                    if (article.Name == "NRO-ID-CNPQ")
                    {
                        _author!.CNPQId = article.Value;
                    }
                }

                _authors!.Add(_author!);
            }
        }
    }
}