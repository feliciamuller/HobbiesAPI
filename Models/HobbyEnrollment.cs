using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HobbiesAPI.Models
{
    public class HobbyEnrollment
    {
        [Key]
        public int Id { get; set; }
        public IList<string>? Links { get; set; }
        [ForeignKey("People")]
        public int FKPeopleId { get; set; }
        public People? People { get; set; }
        [ForeignKey("Hobby")]
        public int FKHobbyId { get; set; }
        public Hobby? Hobby { get; set; }
    }
}
