// site.js
// Write your JavaScript code.
function openMobileMenu() {
    const menu = document.getElementById('menu');
    if (menu.classList.contains('-right-full')) {
        menu.classList.remove('-right-full');
        menu.classList.add('-right-0');
    }
}

function closeMobileMenu() {
    const menu = document.getElementById('menu');
    if (menu.classList.contains('-right-0')) {
        menu.classList.remove('-right-0');
        menu.classList.add('-right-full');
    }
}

document.addEventListener('DOMContentLoaded', () => {
    const userMenuButton = document.getElementById('user-menu-button');
    const userDropdown = document.getElementById('user-dropdown');

    userMenuButton.addEventListener('click', () => {
        userDropdown.classList.toggle('hidden');
    });

    document.addEventListener('click', (event) => {
        if (!userMenuButton.contains(event.target) && !userDropdown.contains(event.target)) {
            userDropdown.classList.add('hidden');
        }
    });
});