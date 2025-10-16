namespace HauntedHouse;

public class GameData
{
    
    public GameData()
    {
        
    }
    
    private bool testMessageReceived = false;

    public void SendMessage(string message)
    {
        switch (message)
        {
            case "TEST_MESSAGE":
                if (!testMessageReceived)
                {
                    testMessageReceived = true;
                }
                break;
            // ...and so on
        }
    }
    
    
    
}