function btnMostrar(titulo, texto)
{
    $("#titulo").html(titulo);
    $("#ContenidoModal").html(texto);
    $('#ModalDescripcion').modal("show");
}