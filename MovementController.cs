namespace HauntedHouse;

public class MovementController
{
    private readonly RoomController roomController;

    public MovementController(RoomController roomController)
    {
        this.roomController = roomController;
    }
    
    public ConsoleKey StateDirections(Room currentRoom)
    {
        Console.Clear();
        Console.WriteLine("You can move in the following directions in this room:\n");

        foreach (var adjacentRoom in currentRoom.AdjacentRooms)
        {
            Console.WriteLine($"\t- {adjacentRoom.Key} : {adjacentRoom.Value}");
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