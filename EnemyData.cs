namespace HauntedHouse;
public class EnemyData
{
    public EnemyData()
    {
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
            .Build();
        corporalSaito.SetFlavorText("Saito's flavor text");
        enemies.Add(corporalSaito);
        
        var ensignAbernathy = new Enemy.EnemyBuilder()
            .AddEnemyName("Ensign Abernathy")
            .AddRoomId("CentralCorridor")
            .AddHealth(20)
            .AddAttackDamage(1)
            .AddBlockStrength(1)
            .Build();
        ensignAbernathy.SetFlavorText("Abernathy's flavor text");
        enemies.Add(ensignAbernathy);
        
        var technicianRourke = new Enemy.EnemyBuilder()
            .AddEnemyName("Technicial Rourke")
            .AddRoomId("MessHall")
            .AddHealth(30)
            .AddAttackDamage(10)
            .AddBlockStrength(5)
            .Build();
        technicianRourke.SetFlavorText("Rourk's flavor text");
        enemies.Add(technicianRourke);
        
        var doctorHalberg = new Enemy.EnemyBuilder()
            .AddEnemyName("Doctor Halberg")
            .AddRoomId("SpecimenLab")
            .AddHealth(30)
            .AddAttackDamage(10)
            .AddBlockStrength(5)
            .Build();
        doctorHalberg.SetFlavorText("Halberg's flavor text");
        enemies.Add(doctorHalberg);
        
        var commanderVale = new Enemy.EnemyBuilder()
            .AddEnemyName("Commander Vale")
            .AddRoomId("Bridge")
            .AddHealth(30)
            .AddAttackDamage(10)
            .AddBlockStrength(5)
            .Build();
        commanderVale.SetFlavorText("Vale's flavor text");
        enemies.Add(commanderVale);
        
        var chiefMalik = new Enemy.EnemyBuilder()
            .AddEnemyName("Chief Malik")
            .AddRoomId("Engineering")
            .AddHealth(30)
            .AddAttackDamage(10)
            .AddBlockStrength(5)
            .Build();
        chiefMalik.SetFlavorText("Malik's flavor text");
        enemies.Add(chiefMalik);
        
        var captainWilson = new Enemy.EnemyBuilder()
            .AddEnemyName("Captain Wilson")
            .AddRoomId("CargoBay")
            .AddHealth(30)
            .AddAttackDamage(10)
            .AddBlockStrength(5)
            .Build();
        captainWilson.SetFlavorText("Wilsons's flavor text");
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