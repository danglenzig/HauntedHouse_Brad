namespace HauntedHouse;

public class MovementController
{

    private readonly RoomController roomController;
    private readonly RoomData roomData;
    private readonly Game game;
    private readonly MiscTools miscTools;
    
    
    //public MovementController(RoomController roomController, RoomData roomData)
    public MovementController(Game _game)
    {
        game = _game;
        roomController = game._RoomController;
        roomData = game._RoomData;
        miscTools = new MiscTools();

    }
    
    public void HandleMovement(Room currentRoom)
    {
        var pressedKey = StateDirections(currentRoom);
        //if (pressedKey == ConsoleKey.Q)
        //{
        //    game.Playing = false;
        //    return;
        //}

        if (pressedKey == ConsoleKey.O)
        {
            DisplayObjectives();
            return;
        }
        
        
        Move(pressedKey);
    }
    
    private ConsoleKey StateDirections(Room currentRoom)
    {
        //Console.Clear();
        Console.WriteLine("\nYou can move in the following directions in this room:\n");
        
        List<string> availableDirections = new List<string>();

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
                        availableDirections.Add("UP");
                        break;
                    case Directions.Down:
                        //promtString = "˅";
                        directionString = $"Down to {displayName}";
                        availableDirections.Add("DOWN");
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
                        availableDirections.Add("UP");
                        break;
                    case Directions.Down:
                        //promtString = "˅";
                        directionString = $"South to {displayName}";
                        availableDirections.Add("DOWN");
                        break;
                    case Directions.Left:
                        //promtString = "˂";
                        directionString = $"West to {displayName}";
                        availableDirections.Add("LEFT");
                        break;
                    case Directions.Right:
                        //promtString = "\t˃";
                        directionString = $"East to {displayName}";
                        availableDirections.Add("RIGHT");
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
            Console.WriteLine("\nPress O to view mission objectives.");
            Console.WriteLine("Press any corresponding arrow keys to navigate...\n");
            _pressedKeyInfo = Console.ReadKey();

            keyIsValid = true;
            
            if (!(_pressedKeyInfo.Key == ConsoleKey.LeftArrow ||
                  _pressedKeyInfo.Key == ConsoleKey.RightArrow ||
                  _pressedKeyInfo.Key == ConsoleKey.UpArrow ||
                  _pressedKeyInfo.Key == ConsoleKey.DownArrow || 
                  _pressedKeyInfo.Key == ConsoleKey.O ))
            {
                keyIsValid = false;
            }

            switch (_pressedKeyInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    if (!availableDirections.Contains("LEFT"))
                    {
                        keyIsValid = false;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (!availableDirections.Contains("RIGHT"))
                    {
                        keyIsValid = false;
                    }
                    break;
                case ConsoleKey.UpArrow:
                    if (!availableDirections.Contains("UP"))
                    {
                        keyIsValid = false;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (!availableDirections.Contains("DOWN"))
                    {
                        keyIsValid = false;
                    }
                    break;
            }
            
            
            
            //keyIsValid = (_pressedKeyInfo.Key == ConsoleKey.LeftArrow  || _pressedKeyInfo.Key == ConsoleKey.RightArrow || _pressedKeyInfo.Key == ConsoleKey.UpArrow  || _pressedKeyInfo.Key == ConsoleKey.DownArrow);
        }
        
        return _pressedKeyInfo.Key;
        
        //Console.WriteLine("\nPress any corresponding arrow keys to continue..\n");
        //ConsoleKeyInfo pressedKeyInfo = Console.ReadKey();
        //return pressedKeyInfo.Key;
    }


    private void DisplayObjectives()
    {
        Console.Clear();
        //game.Output("<Mission objectives shown here>");
        Console.WriteLine("-- CURRENT MISSION OBJECTIVES --\n");
        game.Output(game._ObjectivesData.GetStartedObjectivesDisplayString());
        miscTools.PressKeyToContinue();
        Console.Clear();
        HandleMovement(roomController.CurrentRoom);
    }

    private void Move(ConsoleKey pressedKey)
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