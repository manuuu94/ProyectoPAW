$(document).ready(function () {
    $('#tbInventario').DataTable(
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


$(document).ready(function () {
    $('#tbEmpleados').DataTable(
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


$(document).ready(function () {
    $('#tbRegistroCompras').DataTable(
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


$(document).ready(function () {
    $('#tbRegistroClienteAtendidos').DataTable(
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


$(document).ready(function () {
    $('#tbRegistroInventario').DataTable(
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

