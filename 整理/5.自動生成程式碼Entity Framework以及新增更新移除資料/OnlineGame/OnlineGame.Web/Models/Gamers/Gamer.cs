using System.ComponentModel.DataAnnotations;

namespace OnlineGame.Web.Models
{
    [MetadataType(typeof(GamerMetaData))]
    public partial class Gamer
    {
        //[Required]
        //public string Name { get; set; }
        //[Required]
        //public string Gender { get; set; }
        //[Required]
        //public string City { get; set; }
        //[Required]
        //[Display(Name = "Team")]
        //public int TeamId { get; set; }
        //// Error!!
        //// Memeber with the same name is areadly declared in other auto-generated partial class.
        //// Thus, you need MetadataType to add extra code for the Property.
        //// E.g. [MetadataType(typeof(GamerMetaData))
        //// In this case, you may add some extra code for the Property in MetadataType class
    }
}

