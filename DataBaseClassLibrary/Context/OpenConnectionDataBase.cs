namespace DataBaseClassLibrary.Context;
/// <summary>
/// Class for getting db context. Singleton pattern is used for threading safetying
/// </summary>
public class OpenConnectionDataBase: MyDbContext
{
    private static OpenConnectionDataBase instance;
    private static object syncObject = new object();

    protected OpenConnectionDataBase() : base()
    {
    }

    public static OpenConnectionDataBase getInstance()
    {
        if (instance == null)
        {
            lock (syncObject)
            {
                if (instance == null)
                {
                    instance = new OpenConnectionDataBase();
                }
            }
        }

        return instance;
    }
}