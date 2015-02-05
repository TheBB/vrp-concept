using System;
using System.Diagnostics;

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

    public double MinTemp { get; private set; }
    public double MaxTemp { get; private set; }

    public Solver(I instance)
    {
        this.instance = instance;
        MinTemp = MaxTemp = -1.0;

        Console.WriteLine("Made a Solver");
    }

    public void TemperatureRange(double min, double max)
    {
        Debug.Assert(0 < min && min < max);
        MinTemp = min;
        MaxTemp = max;
    }
}

} // Namespace VRP
