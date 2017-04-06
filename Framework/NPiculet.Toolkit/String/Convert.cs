using System.Text;

namespace NPiculet.Toolkit
{
	public static class StringConvert
	{
		public static string ToMoneyUpper(decimal money)
		{
			string[] unit = new string[] { "Ԫ", "ʰ", "��", "Ǫ", "��", "ʰ", "��", "Ǫ", "��", "ʰ", "��", "Ǫ", "��" };
			string[] numr = new string[] { "��", "Ҽ", "��", "��", "��", "��", "½", "��", "��", "��" };

			string[] moneyString = money.ToString("0.##").Split('.');
			string moneyIntString = moneyString[0];
			string moneyPntString = moneyString.Length == 2 ? moneyString[1] : "";

			StringBuilder moneyUpper = new StringBuilder();

			string prefixMinus = ""; //����ǰ׺
			string cacheNumr = "��";

			string curDigit;
			string curMoney;
			string curNumbr;

			//������������
			for (int i = moneyIntString.Length; i > 0; i--) {
				//��λ����
				int index = moneyIntString.Length - i;

				//��ǰ������֣������ȡ
				curMoney = moneyIntString.Substring(i - 1, 1);
				if (curMoney == "-") {
					prefixMinus = "��";
				} else {
					//��ǰ����д
					curNumbr = numr[int.Parse(curMoney)];
					//��ǰ��λ
					curDigit = unit[index];

					//��ȡ���ֺ͵�λ����
					if (curNumbr == "��") {
						//��һ����Ϊ��
						if (cacheNumr != "��") {
							if (i > 1) {
								if (index == 0) {
									moneyUpper.Insert(0, curNumbr + curDigit);
								} else {
									//���ӵ�λ
									if (index % 4 == 0 && i != 1) {
										moneyUpper.Insert(0, curDigit + curNumbr);
									} else {
										moneyUpper.Insert(0, curNumbr);
									}
								}
							}
						} else {
							//���ӵ�λ
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

			//����С������
			switch (moneyPntString.Length) {
				case 1:
					//��ǰ����д
					curNumbr = numr[int.Parse(moneyPntString)];
					moneyUpper.Append(curNumbr + "��");
					break;
				case 2:
					//��
					string numbr1 = numr[int.Parse(moneyPntString.Substring(0, 1))];
					//��
					string numbr2 = numr[int.Parse(moneyPntString.Substring(1, 1))];

					if (numbr1 == "��") {
						if (moneyIntString != "0") {
							moneyUpper.Append(numbr1 + numbr2 + "��");
						} else {
							moneyUpper.Append(numbr2 + "��");
						}
					} else {
						moneyUpper.Append(numbr1 + "��" + numbr2 + "��");
					}
					break;
				default:
					moneyUpper.Append("��");
					break;
			}

			return prefixMinus + moneyUpper.ToString();
		}
	}
}