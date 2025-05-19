using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
Failed TestMethod3 [10 ms]
  Error Message:
   Assert.IsTrue failed. 
  Stack Trace:
     at NET.UnitTest1.TestMethod3() in D:\a\mod-lab02-fa-csharp\mod-lab02-fa-csharp\fa.Tests\UnitTest1.cs:line 31
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Void** arguments, Signature sig, Boolean isConstructor)
   at System.Reflection.MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)
  Failed TestMethod5 [< 1 ms]
  Error Message:
   Assert.IsTrue failed. 
  Stack Trace:
     at NET.UnitTest1.TestMethod5() in D:\a\mod-lab02-fa-csharp\mod-lab02-fa-csharp\fa.Tests\UnitTest1.cs:line 47
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Void** arguments, Signature sig, Boolean isConstructor)
   at System.Reflection.MethodBaseInvoker.InvokeWithNoArgs(Object obj, BindingFlags invokeAttr)

    public class FA2 : FiniteAutomata
    {
        public FA2() : base(CreateStates()) { }

        private static State CreateStates()
        {
            var a = new State("a", false);
            var b = new State("b", false);
            var c = new State("c", false);
            var d = new State("d", true);

            a.Transitions['0'] = b;
            a.Transitions['1'] = c;

            b.Transitions['0'] = a;
            b.Transitions['1'] = d;

            c.Transitions['0'] = d;
            c.Transitions['1'] = a;

            d.Transitions['0'] = c;
            d.Transitions['1'] = b;

            return a;
        }
    }

    public class FA3 : FiniteAutomata
    {
        public FA3() : base(CreateStates()) { }

        private static State CreateStates()
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

            return a;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
