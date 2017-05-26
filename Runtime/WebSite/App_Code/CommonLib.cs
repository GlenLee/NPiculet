using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using NPiculet.Base.EF;

/// <summary>
/// CommonLib 的摘要说明
/// </summary>
public class CommonLib
{
	public static readonly List<string> EnterpriseNatures;

	static CommonLib()
	{
		using (NPiculetEntities db = new NPiculetEntities())
		{
			var list = db.bas_dict_item.Where(x => x.GroupCode == "EnterpriseNature").OrderBy(x => x.OrderBy).Select(x => x.Name);
			EnterpriseNatures = list.ToList();
		}
	}

	public static void BindAdvToRepeater(Repeater repeater, AdvType type, int recNum)
	{
		using (NPiculetEntities db = new NPiculetEntities())
		{
			int status = (int)AdvStatus.已审核;
			string advType = type.ToString();
			var data = db.cms_adv_info.Where(x => x.Type == advType
				&& x.IsEnabled == status
				&& (x.EndDate == null || x.EndDate <= DateTime.Now)).
				OrderBy(x => x.OrderBy).
				Take(recNum).ToList();
			if (data.Count < 1)
				return;
			repeater.DataSource = data;
			repeater.DataBind();
		}
	}
}

public enum AdvStatus
{
	编辑中 = -1,
	待审核 = 0,
	已审核 = 1,
	未通过 = 2
}

public enum AdvType
{
	轮播广告 = 0,
	底部广告 = 1,
	右侧广告 = 2,
	推荐品牌 = 3
}

public enum HireStatus
{
	未公开 = 0,
	已公开 = 1
}

public class HireStatusHelper
{
	private static readonly List<string> ALL_HIRE_STATUS = new List<string>();
	private static readonly Dictionary<int, HireStatus> ALL_STATUS = new Dictionary<int, HireStatus>();

	static HireStatusHelper()
	{
		foreach (HireStatus value in (HireStatus[])Enum.GetValues(typeof(HireStatus)))
		{
			ALL_STATUS.Add((int)value, value);
		}

		foreach (string value in Enum.GetNames(typeof(HireStatus)))
		{
			ALL_HIRE_STATUS.Add(value);
		}
	}

	public static List<string> AllHireStatus
	{
		get { return ALL_HIRE_STATUS; }
	}

	public static string GetStatus(int value)
	{
		if (ALL_STATUS.ContainsKey(value))
			return ALL_STATUS[value].ToString();
		return "";
	}
}

public class AdvHelper
{
	private static readonly List<string> ALL_ADV_TYPES = new List<string>();


	private static readonly Dictionary<int, AdvStatus> ALL_STATUS = new Dictionary<int, AdvStatus>();

	static AdvHelper()
	{
		foreach (AdvStatus value in (AdvStatus[])Enum.GetValues(typeof(AdvStatus)))
		{
			ALL_STATUS.Add((int)value, value);
		}

		foreach (string value in Enum.GetNames(typeof(AdvType)))
		{
			ALL_ADV_TYPES.Add(value);
		}
	}

	public static List<string> AllAdvTypes
	{
		get { return ALL_ADV_TYPES; }
	}

	public static string GetStatus(int value)
	{
		if (ALL_STATUS.ContainsKey(value))
			return ALL_STATUS[value].ToString();
		return "";
	}
}

public enum EntMemeberStatus
{

	[Description("red")]
	未审核 = 0,

	[Description("green")]
	已审核 = 1
}

public class EntMemeberStatusHelper
{
	private static readonly List<string> ALL_MEMBER_STATUS = new List<string>();
	private static readonly Dictionary<int, EntMemeberStatus> ALL_STATUS = new Dictionary<int, EntMemeberStatus>();
	private static readonly List<EntMemeberStatus> ALL_STATUS_ENUM = new List<EntMemeberStatus>();

	static EntMemeberStatusHelper()
	{
		foreach (EntMemeberStatus value in (EntMemeberStatus[])Enum.GetValues(typeof(EntMemeberStatus)))
		{
			ALL_STATUS.Add((int)value, value);
			ALL_STATUS_ENUM.Add(value);
		}

		foreach (string value in Enum.GetNames(typeof(AdvType)))
		{
			ALL_MEMBER_STATUS.Add(value);
		}
	}

	public static List<string> AllMemberStatus
	{
		get { return ALL_MEMBER_STATUS; }
	}

	public static List<EntMemeberStatus> AllMemberStatusEnum
	{
		get { return ALL_STATUS_ENUM; }
	}

	public static string GetStatus(int key)
	{
		if (ALL_STATUS.ContainsKey(key))
			return ALL_STATUS[key].ToString();
		return "";
	}

	public static EntMemeberStatus GetEnumStatus(int key)
	{
		if (ALL_STATUS.ContainsKey(key))
			return ALL_STATUS[key];
		return EntMemeberStatus.未审核;
	}

	public static string GetStatusColor(string key)
	{
		int color;
		int.TryParse(key, out color);
		return ALL_STATUS.ContainsKey(color) ? ALL_STATUS[color].Description() : EntMemeberStatus.未审核.Description();
	}

	public static EntMemeberStatus GetStatus(string value)
	{
		foreach (EntMemeberStatus status in AllMemberStatusEnum)
		{
			if (status.ToString() == value)
				return status;
		}
		return EntMemeberStatus.已审核;
	}
}

public static class EnumExtension
{
	public static string Description(this Enum enumObject)
	{
		DescriptionAttribute attribute = enumObject.GetType()
			.GetField(enumObject.ToString())
			.GetCustomAttributes(typeof(DescriptionAttribute), false)
			.SingleOrDefault() as DescriptionAttribute;
		return attribute == null ? enumObject.ToString() : attribute.Description;
	}
}