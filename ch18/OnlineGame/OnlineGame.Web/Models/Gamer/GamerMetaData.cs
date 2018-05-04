using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using OnlineGame.Web.WebShare;
using OnlineGame.Web.WebShare.Attribute;
namespace OnlineGame.Web.Models
{
    public class GamerMetaData
    {
        //private static readonly string DateFormat = System.Configuration.ConfigurationManager.AppSettings["DateStringFormat"];   
        ////It will not work.
        ////DisplayFormat attribute DataFormatString property only take "DateStringFormat" constant string.

        [StringLength(20, MinimumLength = 2)]
        //[RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")] //First Name Last Name
        //[RegularExpression(WebShareConst.FirstNameLastNameRegularExpression)] //First Name Last Name
        //[RegularExpression(WebShareConst.FirstNameLastNameRegularExpression, ErrorMessage = "Please enter first name or first name and last name.")] //First Name Last Name
        [RegularExpression(WebShareConst.FirstNameLastNameRegularExpression, ErrorMessage = WebShareConst.FirstNameLastNameNotValid)] //First Name Last Name


        [Required]
        public string Name { get; set; }
        //[Remote("IsEmailAvailable", "Gamer", ErrorMessage = "The email has already been taken.")]
        //[Remote("IsEmailAvailable", "Gamer", ErrorMessage = WebShareConst.EmailHasBeenTaken)]
        //[RemoteClientServer("IsEmailAvailable", "Gamer", ErrorMessage = WebShareConst.EmailHasBeenTaken)]
        ////Remote attribute can only do the client side validation.
        ////RemoteClientServer is a customize attribute which can do both client side and server side validation.
        ////Don't add Remote attribute in shared model, it will affect both Edit and Create mode.
        ////If you really want to use it, please use two different model classes for Edit and Create mode.
        //[RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Email is not valid")]  //EmailAddress Regular Expression
        //[RegularExpression(WebShareConst.EmailRegularExpression, ErrorMessage = "Email is not valid")]  //EmailAddress Regular Expression
        [RegularExpression(WebShareConst.EmailRegularExpression, ErrorMessage = WebShareConst.EmailNotValid)]  //EmailAddress Regular Expression
        [Required]
        public string EmailAddress { get; set; }

        [Range(1, 1000000)]
        [Required]
        public int GameMoney { get; set; }

