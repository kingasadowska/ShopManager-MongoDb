using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Application.Commands
{
    public class Operations
    {
        public void WriteLine(string value)
        {
            Console.WriteLine(value);
        }

        public string Read()
        {
            return Console.ReadLine();
        }

        public int ReadInt()
        {
            return Convert.ToInt32(Console.ReadLine());
        }

        public uint ReadUint()
        {
            return Convert.ToUInt32(Console.ReadLine());
        }

        public decimal ReadDecimal()
        {
            return Convert.ToDecimal(Console.ReadLine());
        }

        public (string, decimal, int, uint, bool) AddProduct()
        {
            this.WriteLine("Type name:");
            string name = this.Read();

            this.WriteLine("Type price:");
            decimal price = this.ReadDecimal();

            this.WriteLine("Type id:");
            int id = this.ReadInt();

            this.WriteLine("Type quantity:");
            uint quantity = this.ReadUint();

            bool isValid = true;
            if (string.IsNullOrWhiteSpace(name) || price == 0 || id == 0 || quantity == 0)
            {
                this.WriteLine("You send me wrong data");
            }
            return (name, price, id, quantity, isValid );
        }

        public (int, bool) GetProduct()
        {
            this.WriteLine("Type id:");
            int id = this.ReadInt();

            bool isValid = true;
            if (id == 0)
            {
                this.WriteLine("You send me wrong data");
            }
            return (id, isValid);
        }

        public void ShowSummaryOfAddedProduct(int quantity, int id, string name, int price)
        {
            this.WriteLine(
                $"Success! You add a new product. " +
                Environment.NewLine +
                $"Name: {name} " +
                Environment.NewLine +
                $"Price: {price} " +
                Environment.NewLine +
                $"Id: {id}" +
                Environment.NewLine +
                $"Quantity: {quantity}");
        }
    }
}


