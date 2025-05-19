using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace fans
{
    public class State
    {
        public string Name { get; set; }
        public Dictionary<char, State> Transitions { get; } = new Dictionary<char, State>();
        public bool IsFinal { get; set; }

        public State(string name, bool isFinal)
        {
            Name = name;
            IsFinal = isFinal;
        }
    }

    public abstract class FiniteAutomata
    {
        protected readonly State StartState;

        protected FiniteAutomata(State startState)
        {
            StartState = startState;
        }

        public virtual bool Run(string input)
        {
            State current = StartState;
            foreach (char ch in input)
            {
                if (!current.Transitions.ContainsKey(ch)) return false;
                current = current.Transitions[ch];
            }
            return current.IsFinal;
        }
    }

    public class FA1 : FiniteAutomata
    {
        public FA1() : base(CreateStates()) {}

        private static State CreateStates()
        {
            var q0 = new State("q0", false);
            var q1 = new State("q1", false);
            var q2 = new State("q2", true);

            q0.Transitions['0'] = q1;
            q0.Transitions['1'] = q0;

            q1.Transitions['0'] = q0;
            q1.Transitions['1'] = q2;

            q2.Transitions['0'] = q0;
            q2.Transitions['1'] = q2;

            return q0;
        }
    }

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
