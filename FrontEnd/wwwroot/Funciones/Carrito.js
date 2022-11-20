$(document).ready(function () {
    $('#tbCarro').DataTable(
        {
            "bFilter": true,
            "bInfo": true,
            "bLengthChange": true,
            dom: 'Bfrtip',
            buttons: [
                'copy', 'excel', 'pdf'
            ]
        }
    );
});


function validar() {
    var test = document.getElementById("id_prod");
    if (test == null) {
        MostrarAlerta("CARRITO VACIO", 'error');
        return false;
    }
    return true;
};