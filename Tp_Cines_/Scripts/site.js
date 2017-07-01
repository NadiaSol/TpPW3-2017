//jQuery(function ($) {
//    $.validator.addMethod('date',
//    function (value, element) {
//        if (this.optional(element)) {
//            return true;
//        }

//        var ok = true;
//        try {
//            $.datepicker.parseDate('dd/mm/yyyy', value);
//        }
//        catch (err) {
//            ok = false;
//        }
//        return ok;
//    });
//});

$.validator.methods.date = function (value, element) {
    return this.optional(element) || parseDate(value, "yyyy-MM-dd") !== null;
}