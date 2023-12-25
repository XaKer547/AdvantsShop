let cart;
let finalPriceEl;

let currentCartItem;

if (window.location.pathname == "/Cart") {
    var counters = document.getElementsByClassName("cart-item-counter");
    cart = document.getElementById('cart');
    finalPriceEl = document.getElementById('final-price');

    for (var i = 0; i < counters.length; i++) {
        counterValueChangedWithoutNotify(counters[i]);
    }

    calculateFinalPrice();
}
function counterDown(btn) {
    var id = btn.getAttribute('target');

    var input = document.getElementById(id);

    if (input.value < 2) {
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
    cartItemSelectionChanged(inc);

    var cartItemPriceInfo = currentCartItem.querySelector('.cart-item-price-info');

    var unitPrice = cartItemPriceInfo.querySelector('#unit-price').getAttribute("data-cost");

    var totalPrice = inc.value * parseFloat(unitPrice);

    var totalPriceEl = cartItemPriceInfo.querySelector('#total-price');

    totalPriceEl.setAttribute('data-total-cost', totalPrice);

    totalPriceEl.innerHTML = formatNumber(totalPrice);

    calculateFinalPrice();

    var itemId = currentCartItem.getAttribute('data-item-id');

    $.ajax({
        method: 'patch',
        url: '/Cart/ChangeItemAmount',
        data: { itemId: itemId, amount: inc.value }
    });
}

function counterValueChangedWithoutNotify(inc) {
    currentCartItem = $(inc).parents().filter('.cart-item')[0];

    var unitPrice = currentCartItem.querySelector('#unit-price').getAttribute("data-cost");

    var totalPrice = inc.value * parseFloat(unitPrice);

    var totalPriceEl = currentCartItem.querySelector('#total-price');

    totalPriceEl.setAttribute('data-total-cost', totalPrice);

    totalPriceEl.innerHTML = formatNumber(totalPrice);
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
    cartItemSelectionChanged(btn);
}

function cartItemSelectionChanged(e) {
    currentCartItem = $(e).parents().filter('.cart-item')[0];
}

function deleteCartItem() {
    var itemId = currentCartItem.getAttribute('data-item-id');

    var finalPrice = finalPriceEl.getAttribute('data-final-cost');

    var division = parseFloat(finalPrice) - parseFloat(currentCartItem.querySelector('#total-price').getAttribute('data-total-cost'));

    finalPriceEl.setAttribute('data-final-cost', division);
    finalPriceEl.innerHTML = formatNumber(division);

    cart.removeChild(currentCartItem);

    $.ajax({
        method: 'POST',
        url: '/Cart/RemoveItem',
        data: { itemId: itemId }
    });
}

function deleteCartItems() {
    $.ajax({
        method: 'HEAD',
        url: '/Cart/ClearCart',
    }).done(function () {
        $(cart).empty();
        finalPriceEl.innerHTML = 0;
    });
}