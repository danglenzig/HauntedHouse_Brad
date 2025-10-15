using System.Runtime.CompilerServices;
using HauntedHouse;

namespace HauntedHouse;

public class Game
{
    
    private RoomData _roomData;
    private EnemyData _enemyData;
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
        
        Console.WriteLine("Welcome to the SS Calliope!");
        // TODO: opening narration
        
        while (playing)
        {
            roomController.OnRoomEnter();
            //roomController.PlayDialogue();
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
        
        player = new Player(this, 100, 10, 5, 5);
        _roomData = new RoomData();
        _enemyData = new EnemyData();
        roomController = new RoomController(_roomData, _enemyData);
        movementController = new MovementController(roomController, _roomData);
        
    }
    
    
    
}
