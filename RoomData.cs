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
            .AddDisplayName("the airlock")
            .AddRoomOrientation(false)
            
            .AddOnEnterDialogue("You step into the airlock. The walls are scuffed with suit scratches, and a faint mist of\ncondensation drifts in the cold air.")
            .AddOnEnterDialogue("The silence feels wrong")
            
            .AddOnExitDialogue("Let's go...")
            
            .AddAdjacentRoom(Directions.Up, "CentralCorridor")
            .AddMiscTools()
            .Build();
        rooms.Add("Airlock", airlock);

        var centralCorridor = new Room.RoomBuilder()
            .AddRoomId("CentralCorridor")
            .AddDisplayName("the central corridor")
            .AddRoomOrientation(false)
            
            .AddOnEnterDialogue("A wide passageway lined with darkened display panels and flickering overhead lights.\nScattered crates make it easy for something to hide.")
            
            .AddOnExitDialogue("You are now leaving the central corridor.")
            
            .AddAdjacentRoom(Directions.Down, "Airlock")
            .AddAdjacentRoom(Directions.Right, "CrewQuarters")
            .AddAdjacentRoom(Directions.Up, "Bridge")
            .AddAdjacentRoom(Directions.Left, "MedicalBay")
            .AddMiscTools()
            .Build();
        rooms.Add("CentralCorridor", centralCorridor);

        var bridge = new Room.RoomBuilder()
            .AddRoomId("Bridge")
            .AddDisplayName("the bridge")
            .AddRoomOrientation(false)
            
            .AddOnEnterDialogue("The ship’s nerve center. The captain’s chair is empty, the consoles dead except for a faint\nblinking error on the navigation system.")
            
            .AddOnExitDialogue("You are now leaving the bridge")
            
            .AddAdjacentRoom(Directions.Up, "Turbolift")
            .AddAdjacentRoom(Directions.Right, "ObservationDeck")
            .AddAdjacentRoom(Directions.Down, "CentralCorridor")
            .AddMiscTools()
            .Build();
        rooms.Add("Bridge", bridge);

        var observationDeck = new Room.RoomBuilder()
            .AddRoomId("ObservationDeck")
            .AddDisplayName("the observation deck")
            .AddRoomOrientation(false)
            
            .AddOnEnterDialogue("A glass dome opens to the black infinity of space.")
            .AddOnEnterDialogue("Streaks of blood smear across the viewport as though someone was dragged.")
            
            .AddOnExitDialogue("You are now leaving the observation deck.")
            
            .AddAdjacentRoom(Directions.Left, "Bridge")
            .AddMiscTools()
            .Build();
        rooms.Add("ObservationDeck", observationDeck);

        var turbolift = new Room.RoomBuilder()
            .AddRoomId("Turbolift")
            .AddDisplayName("the turbolift")
            .AddRoomOrientation(true)
            
            .AddOnEnterDialogue("You're in the ship's central turbolift. It has two buttons: UP and DOWN")
            
            .AddOnExitDialogue("Press a button")
            
            .AddAdjacentRoom(Directions.Up, "Bridge")
            .AddAdjacentRoom(Directions.Down, "Engineering")
            .AddMiscTools()
            .Build();
        rooms.Add("Turbolift", turbolift);

        var crewQuarters = new Room.RoomBuilder()
            .AddRoomId("CrewQuarters")
            .AddDisplayName("crew quarters")
            .AddRoomOrientation(false)
            
            
            .AddOnEnterDialogue("Narrow bunks, personal effects scattered everywhere. Some metal lockers hang open,")
            .AddOnEnterDialogue("...others are bowed outward, as if clawed from the inside.")
            
            .AddOnExitDialogue("You are now leaving the crew quarters.")
            
            
            .AddAdjacentRoom(Directions.Left, "CentralCorridor")
            .AddAdjacentRoom(Directions.Right, "MessHall")
            .AddMiscTools()
            .Build();
        rooms.Add("CrewQuarters", crewQuarters);

        var messHall = new Room.RoomBuilder()
            .AddRoomId("MessHall")
            .AddDisplayName("the mess hall")
            .AddRoomOrientation(false)
            
            .AddOnEnterDialogue("A wide room with overturned tables and trays. The smell of rot mixes with burned food.")
            .AddOnEnterDialogue("A ceiling vent rattles as though something’s crawling inside")
            
            .AddOnExitDialogue("You are now leaving the kitchen.")
            
            .AddAdjacentRoom(Directions.Left, "CrewQuarters")
            .AddMiscTools()
            .Build();
        rooms.Add("MessHall", messHall);

        var medicalBay = new Room.RoomBuilder()
            .AddRoomId("MedicalBay")
            .AddDisplayName("the medical bay")
            .AddRoomOrientation(false)
            
            .AddOnEnterDialogue("Bright white tiles stained brown. Several operating beds hold motionless crew,\ntheir chests oddly swollen.")
            .AddOnEnterDialogue("Surgical tools are scattered everywhere")
            
            .AddOnExitDialogue("You are leaving the medical bay.")
            
            .AddAdjacentRoom(Directions.Right, "CentralCorridor")
            .AddAdjacentRoom(Directions.Up, "SpecimenLab")
            .AddMiscTools()
            .Build();
        rooms.Add("MedicalBay", medicalBay);

        var specimenLab = new Room.RoomBuilder()
            .AddRoomId("SpecimenLab")
            .AddDisplayName("the specimen lab")
            .AddRoomOrientation(false)
            
            .AddOnEnterDialogue("Glass tubes line the walls, most shattered. Strange organic growths spread across the floor.")
            .AddOnEnterDialogue("Whatever research was done here, it got out of control.")
            
            .AddOnExitDialogue("You are now leaving the specimen lab.")
            
            .AddAdjacentRoom(Directions.Down, "MedicalBay")
            .AddMiscTools()
            .Build();
        rooms.Add("SpecimenLab", specimenLab);

        var engineering = new Room.RoomBuilder()
            .AddRoomId("Engineering")
            .AddDisplayName("main engineering")
            .AddRoomOrientation(false)
            
            .AddOnEnterDialogue("The loud hum of the ship’s reactor is now only a faint irregular throb.")
            .AddOnEnterDialogue("Exposed pipes vent steam, and the room shudders occasionally as if alive.")
            
            .AddOnExitDialogue("You are now leaving main engineering.")
            
            .AddAdjacentRoom(Directions.Right, "Turbolift")
            .AddAdjacentRoom(Directions.Down, "CargoBay")
            .AddMiscTools()
            .Build();
        rooms.Add("Engineering", engineering);

        var cargoBay = new Room.RoomBuilder()
            .AddRoomId("CargoBay")
            .AddDisplayName("the cargo bay")
            .AddRoomOrientation(false)
            
            .AddOnEnterDialogue("This is the cargo bay.")
            
            .AddOnExitDialogue("You are now leaving the cargo bay.")
            
            .AddAdjacentRoom(Directions.Up, "Engineering")
            .AddMiscTools()
            .Build();
        rooms.Add("CargoBay", cargoBay);
    }

    public string GetDisplayNameFromId(string roomId)
    {
        return rooms[roomId].DisplayName;
    }
    
}