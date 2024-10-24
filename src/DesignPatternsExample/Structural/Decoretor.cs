namespace DesignPattersExample.Structural;

//Component Interface
public interface IComponent
{
    string Operation();
}

//Concrete Component
public class ConcreteComponent : IComponent
{
    public string Operation() => "ConcreteComponet";
}

//Base Decorator
public abstract class Decorator : IComponent
{
    protected IComponent _component;

    public Decorator(IComponent component)
    {
        _component = component;
    }
    public virtual string Operation()
    {
       return _component.Operation();
    }
}

//Concrete Decorators
public class ConcreteDecoratorA : Decorator
{
    public ConcreteDecoratorA(IComponent component) : base(component){}

    public override string Operation()
    {
        return $"ConcreteDecoratorA {_component.Operation()}";
    }
}

public class ConcreteDecoratorB : Decorator
{
    public ConcreteDecoratorB(IComponent component): base(component){}

    public override string Operation()
    {
       return $"ConcreteDecoratorB {_component.Operation()}";
    }
}