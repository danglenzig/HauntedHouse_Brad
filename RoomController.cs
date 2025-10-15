namespace HauntedHouse;

public class RoomController
{
    // DO NOT CHANGE THIS ID, we always want to start in the entrance
    private static string FirstRoomId = "Entrance";
    public Room CurrentRoom { get; private set; }

    private RoomData roomData;
    private List<string> roomIds;

    public RoomController(RoomData roomData)
    {
        this.roomData = roomData;
        LoadRoom(FirstRoomId);
    }

    public void LoadRoom(string roomName)
    {
        CurrentRoom = roomData.GetRoomData(roomName);
    }

    public void PlayDialogue()
    {
        CurrentRoom.PlayDialogues();
    }
}