namespace HauntedHouse
{
    public class RoomData
    {
        private readonly Dictionary<string, Room> rooms = new();
        private readonly Game game;

        public RoomData(Game _game)
        {
            game = _game;
            CreateRooms();
        }

        public Room GetRoomData(string roomId)
        {
            return rooms[roomId];
        }

        private void CreateRooms()
        {
            // ============================================================
            // AIRLOCK
            // ============================================================
            var airlock = new Room.RoomBuilder()
                .AddRoomId("Airlock")
                .AddDisplayName("the airlock")
                .AddRoomOrientation(false)
                .AddOnEnterDialogue(StoryData.Airlock_1)
                .AddOnEnterDialogue(StoryData.Airlock_2)
                .AddOnEnterDialogue(StoryData.Airlock_3)
                .AddOnEnterDialogue(StoryData.Airlock_4)
                .AddOnExitDialogue(StoryData.Airlock_Exit)
                .AddAdjacentRoom(Directions.Up, "CentralCorridor")
                .AddMiscTools()
                .AddGameReference(game)
                .Build();
            rooms.Add("Airlock", airlock);

            // ============================================================
            // CENTRAL CORRIDOR
            // ============================================================
            var centralCorridor = new Room.RoomBuilder()
                .AddRoomId("CentralCorridor")
                .AddDisplayName("the central corridor")
                .AddRoomOrientation(false)
                .AddOnEnterDialogue(StoryData.CentralCorridor_1)
                .AddOnEnterDialogue(StoryData.CentralCorridor_2)
                .AddOnExitDialogue(StoryData.CentralCorridor_Exit)
                .AddAdjacentRoom(Directions.Down, "Airlock")
                .AddAdjacentRoom(Directions.Left, "MedicalBay")
                .AddAdjacentRoom(Directions.Right, "CrewQuarters")
                .AddAdjacentRoom(Directions.Up, "Bridge")
                .AddCompleteObjectiveIDOnEnter("BoardTheStation")
                .AddMiscTools()
                .AddGameReference(game)
                .Build();
            rooms.Add("CentralCorridor", centralCorridor);

            // ============================================================
            // MEDICAL BAY
            // ============================================================
            var medicalBay = new Room.RoomBuilder()
                .AddRoomId("MedicalBay")
                .AddDisplayName("the medical bay")
                .AddRoomOrientation(false)
                .AddOnEnterDialogue(StoryData.MedicalBay_1)
                .AddOnEnterDialogue(StoryData.MedicalBay_2)
                .AddOnEnterDialogue(StoryData.MedicalBay_3)
                .AddOnExitDialogue(StoryData.MedicalBay_Exit)
                .AddAdjacentRoom(Directions.Right, "CentralCorridor")
                .AddAdjacentRoom(Directions.Up, "SpecimenLab")
                .AddMiscTools()
                .AddGameReference(game)
                .Build();
            rooms.Add("MedicalBay", medicalBay);

            // ============================================================
            // CREW QUARTERS
            // ============================================================
            var crewQuarters = new Room.RoomBuilder()
                .AddRoomId("CrewQuarters")
                .AddDisplayName("the crew quarters")
                .AddRoomOrientation(false)
                .AddOnEnterDialogue(StoryData.CrewQuarters_1)
                .AddOnEnterDialogue(StoryData.CrewQuarters_2)
                .AddOnEnterDialogue(StoryData.CrewQuarters_Desk)
                .AddOnEnterDialogue(StoryData.CrewQuarters_Bed)
                .AddOnExitDialogue(StoryData.CrewQuarters_Exit)
                .AddAdjacentRoom(Directions.Left, "CentralCorridor")
                .AddAdjacentRoom(Directions.Right, "MessHall")
                .AddMiscTools()
                .AddGameReference(game)
                .Build();
            rooms.Add("CrewQuarters", crewQuarters);

            // ============================================================
            // MESS HALL
            // ============================================================
            var messHall = new Room.RoomBuilder()
                .AddRoomId("MessHall")
                .AddDisplayName("the mess hall")
                .AddRoomOrientation(false)
                .AddOnEnterDialogue(StoryData.MessHall_1)
                .AddOnEnterDialogue(StoryData.MessHall_2)
                .AddOnEnterDialogue(StoryData.MessHall_Encounter)
                .AddOnExitDialogue(StoryData.MessHall_Exit)
                .AddAdjacentRoom(Directions.Left, "CrewQuarters")
                .AddMiscTools()
                .AddGameReference(game)
                .Build();
            rooms.Add("MessHall", messHall);

            // ============================================================
            // ENGINEERING
            // ============================================================
            var engineering = new Room.RoomBuilder()
                .AddRoomId("Engineering")
                .AddDisplayName("engineering deck")
                .AddRoomOrientation(false)
                .AddOnEnterDialogue(StoryData.Engineering_1)
                .AddOnEnterDialogue(StoryData.Engineering_2)
                .AddOnExitDialogue(StoryData.Engineering_Exit)
                .AddAdjacentRoom(Directions.Up, "Turbolift")
                .AddAdjacentRoom(Directions.Down, "CargoBay")
                .AddMiscTools()
                .AddGameReference(game)
                .Build();
            rooms.Add("Engineering", engineering);

            // ============================================================
            // SPECIMEN LAB
            // ============================================================
            var specimenLab = new Room.RoomBuilder()
                .AddRoomId("SpecimenLab")
                .AddDisplayName("the specimen lab")
                .AddRoomOrientation(false)
                .AddOnEnterDialogue(StoryData.SpecimenLab_1)
                .AddOnEnterDialogue(StoryData.SpecimenLab_2)
                .AddOnExitDialogue(StoryData.SpecimenLab_Exit)
                .AddAdjacentRoom(Directions.Down, "MedicalBay")
                .AddMiscTools()
                .AddGameReference(game)
                .Build();
            rooms.Add("SpecimenLab", specimenLab);

            // ============================================================
            // OBSERVATION DECK
            // ============================================================
            var observationDeck = new Room.RoomBuilder()
                .AddRoomId("ObservationDeck")
                .AddDisplayName("the observation deck")
                .AddRoomOrientation(false)
                .AddOnEnterDialogue(StoryData.ObservationDeck_1)
                .AddOnEnterDialogue(StoryData.ObservationDeck_CombatIntro)
                .AddOnEnterDialogue(StoryData.ObservationDeck_CombatOutro)
                .AddOnExitDialogue(StoryData.ObservationDeck_Exit)
                .AddAdjacentRoom(Directions.Left, "Bridge")
                .AddMiscTools()
                .AddGameReference(game)
                .Build();
            rooms.Add("ObservationDeck", observationDeck);

            // ============================================================
            // BRIDGE
            // ============================================================
            var bridge = new Room.RoomBuilder()
                .AddRoomId("Bridge")
                .AddDisplayName("the bridge")
                .AddRoomOrientation(false)
                .AddOnEnterDialogue(StoryData.Bridge_1)
                .AddOnEnterDialogue(StoryData.Bridge_2)
                .AddOnExitDialogue(StoryData.Bridge_Exit)
                .AddAdjacentRoom(Directions.Down, "CentralCorridor")
                .AddAdjacentRoom(Directions.Right, "ObservationDeck")
                .AddAdjacentRoom(Directions.Up, "Turbolift")
                .AddMiscTools()
                .AddGameReference(game)
                .Build();
            rooms.Add("Bridge", bridge);

            // ============================================================
            // CARGO BAY
            // ============================================================
            var cargoBay = new Room.RoomBuilder()
                .AddRoomId("CargoBay")
                .AddDisplayName("the cargo bay")
                .AddRoomOrientation(false)
                .AddOnEnterDialogue("Massive crates float silently. Something scratches from within one of them.")
                .AddOnExitDialogue("You retreat, the cold metal floor vibrating beneath your boots.")
                .AddAdjacentRoom(Directions.Up, "Engineering")
                .AddMiscTools()
                .AddGameReference(game)
                .Build();
            rooms.Add("CargoBay", cargoBay);

            // ============================================================
            // TURBOLIFT
            // ============================================================
            var turbolift = new Room.RoomBuilder()
                .AddRoomId("Turbolift")
                .AddDisplayName("the turbolift shaft")
                .AddRoomOrientation(false)
                .AddOnEnterDialogue("The turbolift is offline. The car hangs between decks, cables swaying gently.")
                .AddOnExitDialogue("You grip the ladder and climb toward Engineering.")
                .AddAdjacentRoom(Directions.Down, "Bridge")
                .AddAdjacentRoom(Directions.Up, "Engineering")
                .AddMiscTools()
                .AddGameReference(game)
                .Build();
            rooms.Add("Turbolift", turbolift);
        }

