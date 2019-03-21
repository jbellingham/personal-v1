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
        
        [InlineJson]
        public virtual ICollection<Duty> Duties { get; set; } = new HashSet<Duty>();
        
        [InlineJson]
        public virtual ICollection<Technology> Stack { get; set; } = new HashSet<Technology>();
    }
    
    public class Duty : BaseModel
    {
        public string Description { get; set; }
    }
    
    public class Technology : BaseModel
    {
        public string Name { get; set; }
    }
}