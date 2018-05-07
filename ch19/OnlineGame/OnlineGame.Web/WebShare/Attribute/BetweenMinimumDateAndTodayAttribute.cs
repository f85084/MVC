using System;
namespace OnlineGame.Web.WebShare.Attribute
{
    public class BetweenMinimumDateAndTodayAttribute : DateRangeAttribute
    {
        public BetweenMinimumDateAndTodayAttribute(string minDate)
           : base(ParseDate(minDate), DateTime.Now)
        {
        }
    }
}