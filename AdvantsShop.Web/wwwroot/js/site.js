const swiper = new Swiper('.swiper', {
    direction: 'horizontal',
    loop: false,

    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
});


const maxStars = 5;

var ratings = document.getElementsByClassName('rating');
for (let i = 0; i < ratings.length; i++) {

    let rating = ratings[i];

    var starsAmount = rating.getAttribute('stars-amount');

    for (var j = 0; j < maxStars; j++) {

        var star = document.createElement('img');

        star.src = "/icons/star.svg";

        star.classList.add('star');

        if (j < starsAmount) {
            star.classList.add('toogled');
        }

        rating.appendChild(star);
    }
}

function counterDown(btn) {

    var id = btn.getAttribute('target');

    var input = document.getElementById(id);

    if (input.value < 2) {
        confirmCartItemDelete();
        return;
    }

    input.value--;

    counterValueChanged(input);
}
const cart = document.getElementById('cart');

let currentCartItem;
function counterValueChanged(inc) {
    var container = inc.parentNode.parentNode;

    var unitPrice = container.querySelector('#unit-price').getAttribute("data-cost");

    var finalPrice = inc.value * parseFloat(unitPrice);

    container.querySelector('#final-price').innerHTML = finalPrice.toString().replace(/\B(?=(\d{3})+(?!\d))/g, " ");
}
function counterUp(btn) {
    var id = btn.getAttribute('target');

    var input = document.getElementById(id);

    input.value++;
    counterValueChanged(input);
}

function selectCartItemToDelete(btn) {
    currentCartItem = $(btn).parents().filter('.cart-item')[0];
}

function deleteCartItem() {
    cart.removeChild(currentCartItem);
}

function deleteCartItems() {
    $(cart).empty();
}