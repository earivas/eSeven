$("#btnNuevo").click(function (eve) {
    $("#modal-content").load("/PageTypes/Create");
});


$(".btnEditar").click(function (eve) {
    $("#modal-content").load("/PageTypes/Edit/" + $(this).data("id"));

});


$("#btnEditar").click(function (eve) {
    $("#modal-content").load("/PageTypes/Edit/" + $(this).data("id"));

});

$(".btnDetails").click(function (eve) {
    $("#modal-content").load("/PageTypes/Details/" + $(this).data("id"));
}
);
$(".btnDelete").click(function (eve) {
    $("#modal-content").load("/PageTypes/Delete/" + $(this).data("id"));
}
);