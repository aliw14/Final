let dropdownBtn = document.getElementById("dropdown-btn");
let target = document.getElementById("target");
let arrow = document.querySelector("#chevron")

dropdownBtn.addEventListener("click", function () {
    if (target.style.display === "none" || target.style.display === "") {
        target.style.display = "block";
    } else {
        target.style.display = "none";
    }
});

dropdownBtn.addEventListener("click", function () {
    if (arrow.style.transform === "rotate(180deg)") {
        arrow.style.transform = "rotate(0deg)";
        arrow.style.transition = "0.3s";
    } else {
        arrow.style.transform = "rotate(180deg)";
        arrow.style.transition = "0.3s";

    }
});

const cardItems = document.querySelectorAll('.shuffle-item');

const dropdown = document.getElementById('target');
const dropdownItems = dropdown.querySelectorAll('li');

dropdownItems.forEach(item => {
    item.addEventListener('click', () => {
        const selectedCategory = item.textContent.trim();

        cardItems.forEach(cardItem => {
            const cardTitle = cardItem.querySelector('.card-items__title').textContent.trim();
            if (selectedCategory === 'Hamısı' || cardTitle === selectedCategory) {
                cardItem.style.display = 'block';
            } else {
                cardItem.style.display = 'none';
            }
        });
    });
});

$(document).on('keyup', '#input-search', function () {
    var searchedWork = $(this).val();
    $.ajax({
        url: "/karyera/search?searchedWork=" + searchedWork,
        type: "GET",
        
        success: function (response) {
            $("#searchedWork li").slice(1).remove();

            $("#searchedWork").append(response);
        },
        error: function (xhr) {

        }
    });
})