$(document).ready(function () {
    var max_fields = 10; //maximum input boxes allowed
    var wrapper = $(".input_fields_wrap"); //Fields wrapper
    var add_button = $(".add_field_button"); //Add button ID

    var x = 1; //initlal text box count
    $(add_button).click(function (e) { //on add input button click
        e.preventDefault();
        if (x < max_fields) { //max input box allowed
            x++; //text box increment
            $(wrapper).append('<div><input type="text" name="question' + x + '"/><label style="display:inline-block;"><input type="checkbox" name="answer' + x + '" />Correct? </label><a href="#" class="remove_field">Remove</a></div>'); //add input box
        }
    });

    $(wrapper).on("click", ".remove_field", function (e) { //user click on remove text
        e.preventDefault(); $(this).parent('div').remove(); x--;
    });

    $('select#domeniu').on('change', function () {
        if ($(this).val() == "new") {
            $('#domeniu_block').show();
        } else if ($(this).val() != '-') {      //a fost ales un domeniu
            idDomeniu = $(this).val();
            $.ajax({
                type: "POST",
                url: "/Insert/getSubdomenii",
                data: { id: idDomeniu },
                success: function (response) {
                    response = JSON.parse(response);
                    $.each(response, function (key, value) {
                        if (key != "0")
                            $('select#subdomeniu').append('<option value="' + key + '" >' + value + '</option>');
                    });
                },
                failure: function (response) {
                    alert(response);
                }
            });
        }
    });

    $('#submit_domeniu').on('click', function (e) {
        //ajax
        e.preventDefault();
        var domeniu = $('#new_domeniu').val();
        if (domeniu) {
            $.ajax({
                type: "POST",
                url: "/Insert/AddDomain",
                data: {domain: domeniu },
                success: function (response) {
                    console.log(response);
                    $('select#domeniu option').removeAttr('checked');
                    $('select#domeniu').append('<option value="' + response + '" selected="selected">' + domeniu + '</option>');
                    $('#domeniu_block').hide();
                },
                failure: function (response) {
                    alert(response);
                }
            });
        }
    });

    $('select#subdomeniu').on('change', function () {
        if ($(this).val() == "new") {
            $('#subdomeniu_block').show();
        } 
    });

    $('#submit_subdomeniu').on('click', function (e) {
        //ajax
        e.preventDefault();
        var idDomeniu = $('select#domeniu').val();
        var subdomeniu = $('#new_subdomeniu').val();
        if (subdomeniu) {
            $.ajax({
                type: "POST",
                url: "/Insert/AddSubDomain",
                data: {id: idDomeniu , subdomain: subdomeniu},
                success: function (response) {
                    console.log(response);
                    $('select#domeniu option').removeAttr('checked');
                    $('select#subdomeniu').append('<option value="' + response + '" selected="selected">' + subdomeniu + '</option>');
                    $('#subdomeniu_block').hide();
                },
                failure: function (response) {
                    alert(response);
                }
            });
        }
    });


});