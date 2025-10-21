namespace HauntedHouse;

public class ObjectivesData
{
    private Game game;
    public ObjectivesData(Game _game)
    {
        game = _game;
        CreateObjectives();
    }
    private List<Objective> objectives = new List<Objective>();

    private void CreateObjectives()
    {
        var BoardTheStation = new Objective.ObjectiveBuilder()
            .AddObjectiveID("BoardTheStation")
            .AddObjectiveDisplayName("Board the station")
            .AddObjectiveText("Enter the Calliope through the airlock hatch")
            .AddDefaultState(EnumObjectiveState.STARTED)
            .AddGameReference(game)
            .Build();
        objectives.Add(BoardTheStation);

        var RestorePower = new Objective.ObjectiveBuilder()
            .AddObjectiveID("RestorePower")
            .AddObjectiveDisplayName("Restore power")
            .AddObjectiveText("It's dark and cold here. You need to restore the stations power")
            .AddDefaultState(EnumObjectiveState.NOT_STARTED)
            .AddGameReference(game)
            .Build();
        objectives.Add(RestorePower);

        var RecoverTheMissionLogs = new Objective.ObjectiveBuilder()
            .AddObjectiveID("RecoverMissionLogs")
            .AddObjectiveDisplayName("Recover the mission logs")
            .AddObjectiveText("The bosses at Helios really want this data.")
            .AddDefaultState(EnumObjectiveState.NOT_STARTED)
            .AddGameReference(game)
            .Build();
        objectives.Add(RecoverTheMissionLogs);
        
        BoardTheStation.AddStartObjectiveOnCompleted(RestorePower);
        RestorePower.AddStartObjectiveOnCompleted(RecoverTheMissionLogs);

    }

    public Objective? GetObjectiveByID(string objID)
    {
        foreach (Objective obj in objectives)
        {
            if (obj.ObjectiveID == objID)
            {
                return obj;
            }
        }
        Console.WriteLine($"ERROR: Objective with ID {objID} not found. Returning null");
        return null;
    }
}