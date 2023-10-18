using System;
using System.IO;
using Newtonsoft.Json.Linq;

public class FileWordCounter
{
    public int CountWordsInFile(string filePath)
    {
        if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
        {
    
            throw new FileNotFoundException("File not found.", filePath);
        }

        string fileExtension = Path.GetExtension(filePath).ToLower();
        string fileContents;

        switch (fileExtension)
        {
            case ".txt":
                fileContents = File.ReadAllText(filePath);
                break;
            case ".csv":
                fileContents = File.ReadAllText(filePath);
                fileContents = fileContents.Replace(",", " ");
                break;
            case ".json":
                var jsonContent = JObject.Parse(File.ReadAllText(filePath));
                fileContents = jsonContent.ToString();
                break;
            default:
                throw new NotSupportedException("File format not supported.");
        }

        // Split the file content into words based on whitespace and count the words
        string[] words = fileContents.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }
}
