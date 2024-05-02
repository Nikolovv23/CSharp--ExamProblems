// On the first line of the input, you will receive the concealed message. After that, until the "Reveal" command is given,
// you will receive strings with instructions for different operations that need to be performed upon the concealed message
// to interpret it and reveal its actual content. There are several types of instructions, split by ":|:"
// •	"InsertSpace:|:{index}":
// o Inserts a single space at the given index. The given index will always be valid.
// •	"Reverse:|:{substring}":
// o If the message contains the given substring, cut it out, reverse it and add it at the end of the message. 
// o	If not, print "error".
// o	This operation should replace only the first occurrence of the given substring if there are two or more occurrences.
// •	"ChangeAll:|:{substring}:|:{replacement}":
// o Changes all occurrences of the given substring with the replacement text.
// Input / Constraints
// •	On the first line, you will receive a string with a message.
// •	On the following lines, you will be receiving commands, split by ":|:".
// Output
// •	After each set of instructions, print the resulting string. 
// •	After the "Reveal" command is received, print this message:
// "You have a new text message: {message}"

//      Input
// heVVodar!gniV
// ChangeAll:|:V:|:l
// Reverse:|:!gnil
// InsertSpace:|:5
// Reveal
//     Output
// hellodar!gnil
// hellodarling!
// hello darling!
// You have a new text message: hello darling!



using System.Text;

namespace SecretChat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string input = default;
            StringBuilder output = new StringBuilder();

            while ((input = Console.ReadLine()) != "Reveal")
            {
                string[] tokens = input.Split(":|:");

                string command = tokens[0];
                if (command == "InsertSpace")
                {
                    int index = int.Parse(tokens[1]);
                    message = message.Insert(index, " ");
                }
                else if (command == "ChangeAll")
                {
                    string changeAll = tokens[1];
                    string replacement = tokens[2];

                    message = message.Replace(changeAll, replacement);
                }
                else //Reverse
                {
                    string substring = tokens[1];
                    int index = message.IndexOf(substring);
                    if (index < 0)
                    {
                        Console.WriteLine("error");
                        continue;
                    }

                    string reversedSubstring = new string(substring.Reverse().ToArray());
                    message = message.Remove(index, substring.Length);
                    message += reversedSubstring;
                }
                Console.WriteLine(message);
            }
            Console.WriteLine($"You have a new text message: {message}");
        }
    }
}
