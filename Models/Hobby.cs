using System.ComponentModel.DataAnnotations;

namespace HobbiesAPI.Models
{
    public class Hobby
    {
        [Key]
        public int HobbyId { get; set; }
        public string HobbyName { get; set; }
        public string Description { get; set; }
        public IList<HobbyEnrollment>? HobbyEnrollments { get; set; }
    }
}
