using System.Collections.Generic;

namespace Personal.Domain.Models
{
    public class Technology : BaseModel
    {
        public string Name { get; set; }
        public int Ordinal { get; set; }
        public virtual ICollection<PositionTechnology> Positions { get; set; }
    }
}