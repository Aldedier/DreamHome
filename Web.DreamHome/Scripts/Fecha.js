"use strict"

function AplicarDatePlugin() {
    $(".FechaHora").datetimepicker({
        format: 'DD/MM/YYYY',
        defaultDate: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate(), 0, 0, 0, 0),
        showClear: true,
    });
}

function AplicarDateTimePlugin() {
    $(".FechaHora").datetimepicker({
        format: 'DD/MM/YYYY HH:mm:ss',
        defaultDate: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate(), 0, 0, 0, 0),
        showClear: true,
    });
}

function AplicarDateTimePluginHoraActual() {
    $(".FechaHoraActual").datetimepicker({
        format: 'DD/MM/YYYY HH:mm:ss',
        defaultDate: new Date(new Date().getFullYear(), new Date().getMonth(), new Date().getDate(), new Date().getHours(), new Date().getMinutes(), new Date().getSeconds(), 0),
        showClear: true,
    });
}

function AplicarDateTimePluginCero() {
    $(".FechaHoraCero").datetimepicker({
        format: 'DD/MM/YYYY HH:mm:ss',
        defaultDate: null,
        showClear: true,
    });
}