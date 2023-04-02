using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetPublishedArticlesInformationService : IGetDataInformationService
    {
        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            List<ScientificArticle> scientificArticles = new();

            XmlNodeList publishedArticlesInformation = academicResearcherDocument!.GetElementsByTagName("ARTIGO-PUBLICADO");

            if (publishedArticlesInformation.Count < 0) return;

            foreach (XmlNode element in publishedArticlesInformation)
            {
                ScientificArticle scientificArticle = new();

                List<Author> authors = new();

                if (element.ChildNodes is null || element.ChildNodes.Count == 0) continue;

                foreach( XmlNode articleElement in element.ChildNodes)
                {
                    Author author = new();

                    if (articleElement is null) continue;

                    if (articleElement.Name is not null && articleElement.Name == "DADOS-BASICOS-DO-ARTIGO")
                    {
                        if (articleElement.Attributes is null || articleElement.Attributes.Count == 0) continue;

                        XmlAttributeCollection articles = articleElement.Attributes;

                        foreach (XmlAttribute article in articles)
                        {
                            if (article is null || string.IsNullOrEmpty(article.Name) || string.IsNullOrEmpty(article.Value)) continue;

                            if (article.Name == "TITULO-DO-ARTIGO")
                            {
                                scientificArticle.Title = article.Value;
                            }

                            if (article.Name == "ANO-DO-ARTIGO")
                            {
                                scientificArticle.ArticleYear = new DateOnly(int.Parse(article.Value), 1, 1);
                            }

                            if (article.Name == "IDIOMA")
                            {
                                scientificArticle.Language = article.Value;
                            }

                            if (article.Name == "DOI")
                            {
                                scientificArticle.DOI = article.Value;
                            }
                        }

                        scientificArticles.Add(scientificArticle);
                    }

                    if (articleElement.Name is not null && articleElement.Name == "DETALHAMENTO-DO-ARTIGO")
                    {
                        if (articleElement.Attributes is null || articleElement.Attributes.Count == 0) continue;

                        XmlAttributeCollection articles = articleElement.Attributes;

                        foreach (XmlAttribute article in articles)
                        {
                            if (article is null || string.IsNullOrEmpty(article.Name) || string.IsNullOrEmpty(article.Value)) continue;

                            if (article.Name == "TITULO-DO-PERIODICO-OU-REVISTA")
                            {
                                scientificArticle.TitleOfJornalOrMagazine = article.Value;
                            }

                            if (article.Name == "ISSN")
                            {
                                scientificArticle.ISSN = article.Value;
                            }

                            if (article.Name == "VOLUME")
                            {
                                scientificArticle.Volume = article.Value;
                            }

                            if (article.Name == "SERIE")
                            {
                                scientificArticle.Series = article.Value;
                            }

                            if (article.Name == "PAGINA-INICIAL")
                            {
                                scientificArticle.InitialPage = int.Parse(article.Value);
                            }
                        }
                    }

                    if (articleElement.Name is not null && articleElement.Name == "AUTORES") 
                    {
                        if (articleElement.Attributes is null || articleElement.Attributes.Count == 0) continue;

                        XmlAttributeCollection articles = articleElement.Attributes;

                        foreach (XmlAttribute article in articles)
                        {
                            if (article is null || string.IsNullOrEmpty(article.Name) || string.IsNullOrEmpty(article.Value)) continue;

                            if (article.Name == "NOME-COMPLETO-DO-AUTOR")
                            {
                                author.FullName = article.Value;
                            }

                            if (article.Name == "NOME-PARA-CITACAO")
                            {
                                author.CitationName = article.Value;
                            }

                            if (article.Name == "NRO-ID-CNPQ")
                            {
                                author.CNPQId = article.Value;
                            }
                        }

                        authors.Add(author);
                    }

                    scientificArticle.Authors = authors;
                }
            }
            academicResearcher.PublishedArticles = scientificArticles;
        }
    }
}