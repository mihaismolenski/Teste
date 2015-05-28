
function questionSubmit(item, questionId) {
    
    var formId = "#question_" + questionId;
    console.log($(formId).serialize());
    console.log(formId);
    $.ajax({
        url: '/Quiz/Submit',
        type: 'POST',
        data: $(formId).serialize(),
        success: function (result) {
            alert(result);
        }
    });
}