const textElements = document.querySelectorAll(".text");

textElements.forEach((element) => {
    const metin = element.textContent.trim();
    const ilk10Kelime = metin.split(" ").slice(0, 10).join(" ");
    element.textContent = ilk10Kelime + "...";
});

let heading = document.querySelector("#onee")

let kisa = heading.textContent.trim();
let ilk7soz = kisa.split(" ").slice(0, 7).join(" ");

heading.textContent = ilk7soz + "...";

let headingg = document.querySelector("#fourr")

let kisalt = headingg.textContent.trim();
let ilk10soz = kisalt.split(" ").slice(0, 10).join(" ");

headingg.textContent = ilk10soz + "...";
