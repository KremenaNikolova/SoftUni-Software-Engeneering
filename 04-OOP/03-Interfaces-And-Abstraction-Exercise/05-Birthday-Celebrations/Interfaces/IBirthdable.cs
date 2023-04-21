using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday
{
    public interface IBirthdable
    {
        string Name { get; }    
        string Birthdate { get;}

        public void BirthdateCheck(string date);
    }
}
