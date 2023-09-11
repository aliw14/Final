var skip = 8;

$(document).on('click', '#loadMore', function () {
    var qidaCount = $("#qidaCount").val();

    $.ajax({
        url: "/qida/loadQida?skip="+skip,
        type: "GET",

        success: function (response) {
            $("#qidaRow").append(response);
            console.log(qidaCount)

            skip += 8;
            if (skip > qidaCount)
               $("#loadMore").remove();

        },

        error: function (xhr) {

        }
    });
})