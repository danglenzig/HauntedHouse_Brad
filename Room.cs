using HauntedHouse;

namespace HauntedHouse;

public class Room
{
    
    public string RoomId;
    public string DisplayName;
    public bool IsVertical;
    //public bool alreadySeen = false;
    public List<string> Dialogues = new ();
    public Dictionary<Directions, string> AdjacentRooms = new ();


    public void OnRoomEntered(EnemyData enemyData)
    {
        
        // - check if there's an enemy in this room
        // - if so, check its health (is it dead)
        // - if not, fight it (HandleCombat(), below)
        //     - during the give the player an option to retreat the way they came
        //     - TODO: how do we know what room they came from?
        // - Kill the enemy or die

        if (enemyData.GetEnemyByRoomId(RoomId) != null)
        {
            Enemy enemy = enemyData.GetEnemyByRoomId(RoomId);
            HandleCombat(enemy);
        }
        PlayLongDialogues();
        
        
        
        
    }
    
    public void PlayLongDialogues()
    {
        foreach (string dialogue in Dialogues)
        {
            Console.Clear();
            foreach (var character in dialogue)
            {
                Console.Write(character);
                Thread.Sleep(2);
            }

            Console.WriteLine("\n\nPress any key to continue..");
            Console.ReadKey();
        }
    }

    public void HandleCombat(Enemy enemy)
    {
        //Enemy enemy = enemyData.GetEnemyByRoomId(RoomId);
        Console.Clear();
        string msg = $"You gonna fight {enemy.EnemyName}!\n{enemy.FlavorText}";
        foreach (var character in msg)
        {
            Console.Write(character);
            Thread.Sleep(2);
        }
        
        Console.WriteLine("\n\nPress any key to continue..");
        Console.ReadKey();
        
        //TODO: handle combat
        // if the enemy is dead, make a comment and move on 
    }
    
    

    public class RoomBuilder
    {
        private Room room = new ();

        public RoomBuilder AddRoomId(string roomId)
        {
            room.RoomId = roomId;
            return this;
        }

        public RoomBuilder AddDialogue(string dialogue)
        {
            room.Dialogues.Add(dialogue);
            return this;
        }

        public RoomBuilder AddAdjacentRoom(Directions direction, string adjacentRoomId)
        {
            room.AdjacentRooms.Add(direction, adjacentRoomId);
            return this;
        }

        public RoomBuilder AddRoomOrientation(bool isVerical)
        {
            room.IsVertical = isVerical;
            return this;
        }

        public RoomBuilder AddDisplayName(string displayName)
        {
            room.DisplayName = displayName;
            return this;
        }
        

        public Room Build()
        {
            return room;
        }
    }
    
}