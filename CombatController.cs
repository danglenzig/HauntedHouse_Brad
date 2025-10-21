using System.Collections.Concurrent;

namespace HauntedHouse;

public class CombatController
{
    private enum EnumTurn {PLAYER, ENEMY}
    // comment
    
    private Game game;
    private MiscTools miscTools;
    private EnemyData enemyData;
    private Player player;
    private Enemy currentEnemy;
    private EnumTurn currentTurn;
    private bool combatOngoing = false;
    
    public CombatController(Game _game)
    {
        game = _game;
        miscTools = new MiscTools();
        enemyData = game._EnemyData;
        player = game._Player;
    }

    public void HandleCombat(string roomId)
    {
        combatOngoing = true;
        Enemy enemy = enemyData.GetEnemyByRoomId(roomId);
        
        //Console.WriteLine(enemy == null);
        //Console.WriteLine(roomId);
        //miscTools.PressKeyToContinue();
        
        if (enemy == null)
        {
            combatOngoing = false;
            return;
        }
        currentEnemy = enemy;
        
        

        if (currentEnemy.IsDead)
        {
            HandleAlreadyDead(currentEnemy.EnemyName);
            //combatOngoing = false;
            return;
        }
        
        Console.Clear();
        string msg = $"You gonna fight {currentEnemy.EnemyName}!\n{enemy.FlavorText}";
        
        currentTurn = EnumTurn.PLAYER;
        
        
        miscTools.RevealText(msg, 20);
        miscTools.PressKeyToContinue();
        HandleTurn();
    }

    private void HandleAlreadyDead(string deadEnemyName)
    {
        combatOngoing = false;
        miscTools.RevealText($"You see {deadEnemyName}'s defeated and lifeless corpse on the floor.\n", 20);
        miscTools.PressKeyToContinue();
        return;
        //
    }

    private void HandleTurn()
    {
        if (!combatOngoing)
        {
            currentEnemy = null;
            return;
            
        }
        switch (currentTurn)
        {
            case EnumTurn.PLAYER:
                // take player turn
                HandlePlayerTurn();
                break;
            case EnumTurn.ENEMY:
                // take enemy turn
                HandleEnemyTurn();
                break;
        }
    }
    
    private void HandlePlayerTurn()
    {
        Console.Clear();
        miscTools.RevealText($"{player.Name}'s turn...\n", 20);
        miscTools.PressKeyToContinue();
        
        // present combat options
        // 1. Attack
        // 2. Block
        // 3. Heal
        int playerChoice = -1;
        miscTools.RevealText("Choose an action:\n", 20);
        miscTools.RevealText("1) Attack\n", 20);
        miscTools.RevealText("2) Block\n", 20);
        miscTools.RevealText("3) Heal\n", 20);
        while (playerChoice < 1 || playerChoice > 3)
        {
            Console.Write("--> ");
            playerChoice = int.Parse(Console.ReadLine());
        }

        switch (playerChoice)
        {
            case 1:
                HandleAttack();
                break;
            case 2:
                HandleBlock();
                break;
            case 3:
                
                break;
        }
       
        
        currentTurn = EnumTurn.ENEMY;
        HandleTurn();
    }

    private void HandleEnemyTurn()
    {
        Console.Clear();
        miscTools.RevealText($"{currentEnemy.EnemyName}'s turn...", 20);
        miscTools.PressKeyToContinue();
        
        // choose whether to attack or block
        Random random = new Random();
        int randoInt = random.Next(0, 99);

        if (randoInt <= currentEnemy.Aggro)
        {
            HandleAttack();
        }
        else
        {
            HandleBlock();
        }
        
        
        
        currentTurn = EnumTurn.PLAYER;
        HandleTurn();
    }

    private void HandleAttack()
    {
        int attackDamage = -1;
        switch (currentTurn)
        {
            case EnumTurn.PLAYER:
                miscTools.RevealText($"{player.Name} attacks!", 20);
                miscTools.PressKeyToContinue();
                attackDamage = player.AttackDamage;
                if (currentEnemy.IsBlocking)
                {
                    attackDamage -= currentEnemy.BlockStrength;
                    if (attackDamage <= 0)
                    {
                        attackDamage = 0;
                    }
                    currentEnemy.IsBlocking = false; // block lasts for one turn
                    miscTools.RevealText($"{currentEnemy.EnemyName} is blocking! Attack damage reduced to {attackDamage}\n", 20);
                    miscTools.PressKeyToContinue();
                }
                if (attackDamage <= 0)
                {
                    attackDamage = 0;
                }
                
                if (currentEnemy.Health - attackDamage <= 0)
                {
                    currentEnemy.Health = 0;
                    combatOngoing = false;
                    currentEnemy.Die();
                }
                else
                {
                    int prevHealth = currentEnemy.Health;
                    currentEnemy.Health -= attackDamage;
                    miscTools.RevealText($"{currentEnemy.EnemyName} takes {attackDamage} damage!\n", 20);
                    miscTools.RevealText($"{currentEnemy.EnemyName} health reduced from {prevHealth} to {currentEnemy.Health}.\n", 20);
                    miscTools.PressKeyToContinue();
                }
                break;
            
            case EnumTurn.ENEMY:
                miscTools.RevealText($"{currentEnemy.EnemyName} attacks!", 20);
                miscTools.PressKeyToContinue();
                attackDamage = currentEnemy.AttackDamage;
                if (player.IsBlocking)
                {
                    attackDamage -= player.BlockStrength;
                    if (attackDamage <= 0)
                    {
                        attackDamage = 0;
                    }
                    player.IsBlocking = false;
                    miscTools.RevealText($"{player.Name} is blocking! Attack damage reduced to {attackDamage}\n", 20);
                    miscTools.PressKeyToContinue();
                }
                if (attackDamage <= 0)
                {
                    attackDamage = 0;
                }

                if (player.Health - attackDamage <= 0)
                {
                    player.Health = 0;
                    combatOngoing = false;
                    player.Die();
                }
                else
                {
                    int prevHealth = player.Health;
                    player.Health -= attackDamage;
                    miscTools.RevealText($"{player.Name} takes {attackDamage} damage!\n", 20);
                    miscTools.RevealText($"{player.Name} health reduced from {prevHealth} to {player.Health}.\n", 20);
                    miscTools.PressKeyToContinue();
                }
                break;
        }
    }

    private void HandleBlock()
    {
        if (currentTurn == EnumTurn.PLAYER)
        {
            miscTools.RevealText($"{player.Name} blocks!\n", 20);
            miscTools.RevealText($"Incoming damaged reduced by {player.BlockStrength} for one turn.\n", 20);
            miscTools.PressKeyToContinue();
            player.IsBlocking = true;
        }
        else
        {
            miscTools.RevealText($"{currentEnemy.EnemyName} blocks!\n", 20);
            miscTools.RevealText($"Incoming damaged reduced by {currentEnemy.BlockStrength} for one turn.\n", 20);
            miscTools.PressKeyToContinue();
            currentEnemy.IsBlocking = true;
        }
    }

    private void HandleHeal()
    {
        if (currentTurn == EnumTurn.ENEMY) return; // this should never happen
        miscTools.RevealText($"{player.Name} heals!\n", 20);
        miscTools.RevealText($"Current health: {player.Health}\n", 20);
        miscTools.PressKeyToContinue();
        player.Health += player.HealAmount; // setter will cap Health at the max value
    }
    
}