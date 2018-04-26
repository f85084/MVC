using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace OnlineGame.Web.Models
{
    public class GamerMetaData
    {
        //[HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        //1.
        ////[DisplayAttribute(Name="Full Name")]
        ////[Display(Name = "Full Name")]
        ////[DisplayName("Full Name")]
        //Display Name as "Full Name"
        [DisplayName("Full Name")]
        public string Name { get; set; }
        //2.
        //If gender is NULL, then display "Gender not specified".
        [DisplayFormat(NullDisplayText = "Gender not specified")]
        public string Gender { get; set; }
        public string City { get; set; }
        //3.
        //DateTime
        //3.1.
        ////[DisplayFormat(DataFormatString = ".....")]
        //3.1.1.
        //////[DisplayFormat(DataFormatString = "{0:d}")]
        ////[DisplayFormatAttribute(DataFormatString="{0:d}")]
        ////public Nullable<System.DateTime> DateOfBirth { get; set; }
        //Display only the date part. E.g. 29/04/1986
        //3.1.2.
        ////[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        ////public Nullable<System.DateTime> DateOfBirth { get; set; }
        //Display in 24 hour notation. E.g. 29/04/1986 13:00:00
        //3.1.3.
        ////[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        ////public Nullable<System.DateTime> DateOfBirth { get; set; }
        //Display in 12 hour notation. E.g. 29/04/1986 1:00:00 PM
        //3.2.
        ////[DataType(DataType....)] 
        //3.2.1.
        ////[DataType(DataType.Date)] 
        ////public Nullable<System.DateTime> DateOfBirth { get; set; }
        //Display only date part
        //Please be aware, it actually covert DateTime to Date.
        //so Views/Shared/EditorTemplates/DateTime.cshtml will not Work.
        //3.2.2.
        ////[DataType(DataType.Time)] 
        ////public Nullable<System.DateTime> DateOfBirth { get; set; }
        //Display only 12 hour notation Time part
        //Please be aware, it actually covert DateTime to Date.
        //so Views/Shared/EditorTemplates/DateTime.cshtml will not Work.
        //[DataType(DataType.Date)] //Views/Shared/EditorTemplates/DateTime.cshtml will not Work.
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] //ApplyFormatInEditMode
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        //5.
        // Display mailto hyperlink
        [DataType(DataType.EmailAddress)]
        //[ReadOnly(true)]
        public string EmailAddress { get; set; }
        //4.
        ////[ScaffoldColumn(false)]
        //[ScaffoldColumn(false)] attribute means it will not display the column
        //when using @Html.DisplayForModel() helper.
        [ScaffoldColumn(false)]
        public Nullable<int> Score { get; set; }
        //8.
        //8.1.
        //In the Models/Gamer/GamerMetaData.cs
        ////[DataType(DataType.Url)]
        ////[UIHint("UrlToNewWindow")]
        ////public string ProfileUrl { get; set; }
        //[DataType(DataType.Url)] attribute will display a hyperlink.
        //[UIHint("UrlToNewWindow")] attribute specify the name of view DisplayTemplate
        //to display the property data.
        //In this case, it will look for "DisplayTemplates/UrlToNewWindow.cshtml"
        //under "Shared" folder or "Gamer" folder.
        //Use that view template to disply the data of this property.
        //8.2.
        ////<a href="@ViewData.Model" target="_blank">@ViewData.Model</a>
        //In the Shared/DisplayTemplates/UrlToNewWindow.cshtml,
        //@ViewData.Model will take the Model data from the parent view.
        //In this case, it will return a profile url.
        [DataType(DataType.Url)]
        [UIHint("UrlToNewWindow")]
        public string ProfileUrl { get; set; }
        //7.
        ////[DataType(DataType.Currency)]
        ////public Nullable<int> GameMoney { get; set; }
        //Display the currency symbol by globalization culture in web.config file.
        //7.1.
        //In System.Web tag of web.config file,
        //7.1.1.
        //<system.web> <globalization culture = "en-au" /> ...
        //Display au $ symbol.
        //7.1.2.
        //<system.web> <globalization culture = "en-uk" /> ...
        //Display UK pound symbol.
        [DataType(DataType.Currency)]
        public Nullable<int> GameMoney { get; set; }
        public Nullable<int> TeamId { get; set; }
    }
}
/*
------------------------------
1.
////[DisplayAttribute(Name="Full Name")]
////[Display(Name = "Full Name")]
//[DisplayName("Full Name")]
//public string Name { get; set; }
Display Name as "Full Name"
------------------------------
2.
//[DisplayFormat(NullDisplayText = "Gender not specified")]
//public string Gender { get; set; }
If gender is NULL, then display "Gender not specified".
------------------------------
3.
DateTime
--------------
3.1.
//[DisplayFormat(DataFormatString = ".....")]
3.1.1.
////[DisplayFormat(DataFormatString = "{0:d}")]
//[DisplayFormatAttribute(DataFormatString="{0:d}")]
//public Nullable<System.DateTime> DateOfBirth { get; set; }
Display only the date part. E.g. 29/04/1986
3.1.2.
//[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
//public Nullable<System.DateTime> DateOfBirth { get; set; }
Display in 24 hour notation. E.g. 29/04/1986 13:00:00
3.1.3.
//[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss tt}")]
//public Nullable<System.DateTime> DateOfBirth { get; set; }
Display in 12 hour notation. E.g. 29/04/1986 1:00:00 PM
--------------
3.2.
//[DataType(DataType....)] 
3.2.1.
//[DataType(DataType.Date)] 
//public Nullable<System.DateTime> DateOfBirth { get; set; }
Display only date part
Please be aware, it actually covert DateTime to Date.
So Views/Shared/EditorTemplates/DateTime.cshtml will not Work.
3.2.2.
//[DataType(DataType.Time)] 
//public Nullable<System.DateTime> DateOfBirth { get; set; }
Display only 12 hour notation Time part
Please be aware, it actually covert DateTime to Date.
So Views/Shared/EditorTemplates/DateTime.cshtml will not Work.
------------------------------
4.
//[ScaffoldColumn(false)]
public Nullable<int> Score { get; set; }
[ScaffoldColumn(false)] attribute means it will not display the column
when using @Html.DisplayForModel() helper
------------------------------
5.
//[DataType(DataType.EmailAddress)]
//public string EmailAddress { get; set; }
Display mailto hyperlink
------------------------------
6.
//[DataType(DataType.Url)]
//public string ProfileUrl { get; set; }
Display hyperlink
------------------------------
7.
//[DataType(DataType.Currency)]
//public Nullable<int> GameMoney { get; set; }
Display the currency symbol by globalization culture in web.config file.
7.1.
In System.Web tag of web.config file,
7.1.1.
<system.web> <globalization culture="en-au"/> ...
Display au $ symbol.
7.1.2.
<system.web> <globalization culture="en-uk"/> ...
Display UK pound symbol.
------------------------------
8.
8.1.
In the Models/Gamer/GamerMetaData.cs
//[DataType(DataType.Url)]
//[UIHint("UrlToNewWindow")]
//public string ProfileUrl { get; set; }
[DataType(DataType.Url)] attribute will display a hyperlink.
[UIHint("UrlToNewWindow")] attribute specify the name of view DisplayTemplate
to display the property data.
In this case, it will look for "DisplayTemplates/UrlToNewWindow.cshtml"
under "Shared" folder or "Gamer" folder.
Use that view template to disply the data of this property.
8.2.
//<a href="@ViewData.Model" target="_blank">@ViewData.Model</a>
In the Shared/DisplayTemplates/UrlToNewWindow.cshtml,
@ViewData.Model will take the Model data from the parent view.
In this case, it will return a profile url.
------------------------------
9.
//[HiddenInput(DisplayValue = false)]
//public int Id { get; set; }
[HiddenInput(DisplayValue = false)] attribute
means it will become a hidden input
When using @Html.DisplayForModel() helper or @Html.EditorForModel()
------------------------------
10.
//[DataType(DataType.EmailAddress)]
//[ReadOnly(true)]
//public string EmailAddress { get; set; }
[DataType(DataType.EmailAddress)] attribute display mailto hyperlink.
[ReadOnly(true)] or you may delete Setter.
It will make this property un-editable.
You may set a breakpoint to see the [HttpPost] action model for this property is null.
*/

