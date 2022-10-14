using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _4Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> numbers;

        public Lake(List<int> numbers)
        {
            this.numbers = numbers;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < numbers.Count; i=i+2)
            {
                yield return numbers[i];
            }
            for (int i = numbers.Count-1; i >= 0; i--)
            {
                if (i%2!=0)
                {
                    yield return numbers[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
