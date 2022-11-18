using System;
using System.Collections.Generic;
using System.Text;

namespace AuthorProblem
{
    public class Author : Attribute
    {
        public Author(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