        //[Range(typeof(DateTime), "1/1/1970", "1/1/2001", ErrorMessage = "Date is out of Range 超過範圍")]    //Error - Client Side validation will never pass
        //[Range(typeof(DateTime), "1/1/1970", "1/1/2001")] //Error - Client Side validation will never pass
        //[DateRange("01/01/1970", "01/01/2001")]
        //[DateRange("01/01/1970", DateTime.Now.ToShortDateString())] //Error :  An attribute argument must be a constant expression
        //[BetweenMinimumDateAndToday("01/01/1970")]
        [BeforeToday]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayFormat(DataFormatString = WebShareConst.DateStringFormat, ApplyFormatInEditMode = true)]
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
/*
1.
//[StringLength(20, MinimumLength = 2)]
attribute check if the input string has certain length.
If you leave the input textbox as blank, then it does not care.
Thus we need [Required] attribute to ensure the field always has value.
---------------------------------------------
2.
//[Range(1, 1000000)]
//public int GameMoney { get; set; }
The field must be between 1 to 1000000.
---------------------------------------------
3.
//[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
//public DateTime DateOfBirth { get; set; }
We discuss this at T009 and T010 already.
3.1.
DisplayFormat attribute
3.1.1.
//[DisplayFormat(DataFormatString = "{0:d}")]
Display only the date part. E.g. 29/04/1986
3.1.2.
//[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
Display in 24 hour notation. E.g. 29/04/1986 13:00:00
3.1.3.
//[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
Display in 12 hour notation. E.g. 29/04/1986 1:00:00 PM
3.2.
DisplayFormatAttribute attribute
//[DisplayFormatAttribute(DataFormatString="{0:d}")]
Display only the date part. E.g. 29/04/1986
---------------------------------------------
4.
////[Range(typeof(DateTime), "1/1/1970", "1/1/2001", ErrorMessage = "Date is out of Range")]    //Error - Client Side validation will never pass
////[Range(typeof(DateTime), "1/1/1970", "1/1/2001")] //Error - Client Side validation will never pass
////[DateRange("01/01/1970", "01/01/2001")]
////[DateRange("01/01/1970", DateTime.Now.ToShortDateString())] //Error :  An attribute argument must be a constant expression
////[BetweenMinimumDateAndToday("01/01/1970")]
//[BeforeToday]
//[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
//public DateTime DateOfBirth { get; set; }
Validating a datetime range in EF annotation
We can’t pass a DateTime in as attribute arguments must be const.
We have to build our own Customize Validation Attribute
Reference:
https://blogs.msdn.microsoft.com/stuartleeks/2011/01/25/asp-net-mvc-3-integrating-with-the-jquery-ui-date-picker-and-adding-a-jquery-validate-date-range-validator/
https://forums.asp.net/t/1831436.aspx?Validating+a+datetime+range+in+EF+annotation
https://stackoverflow.com/questions/13183647/date-range-validation-with-entity-framework-4-data-annotations
4.1.
[DateRange], [BetweenMinimumDateAndToday], [BeforeToday] are Customize Validation Attributes
Please have a look.
---------------------------------------------
5.
RegularExpression
//[RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$")] //First Name Last Name
//public string Name { get; set; }
//[RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Please enter a valid email address")]  //EmailAddress Regular Expression
//public string EmailAddress { get; set; }
Reference:
https://regexr.com/
https://docs.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-language-quick-reference
---------------------------------------------
6.
//[Remote("IsEmailAvailable", "Gamer", ErrorMessage = "The email has already been taken.")]
//[Remote("IsEmailAvailable", "Gamer", ErrorMessage = WebShareConst.EmailHasBeenTaken)]
//[RemoteClientServer("IsEmailAvailable", "Gamer", ErrorMessage = WebShareConst.EmailHasBeenTaken)]
//// Don't add Remote attribute in shared model, it will affect both Edit and Create mode.
//// You may use two different model class for create and edit mode.
//public string EmailAddress { get; set; }
6.1.
Remote attribute can only do the client side validation.
RemoteClientServer is a customize attribute which can do both client side and server side validation.
Don't add Remote attribute in shared model, it will affect both Edit and Create mode.
If you really want to use it, please use two different model classes for Edit and Create mode.
6.2.
RemoteAttribute uses AJAX to make an asynchronous call to the server-side method.
If the user disables javascript function of the browser, then it will not work.
Thus, we should also have server-side validation.
6.3.
server-side validation.
In the Create HttpPost Method.
It is hard to read that validation logic is in the controller.
Using validation attributes is always the preferred method.
You may use two different model class for create and edit mode.
//[HttpPost]
//[ValidateAntiForgeryToken]
//public async Task<ActionResult> Create([Bind(Include = "Id,Name,Gender,City,DateOfBirth,EmailAddress,ConfirmEmailAddress,Score,ProfileUrl,GameMoney,RolePhoto,RolePhotoAltText,TeamId")] Gamer gamer)
//{
//    //If the Email already exists, then add Model validation error
//    if (db.Gamers.Any(g => g.EmailAddress == gamer.EmailAddress))
//    {
//        //AddModelError(Key, ErrorMessage)
//        ModelState.AddModelError("EmailAddress", WebShareConst.EmailHasBeenTaken);
//    }
//    //It is hard to read that validation logic is in controller.
//    //Using validation attributes is always preferred method.
//    if (!ModelState.IsValid)
//    {
//        ViewBag.TeamId = new SelectList(db.Teams, "Id", "Name", gamer.TeamId);
//        return View(gamer);
//    }
//    db.Gamers.Add(gamer);
//    await db.SaveChangesAsync();
//    return RedirectToAction("Index");
//}
6.4.
Another way to has both server side and client side validation,
you have to create your own RemoteClientServerAttribute which extend RemoteAttribute.
*/
