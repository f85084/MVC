using System.ComponentModel.DataAnnotations;
namespace OnlineGame.Web.Models
{
    [MetadataType(typeof(GamerMetaData))]
    //[DisplayColumn("Id")]
    [DisplayColumn("Name")]
    public partial class Gamer
    {
    }
}