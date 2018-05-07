using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace OnlineGame.Web.WebShare.Attribute
{
    public class DateRangeAttribute : ValidationAttribute
    {
        //private const string DateFormat = "dd/MM/yyyy";
        //private static string DateFormat = System.Configuration.ConfigurationManager.AppSettings["DateDormat"];
        internal const string DateFormat = WebShareConst.DateFormat;
        internal const string DefaultErrorMessage = "{0}, '{1}' must be a date between {2:d} and {3:d}.";
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public DateRangeAttribute(string minDate, string maxDate)
            : base(DefaultErrorMessage)
        {
            MinDate = ParseDate(minDate);
            MaxDate = ParseDate(maxDate);
        }
        public DateRangeAttribute(DateTime minDate, DateTime maxDate)
            : base(DefaultErrorMessage)
        {
            MinDate = minDate;
            MaxDate = maxDate;
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
                ErrorMessageString, name, DateFormat, MinDate, MaxDate);
        }
        internal static DateTime ParseDate(string dateValue)
        {
            return DateTime.ParseExact(dateValue, DateFormat,
                CultureInfo.InvariantCulture);
        }
    }
}
