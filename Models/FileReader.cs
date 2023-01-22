using System;
namespace PlagiarismAnalyzer.Models;

public static class FileReader
{
    private static List<string[]> GetAllTextFileLines()
    {
        string directoryOfTextFiles = "/Users/alexandermarin/Documents/BoostContent/Boost_Content_Texts/";
        string fileNamePrefix = "text"; // text_4 and so on...
        int amountOfTextFiles = 27;

        List<string[]> result = new List<string[]>();

        for (int i = 1; i < amountOfTextFiles + 1; i++)
        {
            string path = directoryOfTextFiles + fileNamePrefix + "_" + i + ".txt";
            string[] storedText = FileReader.ReadFileAndReturnListOfTextLines(path);
            result.Add(storedText);
        }

        return result;
    }

    private static string[] ReadFileAndReturnListOfTextLines(string path)
    {
        string storedFile = path;
        string fileContent = File.ReadAllText(storedFile);
        string[] splitted = fileContent.Split(".");
        return splitted;
    }

    /// <summary>
    /// Main Entry Point. Specify Target filename while it is in the same folder as the other text files.
    /// </summary>
    /// <param name="target"></param>
    public static List<string> AnalyzeTarget(string target)
    {
        List<string[]> allTextFilesLines = FileReader.GetAllTextFileLines();
        string[] targetFileLines = FileReader.ReadFileAndReturnListOfTextLines("/Users/alexandermarin/Documents/BoostContent/Boost_Content_Texts/" + target + ".txt");

        List<string> result = new List<string>();
        foreach (var textFileLines in allTextFilesLines)
        {
            foreach (var textLine in textFileLines)
            {
                foreach (var line in targetFileLines)
                {
                    if (textLine.Trim() == line.Trim())
                    {
                        result.Add(line.Trim());
                    }
                }
            }
        }

        return result;
    }

    public static string GetSourceText(string filename)
    {
        string path = "/Users/alexandermarin/Documents/BoostContent/Boost_Content_Texts/" + filename + ".txt";
        string fileContent = File.ReadAllText(path);
        return fileContent;
    }
}