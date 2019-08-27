using Shop.Domain.Model;
using System.Collections.Generic;

namespace Shop.Infra.ConsoleHelper.Abstract
{
    public interface IConsoleOperator
    {
        (string, decimal, bool) GetProductOffer();
        (string, int, bool) GetProductNameAndQuantity();
        void ShowSummaryOfAddedProducts(string name, decimal price, int quantity);
        void ShowListOfAllAvaiableProducts(List<Product> avaiableProducts);
    }
}
