$(document).ready(function () {
    $('#txtusuario').val("");
    $('#txtpass').val("");
});

$('#btningresar').click(function () {
    var bandera = false;
    //var mensaje = '';
    if ($('#txtusuario').val() === '' )
    {
        bandera = true;
    }
    if ($('#txtpass').val() === '') {
        bandera = true;
    }
    if (bandera === true) {
        swal("Resultado", "Usuario o contraseña vacios.", "error");
    }
    else
    {
        $.ajax({
            data: { usu: $('#txtusuario').val(), contra: $('#txtpass').val()},
            url: "/Acceso/Logeando",
            type: "GET",
            success: function (d) {
                debugger;

                if (d.opcion === 1) {
                   
                    var url = window.location;
                    location.replace(url+"Home/Index2");
                    //console.log(url);
                }
                if (d.opcion === 2) {
                    swal("Resultado", "Usuario Incorrecto", "error");
                }
            }
        }).fail(function (jqXHR, textStatus, errorThrown) {
            //Swal.fire("ERROR", '@SACIERPYCRM.strings.ErrorCode', "error");
            alert("Error al guardar");
        });
    }
   
});