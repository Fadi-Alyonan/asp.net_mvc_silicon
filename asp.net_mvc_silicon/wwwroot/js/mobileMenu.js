const mobileMenu = document.getElementById("mobilemenu");

const toggleMenu = () => {
    const menu = document.getElementById("menu");
    const accountButtons = document.getElementById("account-buttons");
    
    if (menu && accountButtons) {
        menu.classList.toggle("hide");
        accountButtons.classList.toggle("hide");
        
    }
};


const checkScreenSize = () => {
    const menu = document.getElementById("menu");
    const accountButtons = document.getElementById("account-buttons");
   
    if (menu && accountButtons) {
        if (window.innerWidth >= 1200) {

            menu.classList.remove("hide");
            accountButtons.classList.remove("hide");
        } else {

            if (!menu.classList.contains("hide")) {
                menu.classList.add("hide");
            }
            if (!accountButtons.classList.contains("hide")) {
                accountButtons.classList.add("hide");
            }
        }
    }
};

window.addEventListener('resize', checkScreenSize);
checkScreenSize();
