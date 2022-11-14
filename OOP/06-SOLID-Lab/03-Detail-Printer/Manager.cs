using P03.DetailPrinter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DetailPrinter
{
    public class Manager : Employee, IEmployee
    {
        public Manager(string name, ICollection<string> documents) : base(name)
        {
            this.Documents = new List<string>(documents);
        }

        public IReadOnlyCollection<string> Documents { get; set; }

        public override string Print()
        {
            return base.Print() 
                + Environment.NewLine
                + $"{string.Join(Environment.NewLine, Documents)}";
        }
    }
}
