// You will receive an initial list with groceries separated by an exclamation mark "!".
// After that, you will be receiving 4 types of commands until you receive "Go Shopping!".
// •	"Urgent {item}" - add the item at the start of the list.  If the item already exists, skip this command.
// •	"Unnecessary {item}" - remove the item with the given name, only if it exists in the list. Otherwise, skip this command.
// •	"Correct {oldItem} {newItem}" - if the item with the given old name exists, change its name with the new one.Otherwise, skip this command.
// •	"Rearrange {item}" - if the grocery exists in the list, remove it from its current position and add it at the end of the list.Otherwise, skip this command.
// Constraints
// •	There won't be any duplicate items in the initial list.
// Output
// •	Print the list with all the groceries, joined by ", ":
// "{firstGrocery}, {secondGrocery}, … {nthGrocery}"

//      Input:
// Tomatoes!Potatoes!Bread
// Unnecessary Milk
// Urgent Tomatoes
// Go Shopping!
//      Output:
// Tomatoes, Potatoes, Bread


namespace ShoppingList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> products = Console.ReadLine().Split('!').ToList();

            string input = default;

            while ((input = Console.ReadLine()) != "Go Shopping!")
            {
                List<string> command = input.Split(' ').ToList();

                if (command[0] == "Urgent")
                {
                    if (products.Contains(command[1]))
                    {

                    }
                    else
                    {
                        products.Insert(0, command[1]);
                    }
                }
                else if (command[0] == "Unnecessary")
                {
                    if (products.Contains(command[1]))
                    {
                        products.Remove(command[1]);
                    }
                }
                else if (command[0] == "Correct")
                {
                    if (products.Contains(command[1]))
                    {
                        string oldValue = command[1];
                        string newValue = command[2];
                        int index = products.IndexOf(oldValue);
                        products.RemoveAt(index);
                        products.Insert(index, newValue);
                    }
                }
                else if (command[0] == "Rearrange")
                {
                    if (products.Contains(command[1]))
                    {
                        products.Remove(command[1]);
                        products.Add(command[1]);
                    }
                }
            }
            Console.WriteLine(string.Join(", ", products));
        }
    }
}
