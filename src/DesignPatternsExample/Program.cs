//The Observer pattern defines a one-to-many dependency between objects so that when one object changes state, all its dependents are notified and updated automatically.
using System;
using System.Diagnostics;
using DesignPattersExample.Behavioral;
using DesignPattersExample.Creational;
using DesignPattersExample.Structural;

public class Program
{
    private static void Main(string[] args)
    {
        int size = 1000000;
        int[] array = InitializeArray(size);

        PerformSorting(array);
        DemonstrateSingletonUsage();
        DemostrateAdapterUsage();
        DemostrateFactoryMethod();
        DemostrateObserver();      
    }

    // Method to initialize an array with random values
    private static int[] InitializeArray(int size)
    {
        int[] array = new int[size];
        Random rand = new Random();

        for (int i = 0; i < size; i++)
        {
            array[i] = rand.Next(1, size);
        }

        return array;
    }

    // Method to perform sorting using different strategies
    private static void PerformSorting(int[] array)
    {
        Console.WriteLine("Sorting Performance Comparison:");

        // QuickSort
        int[] quickSortArray = (int[])array.Clone();
        MeasureSortingPerformance(new Sorter(new QuickSort()), quickSortArray, "Quick Sort");

        // MergeSort
        int[] mergeSortArray = (int[])array.Clone();
        MeasureSortingPerformance(new Sorter(new MergeSort()), mergeSortArray, "Merge Sort");

        // LinqSort
        int[] linqSortArray = (int[])array.Clone();
        MeasureSortingPerformance(new Sorter(new LinqSort()), linqSortArray, "Linq Sort");
    }

    // Method to measure the sorting performance of a strategy
    private static void MeasureSortingPerformance(Sorter sorter, int[] array, string sortName)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        Console.WriteLine($"\nBefore {sortName}:");
        sorter.Sort(array);
        stopwatch.Stop();
        Console.WriteLine($"{sortName} Time: {stopwatch.ElapsedMilliseconds} ms.");
    }

    // Method to demonstrate Singleton usage
    private static void DemonstrateSingletonUsage()
    {
        Console.WriteLine("\nSingleton Pattern Demonstration:");

        // Access the Singleton instance
        Singleton singleton = Singleton.Instance;

        // Call a method on the singleton instance
        singleton.SomeBusinessLogic();

        // Verify that the same instance is returned
        Singleton anotherSingleton = Singleton.Instance;
        anotherSingleton.SomeBusinessLogic();
        Console.WriteLine($"Are both instances the same? {singleton == anotherSingleton}");
    }

    private static void DemostrateAdapterUsage()
    {
        //Create an instance of adaptee
        var adaptee = new Adaptee();

        //Create an Adapter for the Adaptee
        ITarget adapter = new Adapter(adaptee);

        //Create a Client with the adapter
        var client = new Client(adapter);

        //Execute the Client request;
        client.Execute();
    }
    private static void DemostrateFactoryMethod()
    {
        Creator creatorA = new ConcreteCreatorA();
        Console.WriteLine(creatorA.GetProductName());

        Creator creatorB = new ConcreteCreatorB();
        Console.WriteLine(creatorB.GetProductName());
    }

    private static void DemostrateObserver()
    {
        var subject = new ConcreteSubject();
        var observerA = new ConcreteObserver("A");
        subject.Attach(observerA);

        subject.State = 5;
        subject.Notify();

        var observerB = new ConcreteObserver("B");
        subject.Attach(observerB);

        subject.State = 10;
        subject.Notify();

        subject.Detach(observerA);
        subject.State = 15;
        subject.Notify();
    }
}
