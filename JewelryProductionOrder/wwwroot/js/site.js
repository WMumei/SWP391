document.addEventListener("DOMContentLoaded", function () {
    const menuIcon = document.getElementById("menu-icon");
    const menu = document.getElementById("menu");
    const overlay = document.getElementById("overlay");
    const menuHeader = document.getElementById("menu-header");
    const menuIcon2 = document.getElementById("menu-icon-2");
    let isOpen = false;

    menuIcon2.style.display = "none";

    function openMenu() {
        menu.style.left = "0";
        overlay.classList.add("active");
        document.body.classList.add("menu-open");
        menuIcon.style.opacity = "0";
        menuIcon.style.visibility = "hidden";
        menuIcon.classList.add("inverted");
        isOpen = true;
        menuIcon2.style.display = "block";
    }

    function closeMenu() {
        menu.style.left = "-300px";
        overlay.classList.remove("active");
        document.body.classList.remove("menu-open");
        menuIcon.style.opacity = "1";
        menuIcon.style.visibility = "visible";
        menuIcon.classList.remove("inverted");
        isOpen = false;
        menuIcon2.style.display = "none";
    }

    menuIcon.addEventListener("click", function () {
        if (isOpen) {
            closeMenu();
        } else {
            openMenu();
        }
    });

    overlay.addEventListener("click", function () {
        closeMenu();
    });
});