using System.ComponentModel.DataAnnotations;

namespace UnitTestPlayground.CommandQuery.Models
{
    public class AddUserModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
    }
}