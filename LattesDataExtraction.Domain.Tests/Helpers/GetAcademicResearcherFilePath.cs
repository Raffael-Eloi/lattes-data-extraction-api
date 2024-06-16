namespace LattesDataExtraction.Domain.Tests.Helpers;

public static class GetAcademicResearcherFilePath
{
    public static string Get()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string fullFilePath = Path.Combine(currentDirectory, "Data", "lattes-resume-example.xml");
        fullFilePath = fullFilePath.Replace("bin\\Debug\\net7.0", "");
        return fullFilePath.Replace("bin/Debug/net7.0", "");
    }
}