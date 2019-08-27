using Shop.App.Commands.Abstract;
using System;

namespace Shop.App.Commands
{
    public class ExitCommand : ICommand
    {
        public string Description => "Exit.";

        public void Execute()
        {
            Environment.Exit(0);
        }
    }
}
