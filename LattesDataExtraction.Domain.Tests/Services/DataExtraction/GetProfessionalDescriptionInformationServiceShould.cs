using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Services.DataExtraction;
using LattesDataExtraction.Domain.Tests.Helpers;
using System.Xml;

namespace LattesDataExtraction.Domain.Tests.Services.DataExtraction
{
    internal class GetProfessionalDescriptionInformationServiceShould
    {
        private IGetDataInformationService getProfessionalDescriptionInformationService;

        private string academicResearcherFilePath;

        private XmlDocument academicResearcherDocument;

        [SetUp]
        public void SetUp()
        {
            academicResearcherFilePath = GetAcademicResearcherFilePath.Get();

            academicResearcherDocument = new XmlDocument();

            getProfessionalDescriptionInformationService = new GetProfessionalDescriptionInformationService();
        }

        [Test]
        public void Get_Information_From_Xml_Document()
        {
            #region Arrange

            academicResearcherDocument.Load(academicResearcherFilePath);

            AcademicResearcher academicResearcher = new();

            #endregion

            #region Act

            getProfessionalDescriptionInformationService.GetInformation(academicResearcher, academicResearcherDocument);

            #endregion

            #region Assert

            string expectedProfessionalDescription = @"Bacharel em Ciências da Computação pela Universidade Federal de Santa Catarina - UFSC (1995) e em Psicologia pelo Centro Universitário Luterano de Palmas - CEULP/ULBRA (2012) , com especialização em Redes de Computadores e Inteligência Artificial (2002) e mestrado em Ciências da Computação também pela Universidade Federal de Santa Catarina (2002). Está cursando doutorado em Ensino de Ciências e Matemática pelo PPGECIM-ULBRA. Atualmente é Professor do Centro Universitário Luterano de Palmas nos Cursos de Bacharelado em Sistemas de Informação, Ciência da Computação e Engenharia de Software e também Coordenador Adjunto do curso de Engenharia de Software. Participa dos Conselhos dos Cursos de Sistemas de Informação, Ciência da Computação e Engenharia de Software. É membro ativo do Conselho de Ensino, Pesquisa e extensão (CONSEPE) e do Conselho Superior (CONSUP), tendo participado do Comitê Científico e coordenado a Comissão Própria de Avaliação do CEULP/ULBRA. Tem pesquisas relacionadas à Tecnologia e Qualidade de Vida bem como em Novas Tecnologias Aplicadas na Educação.";

            Assert.That(academicResearcher, Is.Not.Null);

            Assert.Multiple(() =>
            {
                Assert.That(academicResearcher.ProfessionalDescription, Is.EqualTo(expectedProfessionalDescription));
            });

            #endregion
        }
    }
}