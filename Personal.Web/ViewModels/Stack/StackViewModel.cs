using System.Collections.Generic;

namespace Personal.ViewModels.Stack
{
    public class StackViewModel
    {
        public List<Technology> Items { get; set; }
    }

    public class Technology
    {
        public string Name { get; set; }
    }
}