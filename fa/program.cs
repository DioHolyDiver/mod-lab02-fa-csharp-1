using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace fans
{
    public class State
    {
        public string Name { get; }
        public Dictionary<char, State> Transitions { get; } = new Dictionary<char, State>();
        public bool IsFinal { get; }

        public State(string name, bool isFinal)
        {
            Name = name;
            IsFinal = isFinal;
        }
    }

    public class FA1
    {
        private readonly State q0state;
        private readonly State q1state;
        private readonly State q2state;
        private readonly State q3state;
        private readonly State q4state;

        public FA1()
        {
            q0state = new State("q0", false);
            q1state = new State("q1", false);
            q2state = new State("q2", true);
            q3state = new State("q3", false);
            q4state = new State("q4", false);

            // Установка переходов между состояниями
            q0state.Transitions.Add('0', q2state);
            q0state.Transitions.Add('1', q3state);
            q1state.Transitions.Add('0', q4state);
            q1state.Transitions.Add('1', q2state);
            q2state.Transitions.Add('0', q4state);
            q2state.Transitions.Add('1', q2state);
            q3state.Transitions.Add('0', q2state);
            q3state.Transitions.Add('1', q3state);
            q4state.Transitions.Add('0', q4state);
            q4state.Transitions.Add('1', q4state);
        }

        public bool Run(string input)
        {
            State currentState = q0state;

            foreach (char ch in input)
            {
                if (!currentState.Transitions.TryGetValue(ch, out var nextState))
                {
                    return false; // Недопустимый символ
                }
                currentState = nextState;
            }

            return currentState.IsFinal;
        }
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
