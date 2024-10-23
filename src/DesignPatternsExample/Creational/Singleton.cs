namespace DesignPattersExample.Creational;
public class Singleton
{
    private static Singleton _instance;
    
    //lock objects for tread safety
    private  static readonly object _lock = new object();

    private Singleton()
    {
    }

    //public method to get the instance of the singleton
    public static Singleton Instance
    {
        get
        {
            //Double-check locking
            if(_instance == null)
            {
                lock(_lock)
                {
                    if(_instance == null)
                    {
                        _instance = new Singleton();
                    }
                }
            }
            return _instance;
        }
    }

    public void SomeBusinessLogic()
    {
        Console.WriteLine("Executing some business logic...");
    }
}