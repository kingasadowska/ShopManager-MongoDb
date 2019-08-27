using Shop.App.Commands.Abstract;
using Shop.DomainService.Repositories.Abstract;
using Shop.Infra.ConsoleHelper.Abstract;

namespace Shop.App.Commands
{
    public class ReportCommand : ICommand
    {
        private IProductRepository _productRepository;
        private IConsoleOperator _consoleOperator;

        public ReportCommand(
            IProductRepository productRepository,
            IConsoleOperator consoleOperator)
        {
            _productRepository = productRepository;
            _consoleOperator = consoleOperator;
        }

        public string Description => "Report.";

        public void Execute()
        {
            var avaiableProducts = _productRepository.GetAvaiableProductsFromDb();
            _consoleOperator.ShowListOfAllAvaiableProducts(avaiableProducts);
        }
    }
}
