using System;
using System.Collections.Generic;
using System.Text;

namespace Tuple
{
    public class Tuple <T1, T2>
    {
        private T1 firstItem;
        private T2 secondItem;
        public Tuple()
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
        }
        public T1 FirstItem { get; set; }
        public T2 SecondItem { get; set; }


    }
}
