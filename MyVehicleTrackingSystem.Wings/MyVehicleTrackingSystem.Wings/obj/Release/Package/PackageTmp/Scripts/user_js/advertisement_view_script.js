$(document).ready(function () {
    $(function () {
        $(".btnCategoryId").click(function () {
            $('#hiddenCategoryId').val($(this).attr('value'))
        });
        $("button").click(function () {
            $('.validation-summary-errors').html('');
        });
    });
});

$(function () {
    $("a #itemId").click(function () {
        $('#hiddenCategoryIdEdit').val('');
        $('#hiddenItemIdEdit').val('');
        $('#ItemNameEdit').val('');
        $.ajax({
            cache: false,
            type: "GET",
            url: '/Advertisement/EditItems',
            data: { id: $(this).attr("value") },
            dataType: 'json',
            success: function (result) {
                $('#hiddenCategoryIdEdit').val(result.CategoryId);
                $('#hiddenItemIdEdit').val(result.ItemId);
                $('#ItemNameEdit').val(result.ItemName);
                $('#hiddenItemUrlEdit').val(result.FileURL);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve data.');
            }
        });
    });
});

$(function () {
    $("a #categoryId").click(function () {
       
        $('#hiddenCategoryIdEdit').val('');
        $('#CategoryNameEdit').val('');
        $.ajax({
            cache: false,
            type: "GET",
            url: '/Advertisement/EditCategories',
            data: { id: $(this).attr("value") },
            dataType: 'json',
            success: function (result) {
                $('#hiddenCategoryIdEdit').val(result.CategoryId);
                $('#CategoryNameEdit').val(result.CategoryName);
                $('#hiddenCategoryUrlEdit').val(result.FileURL);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve data.');
            }
        });
    });
});

//sort advertisement category
$(document).ready(function () {
    var ajaxRequest = null;
    var my_array = [];

    $("#category_table").sortable({
        items: 'table:not(:first-child)',//tr:not(:first-child)
        appendTo: "parent",
        helper: "clone",
        revert: true,
        start: function (event, ui) {
        },
        stop: function (event, ui) {
            var data = $(this).sortable('toArray', { attribute: 'name' });
            if (ajaxRequest) {
                ajaxRequest.abort();
            }
            ajaxRequest = $.ajax({
                type: "POST",
                url: '/Advertisement/SortAdvertisementCategories',
                traditional: true,
                data: {
                    items: data
                },
                dataType: 'application/json',
                success: function (result) {
                    location.reload();
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    location.reload();
                }
            });
        }
    }).disableSelection();
});


//sort advertisement Items
$(document).ready(function () {
    var ajaxRequest = null;

    $("#item_table > tbody").sortable({
        items: 'tr:has(td)',//tr:not(:first-child)
        appendTo: "parent",
        helper: "clone",
        revert: true,
        start: function (event, ui) {
        },
        stop: function (event, ui) {
            var data = $(this).sortable('toArray', { attribute: 'value' });
            if (ajaxRequest) {
                ajaxRequest.abort();
            }
            ajaxRequest = $.ajax({
                type: "POST",
                url: '/Advertisement/SortAdvertisementItems',
                traditional: true,
                data: {
                    items: data
                },
                dataType: 'application/json',
                success: function (result) {
                     location.reload();
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    location.reload();
                }
            });
        }
    }).disableSelection();
});
