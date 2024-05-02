// On the first line of the input, you will be given a text string. To win the competition, you have to find all hidden word pairs,
// read them, and mark the ones that are mirror images of each other.
// First of all, you have to extract the hidden word pairs. Hidden word pairs are:
// •	Surrounded by "@" or "#" (only one of the two) in the following pattern #wordOne##wordTwo# or @wordOne@@wordTwo@
// •	At least 3 characters long each (without the surrounding symbols).
// •	Made up of letters only.
// If the second word, spelled backward, is the same as the first word and vice versa (casing matters!), they are a match,
// and you have to store them somewhere. Examples of mirror words: 
// #Part##traP# @leveL@@Level@ #sAw##wAs#
// •	If you don`t find any valid pairs, print: "No word pairs found!"
// •	If you find valid pairs print their count: "{valid pairs count} word pairs found!"
// •	If there are no mirror words, print: "No mirror words!"
// •	If there are mirror words print:
// "The mirror words are:
// { wordOne} <=> { wordtwo}, { wordOne} <=> { wordtwo}, … { wordOne} <=> { wordtwo}
// "
// Input / Constraints
// •	You will recive a string.
// Output
// •	Print the proper output messages in the proper cases as described in the problem description.
// •	If there are pairs of mirror words, print them in the end, each pair separated by ", ".
// •	Each pair of mirror word must be printed with " <=> " between the words.

//      Input:
// @mix#tix3dj#poOl##loOp#wl@@bong&song%4very$long@thong#Part##traP##@@leveL@@Level@##car#rac##tu@pack@@ckap@#rr#sAw##wAs#r#@w1r	
//      Output:
// 5 word pairs found!
// The mirror words are:
// Part <=> traP, leveL <=> Level, sAw <=> wAs

using System.Text.RegularExpressions;

namespace MirrorWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> mirrorWords = new Dictionary<string, string>();
            List<string> output = new List<string>();
            string input = Console.ReadLine();
            string pattern = @"(@|#)(?<word>[A-Za-z]{3,})\1\1(?<mirrorWord>[A-Za-z]{3,})\1";
            int matchesCount = 0;
            int mirrorPairsCount = 0;

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);
            matchesCount = matches.Count;
            if (matchesCount == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matchesCount} word pairs found!");
            }

            foreach (Match match in matches)
            {
                string firstWord = match.Groups["word"].Value;
                string secondWord = match.Groups["mirrorWord"].Value;
                string mirrorWord = string.Empty;
                for (int i = secondWord.Length - 1; i >= 0; i--)
                {
                    mirrorWord += secondWord[i].ToString();
                }
                if (firstWord == mirrorWord)
                {
                    mirrorPairsCount++;
                    mirrorWords.Add(firstWord, secondWord);
                }
            }
            if (mirrorPairsCount == 0)
            {
                Console.WriteLine("No mirror words!");
                return;
            }
            Console.WriteLine("The mirror words are:");
            foreach (KeyValuePair<string, string> kpv in mirrorWords)
            {
                output.Add($"{kpv.Key} <=> {kpv.Value}");
            }
            Console.WriteLine(string.Join(", ", output));
        }
    }
}
