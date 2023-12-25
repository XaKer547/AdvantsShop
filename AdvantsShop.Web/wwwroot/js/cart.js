const cart = document.getElementById('cart');
const finalPriceEl = document.getElementById('final-price');

let currentCartItem;

if (cart == null)
    return;

var counters = document.getElementsByClassName("cart-item-counter");

for (var i = 0; i < counters.length; i++) {
    counterValueChangedWithoutNotify(counters[i]);
}

calculateFinalPrice();

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
    var cartItemPriceInfo = currentCartItem.querySelector('.cart-item-price-info');

    var unitPrice = cartItemPriceInfo.querySelector('#unit-price').getAttribute("data-cost");

    var totalPrice = inc.value * parseFloat(unitPrice);

    var totalPriceEl = cartItemPriceInfo.querySelector('#total-price');

    totalPriceEl.setAttribute('data-total-cost', totalPrice);

    totalPriceEl.innerHTML = formatNumber(totalPrice);

    calculateFinalPrice();

    var itemId = cartItem.getAttribute('data-item-id');

    $.ajax({
        method: 'patch',
        url: '/Cart/ChangeItemAmount',
        data: { itemId: itemId, amount: inc.value }
    });
}

function counterValueChangedWithoutNotify(inc) {
    var unitPrice = currentCartItem.querySelector('#unit-price').getAttribute("data-cost");

    var totalPrice = inc.value * parseFloat(unitPrice);

    var totalPriceEl = container.querySelector('#total-price');

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
    currentCartItem = $(btn).parents().filter('.cart-item')[0];
}

function deleteCartItem() {
    var itemId = currentCartItem.getAttribute('data-item-id');

    $.ajax({
        method: 'POST',
        url: '/Cart/RemoveItem',
        data: { itemId: itemId }
    }).done(function () {
        var finalPrice = finalPriceEl.getAttribute('data-final-cost');

        var division = parseFloat(finalPrice) - parseFloat(currentCartItem.querySelector('#total-price').getAttribute('data-total-cost'));

        finalPriceEl.setAttribute('data-final-cost', division);
        finalPriceEl.innerHTML = formatNumber(division);

        cart.removeChild(currentCartItem);
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