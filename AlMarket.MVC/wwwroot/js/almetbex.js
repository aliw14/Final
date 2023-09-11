document.addEventListener("DOMContentLoaded", function () {
    const button = document.getElementById("kateqoriyalarr");
    const ul = document.getElementById("opened");

    button.addEventListener("click", function () {
        if (ul.classList.contains("d-block")) {
            ul.classList.remove("d-block");
        } else {
            ul.classList.add("d-block");
        }
    });
});

document.addEventListener("DOMContentLoaded", function() {
    const divIds = ["2", "3", "4", "5", "6", "7"];

    divIds.forEach(divId => {
        const div = document.getElementById(divId);
        if (div) {
            const pElement = div.querySelector(".card-items__title");
            if (pElement) {
                const words = pElement.textContent.trim().split(" ");
                if (words.length > 4) {
                    const shortenedText = words.slice(0, 4).join(" ");
                    pElement.textContent = shortenedText + " ...";
                }
            }
        }
    });
});
const kutular = document.querySelectorAll(".metbex-card");
kutular.forEach((kutu, index) => {
    kutu.setAttribute("id", `box-${index + 1}`);
});


$(document).on('keyup', '#input-search', function () {
    var searchedFood = $(this).val();
    $.ajax({
        url: "/almetbex/search?searchedFood=" + searchedFood,
        type: "GET",

        success: function (response) {
            $("#searchedFood li").slice(1).remove();

            $("#searchedFood").append(response);
        },
        error: function (xhr) {

        }
    });
})