        public string GetDisplayNameFromId(string roomId)
        {
            return rooms.ContainsKey(roomId) ? rooms[roomId].DisplayName : "unknown room";
        }
    }
}


/*public class RoomData
{
    private Dictionary<string, Room> rooms = new();
    private Game game;

    public RoomData(Game _game)
    {
        game = _game;
        CreateRooms();
    }

    public Room GetRoomData(string roomId)
    {
        return rooms[roomId];
    }

    private void CreateRooms()
    {
        // ============================================================
        // 🧊 AIRLOCK
        // ============================================================
        var airlock = new Room.RoomBuilder()
            .AddRoomId("Airlock")
            .AddDisplayName("the airlock")
            .AddRoomOrientation(false)
            .AddOnEnterDialogue(
                "You float toward the airlock. The outer door is jammed halfway open, emergency lights flicker weakly.")
            .AddOnEnterDialogue(
                "You force the door closed... *CRASH!* Something breaks loose above you, slamming into your helmet. The visor cracks, your suit light dies.")
            .AddOnEnterDialogue(
                "Warning lights flash red. Oxygen levels critical. The station's systems detect pressure change and start repressurizing the airlock.")
            .AddOnEnterDialogue(
                "You gasp for air as the gauge stabilizes. You're alive... barely. The outer door is sealed tight behind you now.")
            .AddOnExitDialogue(
                "You step cautiously into the dark corridor ahead. Only the dim markings on the floor guide you.")
            .AddAdjacentRoom(Directions.Up, "CentralCorridor")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        rooms.Add("Airlock", airlock);

        // ============================================================
        // 🧩 CENTRAL CORRIDOR
        // ============================================================
        var centralCorridor = new Room.RoomBuilder()
            .AddRoomId("CentralCorridor")
            .AddDisplayName("the central corridor")
            .AddRoomOrientation(false)
            .AddOnEnterDialogue(
                "You step into the central corridor. It's pitch black. Faint luminous floor lines pulse dimly, showing paths to other sections.")
            .AddOnEnterDialogue("Bloody footprints mark the floor, some human, some... not.")
            .AddOnExitDialogue("You glance around. Every sound echoes. Only the Medical Bay door seems half-open.")
            .AddAdjacentRoom(Directions.Down, "Airlock")
            .AddAdjacentRoom(Directions.Left, "MedicalBay")
            .AddAdjacentRoom(Directions.Right, "CrewQuarters")
            .AddAdjacentRoom(Directions.Up, "Bridge")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        rooms.Add("CentralCorridor", centralCorridor);

        // ============================================================
        // 🏥 MEDICAL BAY
        // ============================================================
        var medicalBay = new Room.RoomBuilder()
            .AddRoomId("MedicalBay")
            .AddDisplayName("the medical bay")
            .AddRoomOrientation(false)
            .AddOnEnterDialogue(
                "A faint emergency light flickers overhead, flashing rhythmically and disorienting your vision.")
            .AddOnEnterDialogue("A body lies on a stretcher under the flickering light.")
            .AddOnExitDialogue("You leave the body behind. The flicker feels almost alive.")
            .AddAdjacentRoom(Directions.Right, "CentralCorridor")
            .AddAdjacentRoom(Directions.Up, "SpecimenLab")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        rooms.Add("MedicalBay", medicalBay);

        // ============================================================
        // 🛏️ CREW QUARTERS
        // ============================================================
        var crewQuarters = new Room.RoomBuilder()
            .AddRoomId("CrewQuarters")
            .AddDisplayName("crew quarters")
            .AddRoomOrientation(false)
            .AddOnEnterDialogue("The crew quarters are a mess — beds overturned, lockers ripped open.")
            .AddOnEnterDialogue("You see scribbled notes and personal logs scattered around.")
            .AddOnExitDialogue("A cold silence fills the air, as if the room remembers what happened.")
            .AddAdjacentRoom(Directions.Left, "CentralCorridor")
            .AddAdjacentRoom(Directions.Right, "MessHall")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        rooms.Add("CrewQuarters", crewQuarters);

        // ============================================================
        // 🍽️ MESS HALL
        // ============================================================
        var messHall = new Room.RoomBuilder()
            .AddRoomId("MessHall")
            .AddDisplayName("the mess hall")
            .AddRoomOrientation(false)
            .AddOnEnterDialogue("You enter the mess hall. Tables overturned, trays floating midair in zero-g patches.")
            .AddOnEnterDialogue("A man groans by the wall — his leg twisted at an odd angle.")
            .AddOnExitDialogue("The only exit leads back to the crew quarters.")
            .AddAdjacentRoom(Directions.Left, "CrewQuarters")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        rooms.Add("MessHall", messHall);

        // ============================================================
        // 🔭 OBSERVATION DECK
        // ============================================================
        var observationDeck = new Room.RoomBuilder()
            .AddRoomId("ObservationDeck")
            .AddDisplayName("the observation deck")
            .AddRoomOrientation(false)
            .AddOnEnterDialogue(
                "The observation deck overlooks the planet below — shattered glass and floating debris everywhere.")
            .AddOnExitDialogue("You step carefully back toward the bridge.")
            .AddAdjacentRoom(Directions.Left, "Bridge")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        rooms.Add("ObservationDeck", observationDeck);

        // ============================================================
        // ⚙️ ENGINEERING
        // ============================================================
        var engineering = new Room.RoomBuilder()
            .AddRoomId("Engineering")
            .AddDisplayName("main engineering")
            .AddRoomOrientation(false)
            .AddOnEnterDialogue("Engineering hums faintly. Sparks flicker from open conduits.")
            .AddOnEnterDialogue("Something moves near the power core...")
            .AddOnExitDialogue("The hum of the dying reactor fades behind you.")
            .AddAdjacentRoom(Directions.Up, "Turbolift")
            .AddAdjacentRoom(Directions.Down, "CargoBay")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        rooms.Add("Engineering", engineering);

        // ============================================================
        // 🧠 SPECIMEN LAB
        // ============================================================
        var specimenLab = new Room.RoomBuilder()
            .AddRoomId("SpecimenLab")
            .AddDisplayName("the specimen lab")
            .AddRoomOrientation(false)
            .AddOnEnterDialogue("You enter the specimen lab. The stench of decay hits you instantly.")
            .AddOnEnterDialogue("A monstrous figure bursts from containment — the final abomination.")
            .AddOnExitDialogue("You retreat, heart pounding, the door sealing behind you.")
            .AddAdjacentRoom(Directions.Down, "MedicalBay")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        rooms.Add("SpecimenLab", specimenLab);

        // ============================================================
        // 🚪 BRIDGE
        // ============================================================
        var bridge = new Room.RoomBuilder()
            .AddRoomId("Bridge")
            .AddDisplayName("the bridge")
            .AddRoomOrientation(false)
            .AddOnEnterDialogue("The bridge is silent. Console lights blink weakly. Blood stains the captain’s chair.")
            .AddOnExitDialogue("The hum of systems returning to life fills the air.")
            .AddAdjacentRoom(Directions.Down, "CentralCorridor")
            .AddAdjacentRoom(Directions.Right, "ObservationDeck")
            .AddAdjacentRoom(Directions.Up, "Turbolift")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        rooms.Add("Bridge", bridge);
    }
    
    public string GetDisplayNameFromId(string roomId)
    {
        return rooms[roomId].DisplayName;
    }
}*/