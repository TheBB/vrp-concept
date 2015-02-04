using System;
using VRP;

public class MySolution : ISolution
{
}

public class MyInstance : IInstance<MySolution>
{
    public MyInstance()
    {
        Console.WriteLine("Instantiated MyInstance");
    }

    public MySolution makeSolution()
    {
        return new MySolution();
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        new Solver<MyInstance,MySolution>(new MyInstance());
    }
}
