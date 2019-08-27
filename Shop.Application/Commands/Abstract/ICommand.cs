using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Commands.Abstract
{
    public interface ICommand
    {
        string Description { get; }

        void Execute();
    }
}
