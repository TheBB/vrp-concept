using System;

namespace VRP
{

public interface ISolution
{
}

public interface IInstance<S>
    where S : ISolution
{
    S makeSolution();
}

public class Solver<I,S>
    where I : IInstance<S>
    where S : ISolution
{
    private I instance;

    public Solver(I instance)
    {
        this.instance = instance;
        Console.WriteLine("Made a Solver");
    }
}

} // Namespace VRP
