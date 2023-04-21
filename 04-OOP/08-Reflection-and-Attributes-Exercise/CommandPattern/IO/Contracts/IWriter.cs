using System;
using System.Collections.Generic;
using System.Text;

namespace CommandPattern.IO.Contracts
{
    public interface IWriter
    {
        void Write(object value);
        void WriteLine(object value);
    }
}
