using System.IO;
using System.Text.Json;

namespace AdmissionCommitteeWPF.ConfigurationClasses;

public class ConfigurationHelper
{
    private static readonly String _filePath = "configuration.Json";
    
    public static Configuration ReadFromJson()
    {
        if (CheckFileExists(_filePath))
        {
            using (FileStream fs = new FileStream(_filePath, FileMode.Open))
            {
                Configuration? conf = JsonSerializer.Deserialize<Configuration>(fs);
                if (conf == null)
                    throw new ArgumentException($"в файле {_filePath} не оказалось необходимого значения");
                return conf;
            }
            
        }
        WriteToJson(new Configuration());
        return new Configuration();
    }

    public static void WriteToJson(Configuration conf)
    {
        string jsonString = JsonSerializer.Serialize(conf);
        File.WriteAllText(_filePath, jsonString);
    }

    private static bool CheckFileExists(String filePath)
    {
        return File.Exists(filePath);
    }
}