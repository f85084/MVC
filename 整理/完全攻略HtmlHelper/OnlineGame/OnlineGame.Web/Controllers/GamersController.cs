using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using OnlineGame.Web.Models;
namespace OnlineGame.Web.Controllers
{
    public class GamersController : Controller
    {
        private OnlineGameContext _dbContext = new OnlineGameContext();
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult HtmlHelpers()
        {
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Dropdownlist()
        {
            //Use the collection of teams as the parameter to create SelectList
            //which value is Team Id and the text is Team Name.
            //ViewBag.TeamId will bind this SelectList to View Model control components, TeamId1 and TeamId2.
            ViewBag.TeamId1 = new SelectList(await _dbContext.Teams.ToListAsync(), "Id", "Name");
            ViewBag.TeamId2 = new SelectList(await _dbContext.Teams.ToListAsync(), "Id", "Name", 2);
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach (SingleSelect singleSelectItem in await _dbContext.SingleSelects.ToListAsync())
            {
                SelectListItem selectListItem = new SelectListItem
                {
                    Text = singleSelectItem.Name,
                    Value = singleSelectItem.Id.ToString(),
                    Selected = singleSelectItem.IsSelected
                };
                selectListItems.Add(selectListItem);
            }
            ViewBag.selectListItems1 = selectListItems;
            return View();
        }
        
        [HttpGet]
        public ActionResult TextBox()
        {
            Game game = new Game("GameA");
            ViewBag.GameName = game.Name;
            ViewBag.GameTeams = new SelectList(game.Teams, "Id", "Name");
            return View();
        }

        [HttpGet]
        public ActionResult TextBoxFor()
        {
            Game game = new Game("GameB");
            return View(game);
        }

        [HttpGet]
        public ActionResult Radiobuttonlist()
        {
            Game game = new Game("GameA");
            return View(game);
        }
        [HttpPost]
        public string Radiobuttonlist(Game game)
        {
            return string.IsNullOrEmpty(game.SelectedItemId)
                ? "Nothing is selected"
                : $"Selected Id == {game.SelectedItemId}";
            //return RedirectToAction("Index");
        }
        
        
        [HttpGet]
        public async Task<ActionResult> CheckBoxList()
        {
            List<MultipleSelect> multipleSelects =
                await _dbContext.MultipleSelects.ToListAsync();
            return View(multipleSelects);
        }

        [HttpPost]
        public string CheckBoxList(IEnumerable<MultipleSelect> multipleSelects)
        {
            IEnumerable<MultipleSelect> enumerable = multipleSelects as MultipleSelect[] ?? multipleSelects.ToArray();
            if (enumerable.Count(x => x.IsSelected) == 0)
            {
                return "Nothing is selected";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append("Selected Items - ");
            foreach (MultipleSelect item in enumerable)
            {
                if (item.IsSelected)
                {
                    sb.Append($"{item.Name}, ");
                }
            }
            sb.Remove(sb.ToString().LastIndexOf(",", StringComparison.Ordinal), 1);
            return sb.ToString();
        }

        [HttpGet]
        public async Task<ActionResult> ListBox()
        {
            //Create List<SelectListItem> for ListBox
            //Retrive data from DB
            List<MultipleSelect> multipleSelects =
                await _dbContext.MultipleSelects.ToListAsync();

            List<SelectListItem> listSelectListItems =
                multipleSelects.Select(
                    item => new SelectListItem
                    {
                        Text = item.Name,
                        Value = item.Id.ToString(),
                        Selected = item.IsSelected
                    }).ToList();

            MultipleSelectViewModel multipleSelectViewModel = new MultipleSelectViewModel
            {
                MultipleSelectItems = listSelectListItems
            };
            return View(multipleSelectViewModel);
        }

        [HttpPost]
        public string ListBox(IEnumerable<string> selectedItemIds)
        {
            if (selectedItemIds == null)
            {
                return "No cities selected";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append($"Selected ID - {string.Join(", ", selectedItemIds)}");
            return sb.ToString();
        }

    }
}
