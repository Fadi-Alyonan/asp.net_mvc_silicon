const switchMode = document.getElementById("switch-mode");
const body = document.body;
const isDarkMode = localStorage.getItem("darkMode") === 'true';
switchMode.checked = isDarkMode;
if (isDarkMode) {
    body.classList.add('dark-mode')
} else {
    body.classList.remove('dark-mode')
}
switchMode.addEventListener('change', toggleDarkMode)
function toggleDarkMode() {
    if (switchMode.checked) {
        body.classList.add('dark-mode')
        localStorage.setItem('dark-mode', 'true')
    } else {
        body.classList.remove('dark-mode')
        localStorage.setItem('dark-mode', 'false')
    }
}