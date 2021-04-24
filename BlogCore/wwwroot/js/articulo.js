var dataTable;

$(document).ready(function () {
    cargarDatatable();
});

function cargarDatatable() {
    dataTable = $("#tblArticulos").DataTable({
        "ajax": {
            "url": "/admin/articulos/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            {
                "data": "urlImagen",
                "render": function (imagen) {
                    return `<div class="img-fluid " width="100%" style="height:100%" >
                                <img class="" src="../${imagen}" width="100%" style="height:100%" >
                            </div>`
                }, "width": "8%"
            },
            { "data": "id", "width": "5%" },
            { "data": "nombre", "width": "20%" },
            {
                "data": "precio", "render": function (data) {
                    return "RD$" + data
                },"width": "5%"
            },

            
            { "data": "sexo", "width": "5%" },
            { "data": "categoria.nombre", "width": "10%" },
            { "data": "fechaCreacion", "width": "10%" },

            {
                "data": "id",
                "render": function (data) {

                    return `<div class=" d-flex align-items-start flex-column bd-highlight">

                                <div class=" p-2 bd-highlight" style='width:100%;'>
                                    <a href='/Admin/Articulos/Edit/${data}' class='btn btn-warning text-white' style='cursor:pointer; width:100%;'>
                                    <i class='fas fa-edit fa-lg'></i>
                                </a>
                                </div>

                                <div class=" p-2 bd-highlight" style='width:100%;'>
                                    <a onclick=Delete("/Admin/Articulos/Delete/${data}") class='btn btn-danger text-white' style='cursor:pointer; width:100%;'>
                                    <i class='far fa-trash-alt fa-lg'></i>
                                </a>
                                </div>


                                <div class=" p-2 bd-highlight" style='width:100%;'>
                                <a type="button"  data-toggle="modal" data-target="#myModal" class='btn btn-success text-white' style='cursor:pointer; width:100%;'>
                                    <i class="fas fa-cash-register fa-lg"></i>
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

