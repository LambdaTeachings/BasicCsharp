using RPG;
using RPG.Factories;

var weapon = new Weapon() { Name = "Plain Sword", Description = "A Plain Sword dude", Damage = 11, HitChance = 0.8f };
var armor = new Armor() { Name = "Gilded Breeches", AbsoluteDamageReduction = 1, EvasionChance = 0.1f, RelativeDamageReduction = 0.2f };
var player = new CombatEntity(5) { Name = "Player", Weapon = weapon, Armor = armor };

while (!player.IsDead)
{
    var opponent = EnemyFactory.ConstructEnemy();
    Console.WriteLine($"You encounter a {opponent.Name}!");

    while (!opponent.IsDead && !player.IsDead)
    {
        // opponent turn

        player.TryAttack(opponent);
        Console.ReadLine();
        opponent.TryAttack(player);
        Console.ReadLine();
        Console.Clear();
    }

    if (player.IsDead)
        break;

    Console.WriteLine($"You defeated {opponent.Name}!");
    Console.ReadLine();
    Console.Clear();
}

Console.WriteLine("Player died, Game Over!");