function Glosario(action) {
    var strText = $('input[name=texto]').val();
    var strLanguage = "Español";
    $.ajax({
        type: "POST",
        url: action,
        data{
            strText, strLanguage
        },
        success: function (response) {
            if (response != "") {
                $('#textoSalida').value = response;
            }
            else {
                $('#textoSalida').value = "Error";
            }
        }
    });

}