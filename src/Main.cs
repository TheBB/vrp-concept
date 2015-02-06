using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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

public class CordeauParser
{
    public static void Parse(string filename)
    {
        IEnumerable<string> tokens =
            File.ReadAllLines(filename)
                .SelectMany(line => line.Split((char[])null, StringSplitOptions.RemoveEmptyEntries));

        int type = Convert.ToInt32(tokens.First());
        tokens = tokens.Skip(1);

        switch (type)
        {
        case 0: ParseVRP(tokens); break;
        case 1: ParsePVRP(tokens); break;
        case 2: ParseMDVRP(tokens); break;
        case 3: ParseSDVRP(tokens); break;
        case 4: ParseVRPTW(tokens); break;
        case 5: ParsePVRPTW(tokens); break;
        case 6: ParseMDVRPTW(tokens); break;
        case 7: ParseSDVRPTW(tokens); break;
        default: throw new NotSupportedException("Unrecognized instance type " + tokens.First());
        }
    }

    private static void ParseVRP(IEnumerable<string> tokens)
    {
        // Global instance data
        int nVehicles = Convert.ToInt32(tokens.ElementAt(0));
        int nCustomers = Convert.ToInt32(tokens.ElementAt(1));
        Debug.Assert(tokens.ElementAt(2) == "1");

        // Constraints
        int maxDuration = Convert.ToInt32(tokens.ElementAt(3));
        int maxLoad = Convert.ToInt32(tokens.ElementAt(4));

        tokens = tokens.Skip(5);

        // Depot
        ParseDepot(ref tokens);
    }

    private static void ParsePVRP(IEnumerable<string> tokens)
    {
        throw new NotImplementedException("PVRP");
    }

    private static void ParseMDVRP(IEnumerable<string> tokens)
    {
        throw new NotImplementedException("MDVRP");
    }

    private static void ParseSDVRP(IEnumerable<string> tokens)
    {
        throw new NotImplementedException("SDVRP");
    }

    private static void ParseVRPTW(IEnumerable<string> tokens)
    {
        throw new NotImplementedException("VRPTW");
    }

    private static void ParsePVRPTW(IEnumerable<string> tokens)
    {
        throw new NotImplementedException("PVRPTW");
    }

    private static void ParseMDVRPTW(IEnumerable<string> tokens)
    {
        throw new NotImplementedException("MDVRPTW");
    }

    private static void ParseSDVRPTW(IEnumerable<string> tokens)
    {
        throw new NotImplementedException("SDVRPTW");
    }

    private static void ParseDepot(ref IEnumerable<string> tokens)
    {
        tokens = tokens.Skip(7);
    }
}

public class MainClass
{
    public static void Main(string[] args)
    {
        CordeauParser.Parse(args[0]);
    }
}
