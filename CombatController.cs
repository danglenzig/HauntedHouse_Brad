namespace HauntedHouse;

public class CombatController
{

    // comment
    
    private Game game;
    private MiscTools miscTools;
    private EnemyData enemyData;
    
    public CombatController(Game _game)
    {
        game = _game;
        miscTools = new MiscTools();
        enemyData = game._EnemyData;

    }

    public void HandleCombat(string roomId)
    {
        Enemy? enemy = enemyData.GetEnemyByRoomId(roomId);
        if (enemy == null)
        {
            return;
        }
        Player player = game._Player;
        Console.Clear();
        string msg = $"You gonna fight {enemy.EnemyName}!\n{enemy.FlavorText}";
        
        
        // fighting happens (?)
        
        
        
        miscTools.RevealText(msg, 2);
        miscTools.PressKeyToContinue();
    }
    
}