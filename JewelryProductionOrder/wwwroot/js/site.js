document.addEventListener("DOMContentLoaded", function () {
    const menuIcon = document.getElementById("menu-icon");
    const menu = document.getElementById("menu");
    const overlay = document.getElementById("overlay");
    const menuHeader = document.getElementById("menu-header");
    const menuIcon2 = document.getElementById("menu-icon-2"); // added
    let isOpen = false;

    // hide menu-icon-2 on page load
    menuIcon2.style.display = "none"; // added

    function openMenu() {
        menu.style.left = "0";
        overlay.classList.add("active");
        document.body.classList.add("menu-open");
        menuIcon.style.opacity = "0";
        menuIcon.style.visibility = "hidden";
        menuIcon.classList.add("inverted");
        isOpen = true;
        menuIcon2.style.display = "block"; // show menu-icon-2 when menu is open
    }

    function closeMenu() {
        menu.style.left = "-250px";
        overlay.classList.remove("active");
        document.body.classList.remove("menu-open");
        menuIcon.style.opacity = "1";
        menuIcon.style.visibility = "visible";
        menuIcon.classList.remove("inverted");
        isOpen = false;
        menuIcon2.style.display = "none"; // hide menu-icon-2 when menu is closed
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