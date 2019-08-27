using Shop.Application.Commands.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using Shop.Domain.Repositories;
using Shop.Domain.Repositories.Abstract;

namespace Shop.Application.Commands
{
    public class BuyProduct : ICommand
    {
        private readonly IProductRepository _productRepository;
        private readonly IConsoleOperator _consoleOperator;

        public BuyProduct(IProductRepository productRepository, IConsoleOperator consoleOperator)
        {
            _productRepository = productRepository;
            _consoleOperator = consoleOperator;
        }
        public string Description => "Buy products";

        public void Execute()
        {
           var (id, bool) =  _consoleOperator.GetProduct();
        }
    }
}
