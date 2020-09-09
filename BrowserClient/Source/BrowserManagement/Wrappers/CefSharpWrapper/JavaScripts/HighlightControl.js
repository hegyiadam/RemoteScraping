document.onclick = function (e)
{
    var x = event.clientX,
        y = event.clientY,
        elementMouseIsOver = document.elementFromPoint(x, y);
    elementMouseIsOver.style.border = 'thick solid #0000FF';  
};