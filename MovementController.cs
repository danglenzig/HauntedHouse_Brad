namespace HauntedHouse;

public class MovementController
{
    
    private readonly RoomController roomController;
    private readonly RoomData roomData;

    public MovementController(RoomController roomController, RoomData roomData)
    {
        this.roomController = roomController;
        this.roomData = roomData;
    }
    
    public ConsoleKey StateDirections(Room currentRoom)
    {
        Console.Clear();
        Console.WriteLine("You can move in the following directions in this room:\n");

        foreach (var adjacentRoom in currentRoom.AdjacentRooms)
        {
            string displayName = roomData.GetDisplayNameFromId(adjacentRoom.Value);
            string directionString = "";

            
            
            bool roomIsVertical = currentRoom.IsVertical;
            if (roomIsVertical)
            {
                switch (adjacentRoom.Key)
                {
                    case Directions.Up:
                        directionString = $"Up to {displayName}";
                        break;
                    case Directions.Down:
                        directionString = $"Down to {displayName}";
                        break;
                }
            }
            else
            {
                switch (adjacentRoom.Key)
                {
                    case Directions.Up:
                        directionString = $"North to {displayName}";
                        break;
                    case Directions.Down:
                        directionString = $"South to {displayName}";
                        break;
                    case Directions.Left:
                        directionString = $"East to {displayName}";
                        break;
                    case Directions.Right:
                        directionString = $"West to {displayName}";
                        break;
                }
            }
            
            
            Console.WriteLine($"\t- {adjacentRoom.Key} : {directionString}");
        }
        
        Console.WriteLine("\nPress any corresponding arrow keys to continue..\n");
        
        ConsoleKeyInfo pressedKeyInfo = Console.ReadKey();
        
        return pressedKeyInfo.Key;
    }

    public void Move(ConsoleKey pressedKey)
    {
        var moveToRoom = pressedKey switch
        {
            ConsoleKey.UpArrow => roomController.CurrentRoom.AdjacentRooms[Directions.Up],
            ConsoleKey.DownArrow => roomController.CurrentRoom.AdjacentRooms[Directions.Down],
            ConsoleKey.LeftArrow => roomController.CurrentRoom.AdjacentRooms[Directions.Left],
            ConsoleKey.RightArrow => roomController.CurrentRoom.AdjacentRooms[Directions.Right],
            
        };
        
        roomController.LoadRoom(moveToRoom);
    }
    
}