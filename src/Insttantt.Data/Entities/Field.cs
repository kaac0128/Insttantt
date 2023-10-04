using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Insttantt.Data.Entities
{
    public class Field
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FieldID { get; set; }
        public string FieldName { get; set; }

        public ICollection<Step> InputSteps { get; set; }
        public ICollection<Step> OutputSteps { get; set; }
    }
}