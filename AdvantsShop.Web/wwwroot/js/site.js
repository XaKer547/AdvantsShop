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

