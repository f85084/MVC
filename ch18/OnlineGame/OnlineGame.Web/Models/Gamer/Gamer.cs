using System.ComponentModel.DataAnnotations;
namespace OnlineGame.Web.Models
{
    [MetadataType(typeof(GamerMetaData))]
    public partial class Gamer
    {
        [Compare("EmailAddress")]
        [Required]
        public string ConfirmEmailAddress { get; set; }
        //ConfirmEmailAddress property will not save into database.
    }
}
/*
1.
//[Compare("EmailAddress")]
//public string ConfirmEmailAddress { get; set; }
Reference:
https://docs.microsoft.com/en-us/aspnet/core/mvc/models/validation
Validates two properties in a model match.
*/
