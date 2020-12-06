using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace qLogics.Ideas.Models
{
    [Table("qLogicsIdeas")]
    public class Ideas : IAuditable
    {
        public int IdeasId { get; set; }
        public int ModuleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
