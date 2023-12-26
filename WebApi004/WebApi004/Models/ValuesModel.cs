using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using WebApi004.Validations;

namespace WebApi004.Models
{
    public class ValuesModel
    {
        public int Id { get; set; }

        [NoSpace]
        [DisplayName(displayName:"Name1")]
        [MaxLength(length:5)]
        public string Name1 { get; set; }

        [Compare(nameof(Name1))]
        public string? Name2 { get; set; }

        [Range(0,200,ErrorMessage ="年龄超过范围")]
        public int Age { get; set; }

        public string? Gender { get; set; }
    }
}
