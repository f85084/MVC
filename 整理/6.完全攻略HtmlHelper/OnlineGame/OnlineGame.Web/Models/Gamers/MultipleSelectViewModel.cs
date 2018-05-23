using System.Collections.Generic;
using System.Web.Mvc;
namespace OnlineGame.Web.Models
{
    public class MultipleSelectViewModel
    {
        public IEnumerable<string> SelectedItemIds { get; set; }
        public IEnumerable<SelectListItem> MultipleSelectItems { get; set; }
    }
}