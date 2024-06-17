document.addEventListener("DOMContentLoaded", function () {
    const menuIcon = document.getElementById("menu-icon");
    const menuIcon2 = document.getElementById("menu-icon-2");
    const menu = document.getElementById("menu");
    const overlay = document.getElementById("overlay");
    const menuHeader = document.getElementById("menu-header");
    let isOpen = false;

    function openMenu() {
        menu.style.left = "0";
        overlay.classList.add("active");
        document.body.classList.add("menu-open");
        menuIcon.style.opacity = "0";
        menuIcon.style.visibility = "hidden";
        menuIcon2.style.opacity = "1";
        menuIcon2.style.visibility = "visible";
        isOpen = true;
    }

    function closeMenu() {
        menu.style.left = "-250px";
        overlay.classList.remove("active");
        document.body.classList.remove("menu-open");
        menuIcon.style.opacity = "1";
        menuIcon.style.visibility = "visible";
        menuIcon2.style.opacity = "0";
        menuIcon2.style.visibility = "hidden";
        isOpen = false;
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

    // Allow closing the menu by clicking the second icon
    menuIcon2.addEventListener("click", function () {
        closeMenu();
    });
});