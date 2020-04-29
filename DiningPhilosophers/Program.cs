// Framework used: .NET Framework 4
// Compiler used: v4.0.30319.1
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Diagnostics;

namespace DiningPhilosophers
{
    class Program
    {
        private const int PHILOSOPHER_COUNT = 5;

        static void Main(string[] args)
        {
            // Construct philosophers and chopsticks
            var philosophers = InitializePhilosophers();

            // Start dinner
            Console.WriteLine("Dinner is starting!");

            // Spawn threads for each philosopher's eating cycle
            var philosopherThreads = new List<Thread>();
            foreach (var philosopher in philosophers)
            {
                var philosopherThread = new Thread(new ThreadStart(philosopher.EatAll));
                philosopherThreads.Add(philosopherThread);
                philosopherThread.Start();
            }

            // Wait for all philosopher's to finish eating
            foreach (var thread in philosopherThreads)
            {
                thread.Join();
            }

            // Done
            Console.WriteLine("Dinner is over! Press any key to finish the program.");
            Console.ReadKey();
        }

        private static List<Philosopher> InitializePhilosophers()
        {
            // Construct philosophers
            var philosophers = new List<Philosopher>(PHILOSOPHER_COUNT);
            for (int i = 0; i < PHILOSOPHER_COUNT; i++)
            {
                philosophers.Add(new Philosopher(philosophers, i));
            }

            // Assign chopsticks to each philosopher
            foreach (var philosopher in philosophers)
            {
                // Assign left chopstick
                philosopher.LeftChopstick = philosopher.LeftPhilosopher.RightChopstick ?? new Chopstick();

                // Assign right chopstick
                philosopher.RightChopstick = philosopher.RightPhilosopher.LeftChopstick ?? new Chopstick();
            }

            return philosophers;
        }
    }
}