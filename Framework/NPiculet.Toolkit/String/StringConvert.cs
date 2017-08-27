using System.Text;

namespace NPiculet.Toolkit
{
	public static class StringConvert
	{
		public static string ToMoneyUpper(decimal money)
		{
			string[] unit = new string[] { "元", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟", "兆" };
			string[] numr = new string[] { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };

			string[] moneyString = money.ToString("0.##").Split('.');
			string moneyIntString = moneyString[0];
			string moneyPntString = moneyString.Length == 2 ? moneyString[1] : "";

			StringBuilder moneyUpper = new StringBuilder();

			string prefixMinus = ""; //负数前缀
			string cacheNumr = "零";

			string curDigit;
			string curMoney;
			string curNumbr;

			//处理整数部分
			for (int i = moneyIntString.Length; i > 0; i--) {
				//单位索引
				int index = moneyIntString.Length - i;

				//当前金额数字，倒序获取
				curMoney = moneyIntString.Substring(i - 1, 1);
				if (curMoney == "-") {
					prefixMinus = "负";
				} else {
					//当前金额大写
					curNumbr = numr[int.Parse(curMoney)];
					//当前单位
					curDigit = unit[index];

					//获取数字和单位部分
					if (curNumbr == "零") {
						//上一数字为零
						if (cacheNumr != "零") {
							if (i > 1) {
								if (index == 0) {
									moneyUpper.Insert(0, curNumbr + curDigit);
								} else {
									//附加单位
									if (index % 4 == 0 && i != 1) {
										moneyUpper.Insert(0, curDigit + curNumbr);
									} else {
										moneyUpper.Insert(0, curNumbr);
									}
								}
							}
						} else {
							//附加单位
							if (index % 4 == 0 && i != 1) {
								moneyUpper.Insert(0, curDigit);
							}
						}
					} else {
						moneyUpper.Insert(0, curNumbr + curDigit);
					}

					cacheNumr = curNumbr;
				}
			}

			//处理小数部分
			switch (moneyPntString.Length) {
				case 1:
					//当前金额大写
					curNumbr = numr[int.Parse(moneyPntString)];
					moneyUpper.Append(curNumbr + "角");
					break;
				case 2:
					//角
					string numbr1 = numr[int.Parse(moneyPntString.Substring(0, 1))];
					//分
					string numbr2 = numr[int.Parse(moneyPntString.Substring(1, 1))];

					if (numbr1 == "零") {
						if (moneyIntString != "0") {
							moneyUpper.Append(numbr1 + numbr2 + "分");
						} else {
							moneyUpper.Append(numbr2 + "分");
						}
					} else {
						moneyUpper.Append(numbr1 + "角" + numbr2 + "分");
					}
					break;
				default:
					moneyUpper.Append("整");
					break;
			}

			return prefixMinus + moneyUpper.ToString();
		}
	}
}