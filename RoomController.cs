using HauntedHouse;

namespace HauntedHouse;

public class RoomController
{
    
    // DO NOT CHANGE THIS ID, we always want to start in the entrance
    private static string FirstRoomId = "Airlock";
    public Room CurrentRoom { get; private set; }

    private Game game;
    private EnemyData enemyData;
    private RoomData roomData;
    private List<string> roomIds;

    //public RoomController(Game _game,  RoomData roomData, EnemyData enemyData)
    public RoomController(Game _game)
    {
        game = _game;

        enemyData = game._EnemyData;
        roomData = game._RoomData;
        
        //this.enemyData = enemyData;
        //this.roomData = roomData;
        LoadRoom(FirstRoomId);
    }

    public void LoadRoom(string roomName)
    {
        CurrentRoom = roomData.GetRoomData(roomName);
    }

    public void OnRoomEnter()
    {
        CurrentRoom.OnRoomEntered();
    }

    public void OnRoomExit()
    {
        CurrentRoom.OnRoomExited();
    }

    public void HandleRoomCombat()
    {
        Enemy? enemy = enemyData.GetEnemyByRoomId(CurrentRoom.RoomId);
        if (enemy == null)
        {
            return;
        }
        CurrentRoom.HandleCombat(enemy);
    }

    public void HandleRoomItems()
    {
        //
    }
    
    

    //public void PlayDialogue()
    //{
     //   CurrentRoom.PlayDialogues();
    //}

   
    
}