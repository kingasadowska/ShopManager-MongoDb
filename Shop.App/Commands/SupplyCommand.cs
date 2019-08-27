using Shop.App.Commands.Abstract;
using Shop.DomainService.Repositories.Abstract;
using Shop.Infra.ConsoleHelper.Abstract;

namespace Shop.App.Commands
{
    public class SupplyCommand : ICommand
    {
        private readonly IProductRepository _productRepository;
        private readonly IConsoleOperator _consoleOperator;

        public SupplyCommand(
            IProductRepository productRepository,
            IConsoleOperator consoleOperator)
        {
            _productRepository = productRepository;
            _consoleOperator = consoleOperator;
        }

        public string Description => "Update storage for specify product";

        public void Execute()
        {
            var (nameOfProduct, quantity, isValid) = _consoleOperator.GetProductNameAndQuantity();

            var (price, name, sumOfQuantity) = _productRepository.AddToStorage(nameOfProduct, quantity);

            _consoleOperator.ShowSummaryOfAddedProducts(name, price, sumOfQuantity);
        }
    }
}
