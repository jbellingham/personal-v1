using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Personal.ViewModels.Stack
{
    public class StackViewModel
    {
        public class Display
        {
            public List<Position> Positions { get; set; }
        }

        public class Add
        {
            [Required]
            public Guid PositionId { get; set; }
            [Required]
            public string Value { get; set; }
        }

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