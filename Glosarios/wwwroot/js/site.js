function Glosario(action) {
    var strText = document.getElementById("texto").value;
    var strLanguage = "Espanol";
    $.ajax({
        type: "POST",
        url: action,
        data: {
            strText, strLanguage
        },
        success: function (response) {
            if (response != "") {
                document.getElementById("textoSalida").value = response;
                
            }
            else {
                $('#textoSalida').value = "Error";
            }
        }
    });

}
