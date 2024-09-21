var codes = document.querySelectorAll('pre > code');

codes.forEach(e => {
    e.innerHTML = e.innerHTML.replaceAll("Đ", "<mark>");
    e.innerHTML = e.innerHTML.replaceAll("đ", "</mark>");
});