using Shop.Application.Commands.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Commands
{
    public class Report : ICommand
    {
        public string Description => "State of products";

        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
}
