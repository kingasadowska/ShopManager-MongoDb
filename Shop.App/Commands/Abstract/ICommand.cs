namespace Shop.App.Commands.Abstract
{
    public interface ICommand
    {
        string Description { get; }

        void Execute();
    }
}
