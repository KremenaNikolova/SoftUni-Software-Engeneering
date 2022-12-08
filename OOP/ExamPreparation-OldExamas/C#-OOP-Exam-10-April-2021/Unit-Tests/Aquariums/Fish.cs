using System;

namespace Aquariums
{
    public class Fish
    {
        public Fish(string name)
        {
            this.Name = name;
            this.Available = true;
        }

        public string Name { get; set; }

        public bool Available { get; set; }

        public object[] Select(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
