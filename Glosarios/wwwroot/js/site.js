﻿function Glosario(action) {
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
var CCPassword
var CCorreo;
var NicknameLogueado;
function CrearUsuario(action) {
    CCorreo = document.getElementById("CCorreo").value;
    CNombre = document.getElementById("CNombre").value;
    CApellidoPat = document.getElementById("CApellidoPat").value;
    CApellidoMat = document.getElementById("CApellidoMat").value;
    CNickname = document.getElementById("CNickname").value;
    CPassword = document.getElementById("CPassword").value;
    CCPassword = document.getElementById("CCPassword").value;
    if (CCPassword != CPassword) {
        alert("Las contraseñas no coinciden");
        return;
    }
    else {
        $.ajax({
            type: "POST",
            url: action,
            data: {
                CCorreo, CNombre, CApellidoPat, CApellidoMat, CNickname, CPassword
            },
            success: function (response) {

                if (response === "Correo") {
                    alert("Correo con cuenta registrada");
                    return;
                }
                if (response === "Nickname") {
                    alert("Nickname existente");
                    return;
                }
                if (response === "Save") {
                    window.location.href = "LogOn";
                }
                else {
                    alert("Se han detectado los siguientes errores\n" + response);
                    return;
                }
            }
        });
    }
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
                window.location.replace ("https://localhost:44381");
                NicknameLogueado = response;
            }
            else {
                alert("No se puede iniciar sesion verifique sus datos");
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
var strTopic = "";
var strLanguage = "";
function PDF(action) {
    strTopic = document.getElementById("RNombre").value;
    strLanguage = "Español";
    "file:///C:/Users/siul_/source/repos/Glosarios/Glosarios/"
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
                window.open("C:/Users/siul_/source/repos/Glosarios/Glosarios/" + strTopic+".pdf","_blank");              
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