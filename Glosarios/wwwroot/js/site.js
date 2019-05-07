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
var CNombre;
var CApellidoPat;
var CApellidoMat;
var CNickname;
var CPassword;
var CCorreo;
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
            }
            else {
                alert("No se puede iniciar sesion verifique sus datos");
            }
        }
    });
}
