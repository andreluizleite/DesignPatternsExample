namespace DesignPattersExample.Structural;

public interface ITarget
{
    void Request();
}

public class Adaptee
{
    public void SpecificRequest()
    {
        Console.WriteLine("Called SpecificRequest() from adaptee.");
    }
}

public class Adapter : ITarget
{
    private readonly Adaptee _adaptee;

    public Adapter(Adaptee adaptee)
    {
        _adaptee = adaptee;
    }

    public void Request()
    {
        _adaptee.SpecificRequest();
    }
}

public class Client
{
    private readonly ITarget _target;

    public Client(ITarget target)
    {
        _target = target;
    }
    public void Execute()
    {
        _target.Request();
    }
}