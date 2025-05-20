namespace fans
{
    public class State
    {
        public string Name { get; private set; }
        public Dictionary<char, State> Transitions = new();
        public bool IsAcceptState { get; private set; }

        public State(string name, bool isAcceptState)
        {
            Name = name;
            IsAcceptState = isAcceptState;
        }
    }


    public abstract class FA
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

    public class FA1 : FA
    {
        private readonly State _initState;
        public FA1()
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

    public class FA2 : FA
    {
        private readonly State _initState;

        public FA2()
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

    public class FA3 : FA
    {
        private readonly State _initState;

        public FA3()
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
            var FA1 = new FA1();
            var FA2 = new FA2();
            var FA3 = new FA3();
            var result1 = FA1.Run(str);
            var result2 = FA2.Run(str);
            var result3 = FA3.Run(str);
            Console.WriteLine(result1);
            Console.WriteLine(result2);
            Console.WriteLine(result3);
        }
    }
}
