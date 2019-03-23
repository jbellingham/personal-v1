using System.Collections.Generic;

namespace Personal.ViewModels.JobPosition
{
    public class JobPositionViewModel
    {
        public List<Position> Positions { get; set; }

        public class Position
        {
            public string Title { get; set; }
            public string CompanyName { get; set; }
            public string StartDate { get; set; }
            public string EndDate { get; set; }
            public string Location { get; set; }
            public List<Technology> Stack { get; set; }
        }

        public class Technology
        {
            public string Name { get; set; }
        }
    }
}