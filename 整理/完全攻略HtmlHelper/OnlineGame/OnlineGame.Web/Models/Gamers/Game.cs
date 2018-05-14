using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
namespace OnlineGame.Web.Models
{
    public class Game
    {
        public string Name { get; set; }
        public SingleSelect SelectedItem { get; set; }
        public string SelectedItemId { get; set; }

        public List<Team> Teams
        {
            get
            {
                using (OnlineGameContext db = new OnlineGameContext())
                {
                    return db.Teams.ToListAsync().Result;
                }
            }
        }
        public List<SingleSelect> SingleSelectItems
        {
            get
            {
                using (OnlineGameContext db = new OnlineGameContext())
                {
                    //Get List
                    List<SingleSelect> singleSelectItems = db.SingleSelects.ToListAsync().Result;
                    //Set Property
                    SelectedItem = singleSelectItems.Single(item => item.IsSelected);
                    //Return List
                    return singleSelectItems;
                }
            }
        }
        //Constructor
        public Game(string name)
        {
            Name = name;
        }
        public Game()
        {
        }
    }
}

