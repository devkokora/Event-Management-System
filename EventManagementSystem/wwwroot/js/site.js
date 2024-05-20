// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
const search = document.querySelector(".search-index");
const input = document.querySelector(".input-search-index");
const btn = document.querySelector(".btn-search-index");

btn.addEventListener("click", () => {
    search.classList.toggle("active");
    input.focus();
});

$(document).ready(function () {
    function numberWithCommas(x) {
        return x.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    }

    $('.counter-count').each(function () {
        $(this).prop('Counter', 0).animate({
            Counter: $(this).text().replace(/,/g, '') // Remove any existing commas before animating
        }, {
            duration: (Math.random() + 0.5) * 3000,
            easing: 'swing',
            step: function (now) {
                $(this).text(numberWithCommas(Math.ceil(now)));
            }
        });
    });
});