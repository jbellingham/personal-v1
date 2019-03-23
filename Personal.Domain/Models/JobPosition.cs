using System;
using System.Collections.Generic;

namespace Personal.Domain.Models
{
    public class JobPosition : BaseModel
    {
        public virtual string Title { get; set; }
        public virtual string CompanyName { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime? EndDate { get; set; }
        public virtual string Location { get; set; }
        public virtual ICollection<PositionTechnology> Stack { get; set; } = new HashSet<PositionTechnology>();
        
        [InlineJson]
        public virtual ICollection<Duty> Duties { get; set; } = new HashSet<Duty>();
        
    }
    
    public class Duty : BaseModel
    {
        public string Description { get; set; }
    }
}