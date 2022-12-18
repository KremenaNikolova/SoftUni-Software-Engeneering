using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniDI_Framework.Attribute
{
    [AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field)]
    public class Inject : Attribute
    {
    }
}
