using HauntedHouse;

namespace HauntedHouse;

public class Room
{
    
    public string RoomId;
    public string DisplayName;
    public bool IsVertical;
    public Dictionary<Directions, string> AdjacentRooms = new ();
    
    private List<string> OnExitDialogues = new ();
    private List<string> OnEnterDialogues = new();
    private List<string> OnEnterGameStateMessages = new();
    private MiscTools miscTools;
    private Game game;
    public void OnRoomEntered()
    {
        foreach (string message in OnEnterGameStateMessages)
        {
            game._GameData.SendMessage(message);
        }
        PlayOnEnterDialogues();
    }

    public void OnRoomExited()
    {
        PlayExitDialogues();
    }

    public void HandleRoomItems()
    {
        //
    }

    private void PlayExitDialogues()
    {
        Console.Clear();
        foreach (string dialogue in OnExitDialogues)
        {
            Console.Clear();
            miscTools.RevealText(dialogue, 20);
            miscTools.PressKeyToContinue();
        }
    }
    
    private void PlayOnEnterDialogues()
    {
        Console.Clear();
        foreach (string dialogue in OnEnterDialogues)
        {
            Console.Clear();
            miscTools.RevealText(dialogue, 20);
            miscTools.PressKeyToContinue();
        }
    }
    
    
    public class RoomBuilder
    {
        private Room room = new ();

        public RoomBuilder AddRoomId(string roomId)
        {
            room.RoomId = roomId;
            return this;
        }

        public RoomBuilder AddOnExitDialogue(string dialogue)
        {
            room.OnExitDialogues.Add(dialogue);
            return this;
        }

        public RoomBuilder AddOnEnterDialogue(string dialogue)
        {
            room.OnEnterDialogues.Add(dialogue);
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

        public RoomBuilder AddMiscTools()
        {
            room.miscTools =  new MiscTools();
            return this;
        }

        public RoomBuilder AddOnEnterGameStateMessage(string message)
        {
            room.OnEnterGameStateMessages.Add(message);
            return this;
        }

        public RoomBuilder AddGameReference(Game _game)
        {
            room.game = _game;
            return this;
        }
        
        public Room Build()
        {
            return room;
        }
    }
}