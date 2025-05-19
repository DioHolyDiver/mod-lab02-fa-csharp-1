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
        public bool IsAcceptState { get; }

        public State(string name, bool isAcceptState)
        {
            Name = name;
            IsAcceptState = isAcceptState;
        }
    }
    public class FiniteAutomaton
    {
        private readonly State initialState;

        public FiniteAutomaton()
        {
            var stateA = new State("a", false);
            var stateB = new State("b", false);
            var stateC = new State("c", true);
            stateA.Transitions.Add('0', stateA);
            stateA.Transitions.Add('1', stateB);
            stateB.Transitions.Add('0', stateC);
            stateB.Transitions.Add('1', stateA);
            stateC.Transitions.Add('0', stateB);
            stateC.Transitions.Add('1', stateC);
            initialState = stateA;
        }
        public bool? Run(IEnumerable<char> symbols)
        {
            State current = initialState;
            foreach (var symbol in symbols)
            {
                if (!current.Transitions.ContainsKey(symbol))
                    return null;
                current = current.Transitions[symbol];
            }
            return current.IsAcceptState;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = "0000010111";
            FiniteAutomaton automaton = new FiniteAutomaton();
            bool? result = automaton.Run(input);

            if (result.HasValue)
            {
                Console.WriteLine($"Последовательность принята: {result.Value}");
            }
            else
            {
                Console.WriteLine("Неверный символ в последовательности");
            }
        }
    }
}
