using System.ComponentModel.DataAnnotations;
namespace OnlineGame.Web.Models
{
    public class ContactCommentMetaData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        ////Create TextArea for this property.
        //[DataType(DataType.MultilineText)]
        public string CommentText { get; set; }
    }
}