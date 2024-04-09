const switchMode = document.getElementById("switch-mode");
const body = document.body;
const isDarkMode = localStorage.getItem("dark-mode") === 'false';

switchMode.checked = isDarkMode;
if (isDarkMode) {
    body.classList.add('dark-mode');
} else {
    body.classList.remove('dark-mode');
}

switchMode.addEventListener('change', toggleDarkMode);

function toggleDarkMode() {
    if (switchMode.checked) {
        body.classList.add('dark-mode');
        localStorage.setItem('dark-mode', 'false');
    } else {
        body.classList.remove('dark-mode');
        localStorage.setItem('dark-mode', 'true');
    }
}

function setCookie(name, value, days) {
    const date = new Date();
    date.setTime(date.getTime() + (days * 24 * 60 * 60 * 1000));
    const expires = "expires=" + date.toUTCString();
    document.cookie = name + "=" + value + ";" + expires + ";path=/";
}

function getCookie(name) {
    const cookieName = name + "=";
    const decodedCookie = decodeURIComponent(document.cookie);
    const cookieArray = decodedCookie.split(';');
    for (let i = 0; i < cookieArray.length; i++) {
        let cookie = cookieArray[i];
        while (cookie.charAt(0) === ' ') {
            cookie = cookie.substring(1);
        }
        if (cookie.indexOf(cookieName) === 0) {
            return cookie.substring(cookieName.length, cookie.length);
        }
    }
    return "";
}