
function questionSubmit(item, questionId) {
    
    var formId = "#question_" + questionId;
   
    var i=1;
    $.ajax({
        url: '/Quiz/Submit',
        type: 'POST',
        data: $(formId).serialize(),
        success: function (result) {
            if (result) {
                $(formId).hide()
            }
            
            $(formId).find('input').each(function () {
                if ($(this).is(":checked")) {
                    val = $(this).val();
                    text = $("#ans_" + val).text();
                    console.log("#a_" + questionId + "+_" + i)
                    $("#"+ i +"_" + questionId).show().text(text);
                    i++;
                    if (result == 10) {
                        document.location.href = "/Quiz/Results?id="+test;
                    }
                    
                    
                }
            });
        }
    });
}