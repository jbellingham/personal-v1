using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal.Domain.Models
{
    public class PositionTechnology
    {
        [ForeignKey(nameof(PositionId))]
        public JobPosition Position { get; set; }
        public Guid PositionId { get; set; }
        
        [ForeignKey(nameof(TechnologyId))]
        public Technology Technology { get; set; }
        public Guid TechnologyId { get; set; }
    }
}