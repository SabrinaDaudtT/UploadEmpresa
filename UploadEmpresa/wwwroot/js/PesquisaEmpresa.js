$(document).ready(function () {


    $("#btnLimparCampos").on("click", function (ev) {
        debugger
        ev.preventDefault();

        $("#iptCNPJ").val('');
    });

    $("#btnPesquisar").on("click", function (ev) {
        ev.preventDefault();

        debugger
        var cnpj = $("#iptCNPJ").val();

        if (cnpj != null || cnpj != "") {

            buscarCnpj(cnpj);
        }
        else {
            alert('Informe algum filtro');
        }
    });
});

function buscarCnpj(cnpj) {
    debugger
    $("#dvDetailsModal").load("/Home/_Detalhes?cnpj=" + cnpj, function () {
        $('#dvDetailsModal').modal('show');
    });
}
