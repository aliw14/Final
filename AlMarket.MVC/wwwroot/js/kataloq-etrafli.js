let slidess = document.querySelectorAll(".print-img");
var ccounter = 0;

slidess.forEach((sslide, index) => {
    sslide.style.left = `${index * 100}%`;
});

let goPrevv = () => {
    if (ccounter > 0) {
        ccounter--;
    }
    sslideImage();
};

let goNextt = () => {
    if (ccounter < slidess.length - 1) {
        ccounter++;
    }
    sslideImage();
};

let sslideImage = () => {
    slidess.forEach((sslide) => {
        sslide.style.transform = `translateX(-${ccounter * 100}%)`;
    });
};

let arrowone = document.querySelector("#arrowOne")
let arrowtwo = document.querySelector('#arrowTwo')
let numberElement = document.querySelector("#number");
let number = parseInt(numberElement.innerHTML);

arrowtwo.addEventListener("click", function () {
    if (number < 4)
        number += 1;
    numberElement.innerHTML = number;

});

arrowone.addEventListener("click", function () {
    if (number > 1)
        number -= 1;
    numberElement.innerHTML = number;

});

let shareMenu = document.querySelector(".share-down");
let btnShare = document.querySelector("#dropdownMenuButton1");

document.addEventListener("click", function (event) {
    if (event.target === btnShare || shareMenu.contains(event.target)) {
        if (shareMenu.style.display === "none" || shareMenu.style.display === "") {
            shareMenu.style.display = "block";
        } else {
            shareMenu.style.display = "none";
        }
    } else {
        shareMenu.style.display = "none";
    }
});
