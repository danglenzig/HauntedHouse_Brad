namespace HauntedHouse;

public class GameData
{
    
    public GameData()
    {
        
    }
    
    private bool testMessageReceived = false;
    private bool foundTheFlashlight = false;
    public bool PowerRestored { get; set; } = false; 

    //public void SendMessage(string message)
    //{
    //    switch (message)
    //    {
    //        case "TEST_MESSAGE":
    //            if (!testMessageReceived)
    //            {
    //                testMessageReceived = true;
    //            }
    //            break;
    //        case "FOUND_FLASHLIGHT":
    //            // do stuff
    //            foundTheFlashlight = true;
    //            break;
    //        // ...and so on
    //    }
    //}
    
    
    
}