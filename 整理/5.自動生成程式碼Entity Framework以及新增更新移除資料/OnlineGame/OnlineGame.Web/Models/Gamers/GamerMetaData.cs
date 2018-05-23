using System;
using System.ComponentModel.DataAnnotations;
namespace OnlineGame.Web.Models
{
    public class GamerMetaData
    {
        // Here is the place you may add some extra code for the property
        // which is already in the auto-generate partail class.
        //[Required]
        public string Name { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [Display(Name = "Team")]
        public Nullable<int> TeamId { get; set; }
        //In the database, TeamId is Nullable,
        //so the [Required] attibure here will not affect any thing.
        //If the TeamId in database is not Nullable,
        //then without [Display(Name = "Team")] attibute,
        //the validation message will display "TeamId is required".
        //if it is with [Display(Name = "Team")] attibute,
        //then validation message will display "Team is required".
    }
}
