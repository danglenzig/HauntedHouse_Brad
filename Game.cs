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
    public bool Playing
    {
        get=> playing;
        set
        {
            playing = value;
        }
    }
    
    public RoomData _RoomData
    {
        get => _roomData;
    }

    public EnemyData _EnemyData
    {
        get => _enemyData;
    }

    public RoomController _RoomController
    {
        get => roomController;
    }

    public Game()
    {
        CreateDependencies();
        playing = true;
    }

    public void Run()
    {
        
        Console.WriteLine("Welcome to the SS Calliope!");
        Console.WriteLine("\n\nPress any key to continue..");
        Console.ReadKey();
        // TODO: opening narration
        
        while (playing)
        {
            roomController.OnRoomEnter();
            roomController.HandleRoomCombat();
            //roomController.HandleRoomItems(); //TODO
            roomController.OnRoomExit();
            movementController.HandleMovement(roomController.CurrentRoom); // <-- will set playing = false if Q is pressed, otherwise it ingests the arrow keys
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

        roomController = new RoomController(this);
        //roomController = new RoomController(_roomData, _enemyData);
        movementController = new MovementController(this);
        
    }
    
    
    
}
