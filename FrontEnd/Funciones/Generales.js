
function MostrarAlerta(mensaje, tipo, title) {

    Swal.fire({
        type: tipo,
        title: title,
        text: mensaje,
    });
}


//function MostrarAlertaExitosa(mensaje, tipo) {

//    Swal.fire({
//        type: tipo,
//        title: 'Enviado',
//        text: mensaje,
//    });
//}



//function MostrarAlertaFallida(mensaje, tipo) {

//    Swal.fire({
//        type: tipo,
//        title: 'Error',
//        text: mensaje,
//    });
//}
