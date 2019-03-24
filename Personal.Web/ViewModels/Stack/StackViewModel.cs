using System;
using System.Collections.Generic;

namespace Personal.ViewModels.Stack
{
    public class StackViewModel
    {
        public List<Position> Positions { get; set; }

        public class Position
        {
            public Guid PositionId { get; set; }
            public List<Technology> Stack { get; set; }
        }
    }

    public class Technology
    {
        public string Name { get; set; }
    }
}