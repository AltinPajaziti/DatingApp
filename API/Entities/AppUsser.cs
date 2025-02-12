using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class AppUsser
    {
        [Key]
        public int Id { get; set; }
        public required string UserName { get; set; }

        public byte[] PasswordHash { get; set; } = [];

        public byte[] PasswordSalt { get; set; } = [];

        public DateOnly DAteofBirth { get; set; }

        public required string Knownas { get; set; }

        public DateTime Created { get; set; } = DateTime.UtcNow;


        public DateTime LastActive { get; set; } = DateTime.UtcNow;

        public required string Gender { get; set; }

        public string? Intruduction { get; set; }

        public string? Interests { get; set; }

        public string? Lookinfor { get; set; }

        public required string? City { get; set; }

        public required string? Country { get; set; }

        public List<Photo> Photos { get; set; }  = [];









    }
}
