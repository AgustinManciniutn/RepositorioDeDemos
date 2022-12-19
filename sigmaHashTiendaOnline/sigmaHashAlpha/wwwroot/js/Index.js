
$(document).ready(function () {

    let arrowL = document.querySelector('#arrowone');

    let arrowR = document.querySelector('#arrowtwo');
    let slider = document.querySelector('.slider');

    let homedownbtn = document.querySelector('.homedownbutton');
    let homecontainer = document.querySelector('#homecontainer');

    let secsection = document.querySelector('.secsection');

    const pos = ['0', '-100%', '-200%', '-300%'];

    function buttonshop(x) {
        if (x.matches) {
            $('.secondbutton').html('<i class="bi bi-bag"></i>');

        }
        else {
            $('.secondbutton').html('Check in store');
        }
    }

    let mql = window.matchMedia('(max-width: 1200px)');

    buttonshop(mql);
    mql.addListener(buttonshop);

    var i = 0;
    arrowL.addEventListener('click', function () {

        if (i != 0) {
            --i;
            slider.style.marginInline = pos[i];
        }

    });
    arrowR.addEventListener('click', function () {
        if (i != 4) {
            ++i;
            slider.style.marginInline = pos[i];
        }
    });

    homedownbtn.addEventListener('click', function () {

        $('#homecontainer').scrollTop($('#secsection').offset().top - 170);

    });

    let ddcat = document.querySelector('.dropdowncategory');
    let ddselect = document.querySelector('.dropdownselected');
    let imgselect = document.querySelector('.selectedimg');
    const ddcatDivs = ddcat.children;

    var u = 0;

    var k = 0;

    for (var obj of ddcatDivs) {
        let j = u * -100;
        obj.addEventListener('mouseover', function () {
            k = j / 10;
            var str = "translate(0," + j.toString() + "%)"
            var str2 = "translate(0," + k.toString() + "%)";
            console.log(str);
            ddselect.style.transform = str;
            imgselect.style.transform = str2;
        });
        u++;
    }


});