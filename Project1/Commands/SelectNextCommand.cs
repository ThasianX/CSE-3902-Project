using Project1.Interfaces;

namespace Project1.Commands
{
    class SelectNextCommand : ICommand
    {
        public void Execute()
        {
            InventoryManager.Instance.SelectNext();
        }
    }
}
