using Shop.Application.Commands.Abstract;
using Shop.Domain.Repositories;
using Shop.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Commands
{
    public class AddProduct : ICommand
    {
        private readonly IProductRepository _productRepository;
        private readonly IConsoleOperator _consoleOperator;

        public AddProduct(IProductRepository productRepository, IConsoleOperator consoleOperator)
        {
            _productRepository = productRepository;
            _consoleOperator = consoleOperator;
        }

        public string Description => "Add product";

        public void Execute()
        {
            var (int, bool) = _consoleOperator.GetProduct();

            if (!isValid)
                return;

            _productRepository.AddProduct(name, price, quantity, id);

            _consoleOperator.ShowSummaryOfAddedProduct(quantity, id, name, price);
        }
    }
}