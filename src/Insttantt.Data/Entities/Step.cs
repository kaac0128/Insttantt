using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Insttantt.Data.Entities
{
    public class Step
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StepID { get; set; }
        public string StepName { get; set; }
        public int FlowId { get; set; }
        public Flow Flow { get; set; }
        public int InputFieldID { get; set; }
        public Field InputField { get; set; }
        public int OutputFieldID { get; set; }
        public Field OutputField { get; set; }
    }
}