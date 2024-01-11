public static class DictionaryDemo
{
    public static void Demo()
    {
        Dictionary<int, Dictionary<string, int>> lootTable = new();

        lootTable.Add(1, new Dictionary<string, int>()
        {
            { "Basic Sword", 40 },
            { "Basic Axe", 50 },
            { "Black Dagger", 10 }
        });

        lootTable.Add(2, new Dictionary<string, int>()
        {
            { "Regular Sword", 45 },
            { "Chopping Axe", 50 },
            { "Sword +1", 5 }
        });

        lootTable.Add(3, new Dictionary<string, int>()
        {
            { "Sword of Doom", 25 },
            { "Axe of Retaliation", 74 },
            { "Mythril Dagger", 1 }
        });

        var level = Random.Shared.Next(1, 4);
        var rand = Random.Shared.Next(0, 101);
        foreach (KeyValuePair<string, int> item in lootTable[level])
        {
            if (rand < item.Value)
                Console.WriteLine($"You got a {item}");
            else
                rand -= item.Value;
        }
    }
}