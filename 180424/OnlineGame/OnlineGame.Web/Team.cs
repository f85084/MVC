using System.ComponentModel.DataAnnotations;
namespace OnlineGame.Web.Models
{
    [MetadataType(typeof(TeamMetaData))]
    public partial class Team
    {
        //[Display(Name = "Team Name")]
        //public string Name { get; set; }
        //// Error!!
        //// Memeber with the same name is areadly declared in other auto-generated partial class.
        //// Thus, you need MetadataType to add extra code for the Property.
        //// E.g. tadataType(typeof(TeamMetaData))]
        //// In this case, you may add some extra code for the Property in MetadataType class
    }
}
