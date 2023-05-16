using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace JobSearch.Models
{
    public class User
    {
        public int Id { get; set; }
        [StringLength(40)]
        public string FirstName { get; set; }
        [StringLength(40)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [StringLength(50)]
        public string Password { get; set; }

    }
}
