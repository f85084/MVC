using System;
namespace OnlineGame.Web.WebShare.Attribute
{
    public class BeforeTodayAttribute : DateRangeAttribute
    {
        public BeforeTodayAttribute()
            : base(DateTime.MinValue, DateTime.Now)
        {
        }
    }
}