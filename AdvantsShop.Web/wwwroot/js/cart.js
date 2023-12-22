
const cart = document.getElementById('cart');
const finalPriceEl = document.getElementById('final-price');

let currentCartItem;

function counterDown(btn) {

    var id = btn.getAttribute('target');

    var input = document.getElementById(id);

    if (input.value < 2) {
        //confirmCartItemDelete();
        return;
    }

    input.value--;

    counterValueChanged(input);
}

function counterUp(btn) {
    var id = btn.getAttribute('target');

    var input = document.getElementById(id);

    input.value++;
    counterValueChanged(input);
}

function counterValueChanged(inc) {
    var container = inc.parentNode.parentNode;

    var unitPrice = container.querySelector('#unit-price').getAttribute("data-cost");

    var totalPrice = inc.value * parseFloat(unitPrice);

    var totalPriceEl = container.querySelector('#total-price');

    totalPriceEl.setAttribute('data-total-cost', totalPrice);

    totalPriceEl.innerHTML = formatNumber(totalPrice);

    calculateFinalPrice();
}

function calculateFinalPrice() {
    var items = cart.children;

    var finalPrice = 0;

    for (let i = 0; i < items.length; i++) {

        let item = items[i];

        finalPrice += parseFloat(item.querySelector('#total-price').getAttribute('data-total-cost'));
    }

    finalPriceEl.innerHTML = formatNumber(finalPrice);

    finalPriceEl.setAttribute('data-final-cost', finalPrice);
}

function selectCartItemToDelete(btn) {
    currentCartItem = $(btn).parents().filter('.cart-item')[0];
}

function deleteCartItem() {

    var finalPrice = finalPriceEl.getAttribute('data-final-cost');

    var division = parseFloat(finalPrice) - parseFloat(currentCartItem.querySelector('#total-price').getAttribute('data-total-cost'));

    finalPriceEl.setAttribute('data-final-cost', division);
    finalPriceEl.innerHTML = formatNumber(division);

    cart.removeChild(currentCartItem);
}

function deleteCartItems() {
    $(cart).empty();

    finalPriceEl.innerHTML = 0;
}

function formatNumber(num) {
    return num.toString().replace(/\B(?=(\d{3})+(?!\d))/g, " ");
}