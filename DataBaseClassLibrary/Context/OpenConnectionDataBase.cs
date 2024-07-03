using DataBaseClassLibrary.Methods;

namespace DataBaseClassLibrary.Context;
/// <summary>
/// Class for getting db context. Singleton pattern is used for threading safetying
/// </summary>
public class OpenConnectionDataBase: MyDbContext
{
    private static Configuration _configuraiton;
    private static OpenConnectionDataBase instance;
    private static string _connectionName;
    private static object syncObject = new object();

    protected OpenConnectionDataBase() : base()
    {
    }
    protected OpenConnectionDataBase(string userName, string userPassword) : base(userName, userPassword)
    {
    }

    public static OpenConnectionDataBase getInstance()
    {
        var conf = ConfigurationHelper.ReadFromJson();
        if (_connectionName != conf.ConnName)
        {
            instance = null;
            _configuraiton = conf;
        }
        if (instance == null)
        {
            lock (syncObject)
            {
                if (instance == null)
                {
                    _connectionName = _configuraiton.ConnName;
                    instance = new OpenConnectionDataBase(_configuraiton.ConnName, _configuraiton.ConnPassword);
                }
            }
            
        }
        return instance;
    }
}