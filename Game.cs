using System.Runtime.CompilerServices;

namespace HauntedHouse;

public class Game
{
    
    private RoomData _roomData; 
    private MovementController movementController;
    private RoomController roomController;
    private Player player;
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

    public void OnPlayerDied()
    {
        Console.WriteLine("YOU DEAD");
        playing = false;
        return;
    }

    
    
    private void CreateDependencies()
    {
        _roomData = new RoomData();
        roomController = new RoomController(_roomData);
        movementController = new MovementController(roomController, _roomData);
        player = new Player(this);
    }
    
    
    
}
