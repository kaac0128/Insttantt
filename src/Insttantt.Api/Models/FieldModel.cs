using Insttantt.Data.Entities;

namespace Insttantt.Api.Models
{
    public class FieldModel
    {
        public int FieldID { get; set; }
        public string FieldName { get; set; }
        public ICollection<StepModel> Steps { get; set; }
    }
}
