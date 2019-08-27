using Shop.App.Commands.Abstract;
using Shop.DomainService.Repositories.Abstract;
using Shop.Infra.ConsoleHelper.Abstract;
using System;

namespace Shop.App.Commands
{
    public class BuyProductsCommand : ICommand
    {
        private IProductRepository _productRepository;
        private IConsoleOperator _consoleOperator;

        public BuyProductsCommand(
            IProductRepository productRepository,
            IConsoleOperator consoleOperator)
        {
            _productRepository = productRepository;
            _consoleOperator = consoleOperator;
        }

        public string Description => "Buy product.";

        public void Execute()
        {
            var avaiableProducts = _productRepository.GetAvaiableProductsFromDb();

            _consoleOperator.ShowListOfAllAvaiableProducts(avaiableProducts);

            Console.WriteLine("How many products would you like to buy?");
            string stringhowManyProductsToBuyInput = Console.ReadLine();
            int howManyProductsToBuy = string.IsNullOrWhiteSpace(stringhowManyProductsToBuyInput) ? 0 : Convert.ToInt32(stringhowManyProductsToBuyInput);
            if (howManyProductsToBuy == 0)
            {
                Console.WriteLine("Wrong data");
            }

            decimal sumOfPrice = 0;
            for (int i = 0; i < howManyProductsToBuy; i++)
            {
                var (id, quantity, isValid) = _consoleOperator.GetProductNameAndQuantity();

                if (!isValid)
                {
                    Console.WriteLine("We don't have that product in ofert.");
                    return;
                }

                var (nameOfProduct, sumOfPriceFromProducts, isValidBuy) = _productRepository.BuyProduct(id, quantity);

                if (!isValidBuy)
                {
                    Console.WriteLine("Sorry, product out of stock!");
                    return;
                }
                sumOfPrice += sumOfPriceFromProducts;
            }
            Console.WriteLine($"Sum price: {sumOfPrice}");
        }
    }
}
