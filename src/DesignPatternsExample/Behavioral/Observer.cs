using System;
using System.Collections.Generic;
namespace DesignPattersExample.Behavioral;

//Subject Interfae
public interface ISubject
{
    void Attach(IObserver observer);
    void Detach(IObserver observable);
    void Notify();
}

public interface IObserver
{
    void Update(ISubject subject);
}

//Concrete SUbject
public class ConcreteSubject : ISubject
{
    public int State {get ; set; } = -0;
    private readonly List<IObserver> _observers = new();
    public void Attach(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
       foreach(var observer in _observers)
       {
            observer.Update(this);
       }
    }
}


//Concrete Observer
public class ConcreteObserver : IObserver
{
    private readonly string _objectName;

    public ConcreteObserver(string objectName)
    {
        _objectName = objectName;
    }
    public void Update(ISubject subject)
    {
        if(subject is ConcreteSubject concreteSubject)
        {
            Console.WriteLine($"Observer {this._objectName}: Reacted to state change: {concreteSubject.State}");
        }
    }
}