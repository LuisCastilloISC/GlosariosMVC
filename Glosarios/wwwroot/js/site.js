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
function GlosarioImagen(action) {
    var strText = document.getElementById("textoImagen").value;
    var strLanguage = "Espanol";
    $.ajax({
        type: "POST",
        url: action,
        data: {
            strText, strLanguage
        },
        success: function (response) {
            if (response != "") {
                document.getElementById("textoSalidaImagen").value = response;

            }
            else {
                $('#textoSalida').value = "Error";
            }
        }
    });

}
function Reconocer(action) {
    CargarImagen("Usuarios/SubirImagen");
    $.ajax({
        type: "POST",
        url: action,
        data: {},
        success: function (response) {
            if (response != "") {
                document.getElementById("textoImagen").value = response;

            }
            else {
                $('#textoImagen').value = "Error";
            }
        }
    });

}
function openCity(evt, cityName) {
    // Declare all variables
    var i, tabcontent, tablinks;

    // Get all elements with class="tabcontent" and hide them
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    // Get all elements with class="tablinks" and remove the class "active"
    tablinks = document.getElementsByClassName("tablinks");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    // Show the current tab, and add an "active" class to the button that opened the tab
    document.getElementById(cityName).style.display = "block";
    evt.currentTarget.className += " active";
}

function CargarImagen(action) {
    var file = document.getElementById('file1').value;
    $.ajax({
        type: "POST",
        url: action,
        data: { file },
        success: function (response) {
                
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('error');
        }
    });
}
