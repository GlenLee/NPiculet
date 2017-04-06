using System;
using System.Collections;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NPiculet.Toolkit
{
	public class GridViewKit
	{
		private Hashtable ht = new Hashtable();

		#region 统计表格单元格
		
		/// <summary>
		/// 统计表格列含有数字的单元格。
		/// </summary>
		/// <param name="row">表格行</param>
		/// <param name="notTotalIndex">不统计的列索引</param>
		/// <param name="resultFormat">输出数字的格式</param>
		public void TotalTableColumns(GridViewRow row, int[] notTotalIndex, string resultFormat)
		{
			if (row.RowType == DataControlRowType.DataRow) {
				//自动统计总和
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
						val = val.Replace("￥", "").Replace(",", "");
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
		/// 统计表格列含有数字的单元格。
		/// </summary>
		/// <param name="row">表格行</param>
		/// <param name="notTotalIndex">不统计的列索引</param>
		public void TotalTableColumns(GridViewRow row, int[] notTotalIndex)
		{
			TotalTableColumns(row, notTotalIndex, "0.######");
		}

		/// <summary>
		/// 统计表格行中含有数据的单元格。
		/// </summary>
		/// <param name="row">表格行</param>
		/// <param name="resultColumnIndex">统计结果输出的列索引</param>
		/// <param name="notTotalIndex">不统计的列索引</param>
		/// <param name="containNames">只统计包含的列索引，如果设置为空字符将统计全部列</param>
		public void TotalTableRows(GridViewRow row, int resultColumnIndex, int[] notTotalIndex, string[] containNames)
		{
			decimal result = 0;
			//自动统计总和
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
					val = val.Replace("￥", "").Replace(",", "");
					decimal tmp;
					if (decimal.TryParse(val, out tmp)) {
						result += tmp;
					}
				}
			}
			row.Cells[resultColumnIndex].Text = result.ToString("0.######");
		}

		#endregion

		#region 合并单元格
		
		/// <summary>
		/// 合并 GridView 的纵向值相同的单元格
		/// </summary>
		/// <param name="gv">数据表控件</param>
		/// <param name="mergerColumnIndex">需要合并的列索引</param>
		/// <param name="compareColumnIndexs">实际比较值的列索引</param>
		public static void MergeRow(GridView gv, int mergerColumnIndex, params int[] compareColumnIndexs)
		{
			//循环，i循环当前行，j循环本行之后待比较的行
			int i = 0, j = 0;
			//定义比较字符串
			string[] compareStrings = new string[compareColumnIndexs.Length + 1];
			//循环格式当前行
			for (i = 0; i < gv.Rows.Count; i++) {
				//需要合并的行数
				int _RowSpan = 1;
				//读取比较字符串
				compareStrings[0] = gv.Rows[i].Cells[mergerColumnIndex].Text;
				for (int x = 0; x < compareColumnIndexs.Length; x++) {
					compareStrings[x + 1] = gv.Rows[i].Cells[compareColumnIndexs[x]].Text;
				}
				//循环比较当前行的值和之后行的值
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
		/// 合并 GridView 的纵向值相同的单元格
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

		#region 清除空数据

		/// <summary>
		/// 如果单元格中数值为0，则清除显示。
		/// </summary>
		/// <param name="gv">GridView控件</param>
		public static void ClearZero(GridView gv)
		{
			//循环行
			foreach (GridViewRow row in gv.Rows) {
				//循环单元格
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
		/// 如果单元格中的值和对比值相同，则清除显示。
		/// </summary>
		/// <param name="gv">GridView控件</param>
		/// <param name="val">对比值</param>
		public static void ClearValue(GridView gv, string val)
		{
			//循环行
			foreach (GridViewRow row in gv.Rows) {
				//循环单元格
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