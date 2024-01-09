/*
* demo - RPG encounter form.
* 
* The RPG encounter form lets game designers look into specific
* encounters in a game to evaluate their difficulty.
* 
* The form should look exactly like in the example.


-------------------------------------
> RPGef - encounter form
-------------------------------------
date: Monday, 2019-03-18
time: 10:05:34 AM

-------------------------------------
> Players Info
-------------------------------------
* count: 3
* combined levels: 55

-------------------------------------
> Environment
-------------------------------------
* name: the hinterlands
* day\night: night
* weather: stormy

-------------------------------------
> Enemies
-------------------------------------
* count: 2
* combined threat level: 54
* items:
  - Black Dragon (20)
  - Leeroy Jenkins (34)

*/

string seperator = "-------------------------------------";
string header = "> ";
string bullet = "* ";
string listItem = "   - ";

int playerCount = 3;
int player1Level = 18;
int player2level = 17;
int player3Level = 20;

string environment = "the hinterlands";
string dayNight = "night";
string weather = "stormy";

int enemyCount = 2;

// enemy 1
string enemy1Name = "Black Dragon";
int enemy1Threat = 20;

// enemy 2
string enemy2Name = "Leeroy Jenkins";
int enemy2Threat = 34;

Console.WriteLine(seperator);
Console.WriteLine(header + "RPGef - encounter form");
Console.WriteLine(seperator);
// You aren't familiar with this syntax just yet, but...
// it's still very readable, right? It simply fetches the
// current date and time and outputs them nicely
Console.WriteLine(
    "date: "
    + DateTime.Now.DayOfWeek
    + ", "
    + DateTime.Now.ToShortDateString());
Console.WriteLine("time: " + DateTime.Now.ToShortTimeString());
Console.WriteLine();

Console.WriteLine(seperator);
Console.WriteLine(header + "Players Info");
Console.WriteLine(seperator);
Console.WriteLine(bullet + "count: " + playerCount);
// The parenthesis enclosing the player levels are important here!
Console.WriteLine(bullet + "combined levels: " + (player1Level + player2level + player3Level));
Console.WriteLine();

Console.WriteLine(seperator);
Console.WriteLine(header + "Environemnt");
Console.WriteLine(seperator);
Console.WriteLine(bullet + "name: " + environment);
// backslash used as an escape character
Console.WriteLine(bullet + "day\\night:" + dayNight);
Console.WriteLine(bullet + "weather: " + weather);
Console.WriteLine();

Console.WriteLine(seperator);
Console.WriteLine(header + "Enemies");
Console.WriteLine(seperator);
Console.WriteLine(bullet + "count: " + enemyCount);
Console.WriteLine(bullet + "combined threat level: " + (enemy1Threat + enemy2Threat));
Console.WriteLine(bullet + "items: ");
Console.WriteLine(listItem + enemy1Name + " (" + enemy1Threat + ")");
Console.WriteLine(listItem + enemy2Name + " (" + enemy2Threat + ")");
Console.WriteLine();