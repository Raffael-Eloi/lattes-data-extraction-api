using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Enums;
using LattesDataExtraction.Domain.Factories;
using LattesDataExtraction.Domain.Services.DataExtraction;

namespace LattesDataExtraction.Domain.Tests.Factories
{
    public class GetDataInformationFactoryShould
    {
        private IGetDataInformationFactory getDataInformationFactory;

        [SetUp] 
        public void SetUp() 
        {
            getDataInformationFactory = new GetDataInformationFactory();
        }

        [Test]
        public void Return_Curriculum_Vitae_Service_When_Type_Is_Curriculum_Vitae()
        {
            #region Arrange

            var curriculumVitaeType = DataInformationType.CurriculumVitae;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(curriculumVitaeType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetCurriculumVitaeInformationService)));

            #endregion
        }

        [Test]
        public void Return_General_Data_Service_When_Type_Is_General_Data()
        {
            #region Arrange

            var generalDataType = DataInformationType.GeneralData;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(generalDataType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetGeneralDataInformationService)));

            #endregion
        }

        [Test]
        public void Return_Professional_Description_Service_When_Type_Is_Professional_Description()
        {
            #region Arrange

            var professionalDescriptionType = DataInformationType.ProfessionalDescription;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(professionalDescriptionType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetProfessionalDescriptionInformationService)));

            #endregion
        }

        [Test]
        public void Return_Professional_Address_Service_When_Type_Is_Professional_Address()
        {
            #region Arrange

            var professionalAddressType = DataInformationType.ProfessionalAddress;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(professionalAddressType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetProfessionalAddressInformationService)));

            #endregion
        }

        [Test]
        public void Return_Academic_Background_Service_When_Type_Is_AcademicBackground()
        {
            #region Arrange

            var academicBackgroundType = DataInformationType.AcademicBackground;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(academicBackgroundType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetAcademicBackgroundInformationService)));

            #endregion
        }

        [Test]
        public void Return_Published_Articles_Service_When_Type_Is_Published_Articles()
        {
            #region Arrange

            var publishedArticlesType = DataInformationType.PublishedArticles;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(publishedArticlesType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetPublishedArticlesInformationService)));

            #endregion
        }

        [Test]
        public void Return_Books_Organized_Or_Published_Service_When_Type_Is_Books_Organized_Or_Published()
        {
            #region Arrange

            var booksOrganizedOrPublishedType = DataInformationType.BooksOrganizedOrPublished;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(booksOrganizedOrPublishedType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetBooksOrganizedOrPublishedInformationService)));

            #endregion
        }

        [Test]
        public void Return_Books_Chapters_Published_Service_When_Type_Is_Books_Chapters_Published()
        {
            #region Arrange

            var booksChaptersPublishedType = DataInformationType.BooksChaptersPublished;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(booksChaptersPublishedType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetBooksChaptersPublishedInformationService)));

            #endregion
        }

        [Test]
        public void Return_Work_At_Events_Service_When_Type_Is_Work_At_Events()
        {
            #region Arrange

            var workAtEventsType = DataInformationType.WorkAtEvents;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(workAtEventsType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetWorkAtEventsInformationService)));

            #endregion
        }

        [Test]
        public void Return_Others_Bibliographic_Production_Service_When_Type_Is_Others_Bibliographic_Production()
        {
            #region Arrange

            var othersBibliographicProductionType = DataInformationType.OthersBibliographicProduction;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(othersBibliographicProductionType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetOthersBibliographicProductionInformationService)));

            #endregion
        }

        [Test]
        public void Return_Technical_Production_Service_When_Type_Is_Technical_Production()
        {
            #region Arrange

            var technicalProductionType = DataInformationType.TechnicalProduction;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(technicalProductionType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetTechnicalProductionsInformationService)));

            #endregion
        }

        [Test]
        public void Return_Completed_Orientation_Service_When_Type_Is_Completed_Orientation()
        {
            #region Arrange

            var completedOrientationType = DataInformationType.CompletedOrientation;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(completedOrientationType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetCompletedOrientationInformationService)));

            #endregion
        }
        
        [Test]
        public void Return_Complementary_Courses_Service_When_Type_Is_Complementary_Courses()
        {
            #region Arrange

            var ComplementaryCoursesType = DataInformationType.ComplementaryCourses;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(ComplementaryCoursesType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetComplementaryCoursesInformationService)));

            #endregion
        }
        
        [Test]
        public void Return_Participation_In_Final_Paper_Panel_Service_When_Type_Is_Participation_In_Final_Paper_Panel()
        {
            #region Arrange

            var participationInFinalPaperPanelType = DataInformationType.ParticipationInFinalPaperPanel;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(participationInFinalPaperPanelType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetParticipationInFinalPaperPanelInformationService)));

            #endregion
        }
        
        [Test]
        public void Return_Orientation_In_Progress_Service_When_Type_Is_Orientation_In_Progress()
        {
            #region Arrange

            var orientationInProgressType = DataInformationType.OrientationInProgress;

            #endregion

            #region Act

            IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(orientationInProgressType);

            #endregion

            #region Assert

            Assert.That(getDataInformationType.GetType(), Is.EqualTo(typeof(GetOrientationInProgressInformationService)));

            #endregion
        }

        [Test]
        public void Throw_Exception_When_Data_Information_Type_Does_Not_Exist()
        {
            #region Arrange

            var unknownType = DataInformationType.Unknowwn;

            #endregion

            #region Act

            Exception? threwException = null;

            try
            {
                IGetDataInformationService getDataInformationType = getDataInformationFactory.Create(unknownType);
            }
            catch (ArgumentException ex)
            {
                threwException = ex;
            }

            #endregion

            #region Assert

            Assert.That(threwException, Is.Not.Null);
            
            Assert.Multiple(() =>
            {
                Assert.That(threwException.GetType(), Is.EqualTo(typeof(ArgumentException)));

                Assert.That(threwException.Message, Is.EqualTo($"The Data Information Type {unknownType} was not implemented."));
            });

            #endregion
        }
    }
}
