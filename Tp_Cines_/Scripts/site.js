//jQuery(function ($) {
//    $.validator.addMethod('date',
////    function (value, element) {
////        if (this.optional(element)) {
////            return true;
////        }

////        var ok = true;
////        try {
////            $.datepicker.parseDate('dd/mm/yyyy', value);
////        }
////        catch (err) {
////            ok = false;
////        }
////        return ok;
////    });
////});

//$.validator.methods.date = function (value, element) {
//    return this.optional(element) || parseDate(value, "yyyy-MM-dd") !== null;
//}
    $(function() {
        $('#FechaInicioDatePicker')
            .datetimepicker({
                locale: 'es',
                format: 'DD/MM/YYYY'
            });
        $('#FechaFinDatePicker')
            .datetimepicker({
                locale: 'es',
                useCurrent: false,
                format: 'DD/MM/YYYY'
            });
        $("#FechaInicioDatePicker").on("dp.change", function (e) {
            $('#FechaFinDatePicker').data("DateTimePicker").minDate(e.date);
        });
        $("#FechaFinDatePicker").on("dp.change", function (e) {
            $('#FechaInicioDatePicker').data("DateTimePicker").maxDate(e.date);
        });
    });
