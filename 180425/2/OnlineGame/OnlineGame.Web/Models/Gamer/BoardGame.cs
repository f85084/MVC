using System.Data.Entity;
using System.Linq;
namespace OnlineGame.Web.Models
{
    public class BoardGame
    {
        public Gamer GameHolder
        {
            get
            {
                using (OnlineGameContext dbContext = new OnlineGameContext())
                {
                    return dbContext.Gamers.SingleAsync(x => x.Id == 1).Result;
                }
            }
        }
    }
}

