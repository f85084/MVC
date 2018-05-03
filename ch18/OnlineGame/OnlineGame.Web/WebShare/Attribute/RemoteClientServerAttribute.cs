using System;
using System.Linq;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace OnlineGame.Web.WebShare.Attribute
{
    public class RemoteClientServerAttribute : RemoteAttribute
    {
        //Implement IsValid() will get the server side validation.
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //1.
            //Using reflection to get the controller that is used by this attribute.
            //In all types of the Executing Assembly, I want the type
            //which the type name is equals to the controller name in route data.
            Type controller = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(type =>
                String.Equals(type.Name,
                $"{RouteData["controller"].ToString()}Controller",
                StringComparison.CurrentCultureIgnoreCase));
            if (controller != null)
            {
                //2.
                // Get the action method that is used by this attribute and has validation logic.
                MethodInfo action = controller.GetMethods()
                    .FirstOrDefault(method =>
                    String.Equals(method.Name,
                    RouteData["action"].ToString(),
                    StringComparison.CurrentCultureIgnoreCase));
                if (action != null)
                {
                    // Create an instance of the controller class
                    object instance = Activator.CreateInstance(controller);
                    // Invoke the action method that is used by this attribute and has validation logic.
                    // action.Invoke(object obj, object[] parameters)
                    //In our case, it will invoke "IsEmailAvailable" action of "GamerController".
                    object response = action.Invoke(instance, new[] { value });
                    //if (response is JsonResult), then get data.
                    //if (response is JsonResult)
                    //object jsonData = ((JsonResult)response).Data;
                    var result = response as JsonResult;
                    object jsonData = result?.Data;
                    //If the data is true, it means pass the validation.
                    //Otherwise return new ValidationResult(ErrorMessage);
                    if (jsonData is bool)
                    {
                        return (bool)jsonData ?
                            ValidationResult.Success :
                            new ValidationResult(ErrorMessage);
                    }
                }
            }
            //3.
            //3.1.
            //// return ValidationResult.Success;
            //If we don't find the controller which passed from the attribute,
            //or if we don't find the action that used by the attribute and has validation logic.
            //Then we return validation pass.
            //That means we ignore this validation attribute.
            //3.2.
            // If you want the validation to fail
            ////return new ValidationResult(base.ErrorMessageString);
            return ValidationResult.Success;
        }
        public RemoteClientServerAttribute(string routeName)
            : base(routeName)
        {
        }
        public RemoteClientServerAttribute(string action, string controller)
            : base(action, controller)
        {
        }
        public RemoteClientServerAttribute(string action, string controller,
            string areaName) : base(action, controller, areaName)
        {
        }
    }
}
/*
1.
//Type controller = Assembly.GetExecutingAssembly().GetTypes()
//    .FirstOrDefault(type =>
//    String.Equals(type.Name,
//    $"{RouteData["controller"].ToString()}Controller",
//    StringComparison.CurrentCultureIgnoreCase));
Using reflection to get controller that is used by this attribute.
In all types of the Executing Assembly, I want the type
which the type name is equals to the controller name in route data.
1.1.
//Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault
In all types of the Executing Assembly
1.2.
//$"{RouteData["controller"].ToString()}Controller"
{RouteData["controller"].ToString()} is the controller name in route data.
//$"{RouteData["controller"].ToString()}Controller"
{NameOfController}+"Controller".
2.
//MethodInfo action = controller.GetMethods()
//    .FirstOrDefault(method =>
//    String.Equals(method.Name,
//    RouteData["action"].ToString(),
//    StringComparison.CurrentCultureIgnoreCase));
2.1.
Get the action method that is used by this attribute and has validation logic.
2.2.
//RouteData["action"].ToString()
RouteData["action"].ToString() is the action name in route data.
The action method uses this attribute and has validation logic.
*/

