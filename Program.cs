/*
 * We are the developers of “Heroes of Tilithia”, an upcoming RPG-fantasy video game.
 * As part of our job as game engineers, we are given the task to implement the damage mechanic in game.
 * Here is the design: 
 * 
 * in HoT, when a character gets attacked, it needs to consider evasion, constitution and armor.
 * Moreover, each calculation is affected by two parameters: attack type - melee, ranged, magical;
 * and attack mechanics.
 * 
 * Evade chance - chance to dodge the attack altogether, calculated first
    * True strike mechanic ignores evasion
    * Evasion is 50% effective against magic and 25% against ranged
 * Constitution - will apply an absolute damage reduction, calculated second
 * Armor - will apply a percentile based damage reduction, calculated third
    * Armor is negated against magic
    * Armor is 50% more efficient against ranged attacks
    * Shatter mechanic with melee attacks negates armor
 */

// Rogue :D
int playerHP = 100;
float playerEvasionChance = 0.35f;
int playerConstitution = 3;
float playerArmor = 0.1f;

// that's not a kobold
int enemyDamage = 40;
string enemyDamageType = "melee"; // ranged / magic are also options
string[] enemyAttackMechanics = { "true strike" }; // you can change this to shatter as well

CalculateDamageOutput();

int CalculateDamageOutput()
{
    Console.WriteLine("Player initial damage input: " + enemyDamage);

    bool evasion = CalculateEvasion(playerEvasionChance, enemyDamageType, enemyAttackMechanics);

    if (evasion)
    {
        Console.WriteLine("Player evaded the attack");
        return 0;
    }

    Console.WriteLine("Player did not evade the attack.");

    int damage = 0;
    damage = CalculateConstitution(playerConstitution, enemyDamage);
    Console.WriteLine("damage after constitution: " + damage);
    damage = CalculateArmor(playerArmor, damage, enemyDamageType, enemyAttackMechanics);
    Console.WriteLine("damage after armor: " + damage);

    return damage;
}

bool CalculateEvasion(float evasion, string damageType, string[] attackMechanics)
{
    var roll = Random.Shared.NextDouble();
    float evasionEffectiveness = 1f;

    for (int i = 0; i < attackMechanics.Length; i++)
    {
        if (attackMechanics[i] == "true strike")
        {
            return false;
        }
    }

    switch (damageType)
    {
        case "magic":
            evasionEffectiveness *= 0.5f;
            break;
        case "ranged":
            evasionEffectiveness *= 0.25f;
            break;
        default:
            break;
    }

    if (roll <= evasion * evasionEffectiveness)
    {
        return true;
    }

    return false;
}

// Why is this a function if its such a simple calculation
// Abstraction!
int CalculateConstitution(int constitution, int damage)
{
    // hidden bug here, can you discern it?
    return damage - constitution;
}

int CalculateArmor(float armor, int damage, string damageType, string[] attackMechanics)
{
    float armorEffectiveness = 1f;

    for (int i = 0; i < attackMechanics.Length; i++)
    {
        if (attackMechanics[i] == "shatter")
        {
            return damage;
        }
    }

    switch (damageType)
    {
        case "magic":
            return damage;
        case "ranged":
            armorEffectiveness *= 1.5f;
            break;
        default:
            break;
    }

    float effectiveArmor = armor * armorEffectiveness;
    if (effectiveArmor > 1)
        effectiveArmor = 1;

    return (int)(damage * (1 - effectiveArmor));
}