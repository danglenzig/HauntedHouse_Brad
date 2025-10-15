namespace HauntedHouse;

public class Player
{
    
    public Player(Game _game)
    {
        game = _game;
    }
    
    private const int maxHealth = 100;
    
    private Game game;
    
    private int health;
    public int Health
    {
        get => health;
        set
        {
            if (value < 0)
            {
                Health = 0;
                Die();
            }
            else if (value > maxHealth)
            {
                Health = maxHealth;
            }
            else
            {
                Health = value;
            }
        }
    }

    

    private void Die()
    {
        game.OnPlayerDied();
    }
}