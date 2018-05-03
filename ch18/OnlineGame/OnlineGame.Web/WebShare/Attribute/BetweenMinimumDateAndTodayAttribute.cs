using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace OnlineGame.Web.WebShare.Attribute
{
    public class BetweenMinimumDateAndTodayAttribute : ValidationAttribute
    {
        //private const string DateFormat = "dd/MM/yyyy";
        //private static string DateFormat = System.Configuration.ConfigurationManager.AppSettings["DateDormat"];
        private const string DateFormat = WebShareConst.DateFormat;
        private const string DefaultErrorMessage = "{0}, '{1}' must be a date between {2:d} and {3:d}.";
        public DateTime MinDate { get; set; }
        private DateTime MaxDate = DateTime.Now;
        public BetweenMinimumDateAndTodayAttribute(string minDate)
            : base(DefaultErrorMessage)
        {
            MinDate = ParseDate(minDate);
        }
        public override bool IsValid(object value)
        {
            if (!(value is DateTime))
            {
                return false;
            }
            DateTime dateValue = (DateTime)value;
            return MinDate <= dateValue && dateValue <= MaxDate;
        }
        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
                ErrorMessageString, DateFormat, name, MinDate, MaxDate);
        }
        private static DateTime ParseDate(string dateValue)
        {
            return DateTime.ParseExact(dateValue, DateFormat,
                CultureInfo.InvariantCulture);
        }
    }
}
