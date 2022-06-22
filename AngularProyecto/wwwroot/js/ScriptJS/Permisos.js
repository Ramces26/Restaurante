$("#btnagregar").click(function () {
    $.ajax({
        data: { opcion:1},
        url: "/Permisos/Create",
        type: "GET",
        success: function (d) {
            $('#ContenedorModal').html(d);
        }
    }).fail(function (jqXHR, textStatus, errorThrown) {
        //Swal.fire("ERROR", '@SACIERPYCRM.strings.ErrorCode', "error");
        alert("Error");
    });

    $('#modal1').show();
});

$("#btnsavepermiso").click(function () {
    if ($('#txtdescripcion').val() === undefined || $('#txtdescripcion').val() === null) {
        alert("Nombre del Permiso vacio");
    }
    else {
        $.ajax({
            data: { valor: $('#txtdescripcion').val() },
            url: "/Permisos/Create",
            type: "POST",
            success: function (d) {
                if (d.opcion === 1)
                {
                    $('#modal1').hide();
                    $('#contenedor').html(d.data);
                    swal("Resultado", "Almacenado Correctamente", "success");
                }
                if (d.opcion === 2) {
                    //alert("repetido");
                    swal("Resultado","Dato Repetido","info");
                }
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            //Swal.fire("ERROR", '@SACIERPYCRM.strings.ErrorCode', "error");
            alert("Error al guardar");
        });
    }
});

function AnularPermiso(IdPermisos) {
    $.ajax({
        data: { id: IdPermisos },
            url: "/Permisos/Anular",
            type: "POST",
            success: function (d) {
                //alert(d.data);
                if (d.opcion === 1) {
                    $('#modal1').hide();
                    $('#contenedor').html(d.data);
                }
                if (d.opcion === 2) {
                    alert("No encontrado");
                }
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            //Swal.fire("ERROR", '@SACIERPYCRM.strings.ErrorCode', "error");
            alert("Error al guardar");
        });
}

$(document).ready(function () {
    $('#tblpermiso').DataTable();
});