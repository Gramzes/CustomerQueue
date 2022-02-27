using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CstomerQueue
{
    class Customer
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string NumberInLine { get; private set; }
        public Customer(string firstName, string lastName, string numberInLine)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.NumberInLine = numberInLine;
        }
        public override string ToString()
        {
            return LastName + " " + FirstName + " - " + NumberInLine;
        }
    }
}
