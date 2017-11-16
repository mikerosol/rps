using System.ComponentModel.DataAnnotations;

namespace Api.Models
{
    public class Person : Location
    {
        public int PersonId { get; set; }

        //[Required]
        //[StringLength(200)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        //[Required]
        //[StringLength(200)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}