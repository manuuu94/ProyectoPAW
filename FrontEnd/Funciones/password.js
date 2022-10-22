function validarPass() {
var password = document.getElementById('password').value;


if (password == "") {
    MostrarAlerta('La contraseña no puede estar vacia');
    return false;
}
else {
    return true;
}
}; 