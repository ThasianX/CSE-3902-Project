using Project1.Interfaces;
using Project1.Levels;

namespace Project1.Commands
{
    class MoveToNextRoomCommand : ICommand
    {
        int nextRoom;

        public MoveToNextRoomCommand(IExit door)
        {
            nextRoom = door.nextRoom;
        }

        public void Execute()
        {
            LevelManager.Instance.MoveRoom(nextRoom);
        }
    }
}
