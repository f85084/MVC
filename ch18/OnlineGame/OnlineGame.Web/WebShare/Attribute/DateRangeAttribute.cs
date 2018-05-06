﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace OnlineGame.Web.WebShare.Attribute
{
    public class DateRangeAttribute : ValidationAttribute
    {
        //private const string DateFormat = "dd/MM/yyyy";
        //private static string DateFormat = System.Configuration.ConfigurationManager.AppSettings["DateDormat"];
        private const string DateFormat = WebShareConst.DateFormat;
        private const string DefaultErrorMessage = "{0}, '{1}' 必須在 {2:d} 和 {3:d}之間.";
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }
        public DateRangeAttribute(string minDate, string maxDate)
            : base(DefaultErrorMessage)
        {
            MinDate = ParseDate(minDate);
            MaxDate = ParseDate(maxDate);
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
        private static DateTime ParseDate(string dateValue)
        {
            return DateTime.ParseExact(dateValue, DateFormat,
                CultureInfo.InvariantCulture);
        }
    }
}
