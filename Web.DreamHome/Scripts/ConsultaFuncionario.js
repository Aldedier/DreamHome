$(function () {

    var valor = document.getElementById("CedulaInforma").value;

    $("#enviarDatos").click(function () {
        $("#notificacion").empty();

        $.ajax({
            type: 'POST',
            url: urlPersona + "/" + valor,
            dataType: 'json',
            data: { id: $("#CedulaInforma").val() },

            success: function (response) {
                if (response.ok == true) {
                    $("#notificacion").html('<div class="alert alert-info alert-dismissible"><h4>' + response.funcionario + '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>' + '</h4></div>');
                } else {
                    $("#notificacion").html('<div class="alert alert-info alert-dismissible"><h4>' + response.funcionario + '<button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>' + '</h4></div>');
                }
            },
            error: function (ex) {
                $("#notificacion").html('<div class="alert alert-danger alert-dismissible"> <h4><i class="fa fa-search"></i> <button type="button" class="close" data-dismiss="alert" aria-hidden="true">&times;</button>'
                       + "Error al consultar: " + ex + '</h4></div>');
            }
        })
    });
});