#nullable enable

namespace WebApi009.Models
{

    public class student
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;

        public int Age { get; set; }

        public string Gender { get; set; } = null!;

        public string? ClassNum { get; set; }
    }
}
