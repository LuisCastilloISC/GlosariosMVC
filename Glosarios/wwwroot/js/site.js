function Glosario(action) {
    var strText = document.getElementById("texto").value;
    var strLanguage = "Español";
    var strConcepto = document.getElementById("Concepto").value;
        
    $.ajax({
        type: "POST",
        url: action,
        data: {
            strText, strLanguage, strConcepto
        },
        success: function (response) {
            if (response != "") {
                if (document.getElementById("textoSalida").value != "") {

                    document.getElementById("textoSalida").value = document.getElementById("textoSalida").value+".\n" + response;
                }
                else {
                    document.getElementById("textoSalida").value = response;
                }
                
            }
            else {
                $('#textoSalida').value = "Error";
            }
        }
    });

}
var CNombre;
var CApellidoPat;
var CApellidoMat;
var CNickname;
var CPassword;
var CCorreo;
var NicknameLogueado;
function CrearUsuario(action) {
    CCorreo = document.getElementById("CCorreo").value;
    CNombre = document.getElementById("CNombre").value;
    CApellidoPat = document.getElementById("CApellidoPat").value;
    CApellidoMat = document.getElementById("CApellidoMat").value;
    CNickname = document.getElementById("CNickname").value;
    CPassword = document.getElementById("CPassword").value;
    $.ajax({
        type: "POST",
        url: action,
        data: {
            CCorreo, CNombre, CApellidoPat, CApellidoMat, CNickname, CPassword
        },
        success: function (response) {
            if (response === "Save") {
                window.location.href = "Usuarios";
            }
            else {
                alert("No se puede agregar el usuario");
            }
        }
    });
}
function Loguear(action) {
    CCorreo = document.getElementById("LCorreo").value;
    CPassword = document.getElementById("LPassword").value;
    $.ajax({
        type: "POST",
        url: action,
        data: {
            CCorreo,CPassword
        },
        success: function (response) {
            if (response != "") {
                window.open("Resumenes");
                NicknameLogueado = response;
            }
            else {
                alert("No se puede iniciar sesion verifique sus datos");
            }
        }
    });
}
var strTopic = "";
var strLanguage = "";
function PDF(action) {
    strTopic = document.getElementById("RNombre").value;
    strLanguage = "Español";
    var strText = document.getElementById("textoSalida").value;
    if (strTopic == "") {
        alert("El glosario debe tener un nombre");
        return;
    }
    if (strText == "") {
        alert("Genere el resumen primero");
        return;
    }
    $.ajax({
        type: "POST",
        url: action,
        data: {
            strTopic,
            strLanguage,
            strText
        },
        success: function () {
            if (true) {

            }
        }

    });
}

