using System;

namespace WHTracker.Data.Models
{
    internal class TitleAttribute : Attribute
    {
        public TitleAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}