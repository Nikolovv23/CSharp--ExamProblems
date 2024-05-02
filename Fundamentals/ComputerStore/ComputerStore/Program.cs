// Write a program that prints you a receipt for your new computer.You will receive the parts' prices (without tax)
// until you receive what type of customer this is - special or regular. Once you receive the type of customer you should print the receipt.
// The taxes are 20% of each part's price you receive. 
// If the customer is special, he has a 10% discount on the total price with taxes.
// If a given price is not a positive number, you should print "Invalid price!" on the console and continue with the next price.
// If the total price is equal to zero, you should print "Invalid order!" on the console.
// Input
// •	You will receive numbers representing prices (without tax) until the command "special" or "regular":
// Output
// •	The receipt should be in the following format: 
// "Congratulations you've just bought a new computer!
// Price without taxes: { total price without taxes}$
// Taxes: { total amount of taxes}$
// -----------
// Total price: { total price with taxes}
// $"
// Note: All prices should be displayed to the second digit after the decimal point! The discount is applied only on the total price.
// Discount is only applicable to the final price!

//     Input:
// 1050
// 200
// 450
// 2
// 18.50 
// 16.86 
// special
//     Output:
// Congratulations you've just bought a new computer!
// Price without taxes: 1737.36$
// Taxes: 347.47$
// -----------
// Total price: 1876.35$


namespace ComputerStore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = default;
            List<double> priceForAll = new List<double>();
            double priceWithoutTaxes = 0;

            while ((input = Console.ReadLine()) != "special")
            {
                if (input == "regular")
                {
                    break;
                }
                double price = double.Parse(input);
                if (price <= 0)
                {
                    Console.WriteLine("Invalid price!");
                }
                else
                {
                    priceForAll.Add(price);
                }
            }

            foreach (double price in priceForAll)
            {
                priceWithoutTaxes += price;
                Math.Round(priceWithoutTaxes, 2);
            }
            double totalSum = 0;
            double taxes = 0;
            double totalSumWithTaxes = 0;
            if (input == "special")
            {
                taxes = 0.2 * priceWithoutTaxes;
                Math.Round(taxes, 2);
                totalSum = priceWithoutTaxes;
                totalSumWithTaxes = (totalSum + taxes) * 0.9;
            }
            else
            {
                taxes = 0.2 * priceWithoutTaxes;
                Math.Round(taxes, 2);
                totalSum = priceWithoutTaxes;
                totalSumWithTaxes = priceWithoutTaxes + taxes;
            }

            if (totalSum == 0)
            {
                Console.WriteLine("Invalid order!");
            }
            else
            {
                Console.WriteLine($"Congratulations you've just bought a new computer!");
                Console.WriteLine($"Price without taxes: {totalSum:f2}$");
                Console.WriteLine($"Taxes: {taxes:f2}$");
                Console.WriteLine("-----------");
                Console.WriteLine($"Total price: {totalSumWithTaxes:f2}$");
            }
        }
    }
}
