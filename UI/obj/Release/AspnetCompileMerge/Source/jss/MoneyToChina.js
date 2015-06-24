
/* 
数字金额转换为中文,Create By HJ 2009-9-4
*/
var changeCNAMoney = function(money) {
    //debugger;
    var IntNum, PointNum, IntValue, PointValue, unit, moneyCNY;
    var Number = "零一二三四五六七八九";
    var NUMUnit = { LING: "零", SHI: "十", BAI: "百", QIAN: "千", WAN: "万", YI: "亿" }
    var CNYUnit = { YUAN: "元", JIAO: "角", FEN: "分", ZHENG: "整" };
    var beforeReplace =
            {
                Values:
                [
                    { Name: NUMUnit.LING + NUMUnit.YI },               // 零亿
                    {Name: NUMUnit.LING + NUMUnit.WAN },              // 零万
                    {Name: NUMUnit.LING + NUMUnit.QIAN },             // 零千
                    {Name: NUMUnit.LING + NUMUnit.BAI },              // 零百
                    {Name: NUMUnit.LING + NUMUnit.SHI },              // 零十
                    {Name: NUMUnit.LING + NUMUnit.LING },             // 零零
                    {Name: NUMUnit.YI + NUMUnit.LING + NUMUnit.WAN }, // 亿零万
                    {Name: NUMUnit.LING + NUMUnit.YI },               // 零亿
                    {Name: NUMUnit.LING + NUMUnit.WAN },              // 零万
                    {Name: NUMUnit.LING + NUMUnit.LING}              // 零零
                ]
            };
    var afterReplace =
            {
                Values:
                [
                    { Name: NUMUnit.YI + NUMUnit.LING }, //亿零
                    {Name: NUMUnit.WAN + NUMUnit.LING }, //万零
                    {Name: NUMUnit.LING },              //零
                    {Name: NUMUnit.LING },              //零
                    {Name: NUMUnit.LING },              //零
                    {Name: NUMUnit.LING },              //零
                    {Name: NUMUnit.YI + NUMUnit.LING }, //亿零
                    {Name: NUMUnit.YI },                //亿
                    {Name: NUMUnit.WAN },               //万
                    {Name: NUMUnit.LING}               //零
                ]
            };
    var pointBefore =
            {
                Values:
                [
                    { Name: NUMUnit.LING + CNYUnit.JIAO }, //零角
                    {Name: NUMUnit.LING + CNYUnit.FEN },  //零分
                    {Name: NUMUnit.LING + NUMUnit.LING }, //零零
                    {Name: CNYUnit.JIAO + NUMUnit.LING}  //角零
                ]
            };
    var pointAfter =
            {
                Values:
                [
                    { Name: NUMUnit.LING }, //零
                    {Name: NUMUnit.LING }, //零
                    {Name: "" },
                    { Name: CNYUnit.JIAO}  //角
                ]
            };

    /// 递归替换
    var replaceAll = function(inputValue, beforeValue, afterValue) {
        while (inputValue.indexOf(beforeValue) > -1) {
            inputValue = inputValue.replace(beforeValue, afterValue);
        }
        return inputValue;
    }
    /// 获取输入金额的整数部分
    IntNum = money.indexOf(".") > -1 ? money.substring(0, money.indexOf(".")) : money;
    /// 获取输入金额的小数部分
    PointNum = money.indexOf(".") > -1 ? money.substring(money.indexOf(".") + 1) : "";
    IntValue = PointValue = "";

    /// 计算整数部分
    for (var i = 0; i < IntNum.length; i++) {
        /// 获取数字单位
        switch ((IntNum.length - i) % 8) {
            case 5:
                unit = NUMUnit.WAN; //万
                break;
            case 0:
            case 4:
                unit = NUMUnit.QIAN; //千
                break;
            case 7:
            case 3:
                unit = NUMUnit.BAI; //百
                break;
            case 6:
            case 2:
                unit = NUMUnit.SHI; //十
                break;
            case 1:
                if ((IntNum.length - i) > 8) {
                    unit = NUMUnit.YI; //亿    
                }
                else { unit = ""; }
                break;
            default:
                unit = "";
                break;
        }
        /// 组成整数部分
        IntValue += Number.substr(parseInt(IntNum.substr(i, 1)), 1) + unit;
    }

    /// 替换零
    for (var i = 0; i < beforeReplace.Values.length; i++) {
        IntValue = replaceAll(IntValue, beforeReplace.Values[i].Name, afterReplace.Values[i].Name);
    }
    // 末尾是零则去除
    if (IntValue.substr(IntValue.length - 1, 1) == NUMUnit.LING) IntValue = IntValue.substring(0, IntValue.length - 1);
    // 一十开头的替换为十开头
    if (IntValue.substr(0, 2) == Number.substr(1, 1) + NUMUnit.SHI) IntValue = IntValue.substr(1, IntValue.length - 1);

    /// 计算小数部分
    if (PointNum != "") {
        PointValue = Number.substr(PointNum.substr(0, 1), 1) + CNYUnit.JIAO;
        PointValue += Number.substr(PointNum.substr(1, 1), 1) + CNYUnit.FEN;
        for (var i = 0; i < pointBefore.Values.length; i++) {
            PointValue = replaceAll(PointValue, pointBefore.Values[i].Name, pointAfter.Values[i].Name);
        }
    }
    moneyCNY = PointValue == "" ? IntValue + CNYUnit.YUAN + CNYUnit.ZHENG : IntValue + CNYUnit.YUAN + PointValue;
    return moneyCNY;
}