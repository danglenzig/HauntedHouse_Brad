namespace HauntedHouse
{
    public class AsciiMap
    {
        private Game game;

        public AsciiMap(Game _game)
        {
            game = _game;
        }

        // Draws the full DSS Calliope map in ASCII.
        // Highlights the current room in yellow.
        // Connections are green if accessible, red if locked.
        public void DrawMap(string currentRoomId)
        {
            Console.Clear();
            Console.WriteLine("          === DSS CALLIOPE MAP ===\n");

            // Local helper to print colored text
            void WriteColored(string text, ConsoleColor color)
            {
                var prev = Console.ForegroundColor;
                Console.ForegroundColor = color;
                Console.Write(text);
                Console.ForegroundColor = prev;
            }

            void HighlightRoom(string roomId, string roomName)
            {
                if (roomId == currentRoomId)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(roomName);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(roomName);
                }
            }

            // ===============================
            //  ACCESS CHECK FUNCTIONS
            // ===============================
            bool IsOpen(string roomA, string roomB)
            {
                bool lvl1 = game._Player.HasKeycardLevel1;
                bool lvl2 = game._Player.HasKeycardLevel2;
                bool power = game.PowerRestored;

                // Always open connections
                if ((roomA == "Airlock" && roomB == "CentralCorridor") ||
                    (roomA == "CentralCorridor" && roomB == "Airlock") ||
                    (roomA == "CentralCorridor" && roomB == "MedicalBay") ||
                    (roomA == "MedicalBay" && roomB == "CentralCorridor"))
                    return true;

                // Level 1 key connections
                if ((roomA == "CentralCorridor" && roomB == "CrewQuarters") ||
                    (roomA == "CrewQuarters" && roomB == "CentralCorridor") ||
                    (roomA == "CrewQuarters" && roomB == "MessHall") ||
                    (roomA == "MessHall" && roomB == "CrewQuarters") ||
                    (roomA == "CentralCorridor" && roomB == "Bridge") ||
                    (roomA == "Bridge" && roomB == "CentralCorridor") ||
                    (roomA == "CentralCorridor" && roomB == "Turbolift") ||
                    (roomA == "Turbolift" && roomB == "CentralCorridor"))
                    return lvl1;

                // Level 2 + power connections
                if (((roomA == "CargoBay" && roomB == "Engineering") ||
                    (roomA == "Engineering" && roomB == "CargoBay") ||
                    (roomA == "MedicalBay" && roomB == "SpecimenLab") ||
                    (roomA == "SpecimenLab" && roomB == "MedicalBay")) && lvl2 && power)
                    return true;

                return false;
            }

            // Helper to draw a connection between two rooms
            void Connection(string a, string b)
            {
                WriteColored("■■■", IsOpen(a, b) ? ConsoleColor.Green : ConsoleColor.Red);
            }

            // ==================================================
            // ROW 1: Engineering ↔ Turbolift
            // ==================================================
            Console.WriteLine("          ┌──────────────┐         ┌─────────────┐");
            Console.Write("          |  "); HighlightRoom("Engineering", "Engineering"); Console.Write(" |");
            Console.Write("───"); Connection("Engineering", "Turbolift"); Console.Write("───");
            Console.Write("|  "); HighlightRoom("Turbolift", "Turbolift"); Console.WriteLine("  |");
            Console.WriteLine("          └──────────────┘         └─────────────┘");

            // Connection down from Turbolift and Engineering
            Console.WriteLine("                  │                       │");
            WriteColored("                 ", ConsoleColor.Gray); Connection("Turbolift", "Bridge"); Console.Write("                     "); Connection("Engineering", "CargoBay"); Console.WriteLine();
            Console.WriteLine("                  │                       │");

            // ==================================================
            // ROW 2: CargoBay under Turbolift
            // ==================================================
            Console.Write("          ┌──────────────┐               "); Connection("CargoBay", "Engineering"); Console.WriteLine();
            Console.Write("          |   "); HighlightRoom("CargoBay", "CargoBay"); Console.Write("   |               "); Connection("CargoBay", "Engineering"); Console.WriteLine();
            Console.Write("          └──────────────┘               "); Connection("CargoBay", "Engineering"); Console.WriteLine();

            // Vertical connector from CargoBay up to Bridge
            Console.WriteLine("                                          │");
            WriteColored("                                         ", ConsoleColor.Gray); Connection("Bridge", "CargoBay"); Console.WriteLine();
            Console.WriteLine("                                          │");

            // ==================================================
            // ROW 3: SpecimenLab ↔ Bridge ↔ ObservationDeck
            // ==================================================
            Console.WriteLine("          ┌──────────────┐         ┌──────────────┐       ┌─────────────────┐");
            Console.Write("          |  "); HighlightRoom("SpecimenLab", "SpecimenLab"); Console.Write(" |");
            Console.Write("         ");
            Console.Write("|    "); HighlightRoom("Bridge", "Bridge"); Console.Write("    |");
            Console.Write("──"); Connection("Bridge", "ObservationDeck"); Console.Write("──");
            Console.Write("| "); HighlightRoom("ObservationDeck", "ObservationDeck"); Console.WriteLine(" |");
            Console.WriteLine("          └──────────────┘         └──────────────┘       └─────────────────┘");

            // Connection down from Bridge
            Console.WriteLine("                  │                       │");
            WriteColored("                 ", ConsoleColor.Gray); Connection("Bridge", "CentralCorridor"); Console.Write("                     "); Connection("Bridge", "ObservationDeck"); Console.WriteLine();
            Console.WriteLine("                  │                       │");

            // ==================================================
            // ROW 4: MedicalBay ↔ CentralCorridor ↔ CrewQuarters ↔ MessHall
            // ==================================================
            Console.WriteLine("          ┌──────────────┐       ┌─────────────────┐       ┌──────────────┐       ┌────────────┐");
            Console.Write("          |  "); HighlightRoom("MedicalBay", "MedicalBay"); Console.Write("  |");
            Console.Write("──"); Connection("MedicalBay", "CentralCorridor"); Console.Write("──");
            Console.Write("| "); HighlightRoom("CentralCorridor", "CentralCorridor"); Console.Write(" |");
            Console.Write("──"); Connection("CentralCorridor", "CrewQuarters"); Console.Write("──");
            Console.Write("| "); HighlightRoom("CrewQuarters", "CrewQuarters"); Console.Write(" |");
            Console.Write("──"); Connection("CrewQuarters", "MessHall"); Console.Write("──");
            Console.Write("|  "); HighlightRoom("MessHall", "MessHall"); Console.WriteLine("  |");
            Console.WriteLine("          └──────────────┘       └─────────────────┘       └──────────────┘       └────────────┘");

            // Connection down from CentralCorridor
            Console.WriteLine("                                          │");
            WriteColored("                                         ", ConsoleColor.Gray); Connection("Airlock", "CentralCorridor"); Console.WriteLine();
            Console.WriteLine("                                          │");

            // ==================================================
            // ROW 5: Airlock
            // ==================================================
            Console.WriteLine("                                   ┌──────────────┐");
            Console.Write("                                   |    "); HighlightRoom("Airlock", "Airlock"); Console.WriteLine("   |");
            Console.WriteLine("                                   └──────────────┘");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("          ██");
            Console.ResetColor();
            Console.Write(" = current location, ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("██");
            Console.ResetColor();
            Console.Write(" = open, ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("██");
            Console.ResetColor();
            Console.WriteLine(" = locked");
        }
    }
}