$(".phone-masked").mask("+7 (999) 999-99-99", { placeholder: "+7 (___) ___-__-__" });


const toastLiveExample = document.getElementById('liveToast')

function addToCart(id) {
    $.ajax({
        method: 'POST',
        url: '/Cart/AddItem',   
        data: { itemId: id }
    }).done(function () {
        const toastBootstrap = bootstrap.Toast.getOrCreateInstance(toastLiveExample)

        toastBootstrap.show()
    });
}

function formatNumber(num) {
    return num.toString().replace(/\B(?=(\d{3})+(?!\d))/g, " ");
}