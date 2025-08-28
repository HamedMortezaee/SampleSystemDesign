using System.IO;

public class FileOperations
{
    public static List<string> ReadLineByLineToFile()
    {
        var filePath = GetLogFilePath();

        List<string> lines = new();
        
        if (File.Exists(filePath))
        {
            using (StreamReader sr = new StreamReader(filePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
        }
        else
        {
            Console.WriteLine("Log file not found.");
        }
        return lines;
    }

    public static void WriteLineByLineToFile(List<string> lines)
    {
        var filePath = GetLogFilePath();
        using (StreamWriter sw = File.AppendText(filePath))
        {
            foreach (string line in lines)
            {
                sw.WriteLine(line);
            }
        }
    }

    private static string GetLogFilePath()
    {
        string folder = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)!.Parent!.Parent!.Parent!.FullName;
        string subFolder = "UserLoginTimeRecordingSystem";

        string fullFolderPath = Path.Combine(folder, subFolder);
        if (!Directory.Exists(fullFolderPath))
            Directory.CreateDirectory(fullFolderPath);

        string fileName = "log.txt";

        string fullPath = Path.Combine(folder, subFolder, fileName);

        return fullPath;
    }
}