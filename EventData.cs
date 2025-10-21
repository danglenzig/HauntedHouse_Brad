 namespace HauntedHouse
{
    public class EventData
    {
        private readonly Game game;
        private readonly Random random = new();

        public EventData(Game _game)
        {
            game = _game;
            CreateEvents();
        }

        private Dictionary<string, GameEvent> events = new();

        public GameEvent GetEventById(string eventId)
        {
            return events.ContainsKey(eventId) ? events[eventId] : null;
        }

        private void CreateEvents()
        {
            // ============================================================
            // GENERIC / BASE EVENTS
            // ============================================================
            events["InspectRoom"] = new GameEvent("InspectRoom", "Inspect the area", (player, room) =>
            {
                game.Output("You scan the room carefully. The silence feels heavy.");
                if (random.NextDouble() < 0.2)
                    game.Output("Something moves in the shadows, but nothing emerges.");
            });

            events["Rest"] = new GameEvent("Rest", "Take a short rest", (player, room) =>
            {
                game.Output("You sit down, back against the cold metal. Your breath echoes in your helmet.");
                if (random.NextDouble() < 0.5)
                {
                    player.Health += 1;
                    game.Output("You steady your breathing. (+1 health)");
                }
                else
                {
                    game.Output("A sound in the dark keeps you from relaxing.");
                }
            });

            // ============================================================
            // MEDICAL BAY EVENTS
            // ============================================================
            events["FindFlashlight"] = new GameEvent("FindFlashlight", "Search the body", (player, room) =>
            {
                game.Output(StoryData.MedicalBay_FoundFlashlight);
                player.HasFlashlight = true;
                player.HasKeycardLevel1 = true;
            });

            events["HideFromCreature"] = new GameEvent("HideFromCreature", "Hide under the bed", (player, room) =>
            {
                game.Output(StoryData.MedicalBay_HideEvent);
                if (random.NextDouble() < 0.3)
                {
                    player.Health -= 1;
                    game.Output("Something scraped your leg before it left. (-1 health)");
                }
                else
                {
                    game.Output("It leaves. The air feels colder now.");
                }
            });

            // ============================================================
            // CREW QUARTERS EVENTS
            // ============================================================
            events["FindChocolate"] = new GameEvent("FindChocolate", "Search the bunks", (player, room) =>
            {
                game.Output(StoryData.CrewQuarters_Chocolate);
                player.Health += 1;
            });

            events["ReadLogs"] = new GameEvent("ReadLogs", "Read the datapad", (player, room) =>
            {
                game.Output(StoryData.CrewQuarters_Desk);
                game.Output(StoryData.CrewQuarters_Bed);
            });

            // ============================================================
            // MESS HALL EVENTS
            // ============================================================
            events["MeetHalberg"] = new GameEvent("MeetHalberg", "Approach the survivor", (player, room) =>
            {
                game.Output(StoryData.MessHall_Encounter);
                player.HasMetHalberg = true;
            });

            // ============================================================
            // ENGINEERING EVENTS
            // ============================================================
            events["RestorePower"] = new GameEvent("RestorePower", "Reinitialize the reactor", (player, room) =>
            {
                game.Output(StoryData.Engineering_PowerRestored);
                game.PowerRestored = true;
            });

            events["EngineeringSnack"] = new GameEvent("EngineeringSnack", "Search the lockers", (player, room) =>
            {
                game.Output(StoryData.Engineering_Chocolate);
                player.Health += 1;
            });

            // ============================================================
            // OBSERVATION DECK EVENTS
            // ============================================================
            events["FightAbernathy"] = new GameEvent("FightAbernathy", "Confront Ensign Abernathy", (player, room) =>
            {
                game.Output(StoryData.ObservationDeck_CombatIntro);
                if (random.NextDouble() < 0.5)
                {
                    player.Health -= 2;
                    game.Output("He attacks first — you fire back blindly. (-2 health)");
                }
                else
                {
                    game.Output("You act fast, landing a clean shot.");
                }
                game.Output(StoryData.ObservationDeck_CombatOutro);
                player.HasPistol = true;
            });

            // ============================================================
            // SPECIMEN LAB EVENTS
            // ============================================================
            events["FightCreature"] = new GameEvent("FightCreature", "Engage the organism", (player, room) =>
            {
                game.Output(StoryData.SpecimenLab_Combat);
                double chance = player.HasPistol ? 0.7 : 0.4;
                if (random.NextDouble() < chance)
                {
                    game.Output(StoryData.SpecimenLab_Victory);
                    player.HasDataChip = true;
                }
                else
                {
                    player.Health -= 3;
                    game.Output("The organism overpowers you. (-3 health)");
                    if (player.Health <= 0)
                        game.TriggerEnding(StoryData.Ending_Death);
                }
            });

            // ============================================================
            // FINAL SCENE EVENTS
            // ============================================================
            events["FinalSceneIntro"] = new GameEvent("FinalSceneIntro", "Confront Commander Vale", (player, room) =>
            {
                game.Output(StoryData.FinalScene_Intro);
                game.Output(StoryData.FinalScene_Dialogue);
            });

            events["TrustVale"] = new GameEvent("TrustVale", "Give the chip to Vale", (player, room) =>
            {
                game.Output(StoryData.FinalScene_TrustVale);
                game.TriggerEnding(StoryData.Ending_Bad);
            });

            events["TrustHalberg"] = new GameEvent("TrustHalberg", "Give the chip to Halberg", (player, room) =>
            {
                game.Output(StoryData.FinalScene_TrustHalberg);
                game.TriggerEnding(StoryData.Ending_Good);
            });

            // ============================================================
            // SECRET ENDING
            // ============================================================
            events["SecretEnding"] = new GameEvent("SecretEnding", "Escape in the shuttle", (player, room) =>
            {
                if (player.HasDataChip && game.PowerRestored)
                    game.TriggerEnding(StoryData.Ending_Secret);
                else
                    game.Output("The shuttle systems are dead. You’re not leaving yet.");
            });
        }
    }

    // ============================================================
    // SUPPORTING CLASSES
    // ============================================================
    public class GameEvent
    {
        public string Id { get; }
        public string Description { get; }
        public Action<Player, Room> Execute { get; }

        public GameEvent(string id, string description, Action<Player, Room> execute)
        {
            Id = id;
            Description = description;
            Execute = execute;
        }
    }
    
    
}
