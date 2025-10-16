using System.Runtime.CompilerServices;
using HauntedHouse;

namespace HauntedHouse;

public class Game
{
    
    private RoomData _roomData;
    private EnemyData _enemyData;
    private MovementController movementController;
    private RoomController roomController;
    private CombatController combatController;
    private Player player;
    private MiscTools miscTools;
    private bool playing;

    public Player _Player
    {
        get => player;
        private set => player = value;
    }
    
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
        // TODO: opening narration
        Console.WriteLine("Welcome to the SS Calliope!");
        miscTools.PressKeyToContinue();
        
        while (playing)
        {
            roomController.OnRoomEnter();
            combatController.HandleCombat(roomController.CurrentRoom.RoomId);
            //roomController.HandleRoomItems(); //TODO
            roomController.OnRoomExit();
            movementController.HandleMovement(roomController.CurrentRoom);
            // movementController will set playing = false if Q is pressed, otherwise it ingests the arrow keys
        }
    }

    public void OnPlayerDied()
    {
        Console.WriteLine("YOU DEAD");
        playing = false;
    }
    
    private void CreateDependencies()
    {
        miscTools = new MiscTools();
        _Player = new Player(this, 100, 10, 5, 5);
        _roomData = new RoomData();
        _enemyData = new EnemyData();

        roomController = new RoomController(this);
        combatController = new CombatController(this, _enemyData);
        //roomController = new RoomController(_roomData, _enemyData);
        movementController = new MovementController(this);
    }
}
