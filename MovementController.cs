namespace HauntedHouse;

public class MovementController
{
    
    private readonly RoomController roomController;
    private readonly RoomData roomData;
    private readonly Game game;

    //public MovementController(RoomController roomController, RoomData roomData)
    public MovementController(Game _game)
    {
        game = _game;
        roomController = game._RoomController;
        roomData = game._RoomData;
    }
    
    public ConsoleKey StateDirections(Room currentRoom)
    {
        Console.Clear();
        Console.WriteLine("You can move in the following directions in this room:\n");

        foreach (var adjacentRoom in currentRoom.AdjacentRooms)
        {
            string displayName = roomData.GetDisplayNameFromId(adjacentRoom.Value);
            string directionString = "";
            //string promtString = "";
            
            
            bool roomIsVertical = currentRoom.IsVertical;
            if (roomIsVertical)
            {
                switch (adjacentRoom.Key)
                {
                    case Directions.Up:
                        //promtString = "˄";
                        directionString = $"Up to {displayName}";
                        break;
                    case Directions.Down:
                        //promtString = "˅";
                        directionString = $"Down to {displayName}";
                        break;
                }
            }
            else
            {
                switch (adjacentRoom.Key)
                {
                    case Directions.Up:
                        //promtString = "˄";
                        directionString = $"North to {displayName}";
                        break;
                    case Directions.Down:
                        //promtString = "˅";
                        directionString = $"South to {displayName}";
                        break;
                    case Directions.Left:
                        //promtString = "˂";
                        directionString = $"East to {displayName}";
                        break;
                    case Directions.Right:
                        //promtString = "\t˃";
                        directionString = $"West to {displayName}";
                        break;
                }
            }
            
            //Console.WriteLine($"\t- {promtString} : {directionString}");
            Console.WriteLine($"\t- {adjacentRoom.Key} : {directionString}");
        }
        
        

        ConsoleKeyInfo _pressedKeyInfo = new ConsoleKeyInfo();
        bool keyIsValid = false;

        while (!keyIsValid)
        {
            Console.WriteLine("\nPress any corresponding arrow keys to continue..\n");
            _pressedKeyInfo = Console.ReadKey();
            keyIsValid = (_pressedKeyInfo.Key == ConsoleKey.LeftArrow  || _pressedKeyInfo.Key == ConsoleKey.RightArrow || _pressedKeyInfo.Key == ConsoleKey.UpArrow  || _pressedKeyInfo.Key == ConsoleKey.DownArrow);
        }
        
        return _pressedKeyInfo.Key;
        
        //Console.WriteLine("\nPress any corresponding arrow keys to continue..\n");
        //ConsoleKeyInfo pressedKeyInfo = Console.ReadKey();
        //return pressedKeyInfo.Key;
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