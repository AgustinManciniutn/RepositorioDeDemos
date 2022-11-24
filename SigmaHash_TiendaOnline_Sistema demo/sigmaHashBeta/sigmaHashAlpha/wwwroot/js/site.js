let dropstore = document.querySelector('.dropdownstore');
let dropstoreclose = document.querySelector('#dropdownclose');
let storebtn = document.querySelector('#storebtn');

var storeopen = "closed";

dropstoreclose.addEventListener('click', () => {
    setTimeout(() => {
        dropstore.style.opacity = "0";
        dropstore.style.marginTop = "-30px";
    }, 30);
    setTimeout(() => {
        dropstore.style.display = "none";
    }, 400);
    storeopen = "closed";
});
storebtn.addEventListener('mouseover', () => {

    dropstore.style.display = "flex";

    setTimeout(() => {
        dropstore.style.opacity = "1";

    }, 30);

    setTimeout(() => {
        dropstore.style.marginTop = "0px";
        storeopen = "open";
    }, 100);
});

$(function () {
    $("body").click(function (e) {
        if (e.target.id == "dropdownstore" || $(e.target).parents("#dropdownstore").length) {
        } else {
            if (storeopen === "open") {
                dropstore.style.display = "none";
                storeopen = "closed";
            }
        }
    });
});
