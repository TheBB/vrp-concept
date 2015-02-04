using System;
using VRP;

using MySolver = VRP.Solver<MyInstance, MySolution, MyModification>;

public class MySolution : ISolution
{
    public bool Feasible() { return true; }
    public double Cost() { return 1.0; }
}

public class MyModification : IModification<MySolution>
{
    public bool Equals(IModification<MySolution> other_)
    {
        MyModification other = other_ as MyModification;
        if (other == null)
            return false;

        return true;
    }
}

public class MyInstance : IInstance<MySolution,MyModification>
{
    public MyInstance()
    {
        Console.WriteLine("Instantiated MyInstance");
    }

    public MySolution InitialSolution()
    {
        return new MySolution();
    }

    public MyModification Modification(MySolution solution)
    {
        return new MyModification();
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        new MySolver(new MyInstance());
    }
}
