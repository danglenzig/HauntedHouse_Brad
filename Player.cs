namespace HauntedHouse;

public class Player
{
    
    //public const int MAX_HEALTH = 100;
    
    public Player(Game _game, int _startHealth, int _startAttackDamage, int _startHealAmount, int _startBlockStrength)
    {
        game = _game;
        Health = _startHealth;
        AttackDamage = _startAttackDamage;
        HealAmount = _startHealAmount;
        BlockStrength = _startBlockStrength;
    }
    
    private Game game;
    
    private const int maxHealth = 100;
    private const int maxHealAmount = 30;
    private const int maxAttackDamage = 30;
    private const int maxBlockStrength = 30;
    
    // === Narrative & inventory flags ===
    public bool HasFlashlight { get; set; }
    public bool HasKeycardLevel1 { get; set; } // 🔑 Level 1 keycard
    public bool HasKeycardLevel2 { get; set; } // 🔑 Level 2 keycard
    public bool HasMetHalberg { get; set; }
    public bool HasPistol { get; set; }
    public bool HasDataChip { get; set; }
    
    private int health;
    public int Health
    {
        get => health;
        set
        {
            if (value < 0)
            {
                health = 0;
            }
            else if (value > maxHealth)
            {
                health = maxHealth;
            }
            else
            {
                health = value;
            }
        }
    }

    private int healAmount;
    public int HealAmount
    {
        get => healAmount;
        set
        {
            if (value < 0)
            {
                healAmount = 0;
            }
            else if (value > maxHealAmount)
            {
                healAmount = maxHealAmount;
            }
            else
            {
                healAmount = value;
            }
        }
    }

    private int attackDamage;
    public int AttackDamage
    {
        get => attackDamage;
        set
        {
            if (value < 0)
            {
                attackDamage = 0;
            }
            else if (value > maxAttackDamage)
            {
                attackDamage = maxAttackDamage;
            }
            else
            {
                attackDamage = value;
            }
        }
    }
    
    private int blockStrength;
    public int BlockStrength
    {
        get => blockStrength;
        set
        {
            if (value < 0)
            {
                blockStrength = 0;
            }
            else if (value > maxBlockStrength)
            {
                blockStrength = maxBlockStrength;
            }
            else
            {
                blockStrength = value;
            }
        }
    }

    private bool isBlocking;
    public bool IsBlocking
    {
        get => isBlocking;
        set
        {
            if (isBlocking != value)
            {
                isBlocking = value;
            }
        }
    }

    private string name = "Namey Nameson";

    public string Name
    {
        get => name;
        set
        {
            name = value;
        }
    }

    public void Attack(Enemy enemy)
    {
        //
    }

    public void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Health = 0;
            game.OnPlayerDied();
        }
    }

    public void Heal(int amount)
    {
        Health += amount;
        if (Health > 100) Health = 100;
    }

    public void Block()
    {
        //
    }

    //public void Retreat()
    //{
    //    //
    //}

    public void Die()
    {
        game.OnPlayerDied();
    }
    
}