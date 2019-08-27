using Shop.Domain.Model;
using Shop.Infra.ConsoleHelper.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Infra.ConsoleHelper
{
    public class ConsoleOperator : IConsoleOperator
    {
        private void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        private string Read()
        {
            return Console.ReadLine();
        }
        
        public (string, decimal, bool) GetProductOffer()
        {
            WriteLine("Type name:");
            string name = this.Read();

            WriteLine("Type price:");
            string priceInput = this.Read();
            decimal price = string.IsNullOrWhiteSpace(priceInput) ? 0 : Convert.ToDecimal(priceInput);

            bool isValid = true;
            if (string.IsNullOrWhiteSpace(name) || price == 0)
            {
                WriteLine("You send me wrong data");
                isValid = false;
            }
            return (name, price, isValid);
        }

        public (string, int, bool) GetProductNameAndQuantity()
        {
            this.WriteLine("Type name:");
            string name = this.Read();

            this.WriteLine("Type quantity");
            string quantityFromConsole = this.Read();
            int quantity = string.IsNullOrWhiteSpace(quantityFromConsole) ? 0 : Convert.ToInt32(quantityFromConsole);

            bool isValid = true;
            if (string.IsNullOrWhiteSpace(name) || quantity == 0)
            {
                this.WriteLine("You send me wrong data");
                isValid = false;
            }
            return (name, quantity, isValid);
        }

        public void ShowSummaryOfAddedProducts(string name, decimal price, int quantity)
        {
            this.WriteLine(
                $"Success! You add a new product to offer. " +
                Environment.NewLine +
                $"Name: {name} " +
                Environment.NewLine +
                $"Price: {price}" +
                Environment.NewLine +
                $"Quantity: {quantity}");
        }

        public void ShowListOfAllAvaiableProducts(List<Product> avaiableProducts)
        {
            foreach (var item in avaiableProducts)
            {
                Console.WriteLine(
                    $"Id: {item.Id} " +
                    $"Product: {item.NameOfProduct} " +
                    $"Price: {item.Price} " +
                    $"Quantity:{item.Quantity}");
            }
        }
    }
}
