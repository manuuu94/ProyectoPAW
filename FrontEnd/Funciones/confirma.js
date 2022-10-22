function validar() {
    var cedula = $('#CEDULA_CLIENTE').val();
    var contacto = $('#TELEFONO').val();
    var metodo = $('#ID_METODO').val();
    var empleado = $('#ID_EMPLEADO').val();

    if (cedula == "") {
        MostrarAlerta("Ingresar Cédula y Nombre completo", 'error');
        return false;
    }
    if (contacto == "") {
        MostrarAlerta("Ingresar un teléfono", 'error');
        return false;
    }
    if (metodo != 1 && metodo != 2) {
        MostrarAlerta("1=EFECTIVO ; 2=CRÉDITO", 'error');
        return false;
    }
    if (empleado == "") {
        MostrarAlerta("Ingresar ID de empleado", 'error');
        return false;
    }
    return true;
};






//function validar() {
//    var test = document.getElementById("id_prod");
//    if (test == null) {
//        MostrarAlerta("CARRITO VACIO", 'error');
//        return false;
//    }
//    return true;
//};


//function validar() {
//    var number = $('#ID_SERVICIO').val();

//    if (number == 1) {
//        return true;
//    }
//    if (number == 2) {
//        return true;
//    }
//    MostrarAlerta("1=LAVADO ; 2=TIENDA", 'error');
//    //alert("1=LAVADO ; 2=TIENDA");
//    return false;
//}
