using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPiculet.Toolkit
{
	public class GridViewKit
	{
		private Hashtable ht = new Hashtable();

		#region ͳ�Ʊ��Ԫ��
		
		/// <summary>
		/// ͳ�Ʊ���к������ֵĵ�Ԫ��
		/// </summary>
		/// <param name="row">�����</param>
		/// <param name="notTotalIndex">��ͳ�Ƶ�������</param>
		/// <param name="resultFormat">������ֵĸ�ʽ</param>
		public void TotalTableColumns(GridViewRow row, int[] notTotalIndex, string resultFormat)
		{
			if (row.RowType == DataControlRowType.DataRow) {
				//�Զ�ͳ���ܺ�
				for (int i = 0; i < row.Cells.Count; i++) {
					bool doTotal = true;
					if (notTotalIndex != null) {
						foreach (int index in notTotalIndex)
							if (index == i)
								doTotal = false;
					}
					if(doTotal) {
						TableCell tc = row.Cells[i];
						int key = i;
						string val = string.Empty;
						if (tc.Controls.Count > 0) {
							foreach (Control control in tc.Controls) {
								TextBox tb = control as TextBox;
								if (tb != null)
									val = tb.Text;
							}
						} else {
							val = tc.Text;
						}
						val = val.Replace("��", "").Replace(",", "");
						decimal result;
						if (decimal.TryParse(val, out result)) {
							if (ht.ContainsKey(key)) {
								ht[key] = (decimal)ht[key] + result;
							} else {
								ht.Add(i, result);
							}
						}
					}
				}
			}
			if (row.RowType == DataControlRowType.Footer) {
				foreach (int key in ht.Keys) {
					TableCell tc = row.Cells[key];
					tc.Text = Convert.ToDecimal(ht[key]).ToString(resultFormat);
				}
			}
		}

		/// <summary>
		/// ͳ�Ʊ���к������ֵĵ�Ԫ��
		/// </summary>
		/// <param name="row">�����</param>
		/// <param name="notTotalIndex">��ͳ�Ƶ�������</param>
		public void TotalTableColumns(GridViewRow row, int[] notTotalIndex)
		{
			TotalTableColumns(row, notTotalIndex, "0.######");
		}

		/// <summary>
		/// ͳ�Ʊ�����к������ݵĵ�Ԫ��
		/// </summary>
		/// <param name="row">�����</param>
		/// <param name="resultColumnIndex">ͳ�ƽ�������������</param>
		/// <param name="notTotalIndex">��ͳ�Ƶ�������</param>
		/// <param name="containNames">ֻͳ�ư��������������������Ϊ���ַ���ͳ��ȫ����</param>
		public void TotalTableRows(GridViewRow row, int resultColumnIndex, int[] notTotalIndex, string[] containNames)
		{
			decimal result = 0;
			//�Զ�ͳ���ܺ�
			for (int i = 0; i < row.Cells.Count; i++) {
				bool doTotal = true;
				if (notTotalIndex != null) {
					foreach (int index in notTotalIndex)
						if (index == i)
							doTotal = false;
				}

				if (containNames != null && containNames.Length > 0) {
					GridView gv = row.Parent.Parent as GridView;

					bool doContain = true;

					foreach (string name in containNames) {
						if (gv.HeaderRow.Cells[i].Text.IndexOf(name) > -1)
							doContain = false;
					}
					if (doContain)
						doTotal = false;
				}

				if (doTotal) {
					TableCell tc = row.Cells[i];
					string val = string.Empty;
					if (tc.Controls.Count > 0) {
						foreach (Control control in tc.Controls) {
							TextBox tb = control as TextBox;
							if (tb != null)
								val = tb.Text;
						}
					} else {
						val = tc.Text;
					}
					val = val.Replace("��", "").Replace(",", "");
					decimal tmp;
					if (decimal.TryParse(val, out tmp)) {
						result += tmp;
					}
				}
			}
			row.Cells[resultColumnIndex].Text = result.ToString("0.######");
		}

		#endregion

		#region �ϲ���Ԫ��
		
		/// <summary>
		/// �ϲ� GridView ������ֵ��ͬ�ĵ�Ԫ��
		/// </summary>
		/// <param name="gv">���ݱ�ؼ�</param>
		/// <param name="mergerColumnIndex">��Ҫ�ϲ���������</param>
		/// <param name="compareColumnIndexs">ʵ�ʱȽ�ֵ��������</param>
		public static void MergeRow(GridView gv, int mergerColumnIndex, params int[] compareColumnIndexs)
		{
			//ѭ����iѭ����ǰ�У�jѭ������֮����Ƚϵ���
			int i = 0, j = 0;
			//����Ƚ��ַ���
			string[] compareStrings = new string[compareColumnIndexs.Length + 1];
			//ѭ����ʽ��ǰ��
			for (i = 0; i < gv.Rows.Count; i++) {
				//��Ҫ�ϲ�������
				int _RowSpan = 1;
				//��ȡ�Ƚ��ַ���
				compareStrings[0] = gv.Rows[i].Cells[mergerColumnIndex].Text;
				for (int x = 0; x < compareColumnIndexs.Length; x++) {
					compareStrings[x + 1] = gv.Rows[i].Cells[compareColumnIndexs[x]].Text;
				}
				//ѭ���Ƚϵ�ǰ�е�ֵ��֮���е�ֵ
				for (j = i + 1; j < gv.Rows.Count; j++) {
					bool isSame = true;
					if (compareStrings[0] != gv.Rows[j].Cells[mergerColumnIndex].Text) {
						isSame = false;
					}
					for (int x = 0; x < compareColumnIndexs.Length; x++) {
						if (compareStrings[x + 1] != gv.Rows[j].Cells[compareColumnIndexs[x]].Text) {
							isSame = false;
						}
					}
					if (isSame) {
						_RowSpan += 1;
						gv.Rows[j].Cells[mergerColumnIndex].Visible = false;
					} else {
						break;
					}
				}
				if (_RowSpan > 1) {
					gv.Rows[i].Cells[mergerColumnIndex].RowSpan = _RowSpan;
				}
				i = j - 1;
			}
		}

		/// <summary>
		/// �ϲ� GridView ������ֵ��ͬ�ĵ�Ԫ��
		/// </summary>
		/// <param name="gridView"></param>
		public static void MergeRows(GridView gridView)
		{
			for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--) {
				GridViewRow row = gridView.Rows[rowIndex];
				GridViewRow previousRow = gridView.Rows[rowIndex + 1];

				for (int i = 0; i < row.Cells.Count; i++) {
					if (row.Cells[i].Text == previousRow.Cells[i].Text) {
						row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 : previousRow.Cells[i].RowSpan + 1;
						previousRow.Cells[i].Visible = false;
					}
				}
			}
		}

		#endregion

		#region ���������

		/// <summary>
		/// �����Ԫ������ֵΪ0���������ʾ��
		/// </summary>
		/// <param name="gv">GridView�ؼ�</param>
		public static void ClearZero(GridView gv)
		{
			//ѭ����
			foreach (GridViewRow row in gv.Rows) {
				//ѭ����Ԫ��
				foreach (TableCell cell in row.Cells) {
					decimal numeric;
					bool isNumeric = decimal.TryParse(cell.Text, out numeric);
					if (isNumeric && numeric == 0) {
						cell.Text = String.Empty;
					}
				}
			}
		}

		/// <summary>
		/// �����Ԫ���е�ֵ�ͶԱ�ֵ��ͬ���������ʾ��
		/// </summary>
		/// <param name="gv">GridView�ؼ�</param>
		/// <param name="val">�Ա�ֵ</param>
		public static void ClearValue(GridView gv, string val)
		{
			//ѭ����
			foreach (GridViewRow row in gv.Rows) {
				//ѭ����Ԫ��
				foreach (TableCell cell in row.Cells) {
					if (cell.Text == val) {
						cell.Text = String.Empty;
					}
				}
			}
		}

		#endregion
	}
}