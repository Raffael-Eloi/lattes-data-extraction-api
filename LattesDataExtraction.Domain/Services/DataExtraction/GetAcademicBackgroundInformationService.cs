using LattesDataExtraction.Domain.Contracts;
using LattesDataExtraction.Domain.Entities;
using LattesDataExtraction.Domain.Enums;
using System.Xml;

namespace LattesDataExtraction.Domain.Services.DataExtraction
{
    internal class GetAcademicBackgroundInformationService : IGetDataInformationService
    {
        private AcademicResearcher? _academicResearcher;

        private XmlDocument? _academicResearcherDocument;

        private List<AcademicBackground>? academicBackgroundsInformation;

        public void GetInformation(AcademicResearcher academicResearcher, XmlDocument academicResearcherDocument)
        {
            _academicResearcher = academicResearcher;

            _academicResearcherDocument = academicResearcherDocument;

            academicBackgroundsInformation = new List<AcademicBackground>();

            GetGraduationInformationIfExist();

            GetSpecializationInformationIfExist();

            GetMasterInformationIfExist();

            _academicResearcher.AcademicBackgrounds = academicBackgroundsInformation;
        }

        private void GetGraduationInformationIfExist()
        {
            XmlNodeList academicBackgroundInformation = _academicResearcherDocument!.GetElementsByTagName("GRADUACAO");

            if (academicBackgroundInformation.Count < 0) return;

            foreach (XmlNode element in academicBackgroundInformation)
            {
                if (element.Attributes is not null && element.Attributes.Count > 0)
                {
                    AcademicBackground academicBackground = new()
                    {
                        AcademicBackgroundType = AcademicBackgroundType.Graduation
                    };

                    XmlAttribute? instituitionName = element.Attributes["NOME-INSTITUICAO"];

                    if (instituitionName is not null)
                    {
                        academicBackground.InstituitionName = instituitionName.Value;
                    }

                    XmlAttribute? instituitionCode = element.Attributes["CODIGO-INSTITUICAO"];

                    if (instituitionCode is not null)
                    {
                        academicBackground.InstituitionCode = instituitionCode.Value;
                    }

                    XmlAttribute? courseName = element.Attributes["NOME-CURSO"];

                    if (courseName is not null)
                    {
                        academicBackground.CourseName = courseName.Value;
                    }

                    XmlAttribute? courseCode = element.Attributes["CODIGO-CURSO"];

                    if (courseCode is not null)
                    {
                        academicBackground.CourseCode = courseCode.Value;
                    }

                    XmlAttribute? courseCodeCapes = element.Attributes["CODIGO-CURSO-CAPES"];

                    if (courseCodeCapes is not null)
                    {
                        academicBackground.CourseCodeCapes = courseCodeCapes.Value;
                    }

                    XmlAttribute? areaCourseCode = element.Attributes["CODIGO-AREA-CURSO"];

                    if (areaCourseCode is not null)
                    {
                        academicBackground.AreaCourseCode = areaCourseCode.Value;
                    }

                    XmlAttribute? courseStatus = element.Attributes["STATUS-DO-CURSO"];

                    if (courseStatus is not null)
                    {
                        academicBackground.CourseStatus = courseStatus.Value;
                    }

                    XmlAttribute? finalPaperTitle = element.Attributes["TITULO-DO-TRABALHO-DE-CONCLUSAO-DE-CURSO"];

                    if (finalPaperTitle is not null)
                    {
                        academicBackground.FinalPaperTitle = finalPaperTitle.Value;
                    }

                    XmlAttribute? advisorName = element.Attributes["NOME-DO-ORIENTADOR"];

                    if (advisorName is not null)
                    {
                        academicBackground.AdvisorName = advisorName.Value;
                    }

                    XmlAttribute? advisorCode = element.Attributes["NUMERO-ID-ORIENTADOR"];

                    if (advisorCode is not null)
                    {
                        academicBackground.AdvisorCode = advisorCode.Value;
                    }

                    XmlAttribute? startYear = element.Attributes["ANO-DE-INICIO"];

                    if (startYear is not null)
                    {
                        academicBackground.StartYear = new DateOnly(int.Parse(startYear.Value), 1, 1);
                    }

                    XmlAttribute? endYear = element.Attributes["ANO-DE-CONCLUSAO"];

                    if (endYear is not null)
                    {
                        academicBackground.EndYear = new DateOnly(int.Parse(endYear.Value), 1, 1);
                    }

                    academicBackgroundsInformation!.Add(academicBackground);
                }
            }
        }

