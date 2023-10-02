using System.ComponentModel.DataAnnotations;

namespace Insttantt.Data.Entities
{
    public class OutputField
    {
        public int OutputFieldId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DataType FieldType { get; set; }
        public int StepId { get; set; }
        public Step? Step { get; set; }
    }
}