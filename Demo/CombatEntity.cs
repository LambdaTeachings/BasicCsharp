namespace RPG
{
    public class CombatEntity
    {
        public string Name { get; init; }
        public string Description { get; init; }
        public int HP { get; private set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }

        public bool IsDead { get { return HP <= 0; } }

        public CombatEntity(int hp)
        {
            HP = hp;
        }

        public void TryAttack(CombatEntity attacker)
        {
            var damage = attacker.Weapon.Damage;
            var roll = Random.Shared.NextDouble();

            if (roll > attacker.Weapon.HitChance)
            {
                Console.WriteLine($"{attacker.Name} tried to attack {this.Name} and misssed!");
                return;
            }

            roll = Random.Shared.NextDouble();
            if (roll < this.Armor.EvasionChance)
            {
                Console.WriteLine($"{attacker.Name} tried to attack {this.Name} but {this.Name} dodged!");
                return;
            }

            damage -= this.Armor.AbsoluteDamageReduction;

            if (damage < 0)
                damage = 0;

            damage = (int)(damage * (1 - this.Armor.RelativeDamageReduction));

            HP -= damage;
            if (HP < 0)
                HP = 0;

            Console.WriteLine($"{attacker.Name} attacked {this.Name} and dealt {damage} damage! {this.Name} has {this.HP} hp left.");
        }
    }
}