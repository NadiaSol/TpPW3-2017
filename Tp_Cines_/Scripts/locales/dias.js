    jQuery(function ($) {
        $("#datepicker").datepicker({ showOn: 'button',
            buttonImage: '/img/datapicker.png',
            //buttonImageOnly: true,
            beforeShowDay: function(date){ return [date.getDay() == 1 || date.getDay() == 2 || date.getDay() == 4 || date.getDay() == 5,""]} });
        });