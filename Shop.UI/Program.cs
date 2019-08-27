using Shop.App.Commands;
using Shop.App.Commands.Abstract;
using Shop.DomainService.Repositories;
using Shop.Infra.ConsoleHelper;
using System.Collections.ObjectModel;

namespace Shop.UI
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
                new SupplyCommand(productRepository, consoleOperator),
                new BuyProductsCommand(productRepository, consoleOperator),
                new ReportCommand(productRepository, consoleOperator),
            });

            new Menu(options).Run();
        }
    }
}
