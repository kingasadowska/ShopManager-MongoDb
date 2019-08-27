namespace Shop.Application.Commands
{
    public interface IConsoleOperator
    {
        void WriteLine(string value);
        string Read();
        int ReadUInt();
        int ReadInt();
        int ReadDecimal();
        (int, bool) GetProduct();
        (string, decimal, int, uint, bool) AddProduct();
        void ShowSummaryOfAddedProduct(int quantity, int id, string name, int price);
    }
}