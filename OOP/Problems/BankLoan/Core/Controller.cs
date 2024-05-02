using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private LoanRepository loans;
        private BankRepository banks;
        private string[] bankTypes = new string[] { nameof(CentralBank), nameof(BranchBank) };
        public Controller() 
        {
            banks = new BankRepository();
            loans = new LoanRepository();
        }
        public string AddBank(string bankTypeName, string name)
        {
            IBank bank = null;
            if (!bankTypes.Contains(bankTypeName))
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }
            if (nameof(CentralBank) == bankTypeName)
            {
                bank = new CentralBank(name);
            }
            else
            {
                bank = new BranchBank(name);
            }
            banks.AddModel(bank);
            return string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName);
        }
        public string AddLoan(string loanTypeName)
        {
            ILoan loan = null;
            if (nameof(MortgageLoan) == loanTypeName)
            {
                loan = new MortgageLoan();
            }
            else if (nameof(StudentLoan) == loanTypeName)
            {
                loan = new StudentLoan();
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }
            loans.AddModel(loan);
            return string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName);
        }
        public string ReturnLoan(string bankName, string loanTypeName)
        {
            ILoan loan = loans.FirstModel(loanTypeName);
            if (loan == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName));
            }
            IBank bank = banks.Models.FirstOrDefault(b => b.Name == bankName);
            bank.AddLoan(loan);
            loans.RemoveModel(loan);
            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            IBank bank = banks.Models.FirstOrDefault(b => b.Name == bankName);
            IClient client = null;
            if (clientTypeName == nameof(Student))
            {
                if (bank.GetType().Name == nameof(CentralBank))
                {
                    return string.Format(OutputMessages.UnsuitableBank);
                }
                client = new Student(clientName, id, income);
            }
            else if (clientTypeName == nameof(Adult))
            {
                if (bank.GetType().Name == nameof(BranchBank))
                {
                    return string.Format(OutputMessages.UnsuitableBank);
                }
                client = new Adult(clientName, id, income);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }
            bank.AddClient(client);
            return string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName);
        }

        public string FinalCalculation(string bankName)
        {
            double sum = 0;
            IBank bank = banks.Models.FirstOrDefault(b => b.Name == bankName);

            sum += bank.Loans.Sum(l => l.Amount);
            sum += bank.Clients.Sum(c => c.Income);

            return string.Format(OutputMessages.BankFundsCalculated, bankName, $"{sum:f2}");
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var bank in banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
