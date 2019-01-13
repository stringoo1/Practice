using System;
using StoreSystem.Command;

namespace StoreSystem
{
    public class StoreSystem : IDisposable
    {
        private StoreSystemState state;
        private CommandParser CommandParser;

        public StoreSystem()
        {
            this.state = new StoreSystemState();
            this.CommandParser = new CommandParser();
        }

        public void Run()
        {
            Console.WriteLine("Hello!");

            while (this.state.IsRunning)
            {
                Console.Write("> ");
                var inputCommand = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(inputCommand))
                {
                    continue;
                }
                var command = this.CommandParser.Parse(inputCommand);
                command.Execute(state);
            }

            Console.WriteLine("Good-bye");
        }

        public void Dispose()
        {
            this.CommandParser = null;
            this.state = null;
        }
    }
}
