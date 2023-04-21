using System;
using System.Collections.Generic;
using System.Text;

namespace Birthday
{
    public interface IIdentify
    {
        string Name { get;}
        string Id { get; }

        public void ChechID(string checkID);
    }
}
