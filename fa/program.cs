using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace mod_lab02_fa_csharp.fa

namespace fans
{
  public class State
  {
    public string Name { get; private set; }
    public Dictionary<char, State> Transitions = new();
    public bool IsAcceptState{ get; private set; };
     public State(string name, bool isAcceptState)
 {
     Name = name;
     IsAcceptState = isAcceptState;
 }
}
public abstract class Fa
{
    protected bool Run(IEnumerable<char> s, State initState)
    {
        var current = initState;
        foreach (var c in s)
        {
            if (current is null || !current.Transitions.TryGetValue(c, out current))
                return false;
        }

        return current.IsAcceptState;
    }
}

  public class FA1
  {
    private readonly State _initState;
    public Fa1()
    {
      var a = new State("a", false);
      var b = new State("b", false);
      var c = new State("c", false);
      var d = new State("d", true);
      a.Transitions['0'] = c;
      a.Transitions['1'] = b;
      b.Transitions['1'] = a;
      b.Transitions['0'] = d;
      c.Transitions['1'] = d;
      d.Transitions['1'] = d;
  
      _initState = a;
    }
  public bool Run(IEnumerable<char> s) => Run(s, _initState);
}

  public class FA2
  {
     private readonly State _initState;
     public Fa2()
   {
       var a = new State("a", false);
       var b = new State("b", false);
       var c = new State("c", false);
       var d = new State("d", true);
       a.Transitions['0'] = c;
       a.Transitions['1'] = b;
       c.Transitions['0'] = a;
       c.Transitions['1'] = d;
       b.Transitions['0'] = d;
       b.Transitions['1'] = a;
       d.Transitions['0'] = b;
       d.Transitions['1'] = c;
  
       _initState = a;
     }
 public bool Run(IEnumerable<char> s) => Run(s, _initState);
  }
  
  public class FA3
  {
    private readonly State _initState;
    public Fa3()
   {
       var a = new State("a", false);
       var b = new State("b", false);
       var c = new State("c", true);
  
       a.Transitions['0'] = a;
       a.Transitions['1'] = b;
       b.Transitions['0'] = a;
       b.Transitions['1'] = c;
       c.Transitions['0'] = c;
       c.Transitions['1'] = c;
  
       _initState = a;
   }
 public bool Run(IEnumerable<char> s) => Run(s, _initState);
}

  internal class Program
  {
    static void Main(string[] args)
    {
      const string str = "01111";
      var fa1 = new Fa1();
      var fa2 = new Fa2();
      var fa3 = new Fa3();
      var result1 = fa1.Run(str);
      var result2 = fa2.Run(str);
      var result3 = fa3.Run(str);
      Console.WriteLine(result1);
      Console.WriteLine(result2);
      Console.WriteLine(result3);
    }
  }
}
