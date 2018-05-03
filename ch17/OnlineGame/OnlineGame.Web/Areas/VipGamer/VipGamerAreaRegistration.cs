using System.Web.Mvc;

namespace OnlineGame.Web.Areas.VipGamer
{
    public class VipGamerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "VipGamer";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "VipGamer_default",
                "VipGamer/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}