namespace HauntedHouse;

public class MiscTools
{
    public MiscTools()
    {
        
    }

    public void RevealText(string text, int revealInterval)
    {
        if (revealInterval < 1)
        {
            revealInterval = 1;
        }

        if (revealInterval > 100)
        {
            revealInterval = 100;
        }
        foreach (char c in text)
        {
            Console.Write(c);
            Thread.Sleep(revealInterval);
        }
    }

    public void PressKeyToContinue()
    {
        Console.WriteLine("\n\nPress any key to continue..");
        Console.ReadKey();
    }
    
}