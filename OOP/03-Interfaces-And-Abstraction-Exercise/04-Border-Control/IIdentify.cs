using System;
using System.Collections.Generic;
using System.Text;

namespace _04_Border_Control
{
    public interface IIdentify
    {
        string Name { get;}
        string Id { get; }

        public void ChechID(string checkID);
    }
}
