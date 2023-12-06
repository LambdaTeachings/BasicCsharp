namespace RPG
{
    public class Armor
    {
        public string Name { get; init; }
        public string Description { get; init; }

        public int AbsoluteDamageReduction { get; set; }
        public float RelativeDamageReduction { get; set; }
        public float EvasionChance { get; set; }
    }
}