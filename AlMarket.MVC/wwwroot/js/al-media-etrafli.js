let headinng = document.querySelector("#first")

let kisaltt = headinng.textContent.trim();
let ilkonsoz = kisaltt.split(" ").slice(0, 7).join(" ");

headinng.textContent = ilkonsoz + "...";

let headiing = document.querySelector("#second")

let kisallt = headiing.textContent.trim();
let ilkosoz = kisallt.split(" ").slice(0, 7).join(" ");

headiing.textContent = ilkosoz + "...";