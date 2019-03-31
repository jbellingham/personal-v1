using System;
using System.Collections.Generic;

namespace Personal.ViewModels.JobPosition
{
    public class JobPositionViewModel
    {
        public List<Position> Positions { get; set; }

        public class Position
        {
            public Guid PositionId { get; set; }
            public string Title { get; set; }
            public string CompanyName { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string Location { get; set; }
            public List<string> Duties { get; set; }
        }
    }
}