using System.ComponentModel.DataAnnotations;

namespace CRUD_CORE__WEB_API.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNo{ get; set; }
        public string Email{ get; set; }
        public string Password{ get; set; }
    }
}
