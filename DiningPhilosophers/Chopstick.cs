using System.Diagnostics;

namespace DiningPhilosophers
{
    [DebuggerDisplay("Name = {Name}")]
    public class Chopstick
    {
        private static int _count = 1;
        public string Name { get; private set; }

        public Chopstick()
        {
            this.Name = "Chopstick " + _count++;
        }
    }
}
