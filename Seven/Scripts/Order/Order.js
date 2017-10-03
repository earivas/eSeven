$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').focus()
});

$("#myModal").click(function (eve) {
    $("#modal-content").load("/Orders/AddDetail");
});


$("#AddButton").click(function (eve) {
    $("#modal-content").load("/Orders/AddDetail");
});
