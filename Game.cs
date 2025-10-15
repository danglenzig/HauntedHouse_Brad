namespace HauntedHouse;

public class Game
{
    private RoomData _roomData; 
    private MovementController movementController;
    private RoomController roomController;
    private bool playing;

    public Game()
    {
        CreateDependencies();
        playing = true;
    }

    public void Run()
    {
        while (playing)
        {
            roomController.PlayDialogue();
            var pressedKey = movementController.StateDirections(roomController.CurrentRoom);
            if (pressedKey == ConsoleKey.Q)
            {
                playing = false;
                return;
            }
            movementController.Move(pressedKey);
        }
    }
    
    private void CreateDependencies()
    {
        _roomData = new RoomData();
        roomController = new RoomController(_roomData);
        movementController = new MovementController(roomController);
    }
}
