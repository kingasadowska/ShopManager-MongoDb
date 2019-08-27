using Shop.Application.Commands.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Commands
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
