var dataTable;
var day = new Date()
var dayWrapper = moment(day);
var dayString = dayWrapper.format("yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss.fffffffK");

$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#tblUsuarios").DataTable({
        "ajax": {
            "url": "/admin/usuarios/GetAll",
            "type": "GET",
            "datatype": "json",
        },
        "columns": [
            { "data": "nombre", "width": "30%" },
            { "data": "email", "width": "30%"},
            { "data": "phoneNumber", "width": "35%" },
            {
                "data": "lockoutEnd",
                "render": function (data, type, row) {
                    if (data === null || data < dayString) {
                        return `<div class="text-center">
                                    <a onclick=Danger("/Admin/Usuarios/Bloquear/${row.id}") class='btn btn-success'  style='cursor:pointer; width:100px;'>
                                        <i class='fas fa-lock-open fa-lg'></i>
                                    </a>
                                </div>
                                `;
                    }
                    else {
                        return `<div class="text-center">
                                    <a onclick=Success("/Admin/Usuarios/Desbloquear/${row.id}") class='btn btn-danger' style='cursor:pointer; width:100px;'>
                                        <i class='fas fa-lock fa-lg'></i>
                                    </a>
                                </div>
                            
                                `;
                    }
                    

                }, "width": "5%"
                
            },  
            
        ],
        "language": {
            "decimal": "",
            "emptyTable": "No hay registros",
            "info": "Mostrando _START_ a _END_ de _TOTAL_ Entradas",
            "infoEmpty": "Mostrando 0 a 0 de 0 Entradas",
            "infoFiltered": "(Filtrado de _MAX_ total entradas)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Mostrar _MENU_ Entradas",
            "loadingRecords": "Cargando...",
            "processing": "Procesando...",
            "search": "Buscar:",
            "zeroRecords": "Sin resultados encontrados",
            "paginate": {
                "first": "Primero",
                "last": "Ultimo",
                "next": "Siguiente",
                "previous": "Anterior"
            }
        },
        "width": "100%"
    });
}

//Alerta cuando se Desbloquea
function Success(url) {
    $.ajax({
        type: 'SUCCESS',
        url: url,
        success: function (data) {
            if (data.success) {
                toastr.success(data.message);
                dataTable.ajax.reload();
            }                                                                                                                                                                         
            else {
                toastr.error(data.message);
            }
        }
    });
     
}

//Alerta cuando se Bloquea
function Danger(url) {
    $.ajax({
        type: 'DANGER',
        url: url,
        success: function (data) {
            if (data.success) {
                toastr.error(data.message);
                dataTable.ajax.reload();
            }
            else {
                toastr.error(data.message);
            }
        }
    });

}

//Swettalert y toastr de BORRAR
function Delete(url) {
    swal({
        title: "¿Está seguro de borrar?" ,
        text: "¡Este contenido no se puede recuperar!",
        warningMode: true,
        closeOnconfirm: true,
        buttons: true,
        icon: "warning",
    }).then(
        function (isConfirm) {
            if (isConfirm) {
                $.ajax({
                    type: 'DELETE',
                    url: url,
                    success: function (data) {
                        if (data.success) {
                            toastr.success(data.message);
                            dataTable.ajax.reload();
                        }
                        else {
                            toastr.error(data.message);
                        }
                    }
                });
            }
        }
    );
}

