namespace HauntedHouse;

public class Objective
{
    private string objectiveDisplayName = "Do A Thing!";
    public string ObjectiveDisplayName
    {
        get { return objectiveDisplayName; }
        set { objectiveDisplayName = value; }
    }

    private string objectiveID = "DoAThing";
    public string ObjectiveID
    {
        get { return objectiveID; }
        set { objectiveID = value; }
    }
    
    private string objectiveText = "Generic objective description";
    public string ObjectiveText
    {
        get { return objectiveText; }
        set { objectiveText = value; }
    }
    
    private EnumObjectiveState objectiveState = EnumObjectiveState.NOT_STARTED;
    public EnumObjectiveState ObjectiveState
    {
        get { return objectiveState; }
        set { objectiveState = value; }
    }

    public void AddStartObjectiveOnCompleted(Objective _obj)
    {
        StartObjectivesOnCompleted.Add(_obj);
    }

    public void CompleteObjective()
    {
        foreach (Objective _obj in StartObjectivesOnCompleted)
        {
            _obj.ObjectiveState = EnumObjectiveState.STARTED;
        }
        ObjectiveState = EnumObjectiveState.COMPLETED;
    }

    private List<Objective> StartObjectivesOnCompleted = new List<Objective>();
    private Game game;


    public class ObjectiveBuilder
    {
        private Objective objective = new();

        public ObjectiveBuilder AddObjectiveDisplayName(string objName)
        {
            objective.ObjectiveDisplayName = objName;
            return this;
        }

        public ObjectiveBuilder AddObjectiveID(string objID)
        {
            objective.ObjectiveID = objID;
            return this;
        }

        public ObjectiveBuilder AddObjectiveText(string objText)
        {
            objective.ObjectiveText = objText;
            return this;
        }

        public ObjectiveBuilder AddDefaultState(EnumObjectiveState state)
        {
            objective.ObjectiveState = state;
            return this;
        }

        //public ObjectiveBuilder AddStartObjectiveOnCompleted(Objective _objective)
        //{
        //    objective.StartObjectivesOnCompleted.Add(_objective);
        //    return this;
        //}

        public ObjectiveBuilder AddGameReference(Game _game)
        {
            objective.game = _game;
            return this;
        }

        public Objective Build()
        {
            return objective;
        }
    }
    
}

