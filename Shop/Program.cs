using Shop.Application.Commands;
using Shop.Application.Commands.Abstract;
using Shop.Domain.Model;
using Shop.Infrastructure;
using System;
using System.Collections.ObjectModel;

namespace Shop
{
    public class Program
    {
        static void Main(string[] args)
        {
            var productRepository = new ProductRepository();
            var consoleOperator = new ConsoleOperator();

            var options = new ReadOnlyCollection<ICommand>(new ICommand[]
            {
                new ExitCommand(),
                new AddProductOfertCommand(productRepository, consoleOperator),
                new AddProductCommand(productRepository, consoleOperator),
                new BuyProductCommand(productRepository, consoleOperator),
                new ReportCommand(productRepository, consoleOperator),
            });

            new Menu(options).Run();
        }
    }
}
