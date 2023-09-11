var skip = 8;
$(document).on('click', '#More', function () {
    var qeyriqidaCount = $("#qeyriqidaCount").val();

    $.ajax({
        url: "/qeyriqida/loadQeyriQida?skip="+skip,
        type: "GET",

        success: function (response) {
            $('#qeyriqidaRow').append(response);
            skip += 8;

            if (skip >= qeyriqidaCount)
                $("#More").remove();
        },
        error: function (xhr) {

        }
    });
})