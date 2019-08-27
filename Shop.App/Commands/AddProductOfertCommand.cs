using Shop.App.Commands.Abstract;
using Shop.DomainService.Repositories.Abstract;
using Shop.Infra.ConsoleHelper.Abstract;

namespace Shop.App.Commands
{
    public class AddProductOfertCommand : ICommand
    {
        private readonly IProductRepository _productRepository;
        private readonly IConsoleOperator _consoleOperator;

        public AddProductOfertCommand(
            IProductRepository productRepository,
            IConsoleOperator consoleOperator)
        {
            _productRepository = productRepository;
            _consoleOperator = consoleOperator;
        }

        public string Description => "Add a new product to catalogue";

        public void Execute()
        {
            var (name, price, isValid) = _consoleOperator.GetProductOffer();

            _productRepository.AddProduct(name, price, 0);

            _consoleOperator.ShowSummaryOfAddedProducts(name, price, 0);
        }
    }
}
