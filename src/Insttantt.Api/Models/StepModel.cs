

namespace Insttantt.Api.Models
{
    public class StepModel
    {
        public int StepID { get; set; }
        public string StepName { get; set; }

        public int FlowID { get; set; }
        public FlowModel Flow { get; set; }

        public int InputFieldID { get; set; }
        public FieldModel InputField { get; set; }

        public int OutputFieldID { get; set; }
        public FieldModel OutputField { get; set; }
    }
}
