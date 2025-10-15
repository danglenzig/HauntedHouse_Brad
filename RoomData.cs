namespace HauntedHouse;

public class RoomData
{
    
    private Dictionary<string, Room> rooms = new();

    //public Dictionary<string, Room> Rooms
    //{
    //    get => rooms;
    //}
    
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
        var airlock = new Room.RoomBuilder()
            .AddRoomId("Airlock")
            .AddDisplayName("airlock")
            .AddRoomOrientation(false)
            .AddDialogue("You step into the airlock. The walls are scuffed with suit scratches, and a faint mist of\ncondensation drifts in the cold air.")
            .AddDialogue("The silence feels wrong")
            .AddAdjacentRoom(Directions.Up, "CentralCorridor")
            .Build();
        rooms.Add("Airlock", airlock);

        var centralCorridor = new Room.RoomBuilder()
            .AddRoomId("CentralCorridor")
            .AddDisplayName("central corridor")
            .AddRoomOrientation(false)
            .AddDialogue(
                "A wide passageway lined with darkened display panels and flickering overhead lights.\nScattered crates make it easy for something to hide.")
            .AddAdjacentRoom(Directions.Down, "Airlock")
            .AddAdjacentRoom(Directions.Right, "CrewQuarters")
            .AddAdjacentRoom(Directions.Up, "Bridge")
            .AddAdjacentRoom(Directions.Left, "MedicalBay")
            .Build();
        rooms.Add("CentralCorridor", centralCorridor);

        var bridge = new Room.RoomBuilder()
            .AddRoomId("Bridge")
            .AddDisplayName("bridge")
            .AddRoomOrientation(false)
            .AddDialogue(
                "The ship’s nerve center. The captain’s chair is empty, the consoles dead except for a faint\nblinking error on the navigation system.")
            .AddAdjacentRoom(Directions.Up, "Turbolift")
            .AddAdjacentRoom(Directions.Right, "ObservationDeck")
            .AddAdjacentRoom(Directions.Down, "CentralCorridor")
            .Build();
        rooms.Add("Bridge", bridge);

        var observationDeck = new Room.RoomBuilder()
            .AddRoomId("ObservationDeck")
            .AddDisplayName("observation deck")
            .AddRoomOrientation(false)
            .AddDialogue("A glass dome opens to the black infinity of space.")
            .AddDialogue("Streaks of blood smear across the viewport as though someone was dragged.")
            .AddAdjacentRoom(Directions.Left, "Bridge")
            .Build();
        rooms.Add("ObservationDeck", observationDeck);

        var turbolift = new Room.RoomBuilder()
            .AddRoomId("Turbolift")
            .AddDisplayName("turbolift")
            .AddRoomOrientation(true)
            .AddDialogue("You're in the ship's central turbolift. It has two buttons: UP and DOWN")
            .AddAdjacentRoom(Directions.Up, "Bridge")
            .AddAdjacentRoom(Directions.Down, "Engineering")
            .Build();
        rooms.Add("Turbolift", turbolift);

        var crewQuarters = new Room.RoomBuilder()
            .AddRoomId("CrewQuarters")
            .AddDisplayName("crew quarters")
            .AddRoomOrientation(false)
            .AddDialogue("Narrow bunks, personal effects scattered everywhere. Some metal lockers hang open,")
            .AddDialogue("...others are bowed outward, as if clawed from the inside.")
            .AddAdjacentRoom(Directions.Left, "CentralCorridor")
            .AddAdjacentRoom(Directions.Right, "MessHall")
            .Build();
        rooms.Add("CrewQuarters", crewQuarters);

        var messHall = new Room.RoomBuilder()
            .AddRoomId("MessHall")
            .AddDisplayName("mess hall")
            .AddRoomOrientation(false)
            .AddDialogue("A wide room with overturned tables and trays. The smell of rot mixes with burned food.")
            .AddDialogue("A ceiling vent rattles as though something’s crawling inside")
            .AddAdjacentRoom(Directions.Left, "CrewQuarters")
            .Build();
        rooms.Add("MessHall", messHall);

        var medicalBay = new Room.RoomBuilder()
            .AddRoomId("MedicalBay")
            .AddDisplayName("medical bay")
            .AddRoomOrientation(false)
            .AddDialogue(
                "Bright white tiles stained brown. Several operating beds hold motionless crew,\ntheir chests oddly swollen.")
            .AddDialogue("Surgical tools are scattered everywhere")
            .AddAdjacentRoom(Directions.Right, "CentralCorridor")
            .AddAdjacentRoom(Directions.Up, "SpecimenLab")
            .Build();
        rooms.Add("MedicalBay", medicalBay);

        var specimenLab = new Room.RoomBuilder()
            .AddRoomId("SpecimenLab")
            .AddDisplayName("specimen lab")
            .AddRoomOrientation(false)
            .AddDialogue("Glass tubes line the walls, most shattered. Strange organic growths spread across the floor.")
            .AddDialogue("Whatever research was done here, it got out of control.")
            .AddAdjacentRoom(Directions.Down, "MedicalBay")
            .Build();
        rooms.Add("SpecimenLab", specimenLab);

        var engineering = new Room.RoomBuilder()
            .AddRoomId("Engineering")
            .AddDisplayName("main engineering")
            .AddRoomOrientation(false)
            .AddDialogue("The loud hum of the ship’s reactor is now only a faint irregular throb.")
            .AddDialogue("Exposed pipes vent steam, and the room shudders occasionally as if alive.")
            .AddAdjacentRoom(Directions.Right, "Turbolift")
            .AddAdjacentRoom(Directions.Down, "CargoBay")
            .Build();
        rooms.Add("Engineering", engineering);

        var cargoBay = new Room.RoomBuilder()
            .AddRoomId("CargoBay")
            .AddDisplayName("cargo bay")
            .AddRoomOrientation(false)
            .AddDialogue("This is the cargo bay.")
            .AddAdjacentRoom(Directions.Up, "Engineering")
            .Build();
        rooms.Add("CargoBay", cargoBay);
        


        /*
        USAGE PATTERN:

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


        */

        // Continue adding more rooms
    }

    public string GetDisplayNameFromId(string roomId)
    {
        return rooms[roomId].DisplayName;
    }
    
}