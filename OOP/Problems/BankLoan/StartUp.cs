using BankLoan.Core;
using BankLoan.Core.Contracts;

namespace BankLoan
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}

// We are a new bank committed to providing personalized financial services to our customers. Our primary focus is on building strong relationships and 
//     understanding the unique needs of each client. We specialize in offering competitive loans to individuals and businesses, with flexible terms and
//     competitive interest rates. Our streamlined application process ensures a hassle-free experience for our customers. With a dedicated team of 
//     professionals, we aim to deliver exceptional service and support to help our clients achieve their financial goals.

// You are provided with one interface, which will help you with the correct execution process of your program. The interface is Engine and the class
// implementing this interface should read the input and when the program finishes, this class should print the output.

// Input
// Below, you can see the format in which each command will be given in the input:
// · AddBank {bankTypeName} {name}
// · AddLoan {loanTypeName}
// · ReturnLoan {bankName} {loanTypeName}
// · AddClient {bankName} {clientTypeName} {clientName} {id} {income}
// · FinalCalculation {bankName}
// · Statistics
// · End

// Output
// Print the output from each command when issued. If an exception is thrown during any of the commands' execution, print the exception message.

// Examples
//      Input:
// AddBank BranchBank DSKBank
// AddBank CentralBank Fibank
// AddLoan StudentLoan
// AddLoan MortgageLoan
// AddLoan MortgageLoan
// ReturnLoan DSKBank StudentLoan 
// ReturnLoan Fibank StudentLoan
// ReturnLoan Fibank MortgageLoan
// AddClient Fibank Student Maria 54TAF433 346.7
// AddClient Fibank Adult Peter 65GTTHA134 5643.1
// FinalCalculation Fibank
// Statistics
// End

//      Output:
// BranchBank is successfully added.
// CentralBank is successfully added.
// StudentLoan is successfully added.
// MortgageLoan is successfully added.
// MortgageLoan is successfully added.
// StudentLoan successfully added to DSKBank.
// Loan of type StudentLoan is missing.
// MortgageLoan successfully added to Fibank.
// Unsuitable bank.
// Adult successfully added to Fibank.
// The funds of bank Fibank are 55643.10.
// Name: DSKBank, Type: BranchBank
// Clients: none
// Loans: 1, Sum of Rates: 1
// Name: Fibank, Type: CentralBank
// Clients: Peter
// Loans: 1, Sum of Rates: 3

