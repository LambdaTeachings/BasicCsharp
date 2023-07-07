/*
 * demo - there be monsters.
 * As technical designers on a new upcoming dungeon crawler, we were tasked with writing a simple
 * algorithm that will calculate the threat level of an encounter with monsters.The algorithm’s variables are:
    * player levels
    * player count
    * monsters’ hit points
    * monsters’ damage
    * monster count
 * The output of the algorithm is a dangerLevel : string with the following options: Easy, Medium, Hard and Impossible
 * (this will be presented to the players in the game).
 */

// players data
int player1Level = 9;
int player2Level = 12;

// mosnters data
int monster1HP = 10;
int monster2HP = 20;
int monster3HP = 80;

int monster1Damage = 60;
int monster2Damage = 40;
int monster3Damage = 10;

// Encounter data
int easy = -1;
int medium = 3;
int hard = 8;

// players calculations
int playerLevels = player1Level + player2Level;
int playerCount = 2;

float playersCompentence = playerLevels * (1 + playerCount / 10f);

// mosnters calculations
int monsterCount = 3;

float monster1ThreatLevel = (monster1HP + monster1Damage) / 10f;
float monster2ThreatLevel = (monster2HP + monster2Damage) / 10f;
float monster3ThreatLevel = (monster3HP + monster3Damage) / 10f;

float encounterThreatLevel = (monster1ThreatLevel + monster2ThreatLevel +
    monster3ThreatLevel) * (1 + monsterCount / 10f);

// data output

Console.WriteLine("There are " + playerCount + " players, fighting " + monsterCount + " monsters.");

// encounter threat output
float deltaThreat = encounterThreatLevel - playersCompentence;

if (deltaThreat <= easy)
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Easy Encounter");
}
else if (deltaThreat <= medium)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("Medium Encounter");
}
else if (deltaThreat <= hard)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("Hard Encounter");
}
else
{
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.WriteLine("Impossible Encounter");
}

Console.ResetColor();