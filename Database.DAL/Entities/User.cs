using System.ComponentModel.DataAnnotations;

namespace PostgreDatabase.DAL.Entities
{
    public class User
    {
        [Key]
        public long ClientId { get; set; }
        public string? UserName { get; set; }
        public Guid SystemId { get; set; }
    }
}