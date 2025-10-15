namespace HauntedHouse;

public class RoomData
{
    private Dictionary<string, Room> rooms = new();
    
    public RoomData()
    {
        CreateRooms();
    }

    public Room GetRoomData(string roomId)
    {
        return rooms[roomId];
    }
    
    private void CreateRooms()
    {
        var entrance = new Room.RoomBuilder()
            .AddRoomId("Entrance")
            .AddDialogue("Welcome to my House of Horrors!")
            .AddDialogue("You've entered the building and are situated in the grand hall of the mansion:\nA mist creeps along the floor and erie sounds of scraping metal come from beneath your feet, as you\ntry to focus and get an overview of your location in the flickering light of the chandelier.")
            .AddDialogue("Ahead you see a big flight of stairs and to your right is a passage with more rooms,\nto your left you observe what seems to be a dining hall, and behind you is the locked entrance door.")
            .AddDialogue("The setting in the hallway chills your spine and raises the hairs along your neck as fear sets in, and you\nrealise that you're stuck here!")
            .AddDialogue("- \"H-h-hello?\"\n- \"Is anyone here?\", you ask.")
            .AddDialogue("As you stand there in your own silence, a muffled scream for help kicks your instincts to life, and you\nimmediately raise your clenched fists, ready to fight whatever might come close!")
            .AddDialogue("You briefly stop breathing awaiting the impeding doom but, to your surprise nothing happens..")
            .AddAdjacentRoom(Directions.Up, "Stairway")
            .AddAdjacentRoom(Directions.Left, "DiningRoom")
            .AddAdjacentRoom(Directions.Right, "Hallway")
            .Build();

        rooms.Add(entrance.RoomId, entrance);
        
        // Add more rooms here, continue with the Stairway, DiningRoom and Hallway
        var stairway = new Room.RoomBuilder()
            .AddRoomId("Stairway") // Add room id
            .AddDialogue("Add Dialogues") // Add room dialogue(s)
            .AddAdjacentRoom(Directions.Down, "Entrance")// Add adjacent room(s)
            .Build();
        
        rooms.Add(stairway.RoomId, stairway);
        
        var diningRoom = new Room.RoomBuilder()
            .AddRoomId("DiningRoom")
            .AddDialogue("Add Dialogues")
            .AddAdjacentRoom(Directions.Down, "Entrance")
            .Build();
        
        rooms.Add(diningRoom.RoomId, diningRoom);
        
        var hallway = new Room.RoomBuilder()
            .AddRoomId("Hallway")
            .AddDialogue("Add Dialogues")
            .AddAdjacentRoom(Directions.Down, "Entrance")
            .Build();
        
        rooms.Add(hallway.RoomId, hallway);
        
        // Continue adding more rooms
    }
}