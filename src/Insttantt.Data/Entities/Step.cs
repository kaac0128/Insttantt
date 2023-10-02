namespace Insttantt.Data.Entities
{
    public class Step
    {
        public int StepId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Order { get; set; }
        public ICollection<InputField>? InputFields { get; set; }
        public ICollection<OutputField>? OutputFields { get; set; }
        public int FlowId { get; set; }
        public Flow? Flow { get; set; }
    }
}