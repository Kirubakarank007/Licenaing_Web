// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function showNav () {
   
    const nav = document.getElementById('hide-nav-bar-options');
    const navImg = document.getElementById('show-nav-img');
    const hideNav = document.getElementById('hide-nav-bar');
    if (nav.style.display == "none") {
        nav.style.display = "flex";
        navImg.src = "/icons/vertical-lines.png";

    } else {
        nav.style.display = "none";
        navImg.src ="/icons/burger-bar.png"
    }
}