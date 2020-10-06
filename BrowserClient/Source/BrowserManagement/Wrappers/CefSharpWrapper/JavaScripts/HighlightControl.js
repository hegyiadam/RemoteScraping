var current = document.querySelectorAll({0});
current.forEach(function (entry) {
    entry.style.border = 'thick solid red';
    entry.className = entry.className + " scrapeSelection";
});