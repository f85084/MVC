namespace OnlineGame.Web.WebShare
{
    public class WebShareConst
    {
        public const string DateFormat = "dd/MM/yyyy";
        public const string DateFormatJavascriptString = "dd/mm/yy";
        public const string DateStringFormat = "{0:dd/MM/yyyy}";

        //RegularExpression
        //https://regexr.com/
        public const string FirstNameLastNameRegularExpression = @"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$"  ;
        public const string EmailRegularExpression = @"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$";

        //Validation String
        public const string EmailNotValid = "Email is not valid";
        public const string FirstNameLastNameNotValid = "Please enter first name or first name and last name.請輸入性名";
        public const string EmailHasBeenTaken = "email 已經註冊.";
        public const string ValidationSummaryTitleString = "Please check the following fields.";
    }
}