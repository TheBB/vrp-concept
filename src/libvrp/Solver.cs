using System;

namespace VRP
{

public interface ISolution
{
    bool Feasible();
    double Cost();
}

public interface IModification<S>
    where S : ISolution
{
    bool Equals(IModification<S> other);
}

public interface IInstance<S,M>
    where S : ISolution
    where M : IModification<S>
{
    S InitialSolution();
    M Modification(S solution);
}

public class Solver<I,S,M>
    where I : IInstance<S,M>
    where M : IModification<S>
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
