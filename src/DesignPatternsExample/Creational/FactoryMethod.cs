using DesignPattersExample.Creational;

public interface IProduct
{
    string GetName();
}

public class ConcreteProductA : IProduct
{
    public string GetName() => "ConcreteProductA";
}

public class ConcreteProductB : IProduct
{
    public string GetName() => "ConcreteProductB";
}

//Creator abstract class
public abstract class Creator
{
    public abstract IProduct FactoryMethod();

    public string GetProductName()
    {
        var product = FactoryMethod();
        return $"Created: {product.GetName()}";
    }
}

//Concrete Creators
public class ConcreteCreatorA : Creator
{
    public override IProduct FactoryMethod() => new ConcreteProductA();
}
public class ConcreteCreatorB: Creator
{
    public override IProduct FactoryMethod() => new ConcreteProductA();
}