        private void GetSpecializationInformationIfExist()
        {
            XmlNodeList academicBackgroundInformation = _academicResearcherDocument!.GetElementsByTagName("ESPECIALIZACAO");

            if (academicBackgroundInformation.Count < 0) return;

            foreach (XmlNode element in academicBackgroundInformation)
            {
                if (element.Attributes is not null && element.Attributes.Count > 0)
                {
                    AcademicBackground academicBackground = new()
                    {
                        AcademicBackgroundType = AcademicBackgroundType.Specialization
                    };

                    XmlAttribute? instituitionName = element.Attributes["NOME-INSTITUICAO"];

                    if (instituitionName is not null)
                    {
                        academicBackground.InstituitionName = instituitionName.Value;
                    }

                    XmlAttribute? instituitionCode = element.Attributes["CODIGO-INSTITUICAO"];

                    if (instituitionCode is not null)
                    {
                        academicBackground.InstituitionCode = instituitionCode.Value;
                    }

                    XmlAttribute? courseName = element.Attributes["NOME-CURSO"];

                    if (courseName is not null)
                    {
                        academicBackground.CourseName = courseName.Value;
                    }

                    XmlAttribute? courseCode = element.Attributes["CODIGO-CURSO"];

                    if (courseCode is not null)
                    {
                        academicBackground.CourseCode = courseCode.Value;
                    }

                    XmlAttribute? courseStatus = element.Attributes["STATUS-DO-CURSO"];

                    if (courseStatus is not null)
                    {
                        academicBackground.CourseStatus = courseStatus.Value;
                    }

                    XmlAttribute? startYear = element.Attributes["ANO-DE-INICIO"];

                    if (startYear is not null && !string.IsNullOrEmpty(startYear.Value))
                    {
                        academicBackground.StartYear = new DateOnly(int.Parse(startYear.Value), 1, 1);
                    }

                    XmlAttribute? endYear = element.Attributes["ANO-DE-CONCLUSAO"];

                    if (endYear is not null && !string.IsNullOrEmpty(endYear.Value))
                    {
                        academicBackground.EndYear = new DateOnly(int.Parse(endYear.Value), 1, 1);
                    }

                    academicBackgroundsInformation!.Add(academicBackground);
                }
            }
        }

        private void GetMasterInformationIfExist()
        {
            XmlNodeList academicBackgroundInformation = _academicResearcherDocument!.GetElementsByTagName("MESTRADO");

            if (academicBackgroundInformation.Count < 0) return;

            foreach (XmlNode element in academicBackgroundInformation)
            {
                if (element.Attributes is not null && element.Attributes.Count > 0)
                {
                    AcademicBackground academicBackground = new()
                    {
                        AcademicBackgroundType = AcademicBackgroundType.Master
                    };

                    XmlAttribute? instituitionName = element.Attributes["NOME-INSTITUICAO"];

                    if (instituitionName is not null)
                    {
                        academicBackground.InstituitionName = instituitionName.Value;
                    }

                    XmlAttribute? instituitionCode = element.Attributes["CODIGO-INSTITUICAO"];

                    if (instituitionCode is not null)
                    {
                        academicBackground.InstituitionCode = instituitionCode.Value;
                    }

                    XmlAttribute? courseName = element.Attributes["NOME-CURSO"];

                    if (courseName is not null)
                    {
                        academicBackground.CourseName = courseName.Value;
                    }

                    XmlAttribute? courseCode = element.Attributes["CODIGO-CURSO"];

                    if (courseCode is not null)
                    {
                        academicBackground.CourseCode = courseCode.Value;
                    }

                    XmlAttribute? courseCodeCapes = element.Attributes["CODIGO-CURSO-CAPES"];

                    if (courseCodeCapes is not null)
                    {
                        academicBackground.CourseCodeCapes = courseCodeCapes.Value;
                    }

                    XmlAttribute? areaCourseCode = element.Attributes["CODIGO-AREA-CURSO"];

                    if (areaCourseCode is not null)
                    {
                        academicBackground.AreaCourseCode = areaCourseCode.Value;
                    }

                    XmlAttribute? courseStatus = element.Attributes["STATUS-DO-CURSO"];

                    if (courseStatus is not null)
                    {
                        academicBackground.CourseStatus = courseStatus.Value;
                    }

                    XmlAttribute? masterThesis = element.Attributes["TITULO-DA-DISSERTACAO-TESE"];

                    if (masterThesis is not null)
                    {
                        academicBackground.MasterThesis = masterThesis.Value;
                    }

                    XmlAttribute? advisorName = element.Attributes["NOME-DO-ORIENTADOR"];

                    XmlAttribute? advisorNameMaster = element.Attributes["NOME-COMPLETO-DO-ORIENTADOR"];

                    if (advisorName is not null)
                    {
                        academicBackground.AdvisorName = advisorName.Value;
                    }
                    
                    if (advisorNameMaster is not null)
                    {
                        academicBackground.AdvisorName = advisorNameMaster.Value;
                    }

                    XmlAttribute? advisorCode = element.Attributes["NUMERO-ID-ORIENTADOR"];

                    if (advisorCode is not null)
                    {
                        academicBackground.AdvisorCode = advisorCode.Value;
                    }

                    XmlAttribute? startYear = element.Attributes["ANO-DE-INICIO"];

                    if (startYear is not null)
                    {
                        academicBackground.StartYear = new DateOnly(int.Parse(startYear.Value), 1, 1);
                    }

                    XmlAttribute? endYear = element.Attributes["ANO-DE-CONCLUSAO"];

                    if (endYear is not null)
                    {
                        academicBackground.EndYear = new DateOnly(int.Parse(endYear.Value), 1, 1);
                    }
                    
                    XmlAttribute? idOasis = element.Attributes["ID-OASIS"];

                    if (idOasis is not null)
                    {
                        academicBackground.IdOasis = idOasis.Value;
                    }

                    academicBackgroundsInformation!.Add(academicBackground);
                }
            }

        }
    }
}