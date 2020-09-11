var current = null;
var next = null;
$(document).mousemove(() =>
{
    next = $(':hover').last()[0];
    if (next != null)
    {
        if (current != null)
        {
            current.style.border = 'none';
            current.className = current.className.replace(" scrapeSelection", "");
        }
        current = next;
        current.style.border = 'thick solid red';
        current.className = current.className + " scrapeSelection";
    }
});