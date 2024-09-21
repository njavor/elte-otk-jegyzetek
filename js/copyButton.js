document.addEventListener("DOMContentLoaded", function() {
    const copyButtons = document.querySelectorAll('.toolbar-item > button > span');
    copyButtons.forEach(e => {
        e.classList.add('material-symbols-outlined');
    });
});
