var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#tblSliders").DataTable({
        "ajax": {
            "url": "/admin/sliders/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id", "width": "10%"},
            { "data": "nombre", "width": "20%"},
            { "data": "estado", "width": "10%"},
            {
                "data": "urlImagen",
                "render": function (imagen) {
                    return `<div class="img-fluid" width="100%">
                                <img src="../${imagen}" width="100%" >
                            </div>`
                }, "width": "30%"
            },
            {
                "data": "id",
                "render": function (data) {

                    return `<div class=" d-flex align-items-start flex-column bd-highlight mb-3">

                                <div class=" p-2 bd-highlight" style='width:100%;'>
                                    <a href='/Admin/Sliders/Edit/${data}' class=' btn btn-warning' style='cursor:pointer; width:100%;'>
                                        <i class='fas fa-edit fa-lg'></i>
                                    </a>
                                </div>

                                <div class=" p-2 bd-highlight" style='width:100%;'>
                                    <a onclick=Delete("/Admin/Sliders/Delete/${data}") class='btn btn-danger' style='cursor:pointer; width:100%;'>
                                        <i class='far fa-trash-alt fa-lg'></i>
                                    </a>
                                </div>

                                <div class=" p-2 bd-highlight" style='width:100%;'>                             
                                    <a onclick=Danger("#") class='btn btn-success'  style='cursor:pointer; width:100%;' >
                                        <i class='fas fa-lock-open fa-lg'></i>
                                    </a>
                                </div>

                            </div>
                            
                            `;


                }, "width":"5%"
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


function Delete(url) {
    swal({
        title: "¿Está seguro de borrar?",
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

