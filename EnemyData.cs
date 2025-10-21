namespace HauntedHouse;
public class EnemyData
{

    private Game game;
    
    public EnemyData(Game _game)
    {
        game = _game;
        CreateEnemies();
    }

    private List<Enemy> enemies = new List<Enemy>();

    private void CreateEnemies()
    {
        var corporalSaito = new Enemy.EnemyBuilder()
            .AddEnemyName("Corporal Saito")
            .AddRoomId("MedicalBay")
            .AddHealth(30)
            .AddAttackDamage(10)
            .AddBlockStrength(5)
            .AddAggro(75)
            .AddFlavorText("<Text that appears before the fight with Saito>")
            .AddOnDieText("<Text that appears when Saito dies>")
            .AddMiscTools()
             .AddGameReference(game)
            .Build();
        //corporalSaito.SetFlavorText("Saito's flavor text");
        enemies.Add(corporalSaito);
        
        var ensignAbernathy = new Enemy.EnemyBuilder()
            .AddEnemyName("Ensign Abernathy")
            //.AddRoomId("CentralCorridor")
            .AddHealth(20)
            .AddAttackDamage(5)
            .AddBlockStrength(5)
            .AddAggro(75)
            .AddFlavorText("<Text that appears before the fight with Abernathy>")
            .AddOnDieText("<Text that appears when Abernathy dies>")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        //ensignAbernathy.SetFlavorText("Abernathy's flavor text");
        enemies.Add(ensignAbernathy);
        
        var technicianRourke = new Enemy.EnemyBuilder()
            .AddEnemyName("Technician Rourke")
            .AddRoomId("MessHall")
            .AddHealth(30)
            .AddAttackDamage(10)
            .AddBlockStrength(5)
            .AddAggro(75)
            .AddFlavorText("<Text that appears before the fight with Rourke>")
            .AddOnDieText("<Text that appears when Rourke dies>")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        //technicianRourke.SetFlavorText("Rourk's flavor text");
        enemies.Add(technicianRourke);
        
        var doctorHalberg = new Enemy.EnemyBuilder()
            .AddEnemyName("Doctor Halberg")
            .AddRoomId("SpecimenLab")
            .AddHealth(30)
            .AddAttackDamage(10)
            .AddBlockStrength(5)
            .AddAggro(75)
            .AddFlavorText("<Text that appears before the fight with Halberg>")
            .AddOnDieText("<Text that appears when Halberg dies>")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        //doctorHalberg.SetFlavorText("Halberg's flavor text");
        enemies.Add(doctorHalberg);
        
        var commanderVale = new Enemy.EnemyBuilder()
            .AddEnemyName("Commander Vale")
            .AddRoomId("Bridge")
            .AddHealth(30)
            .AddAttackDamage(10)
            .AddBlockStrength(5)
            .AddAggro(75)
            .AddFlavorText("<Text that appears before the fight with Vale>")
            .AddOnDieText("<Text that appears when Vale dies>")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        //commanderVale.SetFlavorText("Vale's flavor text");
        enemies.Add(commanderVale);
        
        var chiefMalik = new Enemy.EnemyBuilder()
            .AddEnemyName("Chief Malik")
            .AddRoomId("Engineering")
            .AddHealth(30)
            .AddAttackDamage(10)
            .AddBlockStrength(5)
            .AddAggro(75)
            .AddFlavorText("<Text that appears before the fight with Malik>")
            .AddOnDieText("<Text that appears when Malik dies>")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        //chiefMalik.SetFlavorText("Malik's flavor text");
        enemies.Add(chiefMalik);
        
        var captainWilson = new Enemy.EnemyBuilder()
            .AddEnemyName("Captain Wilson")
            .AddRoomId("CargoBay")
            .AddHealth(30)
            .AddAttackDamage(10)
            .AddBlockStrength(5)
            .AddAggro(75)
            .AddFlavorText("<Text that appears before the fight with Wilson>")
            .AddOnDieText("<Text that appears when Wilson dies>")
            .AddMiscTools()
            .AddGameReference(game)
            .Build();
        //captainWilson.SetFlavorText("Wilsons's flavor text");
        enemies.Add(captainWilson);
    }

    public Enemy GetEnemyByRoomId(string roomId)
    {
        if (enemies.Count > 0)
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.RoomId == roomId)
                {
                    return enemy;
                }
            }
        }
        return null;
    }
}