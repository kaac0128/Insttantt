
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Insttantt.Data.Entities
{
    public class Flow
    {
        [Key]
        public int FlowID { get; set; }
        public string FlowName { get; set; }

        public ICollection<Step> Steps { get; set; }
    }
}