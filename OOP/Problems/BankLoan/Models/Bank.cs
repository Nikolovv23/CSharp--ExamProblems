using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private int capacity;
        private List<ILoan> loans;
        private List<IClient> clients;

        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new List<ILoan>();
            clients = new List<IClient>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value;
            }
        }

        public int Capacity
        {
            get { return capacity; }
            private set
            {
                capacity = value;
            }
        }

        public IReadOnlyCollection<ILoan> Loans => loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => clients.AsReadOnly();

        public void AddClient(IClient Client)
        {
            if (Clients.Count < Capacity)
            {
                clients.Add(Client);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void AddLoan(ILoan loan) => loans.Add(loan);

        public string GetStatistics()
        {
           StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {Name}, Type: {this.GetType().Name}");
            if (Clients.Any())
            {
                var names = Clients.Select(x => x.Name).ToList();
                sb.AppendLine($"Clients: {string.Join(", ", names)}");
            }
            else
            {
                sb.AppendLine("Clients: none");
            }
            sb.AppendLine($"Loans: {Loans.Count}, Sum of Rates: {this.SumRates()}");
            return sb.ToString().TrimEnd();
        }
        public void RemoveClient(IClient Client) =>clients.Remove(Client);

        public double SumRates() => Loans.Sum(l => l.InterestRate);
        
    }
}
