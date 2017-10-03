var PageTypes = []
//fetch categorias from datababase (p

function LoadCategory(element) {
    if (PageTypes.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/home/getProductCategories',
            success: function (data) {
                PageTypes = data;
                //render categories
                renderPageTypes(element);
            }
        })

    }
    else {
        //render category to the element
        renderPageTypes(element);
    }
}

function renderPageTypes(element) {
    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(PageTypes, function (i, val) {
        $ele.append($('<option/>').val(val.PageTypeID).text(val.PageTypeDescription));
    })
}

////fetch Prpducts from datababase (Pages)

function LoadPages(pageTypeDD) {
    if (PageTypes.length == 0) {
        //ajax function for fetch data
        $.ajax({
            type: "GET",
            url: '/home/getProducts',
            data: { 'categoryID': $(pageTypeDD).val() },
            success: function (data) {
                PageTypes = data;
                //render categories
                renderPages($(pageTypeDD).parents('mycontainer').find('select.product'), data);
            },

            error: function (error) {
                console.log(error);
            }
        })

    }
}

function renderPages(element, data) {
    //render peoduct

    var $ele = $(element);
    $ele.empty();
    $ele.append($('<option/>').val('0').text('Select'));
    $.each(data, function (i, val) {
        $ele.append($('<option/>').val(val.PageID).text(val.PageName));
    })
}

$(document).ready(function () {

    //add button click event
    $('#add').click(function () {
        //validate and order items
        var isAllValid = true;
        if ($('#productCategory').val() == "0") {
            isAllValid = false;
            $('#productCategory').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#productCategory').siblings('span.error').css('visibility', 'hidden');
        }

        if (!($('#quantity').val().trim() != '' && (parseInt($('#quantity').val()) || 0))) {
            isAllValid = false;
            $('#quantity').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#quantity').siblings('span.error').css('visibility', 'hidden');
        }



        if (!($('#rate').val().trim() != '' && !isNaN($('#rate').val().trim()))) {
            isAllValid = false;
            $('#rate').siblings('span.error').css('visibility', 'visible');
        }
        else {
            $('#rate').siblings('span.error').css('visibility', 'hidden');
        }

        if (isAllValid) {
            var $newRow = $('#mainrow').clone().removeAttr('id');
            $('.pc', $newRow).val($('#productCategory').val());
            $('.product', $newrow).val($('#product').val());

            //replace add button with remove button
            $('#add', $newRow).addClass('remove').val('Remove').removeClass('btn-success').addClass('btn-danger');

            // remove id attribute from new clone row
            $('#productCategory, #product,#quantity, #rate,#add', $newrow).removeAttr('id');
            $('span.error', $newRow).remove();
            //append cone row
            $('#orderdetailsItems').append($newRow);

            //clear select data
            $('#productCategory, #product').val('0');
            $('#quantity, #rate').val('');
            $('#orderItemError').empty();

        }
    })

    //remove button click event

    $('#orderdetailsItems').on('click', '.remove', function () {
        $(this).parent('tr').remove();

    });


    $('#submit').click(function () {
        var isAllValid = true;
        //validate  order items

        $('#orderItemError').text('');
        var list = [];
        var errorItemError = 0;

        $('#orderdetailsItems tdbody tr').each(function (index, ele) {
            if ($('select.product', this).val() == "0" ||
                (parseInt($('.quantity', this).val()) || 0) == 0 ||
                $('.rate', this).val() == "" ||
                isNaN($('.rate', this).val())

               ) {
                errorItemError++;
                $(this).addClass('error');

            } else {
                var orderItem = {
                    PageID: $('select.product', this).val(),
                    QtyTokens: parseInt($('.quantity', this).val()),
                    Value: parseInt($('.rate', this).val())
                }

                list.push(orderItem);
            }

        })
        if (errorItemError > 0) {
            $('#orderItemError').text(errorItemCount + "Invalid entry in order item list");
            isAllValid = false;
        }
        if (list.length == 0) {
            $('#orderItemError').text('At least 1 order item required.');
            isAllValid = false;
        }

        if ($('#orderNo').val().trim() == '') {
            $('#orderNo').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#orderNo').siblings('span.error').css('visibility', 'hidden');
        }

        if ($('#orderDate').val().trim() == '') {
            $('#orderDate').siblings('span.error').css('visibility', 'visible');
            isAllValid = false;
        }
        else {
            $('#orderDate').siblings('span.error').css('visibility', 'hidden');
        }


        if (isAllValid) {
            var data = {
                //OrderNro: $('#orderNo').val().trim(),
                OrderDateString: $('#orderDate').val().trim(),
                Description: $('#description').val().trim(),
                OrderDetails: list
            }
            $(this).val('Please wait...');
            $.ajax({
                type: 'POST',
                url: '/home/save',
                data: JSON.stringify(data),
                contentType: 'application/json',
                success: function (data) {

                    if (d.status) {
                        alert('Successfully saved');
                        // here will clear form 
                        list = [];
                        $('#orderNo,#orderDate,#description').val('');
                        $('#orderdetailsItems').empty();

                    }
                    else {
                        alert('Error');
                    }
                    $('#submit').text('Save');
                },
                error: function (error) {
                    console.log(error);
                    $('#submit').text('Save');
                }
            });
        }

    });
});

LoadCategory($('#productCategory')); 