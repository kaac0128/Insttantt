
namespace Insttantt.Data.Entities
{
    public class Flow
    {
        public int FlowId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Step>? Steps { get; set; }
    }
}