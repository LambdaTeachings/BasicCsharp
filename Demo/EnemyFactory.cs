namespace RPG.Factories
{
    public static class EnemyFactory
    {
        private static readonly string[] Prefix = { "Disgusting", "Horrible", "Tremendous", "Abrasive", "Horrendous", "Awesome" };
        private static readonly string[] Type = { "Troll", "Orc", "Goblin", "Skeleton", "Demon", "Student" };

        private static readonly Weapon[] Weapons =
        {
            new Weapon() {Name = "Axe", Description = "A normal axe", Damage = 10, HitChance = 40},
            new Weapon() {Name = "Sword", Description = "A normal sword", Damage = 5, HitChance = 80},
            new Weapon() {Name = "Spear", Description = "A normal spear", Damage = 4, HitChance = 100},
        };

        private static readonly Armor[] Armors =
        {
            new Armor() {Name = "Leather Armor", Description = "A simple leater armor", AbsoluteDamageReduction = 0, EvasionChance = 0.3f, RelativeDamageReduction = 0f},
            new Armor() {Name = "Spiked Helmet", Description = "a simple spiky helmet", AbsoluteDamageReduction = 2, EvasionChance = 0f, RelativeDamageReduction = 0.1f},
            new Armor() {Name = "Iron Leggings", Description = "Leggings yo", AbsoluteDamageReduction = 0, EvasionChance = 0f, RelativeDamageReduction = 0.5f},
        };

        public static CombatEntity ConstructEnemy()
        {
            var name = ConstructName();
            var weapon = ConstructWeapon();
            var armor = ConstructArmor();
            var hp = Random.Shared.Next(5, 25);

            return new CombatEntity(hp)
            {
                Name = name,
                Description = $"A {name} holding a {weapon} and wearing a {armor} with {hp} HP",
                Weapon = weapon,
                Armor = armor
            };
        }

        private static Weapon ConstructWeapon()
        {
            return Weapons[Random.Shared.Next(Weapons.Length)];
        }

        private static Armor ConstructArmor()
        {
            return Armors[Random.Shared.Next(Weapons.Length)];
        }

        private static string ConstructName()
        {
            return Prefix[Random.Shared.Next(Prefix.Length)] + " " + Type[Random.Shared.Next(Prefix.Length)];
        }
    }
}