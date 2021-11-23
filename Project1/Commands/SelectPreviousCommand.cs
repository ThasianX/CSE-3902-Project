using Project1.Interfaces;

namespace Project1.Commands
{
    class SelectPreviousCommand : ICommand
    {
        public void Execute()
        {
            InventoryManager.Instance.SelectPrevious();
        }
    }
}
