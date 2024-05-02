// On the first line of the standard input, you will receive an integer n – the number of heroes that you can choose for your party. On the next n lines,
// the heroes themselves will follow with their hit points and mana points separated by a single space in the following format: 
// "{hero name} {HP} {MP}"
// - HP stands for hit points and MP for mana points
// -	a hero can have a maximum of 100 HP and 200 MP
// After you have successfully picked your heroes, you can start playing the game. You will be receiving different commands, each on a new line,
// separated by " – ", until the "End" command is given. 
// There are several actions that the heroes can perform:
// "CastSpell – {hero name} – {MP needed} – {spell name}"
// •	If the hero has the required MP, he casts the spell, thus reducing his MP. Print this message: 
// o   "{hero name} has successfully cast {spell name} and now has {mana points left} MP!"
// •	If the hero is unable to cast the spell print:
// o   "{hero name} does not have enough MP to cast {spell name}!"
// "TakeDamage – {hero name} – {damage} – {attacker}"
// •	Reduce the hero HP by the given damage amount. If the hero is still alive (his HP is greater than 0) print:
// o   "{hero name} was hit for {damage} HP by {attacker} and now has {current HP} HP left!"
// •	If the hero has died, remove him from your party and print:
// o   "{hero name} has been killed by {attacker}!"
// "Recharge – {hero name} – {amount}"
// •	The hero increases his MP. If it brings the MP of the hero above the maximum value (200), MP is increased to 200. (the MP can't go over the maximum value).
// •	 Print the following message:
// o   "{hero name} recharged for {amount recovered} MP!"
// "Heal – {hero name} – {amount}"
// •	The hero increases his HP. If a command is given that would bring the HP of the hero above the maximum value (100),
// HP is increased to 100 (the HP can't go over the maximum value).
// •	 Print the following message:
// o   "{hero name} healed for {amount recovered} HP!"
// Input
// •	On the first line of the standard input, you will receive an integer n.
// •	On the following n lines, the heroes themselves will follow with their hit points and mana points separated by a space in the following format.
// •	You will be receiving different commands, each on a new line, separated by " – ", until the "End" command is given.
// Output
// •	Print all members of your party who are still alive, in the following format (their HP/MP need to be indented 2 spaces):
// "{hero name}
//   HP: { current HP}
// MP: { current MP}
// "
// Constraints
// •	The starting HP/MP of the heroes will be valid, 32-bit integers will never be negative or exceed the respective limits.
// •	The HP/MP amounts in the commands will never be negative.
// •	The hero names in the commands will always be valid members of your party. No need to check that explicitly.
// 
//     Input:
// 2
// Solmyr 85 120
// Kyrre 99 50
// Heal - Solmyr - 10
// Recharge - Solmyr - 50
// TakeDamage - Kyrre - 66 - Orc
// CastSpell - Kyrre - 15 - ViewEarth
// End
//     Output:
// Solmyr healed for 10 HP!
// Solmyr recharged for 50 MP!
// Kyrre was hit for 66 HP by Orc and now has 33 HP left!
// Kyrre has successfully cast ViewEarth and now has 35 MP!
// Solmyr
//   HP: 95
//   MP: 170
// Kyrre
//   HP: 33
//   MP: 35


namespace HeroesOfCodeAndLogic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int heroesCount = int.Parse(Console.ReadLine());
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
            for (int i = 0; i < heroesCount; i++)
            {
                string[] heroInfo = Console.ReadLine().Split(' ').ToArray();
                string name = heroInfo[0];
                int hp = int.Parse(heroInfo[1]);
                int mp = int.Parse(heroInfo[2]);

                Hero hero = new Hero(name, hp, mp);

                if (!heroes.ContainsKey(name))
                {
                    heroes.Add(name, hero);
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] actionInfo = command.Split(" - ").ToArray();
                string action = actionInfo[0];
                string name = actionInfo[1];

                if (action == "CastSpell")
                {
                    int mpNeeded = int.Parse(actionInfo[2]);
                    string spellName = actionInfo[3];

                    if (heroes[name].MP < mpNeeded)
                    {
                        Console.WriteLine($"{name} does not have enough MP to cast {spellName}!");
                        continue;
                    }
                    int leftMp = heroes[name].MP - mpNeeded;
                    heroes[name].MP -= mpNeeded;
                    Console.WriteLine($"{name} has successfully cast {spellName} and now has {leftMp} MP!");
                }
                else if (action == "TakeDamage")
                {
                    int damage = int.Parse(actionInfo[2]);
                    string attacker = actionInfo[3];

                    heroes[name].HP -= damage;
                    if (heroes[name].HP <= 0)
                    {
                        heroes.Remove(name);
                        Console.WriteLine($"{name} has been killed by {attacker}!");
                        continue;
                    }
                    Console.WriteLine($"{name} was hit for {damage} HP by {attacker} and now has {heroes[name].HP} HP left!");

                }
                else if (action == "Recharge")
                {
                    int amountMp = int.Parse(actionInfo[2]);
                    heroes[name].MP += amountMp;
                    if (heroes[name].MP > 200)
                    {
                        int rechargedMp = 200 - (heroes[name].MP - amountMp);
                        Console.WriteLine($"{name} recharged for {rechargedMp} MP!");
                        heroes[name].MP = 200;
                        continue;
                    }
                    Console.WriteLine($"{name} recharged for {amountMp} MP!");
                }
                else // "Heal"
                {
                    int amountHp = int.Parse(actionInfo[2]);
                    heroes[name].HP += amountHp;
                    if (heroes[name].HP > 100)
                    {
                        int healtedHp = 100 - (heroes[name].HP - amountHp);
                        Console.WriteLine($"{name} healed for {healtedHp} HP!");
                        heroes[name].HP = 100;
                        continue;
                    }
                    Console.WriteLine($"{name} healed for {amountHp} HP!");
                }
            }
            foreach (KeyValuePair<string, Hero> kvp in heroes)
            {
                Console.WriteLine(kvp.Value);
            }
        }
    }
    class Hero
    {
        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }

        public Hero(string name, int hp, int mp)
        {
            Name = name;
            HP = hp;
            MP = mp;
        }
        public override string ToString()
        {
            return $"{Name}\n" +
                $" HP: {HP}\n" +
                $" MP: {MP}";
        }
    }
}
