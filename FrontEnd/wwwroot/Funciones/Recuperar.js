
$(document).ready(function () {
    let msj = $("#IdMsjUser").val();

    if (msj != "") {
        if (msj != "Usuario no existe") {
            MostrarAlerta(msj, 'success', 'Exitoso');
        } else {
            MostrarAlerta(msj, 'error', 'Error');
        }
    }

});

//$(document).ready(function () {

//    let msj = $("#IdMsjUser").val();

//    if (msj = "El correo fue enviado, revise y vuelva a intentar") {
//        MostrarAlertaExitosa(msj, 'success');
//    }
//    else { 
//        msj = "Usuario no existe";
//        MostrarAlertaFallida(msj, 'error');
//    }
     

//});



//function test() {
//    let msj = $("#IdMsjUser").val();

//    if (msj = "El correo fue enviado, revise y vuelva a intentar") {
//        MostrarAlertaExitosa(msj, 'success');
//    }
//    else {
//        msj = "Usuario no existe";
//        MostrarAlertaFallida(msj, 'error');
//    }
//}

