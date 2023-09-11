const slideone = document.querySelectorAll(".thumbnail")
counter = 0;
slideone.forEach(
    (slide, index) => {
        slide.style.left = `${index * 100}%`
    }
)

const goPrev1 = () => {
    if (counter > 0) {
        counter--;
    }
    slideImage1();
}

const goNext1 = () => {
    if (counter < 4) {
        counter++;
    } else {
        counter = 0;
    }
    slideImage1();
}

const slideImage1 = () => {
    slideone.forEach(
        (slide) => {
            slide.style.transform = `translateX(-${counter * 100}%)`
        }
    )
}

///////////////////////////////////
const leftMenu = document.querySelector("#one");
const subMenu = document.querySelector(".sub-menu");

leftMenu.addEventListener("mouseenter", () => {
    subMenu.style.display = "block";
});

leftMenu.addEventListener("mouseleave", () => {
    subMenu.style.display = "none";
});

subMenu.addEventListener("mouseenter", () => {
    subMenu.style.display = "block";
});

subMenu.addEventListener("mouseleave", () => {
    subMenu.style.display = "none";
});
/////////////////////////////////
const leftMenu2 = document.querySelector("#three");
const subMenu2 = document.querySelector("#sub-menu2");

leftMenu2.addEventListener("mouseenter", () => {
    subMenu2.style.display = "block";
});

leftMenu2.addEventListener("mouseleave", () => {
    subMenu2.style.display = "none";
});

subMenu2.addEventListener("mouseenter", () => {
    subMenu2.style.display = "block";
});

subMenu2.addEventListener("mouseleave", () => {
    subMenu2.style.display = "none";
});
/////////////////////////////////////
const leftMenu3 = document.querySelector("#four");
const subMenu3 = document.querySelector("#sub-menu3");

leftMenu3.addEventListener("mouseenter", () => {
    subMenu3.style.display = "block";
});

leftMenu3.addEventListener("mouseleave", () => {
    subMenu3.style.display = "none";
});

subMenu3.addEventListener("mouseenter", () => {
    subMenu3.style.display = "block";
});

subMenu3.addEventListener("mouseleave", () => {
    subMenu3.style.display = "none";
});
/////////////////////////////////////////

////////////////////////////////////////////
const testButton = document.getElementById("test");
const teestElement = document.getElementById("teest");
let isTeestMoved = false;

testButton.addEventListener("click", () => {
    if (isTeestMoved) {
        teestElement.style.right = "-40%";
    } else {
        teestElement.style.right = "0%";
    }
    isTeestMoved = !isTeestMoved;
});

const leftMenu6 = document.querySelector("#six");
const subMenu6 = document.querySelector("#sub-menu6");

leftMenu6.addEventListener("mouseenter", () => {
    subMenu6.style.display = "block";
});

leftMenu6.addEventListener("mouseleave", () => {
    subMenu6.style.display = "none";
});

subMenu6.addEventListener("mouseenter", () => {
    subMenu6.style.display = "block";
});

subMenu6.addEventListener("mouseleave", () => {
    subMenu6.style.display = "none";
});

const languageButton = document.getElementById("languageButton");
const languagesDropdown = document.getElementById("languagesDropdown");

languageButton.addEventListener("click", function () {
    languagesDropdown.classList.toggle("show");
});

window.addEventListener("click", function (event) {
    if (
        event.target !== languageButton &&
        !languagesDropdown.contains(event.target)
    ) {
        languagesDropdown.classList.remove("show");
    }
});

const languageSpan = document.querySelector('#languageButton span');

const dropdownItemss = languagesDropdown.querySelectorAll('.dropdown-item');
dropdownItemss.forEach(item => {
    item.addEventListener('click', function (event) {
        event.preventDefault(); 
        const languageCode = event.target.textContent.trim();
        languageSpan.textContent = languageCode;
    });
});
