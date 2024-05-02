// Your task is to write a program that extracts emojis from a text and find the threshold based on the input.
// You have to get your cool threshold. It is obtained by multiplying all the digits found in the input.
// The cool threshold could be a huge number, so be mindful.
// An emoji is valid when:
// •	It is surrounded by 2 characters, either "::" or "**"
// •	It is at least 3 characters long (without the surrounding symbols)
// •	It starts with a capital letter
// •	Continues with lowercase letters only
// Examples of valid emojis: ::Joy::, **Banana * *, ::Wink::
// Examples of invalid emojis: ::Joy * *, ::fox:es:, **Monk3ys * *, :Snak::Es::
// You need to count all valid emojis in the text and calculate their coolness. The coolness of the emoji is determined by summing all
// the ASCII values of all letters in the emoji. 
// Examples: ::Joy:: - 306, **Banana * *-577, ::Wink:: - 409
// You need to print the result of the cool threshold and, after that take all emojis out of the text, count them and print only the cool ones on the console.
// Input
// •	On the single input, you will receive a piece of string. 
// Output
// •	On the first line of the output, print the obtained Cool threshold in the format:
// "Cool threshold: {coolThresholdSum}"
// •	On the following line, print the count of all emojis found in the text in the format:
// "{countOfAllEmojis} emojis found in the text. The cool ones are:
// { cool emoji 1}
// { cool emoji 2}
// …
// { cool emoji N}
// "
// Constraints
// There will always be at least one digit in the text!

//     Input:
// In the Sofia Zoo there are 311 animals in total! ::Smiley:: This includes 3 **Tigers**, 1 ::Elephant:, 12 * *Monk3ys * *, a** Gorilla::, 5 ::fox:es: and 21 different types of :Snak::Es::. ::Mooning:: * *Shy * *
//     Output:
// Cool threshold: 540
// 4 emojis found in the text. The cool ones are:
// ::Smiley:: 
// * *Tigers * *
// ::Mooning::


using System.Text.RegularExpressions;

namespace EmodjiDetector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> animals = new Dictionary<string, long>();
            Dictionary<string, long> coolAnimals = new Dictionary<string, long>();

            string input = Console.ReadLine();
            string animalsPattern = @"(::|\*\*)(?<name>[A-Z]{1}[a-z]{2,})(\1)";
            string coolThresholdPattern = @"[0-9]";
            long coolThreshold = 1;
            foreach (Match m in Regex.Matches(input, coolThresholdPattern))
            {
                coolThreshold *= long.Parse(m.ToString());
            }
            Console.WriteLine($"Cool threshold: {coolThreshold}");
            foreach (Match animal in Regex.Matches(input, animalsPattern))
            {
                string name = animal.Value;
                string onlyName = animal.Groups["name"].Value;
                long threshold = 1;
                for (int i = 0; i < onlyName.Length; i++)
                {
                    char c = onlyName[i];
                    threshold += c;
                }
                animals.Add(name, threshold);
                if (threshold >= coolThreshold)
                {
                    coolAnimals.Add(name, threshold);
                }
            }
            Console.WriteLine($"{animals.Count} emojis found in the text. The cool ones are:");
            foreach (KeyValuePair<string, long> kvp in coolAnimals)
            {
                Console.WriteLine(kvp.Key);
            }
        }
    }
}
