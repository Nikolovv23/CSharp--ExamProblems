// Write a password reset program that performs a series of commands upon a predefined string. First, you will receive a string, and afterward,
// until the command "Done" is given, you will be receiving strings with commands split by a single space. The commands will be the following:
// •	"TakeOdd"
// o Takes only the characters at odd indices and concatenates them to obtain the new raw password and then prints it.
// •	"Cut {index} {length}"
// o	Gets the substring with the given length starting from the given index from the password and removes its first occurrence,
// then prints the password on the console.
// o	The given index and the length will always be valid.
// •	"Substitute {substring} {substitute}"
// o	If the raw password contains the given substring, replace all of its occurrences with the substitute text given and print the result.
// o	If it doesn't, prints "Nothing to replace!".
// Input
// •	You will be receiving strings until the "Done" command is given.
// Output
// •	After the "Done" command is received, print:
// o   "Your password is: {password}"
// Constraints
// •	The indexes from the "Cut {index} {length}" command will always be valid.

//     Input
// Siiceercaroetavm!:?:ahsott.:i: nstupmomceqr
// TakeOdd
// Cut 15 3
// Substitute :: -
// Substitute | ^
// Done
//     Output
// icecream::hot::summer
// icecream::hot::mer
// icecream-hot-mer
// Nothing to replace!
// Your password is: icecream - hot - mer


using System.Text;

namespace PasswordReset
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string code = Console.ReadLine();
            string input = string.Empty;
            StringBuilder password = new StringBuilder();
            while ((input = Console.ReadLine()) != "Done")
            {
                string[] commands = input.Split(' ').ToArray();
                string command = commands[0];
                if (command == "TakeOdd")
                {
                    for (int i = 1; i < code.Length; i += 2)
                    {
                        password.Append(code[i]);
                    }
                    code = password.ToString();
                    Console.WriteLine(code);
                }
                else if (command == "Cut")
                {
                    int index = int.Parse(commands[1]);
                    int lenght = int.Parse(commands[2]);
                    code = code.Remove(index, lenght);
                    Console.WriteLine(code);
                }
                else // "Substitute"
                {
                    string substring = commands[1];
                    string substitute = commands[2];
                    if (!code.Contains(substring))
                    {
                        Console.WriteLine("Nothing to replace!");
                        continue;
                    }
                    code = code.Replace(substring, substitute);
                    Console.WriteLine(code);
                }
            }
            Console.WriteLine($"Your password is: {code}");
        }
    }
}
