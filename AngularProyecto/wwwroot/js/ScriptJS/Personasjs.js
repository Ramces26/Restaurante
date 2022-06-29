$("#btnagregar").click(function () {
    $.ajax({
        data: { opcion: 1 },
        url: "/Personas/Create",
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

$("#btnsavepersona").click(function () {
    if ($('#Cedula').val() === undefined || $('#Cedula').val() === null) {
        alert("Cedula de la persona vacia");
    }
    else {
        //var fecha = $('#FechaNacimiento').datepicker().val();
        //var sexo = $('#Sexo').val();
        //debugger;
        var objeto ={
            Cedula: $('#Cedula').val(),
            PNombre: $('#PNombre').val(),
            SNombre: $('#SNombre').val(),
            PApellido: $('#PApellido').val(),
            SApelldio: $('#SApelldio').val(),
            Sexo: $('#Sexo').val(),
            FechaNacimiento: $('#FechaNacimiento').val(),
            Celular: $('#Celular').val(),
            Correo: $('#Correo').val(),
            EstadoCivil: $('#EstadoCivil').val(),
            Direccion: $('#Direccion').val()
        };

        $.ajax({
            data: { personas: objeto },
            url: "/Personas/Create",
            type: "POST",
            success: function (d) {
                if (d.opcion === 1) {
                    $('#modal1').hide();
                    $('#contenedor').html(d.data);
                }
                if (d.opcion === 2) {
                    alert("repetido");
                }
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            //Swal.fire("ERROR", '@SACIERPYCRM.strings.ErrorCode', "error");
            alert("Error al guardar");
        });
    }
});

function AnularPersonas(IdPersona) {
    $.ajax({
        data: { id: IdPersona },
        url: "/Personas/Anular",
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
    $('#tblpersona').DataTable();
});