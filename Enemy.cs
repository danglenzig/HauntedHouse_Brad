namespace HauntedHouse;

public class Enemy
{
    /*
    public Enemy(string _enemyName, string _roomId,int _health, int _attackDamage,  int _blockStrength)
    {
        EnemyName = _enemyName;
        RoomId = _roomId;
        Health = _health;
        AttackDamage = _attackDamage;
        BlockStrength = _blockStrength;
        FlavorText = "";
    }
    */
    
    private const int maxHealth = 100;
    //private const int maxHealAmount = 30;
    private const int maxAttackDamage = 30;
    private const int maxBlockStrength = 30;


    private string flavorText;

    public string FlavorText
    {
        get => flavorText;
        private set => flavorText = value;
    }

    private string roomId;

    public string RoomId
    {
        get => roomId;
        private set => roomId = value;
    }
    
    private string enemyName;
    public string EnemyName;
    
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

    public void SetFlavorText(string _flavorText)
    {
        FlavorText = _flavorText;
    }

    public void Attack(Player player)
    {
        //
    }

    public void TakeDamage(int damageAmount)
    {
        //
    }

    public void Heal()
    {
        //
    }

    public void Block()
    {
        //
    }

    public class EnemyBuilder
    {
        private Enemy enemy = new ();

        public EnemyBuilder AddEnemyName(string _enemyName)
        {
            enemy.EnemyName = _enemyName;
            return this;
        }
        public EnemyBuilder AddRoomId(string _roomId)
        {
            enemy.RoomId = _roomId;
            return this;
        }
        public EnemyBuilder AddHealth(int _health)
        {
            enemy.Health= _health;
            return this;
        }
        public EnemyBuilder AddAttackDamage(int _attackDamage)
        {
            enemy.AttackDamage= _attackDamage;
            return this;
        }
        public EnemyBuilder AddBlockStrength(int _blockStrength)
        {
            enemy.BlockStrength= _blockStrength;
            return this;
        }
        public Enemy Build()
        {
            return enemy;
        }
    }
    
}