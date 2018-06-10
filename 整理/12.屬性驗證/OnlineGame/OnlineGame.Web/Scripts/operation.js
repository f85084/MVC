//DateFormate : dd/mm/yyyy
//Reference:
//https://www.w3schools.com/jsref/jsref_obj_regexp.asp
//https://stackoverflow.com/questions/6906725/unobtrusive-validation-in-chrome-wont-validate-with-dd-mm-yyyy
jQuery.validator.methods.date = function (value, element) {
    var dateRegex = /^(0?[1-9]\/|[12]\d\/|3[01]\/){2}(19|20)\d\d$/;
    return this.optional(element) || dateRegex.test(value);
};
$(function () {
});