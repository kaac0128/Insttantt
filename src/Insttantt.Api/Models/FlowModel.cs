

namespace Insttantt.Api.Models
{
    public class FlowModel
    {
        public int FlowID { get; set; }
        public string FlowName { get; set; }

        public ICollection<StepModel> Steps { get; set; }
    }
}
