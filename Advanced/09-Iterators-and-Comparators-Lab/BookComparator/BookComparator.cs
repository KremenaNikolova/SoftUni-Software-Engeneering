using IteratorsAndComparators;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare([AllowNull] Book x, [AllowNull] Book y)
        {
            if (x.Title.CompareTo(y.Title)==0)
            {
                return y.Year.CompareTo(x.Year);
            }
            return x.Title.CompareTo(y.Title);
        }
    }
}
