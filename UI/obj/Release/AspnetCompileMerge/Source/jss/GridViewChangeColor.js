// JScript 文件

var _oldColor;
function SetNewColor(source)
{
    _oldColor = source.style.backgroundColor;
    source.style.backgroundColor = '#F1F7FB';
}
function SetOldColor(source)
{
    source.style.backgroundColor = _oldColor;
}

var _oldstyle;
function OnMouseOver(source)
{
    _oldstyle = source.style.backgroundColor;
    source.style.backgroundColor = '#8C9FF0';
}
function OnMouseOut(source)
{
    source.style.backgroundColor = _oldstyle;
}