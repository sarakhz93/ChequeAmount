
// Materilize Initialization ------------------------------------------
$(document).ready(function () {
    $('select').formSelect();
});

$(document).ready(function () {
    $('.sidenav').sidenav();
});

// AJAX Initialization ------------------------------------------
function getJson(url, data, sucessCallback, errorCallBack) {
    $.ajax({
        url: url,
        type: "post",
        datatype: "json",
        data: data,
        success: sucessCallback,
        error: function () {
            console.log("error in server.");
            if (errorCallBack !== undefined)
                errorCallBack();
        }
    });
}


// -------------------------------------Site Javascripts ------------------------------------------
//-----------------------------------------------------------------------------------------------

$(document).ready(function () {
    
    $("#card_result").hide();
    $("#btn_convert").click(function () {
        $("#card_result").slideUp();
        if ($("#txt_chequeAmountNumber").val() != "") {
            $("#txt_errorList").slideUp();       
            getJson("/Home/ConvertNumberToWords", {
                givenNumber: $("#txt_chequeAmountNumber").val(),
                textStyle: $("#slct_textFormat").val()
            },
                function (ht) {
                    if (ht.errorNumber == 0) {
                        $("#txt_result").text(ht.result);
                        $("#card_result").slideDown();
                    }
                    else {
                        $("#txt_errorList").slideDown();
                    }
                })
        }
        else {
            $("#txt_errorList").slideDown();
        }
    });
});


$(".allownumericwithdecimal").on("keypress keyup blur", function (event) {
    $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
    if ((event.which != 46 || $(this).val().indexOf('.') != -1) && (event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});

$(".allownumericwithoutdecimal").on("keypress keyup blur", function (event) {
    $(this).val($(this).val().replace(/[^\d].+/, ""));
    if ((event.which < 48 || event.which > 57)) {
        event.preventDefault();
    }
});



