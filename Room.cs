namespace HauntedHouse;

public class Room
{
    public string RoomId;
    public List<string> Dialogues = new ();
    public Dictionary<Directions, string> AdjacentRooms = new ();
    
    public void PlayDialogues()
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

        public Room Build()
        {
            return room;
        }
    }
}