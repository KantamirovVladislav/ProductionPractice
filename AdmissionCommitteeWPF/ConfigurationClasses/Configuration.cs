namespace AdmissionCommitteeWPF.ConfigurationClasses;

public class Configuration
{
    private string? connName;
    private string? connPassword;
    private bool isSaveConnection;

    public string? ConnName
    {
        get => connName;
        set => connName = value;
    }

    public string? ConnPassword
    {
        get => connPassword;
        set => connPassword = value;
    }
    
    public bool IsSaveConnection
    {
        get => isSaveConnection;
        set => isSaveConnection = value;
    }
    
    public Configuration()
    {
        connName = null;
        connPassword = null;
    }

    public Configuration(string name, string password)
    {
        connName = name;
        connPassword = password;
    }
    
    public bool CheckConnection()
    {
        if (ConnName == null || ConnPassword == null)
            return false;
        return true;
    }
}