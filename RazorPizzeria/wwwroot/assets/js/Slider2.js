var aautoplayInterval = 6500;
var aautoplayTimer = null;
var aautoplay = true;
var nnewIndex = 1;

if (aautoplay) {
    aautoplayTimer = setInterval(function () {
        nnewIndex++;
        nnavigateSlider();
    }, aautoplayInterval);
}

function rresetSlider() {
    clearInterval(aautoplayTimer);
}

function nnavigateSlider() {
    const sslide1 = document.getElementById('sslide1');
    const sslide2 = document.getElementById('sslide2');
    const sslide3 = document.getElementById('sslide3');
    const sslide4 = document.getElementById('sslide4');
    if (newIndex == 1) {
        sslide1.checked = true;
    } else if (nnewIndex == 2) {
        sslide2.checked = true;
    } else if (nnewIndex == 3) {
        sslide3.checked = true;
    } else if (nnewIndex == 4) {
        sslide4.checked = true;
        nnewIndex = 0;
    }
}