using System.ComponentModel.DataAnnotations;

namespace HobbiesAPI.Models
{
    public class People
    {
        [Key]
        public int PeopleId { get; set; }
        public string PeopleName { get; set; }
        public string Phone { get; set; }
        public IList<HobbyEnrollment>? HobbyEnrollments { get; set; }
    }
}
